using Umbraco.Web;
using PravaStranaUlice.Models.Extensions;
using System.Linq;

namespace PravaStranaUlice.Models
{
    public partial class Home
    {
        public Settings Settings => new UmbracoHelper(UmbracoContext.Current).GetSettings();

        public AthleteLandingPage AthleteLandingPageCast => (AthleteLandingPage)AthleteLandingPage.First();

        public BlogLanding EventsCast => (BlogLanding)Events.First();

        public BlogLanding BlogLandingCast => (BlogLanding)BlogLanding.First();

        public AboutUs AboutUsCast => (AboutUs)AboutUs.First();

    }
}
