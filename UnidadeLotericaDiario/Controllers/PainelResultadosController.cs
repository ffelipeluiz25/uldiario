using System.Web.Mvc;
namespace UnidadeLotericaDiario.Controllers
{
    public class PainelResultadoController : Controller
    {
        [Route("/painel-resultados")]
        public ActionResult PainelResultado()
        {
            return View("PainelResultado");
        }

        [Route("/painel-resultados-mobile")]
        public ActionResult PainelResultadoMobile()
        {
            return View("PainelResultadoMobile");
        }

        
    }
}