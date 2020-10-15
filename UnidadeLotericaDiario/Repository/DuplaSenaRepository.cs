using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class DuplaSenaRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public DuplaSenaRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion

        /// <summary>
        /// RecuperarUltimoResultadoDuplaSena
        /// </summary>
        /// <returns></returns>
        public DuplaSena RecuperarUltimoResultadoDuplaSena()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                        RD.NUM_CONCURSO, 
	                    RD.DAT_CONCURSO, 
	                    RD.NUM_SORTEADOS_1, 
	                    RD.QTD_GANHADORES_1_SENA, 
	                    RD.VALOR_GANHADORES_1_SENA, 
	                    RD.QTD_GANHADORES_1_QUINA, 
	                    RD.VALOR_GANHADORES_1_QUINA, 
	                    RD.QTD_GANHADORES_1_QUADRA, 
	                    RD.VALOR_GANHADORES_1_QUADRA, 
	                    RD.QTD_GANHADORES_1_TERNO, 
	                    RD.VALOR_GANHADORES_1_TERNO, 
	                    RD.NUM_SORTEADOS_2, 
	                    RD.QTD_GANHADORES_2_SENA, 
	                    RD.VALOR_GANHADORES_2_SENA, 
	                    RD.QTD_GANHADORES_2_QUINA, 
	                    RD.VALOR_GANHADORES_2_QUINA, 
	                    RD.QTD_GANHADORES_2_QUADRA, 
	                    RD.VALOR_GANHADORES_2_QUADRA, 
	                    RD.QTD_GANHADORES_2_TERNO, 
	                    RD.VALOR_GANHADORES_2_TERNO,
	                    RD.VALOR_ACUMULADO
                    FROM
                         RESULTADO_DUPLASENA RD
                    ORDER BY 1 DESC
                    LIMIT 1; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                DuplaSena duplaSena = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    duplaSena = new DuplaSena();
                    duplaSena.NumConcurso = dr["NUM_CONCURSO"].ToString();
                    duplaSena.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    duplaSena.NumSorteados_1 = dr["NUM_SORTEADOS_1"].ToString();
                    duplaSena.QtdeGanhadoresSena_1 = dr["QTD_GANHADORES_1_SENA"].ToString();
                    duplaSena.ValorGanhadoresSena_1 = dr["VALOR_GANHADORES_1_SENA"].ToString();
                    duplaSena.QtdeGanhadoresQuina_1 = dr["QTD_GANHADORES_1_QUINA"].ToString();
                    duplaSena.ValorGanhadoresQuina_1 = dr["VALOR_GANHADORES_1_QUINA"].ToString();
                    duplaSena.QtdeGanhadoresQuadra_1 = dr["QTD_GANHADORES_1_QUADRA"].ToString();
                    duplaSena.ValorGanhadoresQuadra_1 = dr["VALOR_GANHADORES_1_QUADRA"].ToString();
                    duplaSena.QtdeGanhadoresTerno_1 = dr["QTD_GANHADORES_1_TERNO"].ToString();
                    duplaSena.ValorGanhadoresTerno_1 = dr["VALOR_GANHADORES_1_TERNO"].ToString();
                    duplaSena.NumSorteados_2 = dr["NUM_SORTEADOS_2"].ToString();
                    duplaSena.QtdeGanhadoresSena_2 = dr["QTD_GANHADORES_2_SENA"].ToString();
                    duplaSena.ValorGanhadoresSena_2 = dr["VALOR_GANHADORES_2_SENA"].ToString();
                    duplaSena.QtdeGanhadoresQuina_2 = dr["QTD_GANHADORES_2_QUINA"].ToString();
                    duplaSena.ValorGanhadoresQuina_2 = dr["VALOR_GANHADORES_2_QUINA"].ToString();
                    duplaSena.QtdeGanhadoresQuadra_2 = dr["QTD_GANHADORES_2_QUADRA"].ToString();
                    duplaSena.ValorGanhadoresQuadra_2 = dr["VALOR_GANHADORES_2_QUADRA"].ToString();
                    duplaSena.QtdeGanhadoresTerno_2 = dr["QTD_GANHADORES_2_TERNO"].ToString();
                    duplaSena.ValorGanhadoresTerno_2 = dr["VALOR_GANHADORES_2_TERNO"].ToString();
                    duplaSena.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();
                return duplaSena;

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
        /// SalvarResultadoDuplaSena
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoDuplaSena(DuplaSena data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_DUPLASENA
                                (
                                    NUM_CONCURSO ,
	                                DAT_CONCURSO ,
	                                NUM_SORTEADOS_1 ,
	                                QTD_GANHADORES_1_SENA ,
	                                VALOR_GANHADORES_1_SENA ,
	                                QTD_GANHADORES_1_QUINA ,
	                                VALOR_GANHADORES_1_QUINA ,
	                                QTD_GANHADORES_1_QUADRA ,
	                                VALOR_GANHADORES_1_QUADRA ,
	                                QTD_GANHADORES_1_TERNO ,
	                                VALOR_GANHADORES_1_TERNO ,
	                                NUM_SORTEADOS_2 ,
	                                QTD_GANHADORES_2_SENA ,
	                                VALOR_GANHADORES_2_SENA, 
	                                QTD_GANHADORES_2_QUINA ,
	                                VALOR_GANHADORES_2_QUINA ,
	                                QTD_GANHADORES_2_QUADRA ,
	                                VALOR_GANHADORES_2_QUADRA, 
	                                QTD_GANHADORES_2_TERNO ,
	                                VALOR_GANHADORES_2_TERNO, 
	                                VALOR_ACUMULADO 
                                ) VALUES 
                                (
                                    '" + data.NumConcurso + @"',
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados_1 + @"',
                                    '" + data.QtdeGanhadoresSena_1 + @"',
                                    '" + data.ValorGanhadoresSena_1.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuina_1 + @"',
                                    '" + data.ValorGanhadoresQuina_1.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuadra_1 + @"',
                                    '" + data.ValorGanhadoresQuadra_1.ToString() + @"',
                                    '" + data.QtdeGanhadoresTerno_1 + @"',
                                    '" + data.ValorGanhadoresTerno_1.ToString() + @"',
                                    '" + data.NumSorteados_2 + @"',
                                    '" + data.QtdeGanhadoresSena_2 + @"',
                                    '" + data.ValorGanhadoresSena_2.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuina_2 + @"',
                                    '" + data.ValorGanhadoresQuina_2.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuadra_2 + @"',
                                    '" + data.ValorGanhadoresQuadra_2.ToString() + @"',
                                    '" + data.QtdeGanhadoresTerno_2 + @"',
                                    '" + data.ValorGanhadoresTerno_2.ToString() + @"',
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