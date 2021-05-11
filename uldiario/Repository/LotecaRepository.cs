using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using uldiario.Models.EntidadesApiLoterias;

namespace ULDiario.Data.Repositories
{
    public class LotecaRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        /// <summary>
        /// LotecaRepository
        /// </summary>
        /// <param name="configuration"></param>
        public LotecaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StringSQLServer");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// RecuperarUltimoResultadoLoteca
        /// </summary>
        /// <returns></returns>
        public async Task<Jogo> RecuperarUltimoResultadoLoteca()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var loteca = await connection.QueryFirstOrDefaultAsync<uldiario.Entidades.Loteca>(
                @"
                    SELECT DISTINCT
                         	RS.NUM_CONCURSO as NumConcurso,
                            RS.DAT_CONCURSO as DataConcurso,
                            RS.QTD_GANHADORES_13PTS as QtdeGanhadores13pts,
                            RS.QTD_GANHADORES_13PTS as ValorGanhadores13pts,
                            RS.QTD_GANHADORES_14PTS as QtdeGanhadores14pts,
                            RS.VALOR_GANHADORES_14PTS as ValorGanhadores14pts,
                            RS.VALOR_ACUMULADO as ValorAcumulado
                    FROM 
                          RESULTADO_LOTECA RS
                    ORDER BY 1 desc; 
                ");

                if (loteca == null)
                    return null;

                Jogo retorno = new Jogo();
                retorno.numero_concurso = loteca.NumConcurso;
                retorno.data_concurso = loteca.DataConcurso;
                retorno.premiacao = new System.Collections.Generic.List<Premiacao>();
                retorno.valor_acumulado = loteca.ValorAcumulado;
                return retorno;
            }
        }

        /// <summary>
        /// SalvarResultadoLoteca
        /// </summary>
        /// <param name="data"></param>
        public async Task<bool> SalvarResultadoLoteca(Jogo jogo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"INSERT INTO RESULTADO_LOTECA 
                                (
                                    NUM_CONCURSO,
                                    DAT_CONCURSO,
                                    QTD_GANHADORES_13PTS,
                                    VALOR_GANHADORES_13PTS,
                                    QTD_GANHADORES_14PTS,
                                    VALOR_GANHADORES_14PTS,
                                    VALOR_ACUMULADO
                                ) VALUES 
                                (
                                    @NUM_CONCURSO,
                                    @DAT_CONCURSO,
                                    @QTD_GANHADORES_13PTS,
                                    @VALOR_GANHADORES_13PTS,
                                    @QTD_GANHADORES_14PTS,
                                    @VALOR_GANHADORES_14PTS,
                                    @VALOR_ACUMULADO
                                )";

                    var pts13 = jogo.premiacao.Where(s => s.acertos.Equals(13)).Select(s => s).FirstOrDefault();
                    var pts14 = jogo.premiacao.Where(s => s.acertos.Equals(14)).Select(s => s).FirstOrDefault();

                    var resultId = await connection.ExecuteAsync(sql, new
                    {
                        NUM_CONCURSO = jogo.numero_concurso,
                        DAT_CONCURSO = Convert.ToDateTime(jogo.data_concurso).Date.ToShortDateString(),
                        QTD_GANHADORES_13PTS = pts13 != null ? pts13.quantidade_ganhadores : 0,
                        VALOR_GANHADORES_13PTS = pts13 != null ? pts13.valor_total : 0,
                        QTD_GANHADORES_14PTS = pts14 != null ? pts14.quantidade_ganhadores : 0,
                        VALOR_GANHADORES_14PTS = pts14 != null ? pts14.valor_total : 0,
                        VALOR_ACUMULADO = jogo.valor_acumulado
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
        public async Task<bool> VerificaExistenciaConcurso(int numero_concurso)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var Loteca = await connection.QueryFirstOrDefaultAsync<uldiario.Entidades.Loteca>(
                   @"SELECT DISTINCT
                         	RS.NUM_CONCURSO as NumConcurso,
	                        RS.DAT_CONCURSO as DataConcurso,
	                        RS.QTD_GANHADORES_13PTS as QtdeGanhadores13pts,
	                        RS.VALOR_GANHADORES_13PTS as ValorGanhadores13pts,
	                        RS.QTD_GANHADORES_14PTS as QtdeGanhadores14pts,
	                        RS.VALOR_GANHADORES_14PTS as ValorGanhadores14pts, 
	                        RS.VALOR_ACUMULADO as ValorAcumulado
                       FROM 
                            RESULTADO_LOTECA RS
                       WHERE
                            RS.NUM_CONCURSO = " + numero_concurso + ";"
                );

                if (Loteca == null)
                    return true;
            }

            return false;
        }

        #endregion

    }
}