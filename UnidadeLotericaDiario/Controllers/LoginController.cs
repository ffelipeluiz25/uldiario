using System.Collections.Generic;
using System.Web.Mvc;
using UnidadeLotericaDiario.Transientes;

namespace UnidadeLotericaDiario.Controllers
{
    public class LoginController : Controller
    {
        [Route("/")]
        public ActionResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// Logar
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Logar(LoginRequest modelo)
        {
            try
            {
                var resultado = new Repository.UsuarioRepository().Logar(modelo.Login, modelo.Senha);
                foreach (KeyValuePair<bool, bool> item in resultado)
                {
                    if (item.Key)
                    {
                        Session["IndAdmin"] = item.Value;
                        return Json(new { sucesso = true });
                    }
                    else
                        return Json(new { sucesso = false, mensagem = "login e senha incorretos!" });
                }
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }

        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Logout()
        {
            try
            {
                Session["IndAdmin"] = null;
                return Json(new { sucesso = true });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }

        }


        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult VerificarUsuarioLogado()
        {
            try
            {
                var logado = Session["IndAdmin"];
                if (logado != null)
                    return Json(new { sucesso = true });
                else
                    return Json(new { sucesso = false });
            }
            catch (System.Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }

        }

    }
}