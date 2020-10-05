using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class DiaDeSorteRepository
    {


        #region Atributos

        string _connectionString;
        //MySqlConnection con;

        #endregion

        #region Construtor

        public DiaDeSorteRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion


        /// <summary>
        /// RecuperarUltimoResultadoDiaDeSorte
        /// </summary>
        /// <returns></returns>
        public DiaDeSorte RecuperarUltimoResultadoDiaDeSorte()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                            RD.NUM_CONCURSO, 
	                        RD.DAT_CONCURSO, 
	                        RD.NUM_SORTEADOS, 
	                        RD.QTD_GANHADORES_7PTS,
                            RD.VALOR_GANHADORES_7PTS,
                            RD.QTD_GANHADORES_6PTS,
                            RD.VALOR_GANHADORES_6PTS,
                            RD.QTD_GANHADORES_5PTS,
                            RD.VALOR_GANHADORES_5PTS,
                            RD.QTD_GANHADORES_4PTS,
                            RD.VALOR_GANHADORES_4PTS,
                            RD.NUM_MES_SORTEADO,
                            RD.NUM_GANHADORES,
                            RD.VALOR_TOTAL,
	                        RD.VALOR_ACUMULADO
                    FROM
                          RESULTADO_DIADESORTE RD
                    ORDER BY 1 desc; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                DiaDeSorte diaDeSorte = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    diaDeSorte = new DiaDeSorte();
                    diaDeSorte.NumConcurso = dr["NUM_CONCURSO"].ToString();
                    diaDeSorte.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    diaDeSorte.NumSorteados = dr["NUM_SORTEADOS"].ToString();
                    diaDeSorte.QtdeGanhadores_7pts = dr["QTD_GANHADORES_7PTS"].ToString();
                    diaDeSorte.ValorGanhadores_7pts = dr["VALOR_GANHADORES_7PTS"].ToString();
                    diaDeSorte.QtdeGanhadores_6pts = dr["QTD_GANHADORES_6PTS"].ToString();
                    diaDeSorte.ValorGanhadores_6pts = dr["VALOR_GANHADORES_6PTS"].ToString();
                    diaDeSorte.QtdeGanhadores_5pts = dr["QTD_GANHADORES_5PTS"].ToString();
                    diaDeSorte.ValorGanhadores_5pts = dr["VALOR_GANHADORES_5PTS"].ToString();
                    diaDeSorte.QtdeGanhadores_4pts = dr["QTD_GANHADORES_4PTS"].ToString();
                    diaDeSorte.ValorGanhadores_4pts = dr["VALOR_GANHADORES_4PTS"].ToString();
                    diaDeSorte.MesSorteado = dr["NUM_MES_SORTEADO"].ToString();
                    diaDeSorte.QtdeGanhadores = dr["NUM_GANHADORES"].ToString();
                    diaDeSorte.ValorTotal = dr["VALOR_TOTAL"].ToString();
                    diaDeSorte.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();
                return diaDeSorte;

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
        /// SalvarResultadoDiaDeSorte
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoDiaDeSorte(DiaDeSorte data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_MEGASENA 
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
                                    NUM_MES_SORTEADO,
                                    NUM_GANHADORES,
                                    VALOR_TOTAL,
                                    VALOR_ACUMULADO
                                ) VALUES 
                                (
                                    '" + data.NumConcurso + @"',
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados + @"',
                                    '" + data.QtdeGanhadores_7pts+ @"',
                                    '" + data.ValorGanhadores_7pts.ToString() + @"',
                                    '" + data.QtdeGanhadores_6pts + @"',
                                    '" + data.ValorGanhadores_6pts.ToString() + @"',
                                    '" + data.QtdeGanhadores_5pts + @"',
                                    '" + data.ValorGanhadores_5pts.ToString() + @"',
                                    '" + data.QtdeGanhadores_4pts + @"',
                                    '" + data.ValorGanhadores_4pts.ToString() + @"',
                                    '" + data.MesSorteado + @"',
                                    '" + data.QtdeGanhadores.ToString() + @"',
                                    '" + data.ValorTotal.ToString() + @"',
                                    '" + data.ValorAcumulado.ToString() + @"'
                                );";
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