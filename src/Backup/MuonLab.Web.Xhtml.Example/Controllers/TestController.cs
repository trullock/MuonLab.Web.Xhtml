using System.Web.Mvc;
using MuonLab.Web.Xhtml.Example.ViewModels;

namespace MuonLab.Web.Xhtml.Example.Controllers
{
	public sealed class TestController : Controller
	{
		public ActionResult Index()
		{
			return this.View("Test", new TestViewModel());
		}
	}
}