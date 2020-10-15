using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class MegaSenaRepository
    {


        #region Atributos

        string _connectionString;
        //MySqlConnection con;

        #endregion

        #region Construtor

        public MegaSenaRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion


        /// <summary>
        /// RecuperarUltimoResultadoMegaSena
        /// </summary>
        /// <returns></returns>
        public MegaSena RecuperarUltimoResultadoMegaSena()
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
                          RESULTADO_MEGASENA RS
                    ORDER BY 1 DESC
                    LIMIT 1; ";

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
                    megasena.QtdeGanhadoresSena = dr["QTD_GANHADORES_SENA"].ToString();
                    megasena.ValorGanhadoresSena = dr["VALOR_GANHADORES_SENA"].ToString();
                    megasena.QtdeGanhadoresQuina = dr["QTD_GANHADORES_QUINA"].ToString();
                    megasena.ValorGanhadoresQuina = dr["VALOR_GANHADORES_QUINA"].ToString();
                    megasena.QtdeGanhadoresQuadra = dr["QTD_GANHADORES_QUADRA"].ToString();
                    megasena.ValorGanhadoresQuadra = dr["VALOR_GANHADORES_QUADRA"].ToString();
                    megasena.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();
                return megasena;

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
        /// SalvarResultadoMegaSena
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoMegaSena(MegaSena data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_MEGASENA 
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
                                    '" + data.NumConcurso + @"',
                                    '" + data.DatConcurso + @"',
                                    '" + data.NumSorteados + @"',
                                    '" + data.QtdeGanhadoresSena + @"',
                                    '" + data.ValorGanhadoresSena.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuina + @"',
                                    '" + data.ValorGanhadoresQuina.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuadra + @"',
                                    '" + data.ValorGanhadoresQuadra.ToString() + @"',
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