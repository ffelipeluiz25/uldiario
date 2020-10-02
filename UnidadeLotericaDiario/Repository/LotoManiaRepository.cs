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
        /// RecuperarUltimoResultadoMegaSena
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
                    ORDER BY 1 desc; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                LotoMania lotoMania = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lotoMania = new LotoMania();
                    lotoMania.NumConcurso = Convert.ToInt32(dr["NUM_CONCURSO"]);
                    lotoMania.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    lotoMania.NumSorteados = dr["NUM_SORTEADOS"].ToString();
                    lotoMania.QtdeGanhadores20pts = Convert.ToInt32(dr["QTD_GANHADORES_20PTS"]);
                    lotoMania.ValorGanhadores20pts = Convert.ToDecimal(dr["VALOR_GANHADORES_20PTS"]);
                    lotoMania.QtdeGanhadores19pts = Convert.ToInt32(dr["QTD_GANHADORES_19PTS"]);
                    lotoMania.ValorGanhadores19pts = Convert.ToDecimal(dr["VALOR_GANHADORES_19PTS"]);
                    lotoMania.QtdeGanhadores18pts = Convert.ToInt32(dr["QTD_GANHADORES_18PTS"]);
                    lotoMania.ValorGanhadores18pts = Convert.ToDecimal(dr["VALOR_GANHADORES_18PTS"]);
                    lotoMania.QtdeGanhadores17pts = Convert.ToInt32(dr["QTD_GANHADORES_17PTS"]);
                    lotoMania.ValorGanhadores17pts = Convert.ToDecimal(dr["VALOR_GANHADORES_17PTS"]);
                    lotoMania.QtdeGanhadores16pts = Convert.ToInt32(dr["QTD_GANHADORES_16PTS"]);
                    lotoMania.ValorGanhadores16pts = Convert.ToDecimal(dr["VALOR_GANHADORES_16PTS"]);
                    lotoMania.QtdeGanhadores15pts = Convert.ToInt32(dr["QTD_GANHADORES_15PTS"]);
                    lotoMania.ValorGanhadores15pts = Convert.ToDecimal(dr["VALOR_GANHADORES_15PTS"]);
                    lotoMania.QtdeGanhadores0pts = Convert.ToInt32(dr["QTD_GANHADORES_0PTS"]);
                    lotoMania.ValorGanhadores0pts = Convert.ToDecimal(dr["VALOR_GANHADORES_0PTS"]);
                    lotoMania.ValorAcumulado = Convert.ToDecimal(dr["VALOR_ACUMULADO"]);
                }
                dr.Dispose();
                con.Close();
                return lotoMania;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
            
            }
        }

        /// <summary>
        /// SalvarResultadoMegaSena
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
                                    " + data.NumConcurso + @",
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados + @"',
                                    " + data.QtdeGanhadores20pts + @",
                                    " + data.ValorGanhadores20pts.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadores19pts + @",
                                    " + data.ValorGanhadores19pts.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadores18pts + @",
                                    " + data.ValorGanhadores18pts.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadores17pts + @",
                                    " + data.ValorGanhadores18pts.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadores16pts + @",
                                    " + data.ValorGanhadores16pts.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadores15pts + @",
                                    " + data.ValorGanhadores15pts.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadores0pts + @",
                                    " + data.ValorGanhadores0pts.ToString().Replace(',', '.') + @",
                                    " + data.ValorAcumulado.ToString().Replace(',', '.') + @"
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