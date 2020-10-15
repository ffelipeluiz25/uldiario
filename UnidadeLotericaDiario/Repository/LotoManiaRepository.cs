using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class LotoManiaRepository
    {


        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public LotoManiaRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion


        /// <summary>
        /// RecuperarUltimoResultadoLotoMania
        /// </summary>
        /// <returns></returns>
        public LotoMania RecuperarUltimoResultadoLotoMania()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                         RL.NUM_CONCURSO,
                         RL.DAT_CONCURSO,
                         RL.NUM_SORTEADOS,
                         RL.QTD_GANHADORES_20PTS,
                         RL.VALOR_GANHADORES_20PTS,
                         RL.QTD_GANHADORES_19PTS,
                         RL.VALOR_GANHADORES_19PTS,
                         RL.QTD_GANHADORES_18PTS,
                         RL.VALOR_GANHADORES_18PTS,
                         RL.QTD_GANHADORES_17PTS,
                         RL.VALOR_GANHADORES_17PTS,
                         RL.QTD_GANHADORES_16PTS,
                         RL.VALOR_GANHADORES_16PTS,
                         RL.QTD_GANHADORES_15PTS,
                         RL.VALOR_GANHADORES_15PTS,
                         RL.QTD_GANHADORES_0PTS,
                         RL.VALOR_GANHADORES_0PTS,
                         RL.VALOR_ACUMULADO
                    FROM
                         RESULTADO_LOTOMANIA RL
                    ORDER BY 1 DESC
                    LIMIT 1; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                LotoMania lotoMania = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lotoMania = new LotoMania();
                    lotoMania.NumConcurso = dr["NUM_CONCURSO"].ToString();
                    lotoMania.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    lotoMania.NumSorteados = dr["NUM_SORTEADOS"].ToString();
                    lotoMania.QtdeGanhadores20pts = dr["QTD_GANHADORES_20PTS"].ToString();
                    lotoMania.ValorGanhadores20pts = dr["VALOR_GANHADORES_20PTS"].ToString();
                    lotoMania.QtdeGanhadores19pts = dr["QTD_GANHADORES_19PTS"].ToString();
                    lotoMania.ValorGanhadores19pts = dr["VALOR_GANHADORES_19PTS"].ToString();
                    lotoMania.QtdeGanhadores18pts = dr["QTD_GANHADORES_18PTS"].ToString();
                    lotoMania.ValorGanhadores18pts = dr["VALOR_GANHADORES_18PTS"].ToString();
                    lotoMania.QtdeGanhadores17pts = dr["QTD_GANHADORES_17PTS"].ToString();
                    lotoMania.ValorGanhadores17pts = dr["VALOR_GANHADORES_17PTS"].ToString();
                    lotoMania.QtdeGanhadores16pts = dr["QTD_GANHADORES_16PTS"].ToString();
                    lotoMania.ValorGanhadores16pts = dr["VALOR_GANHADORES_16PTS"].ToString();
                    lotoMania.QtdeGanhadores15pts = dr["QTD_GANHADORES_15PTS"].ToString();
                    lotoMania.ValorGanhadores15pts = dr["VALOR_GANHADORES_15PTS"].ToString();
                    lotoMania.QtdeGanhadores0pts = dr["QTD_GANHADORES_0PTS"].ToString();
                    lotoMania.ValorGanhadores0pts = dr["VALOR_GANHADORES_0PTS"].ToString();
                    lotoMania.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();
                return lotoMania;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        /// <summary>
        /// SalvarResultadoLotoMania
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoLotoMania(LotoMania data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_LOTOMANIA 
                                (
                                    NUM_CONCURSO,
                                    DAT_CONCURSO,
                                    NUM_SORTEADOS,
                                    QTD_GANHADORES_20PTS,
                                    VALOR_GANHADORES_20PTS,
                                    QTD_GANHADORES_19PTS,
                                    VALOR_GANHADORES_19PTS,
                                    QTD_GANHADORES_18PTS,
                                    VALOR_GANHADORES_18PTS,
                                    QTD_GANHADORES_17PTS,
                                    VALOR_GANHADORES_17PTS,
                                    QTD_GANHADORES_16PTS,
                                    VALOR_GANHADORES_16PTS,
                                    QTD_GANHADORES_15PTS,
                                    VALOR_GANHADORES_15PTS,
                                    QTD_GANHADORES_0PTS,
                                    VALOR_GANHADORES_0PTS,
                                    VALOR_ACUMULADO
                                ) VALUES 
                                (
                                    '" + data.NumConcurso + @"',
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados + @"',
                                    '" + data.QtdeGanhadores20pts + @"',
                                    '" + data.ValorGanhadores20pts.ToString() + @"',
                                    '" + data.QtdeGanhadores19pts + @"',
                                    '" + data.ValorGanhadores19pts.ToString() + @"',
                                    '" + data.QtdeGanhadores18pts + @"',
                                    '" + data.ValorGanhadores18pts.ToString() + @"',
                                    '" + data.QtdeGanhadores17pts + @"',
                                    '" + data.ValorGanhadores18pts.ToString() + @"',
                                    '" + data.QtdeGanhadores16pts + @"',
                                    '" + data.ValorGanhadores16pts.ToString() + @"',
                                    '" + data.QtdeGanhadores15pts + @"',
                                    '" + data.ValorGanhadores15pts.ToString() + @"',
                                    '" + data.QtdeGanhadores0pts + @"',
                                    '" + data.ValorGanhadores0pts.ToString() + @"',
                                    '" + data.ValorAcumulado.ToString() + @"'
                                )";
                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand comand = new MySqlCommand(sql, con);
                con.Open();
                comand.ExecuteNonQuery();
                con.Close();
                comand.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro do ", ex.Message);
                return false;
            }
        }
    }
}