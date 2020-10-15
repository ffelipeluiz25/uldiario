using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class TimeManiaRepository
    {


        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public TimeManiaRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion


        /// <summary>
        /// RecuperarUltimoResultadoTimeMania
        /// </summary>
        /// <returns></returns>
        public TimeMania RecuperarUltimoResultadoTimeMania()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                        RT.NUM_CONCURSO, 
	                    RT.DAT_CONCURSO,
	                    RT.NUM_SORTEADOS,
	                    RT.QTD_GANHADORES_7PTS,
	                    RT.VALOR_GANHADORES_7PTS, 
	                    RT.QTD_GANHADORES_6PTS,
	                    RT.VALOR_GANHADORES_6PTS, 
	                    RT.QTD_GANHADORES_5PTS,
	                    RT.VALOR_GANHADORES_5PTS, 
	                    RT.QTD_GANHADORES_4PTS,
	                    RT.VALOR_GANHADORES_4PTS, 
	                    RT.QTD_GANHADORES_3PTS,
	                    RT.VALOR_GANHADORES_3PTS, 
	                    RT.QTD_GANHADORES_TIME_CORACAO,
	                    RT.VALOR_GANHADORES_TIME_CORACAO, 
	                    RT.DSC_TIME_SORTEADO,
	                    RT.VALOR_ACUMULADO 
                    FROM
                         RESULTADO_TIMEMANIA RT
                    ORDER BY 1 DESC
                    LIMIT 1; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                TimeMania timeMania = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    timeMania = new TimeMania();
                    timeMania.NumConcurso = dr["NUM_CONCURSO"].ToString();
                    timeMania.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    timeMania.NumSorteados = dr["NUM_SORTEADOS"].ToString();
                    timeMania.QtdeGanhadores7pts = dr["QTD_GANHADORES_7PTS"].ToString();
                    timeMania.ValorGanhadores7pts = dr["VALOR_GANHADORES_7PTS"].ToString();
                    timeMania.QtdeGanhadores6pts = dr["QTD_GANHADORES_6PTS"].ToString();
                    timeMania.ValorGanhadores6pts = dr["VALOR_GANHADORES_6PTS"].ToString();
                    timeMania.QtdeGanhadores5pts = dr["QTD_GANHADORES_5PTS"].ToString();
                    timeMania.ValorGanhadores5pts = dr["VALOR_GANHADORES_5PTS"].ToString();
                    timeMania.QtdeGanhadores4pts = dr["QTD_GANHADORES_4PTS"].ToString();
                    timeMania.ValorGanhadores4pts = dr["VALOR_GANHADORES_4PTS"].ToString();
                    timeMania.QtdeGanhadores3pts = dr["QTD_GANHADORES_3PTS"].ToString();
                    timeMania.ValorGanhadores3pts = dr["VALOR_GANHADORES_3PTS"].ToString();
                    timeMania.QtdeGanhadoresTimeCoracao = dr["QTD_GANHADORES_TIME_CORACAO"].ToString();
                    timeMania.ValorGanhadoresTimeCoracao = dr["VALOR_GANHADORES_TIME_CORACAO"].ToString();
                    timeMania.DscTimeSorteado = dr["DSC_TIME_SORTEADO"].ToString();
                    timeMania.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();
                return timeMania;

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
        /// SalvarResultadoTimeManiaa
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoTimeMania(TimeMania data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_TIMEMANIA 
                                (
                                    NUM_CONCURSO, 
	                                DAT_CONCURSO,
	                                NUM_SORTEADOS,
	                                QTD_GANHADORES_7PTS,
	                                VALOR_GANHADORES_7PTS, 
	                                QTD_GANHADORES_6PTS,
	                                VALOR_GANHADORES_6PTS, 
	                                QTD_GANHADORES_5PTS,
	                                VALOR_GANHADORES_5PTS, 
	                                QTD_GANHADORES_4PTS,
	                                VALOR_GANHADORES_4PTS, 
	                                QTD_GANHADORES_3PTS,
	                                VALOR_GANHADORES_3PTS, 
	                                QTD_GANHADORES_TIME_CORACAO,
	                                VALOR_GANHADORES_TIME_CORACAO, 
	                                DSC_TIME_SORTEADO,
	                                VALOR_ACUMULADO 
                                ) VALUES 
                                (
                                    '" + data.NumConcurso + @"',
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados + @"',
                                    '" + data.QtdeGanhadores7pts + @"',
                                    '" + data.ValorGanhadores7pts.ToString() + @"',
                                    '" + data.QtdeGanhadores6pts + @"',
                                    '" + data.ValorGanhadores6pts.ToString() + @"',
                                    '" + data.QtdeGanhadores5pts + @"',
                                    '" + data.ValorGanhadores5pts.ToString() + @"',
                                    '" + data.QtdeGanhadores4pts + @"',
                                    '" + data.ValorGanhadores4pts.ToString() + @"',
                                    '" + data.QtdeGanhadores3pts + @"',
                                    '" + data.ValorGanhadores3pts.ToString() + @"',
                                    '" + data.QtdeGanhadoresTimeCoracao + @"',
                                    '" + data.ValorGanhadoresTimeCoracao.ToString() + @"',
                                    '" + data.DscTimeSorteado + @"',
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