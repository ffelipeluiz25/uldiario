using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnidadeLotericaDiario.Models;

namespace UnidadeLotericaDiario.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Home()
        {
            return View("Index");
        }

        [Route("/cadjogos")]
        public ActionResult cadjogos()
        {
            return View("About");
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
                new Repository.LotoManiaRepository().SalvarResultadoLotoMania(lotoMania);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        #endregion

        #region LotoFacil

        /// <summary>
        /// RecuperarUltimoResultadoMegaSena
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoLotoFacil()
        {
            try
            {
                var resultado = new Repository.LotoFacilRepository().RecuperarUltimoResultadoLotoFacil();
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
        /// SalvarResultadoLotoFacil
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoLotoFacil(LotoFacil lotoFacil)
        {
            try
            {
                new Repository.LotoFacilRepository().SalvarResultadoLotoFacil(lotoFacil);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        #endregion

        #region Quina

        /// <summary>
        /// RecuperarUltimoResultadoQuina
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoQuina()
        {
            try
            {
                var resultado = new Repository.QuinaRepository().RecuperarUltimoResultadoQuina();
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
        /// SalvarResultadoQuina
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoQuina(Quina quina)
        {
            try
            {
                new Repository.QuinaRepository().SalvarResultadoQuina(quina);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }
        #endregion


        #region Loteca

        /// <summary>
        /// RecuperarUltimoResultadoLoteca
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoLoteca()
        {
            try
            {
                var resultado = new Repository.LotecaRepository().RecuperarUltimoResultadoLoteca();
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
        /// SalvarResultadoLoteca
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoLoteca(Loteca loteca)
        {
            try
            {
                new Repository.LotecaRepository().SalvarResultadoLoteca(loteca);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        /// <summary>
        /// SalvarResultadoJogosLoteca
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoJogosLoteca(JogosLoteca jogosLoteca)
        {
            try
            {
                new Repository.LotecaRepository().SalvarResultadoJogosLoteca(jogosLoteca);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        #endregion

        #region TimeMania

        /// <summary>
        /// RecuperarUltimoResultadoTimeMania
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoTimeMania()
        {
            try
            {
                var resultado = new Repository.TimeManiaRepository().RecuperarUltimoResultadoTimeMania();
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
        /// SalvarResultadoTimeMania
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoTimeMania(TimeMania TimeMania)
        {
            try
            {
                new Repository.TimeManiaRepository().SalvarResultadoTimeMania(TimeMania);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }
        #endregion

        #region DuplaSena

        /// <summary>
        /// RecuperarUltimoResultadoDuplaSena
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoDuplaSena()
        {
            try
            {
                var resultado = new Repository.DuplaSenaRepository().RecuperarUltimoResultadoDuplaSena();
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
        /// SalvarResultadoDuplaSena
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoDuplaSena(DuplaSena duplaSena)
        {
            try
            {
                new Repository.DuplaSenaRepository().SalvarResultadoDuplaSena(duplaSena);
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }
        #endregion

        #region Super Sete

        /// <summary>
        /// RecuperarUltimoResultadoSuperSete
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoSuperSete()
        {
            try
            {
                var resultado = new Repository.SuperSeteRepository().RecuperarUltimoResultadoSuperSete();
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

        #endregion

        #region Dia de Sorte

        /// <summary>
        /// RecuperarUltimoResultadoDiaDeSorte
        /// </summary>
        /// <returns></returns>
        public JsonResult RecuperarUltimoResultadoDiaDeSorte()
        {
            try
            {
                var resultado = new Repository.DiaDeSorteRepository().RecuperarUltimoResultadoDiaDeSorte();
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
        /// SalvarResultadoDiaDeSorte
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarResultadoDiaDeSorte(DiaDeSorte diaDeSorte)
        {
            try
            {
                new Repository.DiaDeSorteRepository().SalvarResultadoDiaDeSorte(diaDeSorte);
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