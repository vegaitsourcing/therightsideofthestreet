using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace TheRightSideOfTheStreet.Core.Extensions
{
	/// <summary>
	/// <see cref="HtmlHelper"/> extension methods.
	/// </summary>
	public static class HtmlHelperExtensions
	{
		/// <summary>
		/// Renders result of child action specified by provided <paramref name="expression"/>.
		/// </summary>
		/// <typeparam name="TController">Type of the controller child action belongs to.</typeparam>
		/// <param name="source">HTML helper.</param>
		/// <param name="expression">Expression that specifies child action that should be invoked.</param>
		/// <param name="methodArguments">Child action arguments.</param>
		public static void RenderAction<TController>(this HtmlHelper source, Expression<Action<TController>> expression, params object[] methodArguments) where TController : Controller
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (methodArguments == null) throw new ArgumentNullException(nameof(methodArguments));

			MethodInfo methodInfo = GetMethodInfo(expression);
			string controllerName = typeof(TController).Name.RemoveControllerSuffix();

			RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
			MatchArgumentsWithMethodParameters(methodInfo, (key, value) => routeValueDictionary.Add(key, value),  methodArguments);

			source.RenderAction(methodInfo.Name, controllerName, routeValueDictionary);
		}

		public static void RenderPartial<TViewModel>(this HtmlHelper html, TViewModel model, string partialViewName = null)
			=> html.RenderPartial(GetPartialViewName(model, partialViewName), model,
								  new ViewDataDictionary(html.ViewData) { Model = model }); // ViewDataDictionary parameter is necessary to allow passing null for model value.

		public static MvcHtmlString Partial<TViewModel>(this HtmlHelper html, TViewModel model, string partialViewName = null) where TViewModel : class
			=> html.Partial(GetPartialViewName(model, partialViewName), model,
							new ViewDataDictionary(html.ViewData) { Model = model });   // ViewDataDictionary parameter is necessary to allow passing null for model value.

		private static MethodInfo GetMethodInfo<T>(Expression<T> expression)
		{
			var body = expression.Body as MethodCallExpression;
			if (body == null) throw new ArgumentException("Expression has to specify an existing method on the type T.", nameof(expression));

			return body.Method;
		}

		private static void MatchArgumentsWithMethodParameters(MethodInfo methodInfo, Action<string, object> action, params object[] methodArguments)
		{
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length != methodArguments.Length)
			{
				throw new ArgumentException("Number of provided arguments doesn't match with number of method parameters.", nameof(methodArguments));
			}

			IEnumerator parametersEnumerator = parameters.GetEnumerator();
			IEnumerator argumentsEnumerator = methodArguments.GetEnumerator();

			while (parametersEnumerator.MoveNext() && argumentsEnumerator.MoveNext())
			{
				action(((ParameterInfo)parametersEnumerator.Current).Name, argumentsEnumerator.Current);
			}
		}

		private static string GetPartialViewName<TViewModel>(TViewModel model, string partialViewName = null)
			=> !string.IsNullOrWhiteSpace(partialViewName) ? partialViewName : (model?.GetType() ?? typeof(TViewModel)).Name.RemoveViewModelSuffix();
	}
}
