using System.Web.Mvc;

namespace LegacyMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "ASP.NET MVC 5 on .NET Framework 4.8";
            return View();
        }
    }
}
