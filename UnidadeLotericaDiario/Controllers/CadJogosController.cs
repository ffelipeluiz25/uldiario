using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnidadeLotericaDiario.Models;

namespace UnidadeLotericaDiario.Controllers
{
    public class CadJogosController : Controller
    {

        [Route("/cadastro-megasena")]
        public ActionResult CadMegaSena()
        {
            return View("CadMegaSena");
        }
    }
}