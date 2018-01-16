using System.Web.Mvc;
using System.Web.Routing;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Test", action = "Index", id = UrlParameter.Optional }
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
		}
	}
}