using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class LotoFacilRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public LotoFacilRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion

        /// <summary>
        /// RecuperarUltimoResultadoLotoFacil
        /// </summary>
        /// <returns></returns>
        public LotoFacil RecuperarUltimoResultadoLotoFacil()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                         RL.NUM_CONCURSO_1, 
                         RL.DAT_CONCURSO_1,
                         RL.NUM_SORTEADOS_1,
                         RL.QTD_GANHADORES_1_15PTS, 
                         RL.VALOR_GANHADORES_1_15PTS,
                         RL.QTD_GANHADORES_1_14PTS, 
                         RL.VALOR_GANHADORES_1_14PTS,
                         RL.QTD_GANHADORES_1_13PTS, 
                         RL.VALOR_GANHADORES_1_13PTS,
                         RL.QTD_GANHADORES_1_12PTS, 
                         RL.VALOR_GANHADORES_1_12PTS,
                         RL.QTD_GANHADORES_1_11PTS, 
                         RL.VALOR_GANHADORES_1_11PTS,
                         RL.VALOR_ACUMULADO_1,
                         RL.NUM_CONCURSO_2, 
                         RL.DAT_CONCURSO_2,
                         RL.NUM_SORTEADOS_2,
                         RL.QTD_GANHADORES_2_15PTS,
                         RL.VALOR_GANHADORES_2_15PTS,
                         RL.QTD_GANHADORES_2_14PTS, 
                         RL.VALOR_GANHADORES_2_14PTS,
                         RL.QTD_GANHADORES_2_13PTS, 
                         RL.VALOR_GANHADORES_2_13PTS,
                         RL.QTD_GANHADORES_2_12PTS, 
                         RL.VALOR_GANHADORES_2_12PTS,
                         RL.QTD_GANHADORES_2_11PTS, 
                         RL.VALOR_GANHADORES_2_11PTS,
                         RL.VALOR_ACUMULADO_2 
                    FROM
                         RESULTADO_LOTOFACIL RL
                    ORDER BY 1 desc; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                LotoFacil lotoFacil = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lotoFacil = new LotoFacil();
                    lotoFacil.NumConcurso_1 = dr["NUM_CONCURSO_1"].ToString();
                    lotoFacil.DatConcurso_1 = dr["DAT_CONCURSO_1"].ToString();
                    lotoFacil.NumSorteados_1 = dr["NUM_SORTEADOS_1"].ToString();
                    lotoFacil.QtdeGanhadores15pts_1 = dr["QTD_GANHADORES_1_15PTS"].ToString();
                    lotoFacil.ValorGanhadores15pts_1 = dr["VALOR_GANHADORES_1_15PTS"].ToString();
                    lotoFacil.QtdeGanhadores14pts_1 = dr["QTD_GANHADORES_1_14PTS"].ToString();
                    lotoFacil.ValorGanhadores14pts_1 = dr["VALOR_GANHADORES_1_14PTS"].ToString();
                    lotoFacil.QtdeGanhadores13pts_1 = dr["QTD_GANHADORES_1_13PTS"].ToString();
                    lotoFacil.ValorGanhadores13pts_1 = dr["VALOR_GANHADORES_1_13PTS"].ToString();
                    lotoFacil.QtdeGanhadores12pts_1 = dr["QTD_GANHADORES_1_12PTS"].ToString();
                    lotoFacil.ValorGanhadores12pts_1 = dr["VALOR_GANHADORES_1_12PTS"].ToString();
                    lotoFacil.QtdeGanhadores11pts_1 = dr["QTD_GANHADORES_1_11PTS"].ToString();
                    lotoFacil.ValorGanhadores11pts_1 = dr["VALOR_GANHADORES_1_11PTS"].ToString();
                    lotoFacil.ValorAcumulado_1 = dr["VALOR_ACUMULADO_1"].ToString();

                    lotoFacil.NumConcurso_2 = dr["NUM_CONCURSO_2"].ToString();
                    lotoFacil.DatConcurso_2 = dr["DAT_CONCURSO_2"].ToString();
                    lotoFacil.NumSorteados_2 = dr["NUM_SORTEADOS_2"].ToString();
                    lotoFacil.QtdeGanhadores15pts_2 = dr["QTD_GANHADORES_2_15PTS"].ToString();
                    lotoFacil.ValorGanhadores15pts_2 = dr["VALOR_GANHADORES_2_15PTS"].ToString();
                    lotoFacil.QtdeGanhadores14pts_2 = dr["QTD_GANHADORES_2_14PTS"].ToString();
                    lotoFacil.ValorGanhadores14pts_2 = dr["VALOR_GANHADORES_2_14PTS"].ToString();
                    lotoFacil.QtdeGanhadores13pts_2 = dr["QTD_GANHADORES_2_13PTS"].ToString();
                    lotoFacil.ValorGanhadores13pts_2 = dr["VALOR_GANHADORES_2_13PTS"].ToString();
                    lotoFacil.QtdeGanhadores12pts_2 = dr["QTD_GANHADORES_2_12PTS"].ToString();
                    lotoFacil.ValorGanhadores12pts_2 = dr["VALOR_GANHADORES_2_12PTS"].ToString();
                    lotoFacil.QtdeGanhadores11pts_2 = dr["QTD_GANHADORES_2_11PTS"].ToString();
                    lotoFacil.ValorGanhadores11pts_2 = dr["VALOR_GANHADORES_2_11PTS"].ToString();
                    lotoFacil.ValorAcumulado_2 = dr["VALOR_ACUMULADO_2"].ToString();
                }
                dr.Dispose();
                con.Close();
                return lotoFacil;

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
        /// SalvarResultadoLotoFacil
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoLotoFacil(LotoFacil data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_LOTOFACIL
                                (
                                    NUM_CONCURSO_1,
                                    DAT_CONCURSO_1,
                                    NUM_SORTEADOS_1,
                                    QTD_GANHADORES_1_15PTS,
                                    VALOR_GANHADORES_1_15PTS,
                                    QTD_GANHADORES_1_14PTS,
                                    VALOR_GANHADORES_1_14PTS,
                                    QTD_GANHADORES_1_13PTS,
                                    VALOR_GANHADORES_1_13PTS,
                                    QTD_GANHADORES_1_12PTS,
                                    VALOR_GANHADORES_1_12PTS,
                                    QTD_GANHADORES_1_11PTS,
                                    VALOR_GANHADORES_1_11PTS,
                                    VALOR_ACUMULADO_1,
                                    NUM_CONCURSO_2,
                                    DAT_CONCURSO_2,
                                    NUM_SORTEADOS_2,
                                    QTD_GANHADORES_2_15PTS,
                                    VALOR_GANHADORES_2_15PTS,
                                    QTD_GANHADORES_2_14PTS,
                                    VALOR_GANHADORES_2_14PTS,
                                    QTD_GANHADORES_2_13PTS,
                                    VALOR_GANHADORES_2_13PTS,
                                    QTD_GANHADORES_2_12PTS,
                                    VALOR_GANHADORES_2_12PTS,
                                    QTD_GANHADORES_2_11PTS,
                                    VALOR_GANHADORES_2_11PTS,
                                    VALOR_ACUMULADO_2
                                ) VALUES 
                                (
                                    '" + data.NumConcurso_1 + @"',
                                    '" + data.DatConcurso_1 + @"',
                                    '" + data.NumSorteados_1 + @"',
                                    '" + data.QtdeGanhadores15pts_1 + @"',
                                    '" + data.ValorGanhadores15pts_1.ToString() + @"',
                                    '" + data.QtdeGanhadores14pts_1 + @"',
                                    '" + data.ValorGanhadores14pts_1.ToString() + @"',
                                    '" + data.QtdeGanhadores13pts_1 + @"',
                                    '" + data.ValorGanhadores13pts_1.ToString() + @"',
                                    '" + data.QtdeGanhadores12pts_1 + @"',
                                    '" + data.ValorGanhadores12pts_1.ToString() + @"',
                                    '" + data.QtdeGanhadores11pts_1 + @"',
                                    '" + data.ValorGanhadores11pts_1.ToString() + @"',
                                    '" + data.ValorAcumulado_1.ToString() + @"',
                                    '" + data.NumConcurso_2 + @"',
                                    '" + data.DatConcurso_2 + @"',
                                    '" + data.NumSorteados_2 + @"',
                                    '" + data.QtdeGanhadores15pts_2 + @"',
                                    '" + data.ValorGanhadores15pts_2.ToString() + @"',
                                    '" + data.QtdeGanhadores14pts_2 + @"',
                                    '" + data.ValorGanhadores14pts_2.ToString() + @"',
                                    '" + data.QtdeGanhadores13pts_2 + @"',
                                    '" + data.ValorGanhadores13pts_2.ToString() + @"',
                                    '" + data.QtdeGanhadores12pts_2 + @"',
                                    '" + data.ValorGanhadores12pts_2.ToString() + @"',
                                    '" + data.QtdeGanhadores11pts_2 + @"',
                                    '" + data.ValorGanhadores11pts_2.ToString() + @"',
                                    '" + data.ValorAcumulado_2.ToString() + @"'
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