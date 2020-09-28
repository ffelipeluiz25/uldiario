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
        public MegaSena RecuperarUltimoResultadoLotoMania()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                          RS.NUM_CONCURSO, 
                          RS.DAT_CONCURSO,
                          RS.NUM_SORTEADOS,
                          RS.QTD_GANHADORES_SENA,
                          RS.VALOR_GANHADORES_SENA,
                          RS.QTD_GANHADORES_QUINA,
                          RS.VALOR_GANHADORES_QUINA,
                          RS.QTD_GANHADORES_QUADRA,
                          RS.VALOR_GANHADORES_QUADRA,
                          RS.VALOR_ACUMULADO
                    FROM
                          RESULTADO_LOTOMANIA RL
                    ORDER BY 1 desc; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                MegaSena megasena = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    megasena = new MegaSena();
                    megasena.NumConcurso = Convert.ToInt32(dr["NUM_CONCURSO"]);
                    megasena.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    megasena.NumSorteados = dr["NUM_SORTEADOS"].ToString();
                    megasena.QtdeGanhadoresSena = Convert.ToInt32(dr["QTD_GANHADORES_SENA"]);
                    megasena.ValorGanhadoresSena = Convert.ToDecimal(dr["VALOR_GANHADORES_SENA"]);
                    megasena.QtdeGanhadoresQuina = Convert.ToInt32(dr["QTD_GANHADORES_QUINA"]);
                    megasena.ValorGanhadoresQuina = Convert.ToDecimal(dr["VALOR_GANHADORES_QUINA"]);
                    megasena.QtdeGanhadoresQuadra = Convert.ToInt32(dr["QTD_GANHADORES_QUADRA"]);
                    megasena.ValorGanhadoresQuadra = Convert.ToDecimal(dr["VALOR_GANHADORES_QUADRA"]);
                    megasena.ValorAcumulado = Convert.ToDecimal(dr["VALOR_ACUMULADO"]);
                }
                dr.Dispose();
                con.Close();
                return megasena;

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
                                    QTD_GANHADORES_SENA,
                                    VALOR_GANHADORES_SENA,
                                    QTD_GANHADORES_QUINA,
                                    VALOR_GANHADORES_QUINA,
                                    QTD_GANHADORES_QUADRA,
                                    VALOR_GANHADORES_QUADRA,
                                    VALOR_ACUMULADO
                                ) VALUES 
                                (
                                    " + data.NumConcurso + @",
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados + @"',
                                    " + data.QtdeGanhadoresSena + @",
                                    " + data.ValorGanhadoresSena.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadoresQuina + @",
                                    " + data.ValorGanhadoresQuina.ToString().Replace(',', '.') + @",
                                    " + data.QtdeGanhadoresQuadra + @",
                                    " + data.ValorGanhadoresQuadra.ToString().Replace(',', '.') + @",
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