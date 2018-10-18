using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class BecomeMemberController : BasePageController<BecomeMember>
    {
        public ActionResult BecomeMember(BecomeMember model) => CurrentTemplate(new BecomeMemberViewModel(CreatePageContext(model)));

        public ActionResult BeMember()
        {
            return View();
        }
    }
}