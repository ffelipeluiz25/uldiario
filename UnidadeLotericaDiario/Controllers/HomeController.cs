using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnidadeLotericaDiario.Models;

namespace UnidadeLotericaDiario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region MegaSena

        /// <summary>
        /// RecuperarUltimoResultadoMegaSena
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoMegaSena()
        {
            try
            {
                var resultado = new Repository.MegaSenaRepository().RecuperarUltimoResultadoMegaSena();
                if (resultado == null)
                    return Json(new { sucesso = true, tipo = 2 }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { sucesso = true, tipo = 1, resultado }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// SalvarResultadoMegaSena
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoMegaSena(MegaSena megaSena)
        {
            try
            {
                megaSena.ValorGanhadoresSena = Convert.ToDecimal(megaSena.ValorGanhadoresSenaTeste);
                megaSena.ValorGanhadoresQuadra = Convert.ToDecimal(megaSena.ValorGanhadoresQuadraTeste);
                megaSena.ValorGanhadoresQuina = Convert.ToDecimal(megaSena.ValorGanhadoresQuinaTeste);
                megaSena.ValorAcumulado = Convert.ToDecimal(megaSena.ValorAcumuladoTeste);
                new Repository.MegaSenaRepository().SalvarResultadoMegaSena(megaSena);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        #endregion

        #region LotoMania

        /// <summary>
        /// RecuperarUltimoResultadoMegaSena
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoLotoMania()
        {
            try
            {
                var resultado = new Repository.LotoManiaRepository().RecuperarUltimoResultadoLotoMania();
                if (resultado == null)
                    return Json(new { sucesso = true, tipo = 2 }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { sucesso = true, tipo = 1, resultado }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// SalvarResultadoMegaSena
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoLotoMania(LotoMania lotoMania)
        {
            try
            {
                lotoMania.ValorGanhadores20pts = Convert.ToDecimal(lotoMania.ValorGanhadores20ptsTeste);
                lotoMania.ValorGanhadores19pts = Convert.ToDecimal(lotoMania.ValorGanhadores19ptsTeste);
                lotoMania.ValorGanhadores18pts = Convert.ToDecimal(lotoMania.ValorGanhadores18ptsTeste);
                lotoMania.ValorGanhadores17pts = Convert.ToDecimal(lotoMania.ValorGanhadores17ptsTeste);
                lotoMania.ValorGanhadores16pts = Convert.ToDecimal(lotoMania.ValorGanhadores16ptsTeste);
                lotoMania.ValorGanhadores15pts = Convert.ToDecimal(lotoMania.ValorGanhadores15ptsTeste);
                lotoMania.ValorGanhadores0pts = Convert.ToDecimal(lotoMania.ValorGanhadores0ptsTeste);
                lotoMania.ValorAcumulado = Convert.ToDecimal(lotoMania.ValorAcumuladoTeste);
                new Repository.LotoManiaRepository().SalvarResultadoLotoMania(lotoMania);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        #endregion

    }
}