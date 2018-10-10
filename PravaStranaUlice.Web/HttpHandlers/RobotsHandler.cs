using System.Net;
using System.Web;
using Umbraco.Core.Logging;
using Umbraco.Web;
using PravaStranaUlice.Models.Extensions;
using PravaStranaUlice.Web.Extensions;

namespace PravaStranaUlice.Web.HttpHandlers
{
	public class RobotsHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			HttpContextBase contextBase = context.ToBase();
			string path = context.Server.MapPath(context.Request.RawUrl);

			// Is there a file that already exists on the file system?
			// If so, always serve that.
			if (System.IO.File.Exists(path))
			{
				LogHelper.Debug<RobotsHandler>("Streaming specified robots file from disk.");

				contextBase.Response.TransmitFileContent(path);
				return;
			}

			// Ensure there is an Umbraco context that is necessary for data access.
			UmbracoContext umbracoContext = contextBase.EnsureUmbracoContext();
			if (umbracoContext == null)
			{
				LogHelper.Warn<RobotsHandler>("Umbraco context is null even after ensuring there is one!");
				throw new HttpException((int)HttpStatusCode.NotFound, "Page Not Found");
			}

			contextBase.Response.Clear();
			contextBase.Response.ContentType = "text/plain";

			// Lets try and find the robots file contents from Umbraco.
			//todo fix this
			//contextBase.Response.Write(new UmbracoHelper(umbracoContext).GetSettings()?.Robots ?? string.Empty);

			contextBase.Response.End();
		}

		public bool IsReusable => true;
	}
}
