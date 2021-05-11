using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using uldiario.Models.EntidadesApiLoterias;
using uldiario.Services;

namespace uldiario.Controllers
{
    public class HomeController : Controller
    {

        #region Actions

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("index");
        }

        /// <summary>
        /// AtualizaJogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AtualizaJogos()
        {
            try
            {
                List<Jogo> lista = new ApiService().AtualizaJogos();
                return Json(new { sucesso = true, listaResultado = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        #endregion

    }
}