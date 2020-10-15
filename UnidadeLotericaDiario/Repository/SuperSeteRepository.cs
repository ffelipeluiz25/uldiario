using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class SuperSeteRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public SuperSeteRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion

        /// <summary>
        /// RecuperarUltimoResultadoSuperSete
        /// </summary>
        /// <returns></returns>
        public SuperSete RecuperarUltimoResultadoSuperSete()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                        RS.NUM_CONCURSO, 
	                    RS.DAT_CONCURSO, 
	                    RS.NUM_SORTEADOS, 
	                    RS.QTD_GANHADORES_7PTS,
                        RS.VALOR_GANHADORES_7PTS,
                        RS.QTD_GANHADORES_6PTS,
                        RS.VALOR_GANHADORES_6PTS,
                        RS.QTD_GANHADORES_5PTS,
                        RS.VALOR_GANHADORES_5PTS,
                        RS.QTD_GANHADORES_4PTS,
                        RS.VALOR_GANHADORES_4PTS,
                        RS.QTD_GANHADORES_3PTS,
                        RS.VALOR_GANHADORES_3PTS,
	                    RS.VALOR_ACUMULADO
                    FROM
                         RESULTADO_SUPERSETE RS
                    ORDER BY 1 DESC
                    LIMIT 1; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                SuperSete superSete = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    superSete = new SuperSete();
                    superSete.NumConcurso = dr["NUM_CONCURSO"].ToString();
                    superSete.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    superSete.NumSorteados = dr["NUM_SORTEADOS"].ToString();
                    superSete.QtdeGanhadores_7pts = dr["QTD_GANHADORES_7PTS"].ToString();
                    superSete.ValorGanhadores_7pts = dr["VALOR_GANHADORES_7PTS"].ToString();
                    superSete.QtdeGanhadores_6pts = dr["QTD_GANHADORES_6PTS"].ToString();
                    superSete.ValorGanhadores_6pts = dr["VALOR_GANHADORES_6PTS"].ToString();
                    superSete.QtdeGanhadores_5pts = dr["QTD_GANHADORES_5PTS"].ToString();
                    superSete.ValorGanhadores_5pts = dr["VALOR_GANHADORES_5PTS"].ToString();
                    superSete.QtdeGanhadores_4pts = dr["QTD_GANHADORES_4PTS"].ToString();
                    superSete.ValorGanhadores_4pts = dr["VALOR_GANHADORES_4PTS"].ToString();
                    superSete.QtdeGanhadores_3pts = dr["QTD_GANHADORES_3PTS"].ToString();
                    superSete.ValorGanhadores_3pts = dr["VALOR_GANHADORES_3PTS"].ToString();
                    superSete.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();
                return superSete;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}