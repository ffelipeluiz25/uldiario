using System.Web.Mvc;
namespace UnidadeLotericaDiario.Controllers
{
    public class HomeController : Controller
    {
        [Route("/Home")]
        public ActionResult Home()
        {
            ViewBag.IndAdmin = Session["IndAdmin"];
            return View("Home");
        }
    }
}