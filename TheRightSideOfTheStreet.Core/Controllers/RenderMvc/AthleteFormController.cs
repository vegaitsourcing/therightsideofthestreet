using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheRightSideOfTheStreet.Core.ViewModels;
using TheRightSideOfTheStreet.Models;

namespace TheRightSideOfTheStreet.Core.Controllers.RenderMvc
{
	public class AthleteFormController : BasePageController<AthleteForm>
	{
		public ActionResult AthleteForm(AthleteForm model) => CurrentTemplate(new AthleteFormViewModel(CreatePageContext(model)));
	}

}
