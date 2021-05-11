using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using uldiario.Models.EntidadesApiLoterias;
using uldiario.Util;
using ULDiario.Data.Repositories;
namespace uldiario.Services
{
    public class ApiService
    {

        #region Atributos

        string _connectionString;
        string _urlBase;
        string _token;

        #endregion

        #region Construtor

        /// <summary>
        /// ApiService
        /// </summary>
        public ApiService()
        {
            _urlBase = ConfigurationManager.AppSettings["UrlApiLoteria"];
            _connectionString = ConfigurationManager.ConnectionStrings["StringMySql"].ConnectionString;
            _token = ConfigurationManager.AppSettings["token"];
        }

        #endregion

        #region Métodos

        /// <summary>
        /// GetAuth
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetAuth(HttpRequest request)
        {
            if (request.Headers.TryGetValue("Authorization", out StringValues auth))
                return auth.FirstOrDefault();

            return null;
        }

        /// <summary>
        /// Integracao
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<Jogo> AtualizaJogos()
        {
            
            Jogo obj = new Jogo();
            List<Jogo> lista = new List<Jogo>();
            try
            {

                for (int i = 0; i < 9; i++)
                {
                    string jogo = Enum.GetName(typeof(EJogos), i);
                    var url = "?loteria=" + jogo + "&token=" + _token;
                    if ((int)EJogos.lotofacil == i || (int)EJogos.quina == i || (int)EJogos.duplasena == i)
                    {
                        List<Jogo> listaLotoFacil = new List<Jogo>();
                        obj = RequestApiLoterias(url);
                        if (obj == null)
                            return null;

                        listaLotoFacil.Add(obj);
                        lista.Add(obj);

                        var url2 = "?loteria=" + jogo + "&token=" + _token + "&concurso=" + (obj.numero_concurso - 1);
                        var obj2 = RequestApiLoterias(url2);
                        if (obj2 != null)
                        {
                            lista.Add(obj2);
                            listaLotoFacil.Add(obj2);
                        }
                        SalvarResultado(jogo, lista: listaLotoFacil);
                    }
                    else
                    {
                        obj = RequestApiLoterias(url);
                        if (obj != null)
                        {
                            SalvarResultado(jogo, obj);
                            lista.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return lista;
        }

        /// <summary>
        /// RequestApiLoterias
        /// </summary>
        /// <param name="request"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public Jogo RequestApiLoterias(string url)
        {
            Jogo obj = null;
            string urlBase = ConfigurationManager.AppSettings["UrlApiLoteria"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Jogo>();
                    readTask.Wait();
                    obj = (Jogo)readTask.Result;
                }
            }
            return obj;
        }

        /// <summary>
        /// SalvarResultado
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="jogo"></param>
        /// <param name="lista"></param>
        private bool SalvarResultado(string jogo, Jogo obj = null, List<Jogo> lista = null)
        {
            try
            {
                switch (jogo)
                {
                    //case "megasena":
                    //    {
                    //        var repo = new MegaSenaRepository(_connectionString);
                    //        if (repo.VerificaExistenciaConcurso(obj.numero_concurso))
                    //            repo.SalvarResultadoMegaSena(obj);
                    //    }
                    //    break;
                    //case "lotomania":
                    //    {
                    //        if ( _repoLotoMania.VerificaExistenciaConcurso(obj.numero_concurso))
                    //             _repoLotoMania.SalvarResultadoLotoMania(obj);
                    //    }
                    //    break;
                    //case "lotofacil":
                    //    {
                    //        if (lista != null &&  _repoLotoFacil.VerificaExistenciaConcurso(lista))
                    //             _repoLotoFacil.SalvarResultadoLotoFacil(lista);
                    //    }
                    //    break;
                    //case "quina":
                    //    {
                    //        if (lista != null &&  _repoQuina.VerificaExistenciaConcurso(lista))
                    //             _repoQuina.SalvarResultadoQuina(lista);
                    //    }
                    //    break;
                    //case "loteca":
                    //    {
                    //        if ( _repoLoteca.VerificaExistenciaConcurso(obj.numero_concurso))
                    //             _repoLoteca.SalvarResultadoLoteca(obj);
                    //    }
                    //    break;
                    //case "timemania":
                    //    {
                    //        if ( _repoTimeMania.VerificaExistenciaConcurso(obj.numero_concurso))
                    //             _repoTimeMania.SalvarResultadoTimeMania(obj);
                    //    }
                    //    break;
                    //case "duplasena":
                    //    {
                    //        if ( _repoDuplaSena.VerificaExistenciaConcurso(lista))
                    //             _repoDuplaSena.SalvarResultadoDuplaSena(lista);
                    //    }
                    //    break;
                    //case "supersete":
                    //    {
                    //        if ( _repoSuperSete.VerificaExistenciaConcurso(obj.numero_concurso))
                    //             _repoSuperSete.SalvarResultadoSuperSete(obj);
                    //    }
                    //    break;
                    //case "diadesorte":
                    //    {
                    //        if ( _repoDiaDeSorte.VerificaExistenciaConcurso(obj.numero_concurso))
                    //             _repoDiaDeSorte.SalvarResultadoDiaDeSorte(obj);
                    //    }
                    //    break;
                    default:
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Autenticar
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public int Autenticar(string login, string senha)
        {
            return 1;
        }

        #endregion

    }
}