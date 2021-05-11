using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using uldiario.Models.EntidadesApiLoterias;
using uldiario.Util;

namespace ULDiario.Data.Repositories
{
    public class DiaDeSorteRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        /// <summary>
        /// DiaDeSorteRepository
        /// </summary>
        /// <param name="configuration"></param>
        public DiaDeSorteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StringSQLServer");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// RecuperarUltimoResultadoDiaDeSorte
        /// </summary>
        /// <returns></returns>
        public async Task<Jogo> RecuperarUltimoResultadoDiaDeSorte()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var DiaDeSorte = await connection.QueryFirstOrDefaultAsync<uldiario.Entidades.DiaDeSorte>(
                @"
                    SELECT DISTINCT
                         	RS.NUM_CONCURSO as NumConcurso,
	                        RS.DAT_CONCURSO as DataConcurso, 
	                        RS.NUM_SORTEADOS as NumSorteados, 
	                        RS.QTD_GANHADORES_7PTS as QtdeGanhadores7pts, 
	                        RS.VALOR_GANHADORES_7PTS as ValorGanhadores7pts, 
	                        RS.QTD_GANHADORES_6PTS as QtdeGanhadores6pts, 
	                        RS.VALOR_GANHADORES_6PTS as ValorGanhadores6pts, 
	                        RS.QTD_GANHADORES_5PTS as QtdeGanhadores5pts, 
	                        RS.VALOR_GANHADORES_5PTS as ValorGanhadores5pts, 
	                        RS.QTD_GANHADORES_4PTS as QtdeGanhadores4pts, 
	                        RS.VALOR_GANHADORES_4PTS as ValorGanhadores4pts, 
	                        RS.NUM_MES_SORTEADO as NumMesSorteado, 
	                        RS.NUM_GANHADORES as NumGanhadores, 
                            RS.VALOR_TOTAL as ValorTotal, 
	                        RS.VALOR_ACUMULADO as ValorAcumulado
                    FROM 
                          RESULTADO_DIADESORTE RS
                    ORDER BY 1 desc; 
                ");

                if (DiaDeSorte == null)
                    return null;

                Jogo jogo = new Jogo();
                return jogo;
            }
        }

        /// <summary>
        /// SalvarResultadoDiaDeSorte
        /// </summary>
        /// <param name="data"></param>
        public async Task<bool> SalvarResultadoDiaDeSorte(Jogo jogo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"INSERT INTO RESULTADO_DIADESORTE 
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
                                   @NUM_CONCURSO,
                                   @DAT_CONCURSO,
                                   @NUM_SORTEADOS,
                                   @QTD_GANHADORES_7PTS,
                                   @VALOR_GANHADORES_7PTS,
                                   @QTD_GANHADORES_6PTS,
                                   @VALOR_GANHADORES_6PTS,
                                   @QTD_GANHADORES_5PTS,
                                   @VALOR_GANHADORES_5PTS,
                                   @QTD_GANHADORES_4PTS,
                                   @VALOR_GANHADORES_4PTS,
                                   @NUM_MES_SORTEADO, 
                                   @NUM_GANHADORES, 
                                   @VALOR_TOTAL, 
                                   @VALOR_ACUMULADO 
                                )";

                    var sete = jogo.premiacao.Where(s => s.acertos.Equals(7)).Select(s => s).FirstOrDefault();
                    var seis = jogo.premiacao.Where(s => s.acertos.Equals(6)).Select(s => s).FirstOrDefault();
                    var cinco = jogo.premiacao.Where(s => s.acertos.Equals(5)).Select(s => s).FirstOrDefault();
                    var quatro = jogo.premiacao.Where(s => s.acertos.Equals(4)).Select(s => s).FirstOrDefault();

                    var obj = jogo.premiacao.Where(s => s.acertos.Equals(1)).Select(s => s).FirstOrDefault();
                    var valor_total = obj.valor_total;
                    var quantidade_ganhadores = obj.quantidade_ganhadores;
                    var resultId = await connection.ExecuteAsync(sql, new
                    {
                        NUM_CONCURSO = jogo.numero_concurso,
                        DAT_CONCURSO = Convert.ToDateTime(jogo.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS = Utils.FormataListaRetornaStringFormatada(jogo.dezenas),
                        QTD_GANHADORES_7PTS = sete.quantidade_ganhadores,
                        VALOR_GANHADORES_7PTS = sete.valor_total,
                        QTD_GANHADORES_6PTS = seis.quantidade_ganhadores,
                        VALOR_GANHADORES_6PTS = seis.valor_total,
                        QTD_GANHADORES_5PTS = cinco.quantidade_ganhadores,
                        VALOR_GANHADORES_5PTS = cinco.valor_total,
                        QTD_GANHADORES_4PTS = quatro.quantidade_ganhadores,
                        VALOR_GANHADORES_4PTS = quatro.valor_total,
                        NUM_MES_SORTEADO = jogo.nome_mes_sorte,
                        NUM_GANHADORES = quantidade_ganhadores,
                        VALOR_TOTAL = valor_total,
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
                var DiaDeSorte = await connection.QueryFirstOrDefaultAsync<uldiario.Entidades.DiaDeSorte>(
                   @"SELECT DISTINCT
                         	RS.NUM_CONCURSO as NumConcurso,
	                        RS.DAT_CONCURSO as DataConcurso, 
	                        RS.NUM_SORTEADOS as NumSorteados, 
	                        RS.QTD_GANHADORES_7PTS as QtdeGanhadores7pts, 
	                        RS.VALOR_GANHADORES_7PTS as ValorGanhadores7pts, 
	                        RS.QTD_GANHADORES_6PTS as QtdeGanhadores6pts, 
	                        RS.VALOR_GANHADORES_6PTS as ValorGanhadores6pts, 
	                        RS.QTD_GANHADORES_5PTS as QtdeGanhadores5pts, 
	                        RS.VALOR_GANHADORES_5PTS as ValorGanhadores5pts, 
	                        RS.QTD_GANHADORES_4PTS as QtdeGanhadores4pts, 
	                        RS.VALOR_GANHADORES_4PTS as ValorGanhadores4pts, 
	                        RS.NUM_MES_SORTEADO as NumMesSorteado, 
	                        RS.NUM_GANHADORES as NumGanhadores, 
                            RS.VALOR_TOTAL as ValorTotal, 
	                        RS.VALOR_ACUMULADO as ValorAcumulado
                       FROM 
                            RESULTADO_DIADESORTE RS
                       WHERE
                            RS.NUM_CONCURSO = " + numero_concurso + ";"
                );

                if (DiaDeSorte == null)
                    return true;

            }

            return false;
        }

        #endregion

    }
}