using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class LotecaRepository
    {


        #region Atributos

        string _connectionString;
        //MySqlConnection con;

        #endregion

        #region Construtor

        public LotecaRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion


        /// <summary>
        /// RecuperarUltimoResultadoLoteca
        /// </summary>
        /// <returns></returns>
        public Loteca RecuperarUltimoResultadoLoteca()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                          RL.NUM_CONCURSO, 
                          RL.DAT_CONCURSO,
                          RL.QTD_GANHADORES_15PTS,
                          RL.VALOR_GANHADORES_15PTS,
                          RL.QTD_GANHADORES_16PTS,
                          RL.VALOR_GANHADORES_16PTS,
                          RL.VALOR_ACUMULADO
                    FROM
                          RESULTADO_LOTECA RL
                    ORDER BY 1 desc; ";




                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                Loteca obj = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = new Loteca();
                    obj.NumConcurso = dr["NUM_CONCURSO"].ToString();
                    obj.DatConcurso = dr["DAT_CONCURSO"].ToString();
                    obj.QtdeGanhadores15pts = dr["QTD_GANHADORES_15PTS"].ToString();
                    obj.ValorGanhadores15pts = dr["VALOR_GANHADORES_15PTS"].ToString();
                    obj.QtdeGanhadores16pts = dr["QTD_GANHADORES_16PTS"].ToString();
                    obj.ValorGanhadores16pts = dr["VALOR_GANHADORES_16PTS"].ToString();
                    obj.ValorAcumulado = dr["VALOR_ACUMULADO"].ToString();
                }
                dr.Dispose();
                con.Close();

                if (obj != null)
                {
                    String sqlJogos = @"
                    SELECT DISTINCT
                          RJL.NUM_CONCURSO,
                          RJL.IND_FAIXA,
                          RJL.IND_TIPO_RESULTADO
                    FROM
                          RESULTADO_JOGOS_LOTECA RJL
                    WHERE
                          RJL.NUM_CONCURSO = " + obj.NumConcurso + @"
                    ORDER BY 1 desc; ";
                    con = new MySqlConnection(_connectionString);
                    cmd = new MySqlCommand(sqlJogos, con);
                    con.Open();
                    JogosLoteca objJogos = null;
                    MySqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        objJogos = new JogosLoteca();
                        objJogos.NumConcurso = dr1["NUM_CONCURSO"].ToString();
                        objJogos.IndFaixa = Convert.ToInt32(dr1["IND_FAIXA"].ToString());
                        objJogos.IndTipoResultado = Convert.ToInt32(dr1["IND_TIPO_RESULTADO"].ToString());
                        obj.ListaJogos.Add(objJogos);
                    }
                    dr1.Dispose();
                    con.Close();
                }
                
                return obj;

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
        /// SalvarResultadoLoteca
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoLoteca(Loteca data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_LOTECA 
                                (
                                    NUM_CONCURSO,
                                    DAT_CONCURSO,
                                    QTD_GANHADORES_15PTS,
                                    VALOR_GANHADORES_15PTS,
                                    QTD_GANHADORES_16PTS,
                                    VALOR_GANHADORES_16PTS,
                                    VALOR_ACUMULADO
                                ) VALUES 
                                (
                                    '" + data.NumConcurso + @"',
                                    '" + data.DatConcurso + @"',
                                    '" + data.QtdeGanhadores15pts + @"',
                                    '" + data.ValorGanhadores15pts.ToString() + @"',
                                    '" + data.QtdeGanhadores16pts + @"',
                                    '" + data.ValorGanhadores16pts.ToString() + @"',
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

        /// <summary>
        /// SalvarResultadoJogosLoteca
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoJogosLoteca(JogosLoteca data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_JOGOS_LOTECA 
                                (
                                    NUM_CONCURSO,
                                    IND_FAIXA,
                                    IND_TIPO_RESULTADO
                                ) VALUES 
                                (
                                    '" + data.NumConcurso + @"',
                                    " + data.IndFaixa + @",
                                    " + data.IndTipoResultado + @"
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