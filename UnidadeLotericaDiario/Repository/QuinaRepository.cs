using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class QuinaRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public QuinaRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion

        /// <summary>
        /// RecuperarUltimoResultadoQuina
        /// </summary>
        /// <returns></returns>
        public Quina RecuperarUltimoResultadoQuina()
        {
            try
            {
                String sql = @"
                    SELECT DISTINCT
                        RQ.NUM_CONCURSO_1, 
                        RQ.DAT_CONCURSO_1 ,
                        RQ.NUM_SORTEADOS_1 ,
                        RQ.QTD_GANHADORES_QUINA_1, 
                        RQ.VALOR_GANHADORES_QUINA_1 ,
                        RQ.QTD_GANHADORES_QUADRA_1 ,
                        RQ.VALOR_GANHADORES_QUADRA_1,
                        RQ.QTD_GANHADORES_TERNO_1 ,
                        RQ.VALOR_GANHADORES_TERNO_1, 
                        RQ.QTD_GANHADORES_DUQUE_1 ,
                        RQ.VALOR_GANHADORES_DUQUE_1, 
                        RQ.VALOR_ACUMULADO_1 ,
                        RQ.NUM_CONCURSO_2 ,
                        RQ.DAT_CONCURSO_2 ,
                        RQ.NUM_SORTEADOS_2 ,
                        RQ.QTD_GANHADORES_QUINA_2 ,
                        RQ.VALOR_GANHADORES_QUINA_2, 
                        RQ.QTD_GANHADORES_QUADRA_2 ,
                        RQ.VALOR_GANHADORES_QUADRA_2,
                        RQ.QTD_GANHADORES_TERNO_2 ,
                        RQ.VALOR_GANHADORES_TERNO_2, 
                        RQ.QTD_GANHADORES_DUQUE_2 ,
                        RQ.VALOR_GANHADORES_DUQUE_2, 
                        RQ.VALOR_ACUMULADO_2 
                    FROM
                         RESULTADO_QUINA RQ
                    ORDER BY 1 DESC
                    LIMIT 1; ";

                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader dr;
                Quina quina = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    quina = new Quina();
                    quina.NumConcurso_1 = dr["NUM_CONCURSO_1"].ToString();
                    quina.DatConcurso_1 = dr["DAT_CONCURSO_1"].ToString();
                    quina.NumSorteados_1 = dr["NUM_SORTEADOS_1"].ToString();
                    quina.QtdeGanhadoresQuina_1 = dr["QTD_GANHADORES_QUINA_1"].ToString();
                    quina.ValorGanhadoresQuina_1 = dr["VALOR_GANHADORES_QUINA_1"].ToString();
                    quina.QtdeGanhadoresQuadra_1 = dr["QTD_GANHADORES_QUADRA_1"].ToString();
                    quina.ValorGanhadoresQuadra_1 = dr["VALOR_GANHADORES_QUADRA_1"].ToString();
                    quina.QtdeGanhadoresTerno_1 = dr["QTD_GANHADORES_TERNO_1"].ToString();
                    quina.ValorGanhadoresTerno_1 = dr["VALOR_GANHADORES_TERNO_1"].ToString();
                    quina.QtdeGanhadoresDuque_1 = dr["QTD_GANHADORES_DUQUE_1"].ToString();
                    quina.ValorGanhadoresDuque_1 = dr["VALOR_GANHADORES_DUQUE_1"].ToString();
                    quina.ValorAcumulado_1 = dr["VALOR_ACUMULADO_1"].ToString();
                    quina.NumConcurso_2 = dr["NUM_CONCURSO_2"].ToString();
                    quina.DatConcurso_2 = dr["DAT_CONCURSO_2"].ToString();
                    quina.NumSorteados_2 = dr["NUM_SORTEADOS_2"].ToString();
                    quina.QtdeGanhadoresQuina_2 = dr["QTD_GANHADORES_QUINA_2"].ToString();
                    quina.ValorGanhadoresQuina_2 = dr["VALOR_GANHADORES_QUINA_2"].ToString();
                    quina.QtdeGanhadoresQuadra_2 = dr["QTD_GANHADORES_QUADRA_2"].ToString();
                    quina.ValorGanhadoresQuadra_2 = dr["VALOR_GANHADORES_QUADRA_2"].ToString();
                    quina.QtdeGanhadoresTerno_2 = dr["QTD_GANHADORES_TERNO_2"].ToString();
                    quina.ValorGanhadoresTerno_2 = dr["VALOR_GANHADORES_TERNO_2"].ToString();
                    quina.QtdeGanhadoresDuque_2 = dr["QTD_GANHADORES_DUQUE_2"].ToString();
                    quina.ValorGanhadoresDuque_2 = dr["VALOR_GANHADORES_DUQUE_2"].ToString();
                    quina.ValorAcumulado_2 = dr["VALOR_ACUMULADO_2"].ToString();
                }
                dr.Dispose();
                con.Close();
                return quina;

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
        /// SalvarResultadoQuina
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoQuina(Quina data)
        {
            try
            {
                var sql = @"INSERT INTO RESULTADO_QUINA
                                (
                                    NUM_CONCURSO_1 ,
                                    DAT_CONCURSO_1 ,
                                    NUM_SORTEADOS_1 ,
                                    QTD_GANHADORES_QUINA_1 ,
                                    VALOR_GANHADORES_QUINA_1, 
                                    QTD_GANHADORES_QUADRA_1 ,
                                    VALOR_GANHADORES_QUADRA_1,
                                    QTD_GANHADORES_TERNO_1 ,
                                    VALOR_GANHADORES_TERNO_1, 
                                    QTD_GANHADORES_DUQUE_1 ,
                                    VALOR_GANHADORES_DUQUE_1, 
                                    VALOR_ACUMULADO_1 ,
                                    NUM_CONCURSO_2 ,
                                    DAT_CONCURSO_2 ,
                                    NUM_SORTEADOS_2 ,
                                    QTD_GANHADORES_QUINA_2 ,
                                    VALOR_GANHADORES_QUINA_2, 
                                    QTD_GANHADORES_QUADRA_2 ,
                                    VALOR_GANHADORES_QUADRA_2,
                                    QTD_GANHADORES_TERNO_2 ,
                                    VALOR_GANHADORES_TERNO_2, 
                                    QTD_GANHADORES_DUQUE_2 ,
                                    VALOR_GANHADORES_DUQUE_2, 
                                    VALOR_ACUMULADO_2 
                                ) VALUES 
                                (
                                    '" + data.NumConcurso_1 + @"',
                                    '" + data.DatConcurso_1 + @"',
                                    '" + data.NumSorteados_1 + @"',
                                    '" + data.QtdeGanhadoresQuina_1 + @"',
                                    '" + data.ValorGanhadoresQuina_1.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuadra_1 + @"',
                                    '" + data.ValorGanhadoresQuadra_1.ToString() + @"',
                                    '" + data.QtdeGanhadoresTerno_1 + @"',
                                    '" + data.ValorGanhadoresTerno_1.ToString() + @"',
                                    '" + data.QtdeGanhadoresDuque_1 + @"',
                                    '" + data.ValorGanhadoresDuque_1.ToString() + @"',
                                    '" + data.ValorAcumulado_1.ToString() + @"',
                                    '" + data.NumConcurso_2 + @"',
                                    '" + data.DatConcurso_2 + @"',
                                    '" + data.NumSorteados_2 + @"',
                                    '" + data.QtdeGanhadoresQuina_2 + @"',
                                    '" + data.ValorGanhadoresQuina_2.ToString() + @"',
                                    '" + data.QtdeGanhadoresQuadra_2 + @"',
                                    '" + data.ValorGanhadoresQuadra_2.ToString() + @"',
                                    '" + data.QtdeGanhadoresTerno_2 + @"',
                                    '" + data.ValorGanhadoresTerno_2.ToString() + @"',
                                    '" + data.QtdeGanhadoresDuque_2 + @"',
                                    '" + data.ValorGanhadoresDuque_2.ToString() + @"',
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