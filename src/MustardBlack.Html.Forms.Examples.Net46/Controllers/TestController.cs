using System.Web.Mvc;
using MustardBlack.Html.Forms.Examples.Net46.ViewModels;

namespace MustardBlack.Html.Forms.Examples.Net46.Controllers
{
	public sealed class TestController : Controller
	{
		public ActionResult Index()
		{
			return this.View("Test", new TestViewModel());
		}
	}
}