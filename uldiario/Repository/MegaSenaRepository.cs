using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using uldiario.Entidades;
using uldiario.Models.EntidadesApiLoterias;
using uldiario.Util;
namespace ULDiario.Data.Repositories
{
    public class MegaSenaRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        /// <summary>
        /// MegaSenaRepository
        /// </summary>
        /// <param name="configuration"></param>
        public MegaSenaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// SalvarResultadoMegaSena
        /// </summary>
        /// <param name="data"></param>
        public bool SalvarResultadoMegaSena(Jogo data)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                                    @NUM_CONCURSO,
                                    @DAT_CONCURSO,
                                    @NUM_SORTEADOS,
                                    @QTD_GANHADORES_SENA,
                                    @VALOR_GANHADORES_SENA,
                                    @QTD_GANHADORES_QUINA,
                                    @VALOR_GANHADORES_QUINA,
                                    @QTD_GANHADORES_QUADRA,
                                    @VALOR_GANHADORES_QUADRA,
                                    @VALOR_ACUMULADO
                                )";
                    var sena = data.premiacao.Where(s => s.nome.ToLower().Equals("sena")).Select(s => s).FirstOrDefault();
                    var quadra = data.premiacao.Where(s => s.nome.ToLower().Equals("quadra")).Select(s => s).FirstOrDefault();
                    var quina = data.premiacao.Where(s => s.nome.ToLower().Equals("quina")).Select(s => s).FirstOrDefault();

                    MegaSena obj = new MegaSena();
                    var resultId = connection.Execute(sql, new
                    {
                        NUM_CONCURSO = data.numero_concurso,
                        DAT_CONCURSO = Convert.ToDateTime(data.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS = Utils.FormataListaRetornaStringFormatada(data.dezenas),
                        QTD_GANHADORES_SENA = sena.quantidade_ganhadores,
                        VALOR_GANHADORES_SENA = sena.valor_total,
                        QTD_GANHADORES_QUADRA = quadra.quantidade_ganhadores,
                        VALOR_GANHADORES_QUADRA = quadra.valor_total,
                        QTD_GANHADORES_QUINA = quina.quantidade_ganhadores,
                        VALOR_GANHADORES_QUINA = quina.valor_total,
                        VALOR_ACUMULADO = data.valor_acumulado
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro do ", ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// VerificaExistenciaConcurso
        /// </summary>
        /// <param name="numero_concurso"></param>
        /// <returns></returns>
        public bool VerificaExistenciaConcurso(int numero_concurso)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var megasena = connection.QueryFirstOrDefault<MegaSena>(
                @"
                    SELECT DISTINCT
                          RS.NUM_CONCURSO AS NumConcurso, 
                          RS.DAT_CONCURSO AS DataConcurso,
                          RS.NUM_SORTEADOS AS NumSorteados,
                          RS.QTD_GANHADORES_SENA AS QtdeGanhadoresSena,
                          RS.VALOR_GANHADORES_SENA AS ValorGanhadoresSena,
                          RS.QTD_GANHADORES_QUINA AS QtdeGanhadoresQuina,
                          RS.VALOR_GANHADORES_QUINA AS ValorGanhadoresQuina,
                          RS.QTD_GANHADORES_QUADRA AS QtdeGanhadoresQuadra,
                          RS.VALOR_GANHADORES_QUADRA AS ValorGanhadoresQuadra,
                          RS.VALOR_ACUMULADO AS ValorAcumulado
                    FROM 
                          RESULTADO_MEGASENA RS
                    WHERE
                          RS.NUM_CONCURSO = " + numero_concurso + ";");

                if (megasena == null)
                    return true;
            }

            return false;//nao precisa inserir
        }

        #endregion

    }
}