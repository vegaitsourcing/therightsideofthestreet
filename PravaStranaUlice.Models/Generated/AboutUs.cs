using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PravaStranaUlice.Models.Extensions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace PravaStranaUlice.Models
{
	public partial class AboutUs : PublishedContentModel, IPage
	{
		public Settings Settings => new UmbracoHelper(UmbracoContext.Current).GetSettings();

		public string EmbedVideo
		{
			get { return this.IntroVideo.Replace("watch?v=", "embed/"); }
		}
	}

	
}
