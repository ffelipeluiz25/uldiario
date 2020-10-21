using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using UnidadeLotericaDiario.Models;
namespace UnidadeLotericaDiario.Repository
{
    public class UsuarioRepository
    {


        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        public UsuarioRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString; ;
        }

        #endregion


        /// <summary>
        /// RecuperarUltimoResultadoDiaDeSorte
        /// </summary>
        /// <returns></returns>
        public Dictionary<bool,bool> Logar(string login, string senha)
        {
            Dictionary<bool, bool> dic = new Dictionary<bool, bool>();
            try
            {
                String sql = @" SELECT U.IND_ADMINISTRADOR FROM USUARIO U WHERE U.DSC_LOGIN = @login AND U.DSC_SENHA = @senha;";
                MySqlConnection con = new MySqlConnection(_connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@senha", senha);
                con.Open();
                var contador = 0;
                MySqlDataReader dr;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    contador++;
                    bool autenticarAdmin = dr["IND_ADMINISTRADOR"].ToString() == "1";
                    dic.Add(true, autenticarAdmin);
                }
                if(contador.Equals(0))
                    dic.Add(false, false);

                dr.Dispose();
                con.Dispose();
                return dic;
            }
            catch (Exception ex)
            {
                throw ex;
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