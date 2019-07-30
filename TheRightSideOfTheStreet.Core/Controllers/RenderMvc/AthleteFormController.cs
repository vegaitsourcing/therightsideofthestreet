using System.Threading;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class AthleteFormController : BasePageController<AthleteForm>
	{
		public ActionResult AthleteForm(AthleteForm model)
		{
			if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
			{
				if (Request.UrlReferrer.AbsolutePath.Equals("/sw-athletes/"))
				{
					return CurrentTemplate(new AthleteFormViewModel(CreatePageContext(model)) { FromAthletePage = true });
				}
			}
			else if(Thread.CurrentThread.CurrentCulture.Name == "sr-Latn")
			{
				if (Request.UrlReferrer.AbsolutePath.Equals("/sw-atlete/"))
				{
					return CurrentTemplate(new AthleteFormViewModel(CreatePageContext(model)) { FromAthletePage = true });
				}
			}

			return CurrentTemplate(new AthleteFormViewModel(CreatePageContext(model)));
		}
	}

}
