using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uldiario.Models.EntidadesApiLoterias;
using Dapper;
using uldiario.Util;

namespace ULDiario.Data.Repositories
{
    public class DuplaSenaRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        /// <summary>
        /// DuplaSenaRepository
        /// </summary>
        /// <param name="configuration"></param>
        public DuplaSenaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StringSQLServer");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// RecuperarUltimoResultadoDuplaSena
        /// </summary>
        /// <returns></returns>
        public async Task<Jogo> RecuperarUltimoResultadoDuplaSena()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {

                var DuplaSena = await connection.QueryFirstOrDefaultAsync<uldiario.Entidades.DuplaSena>(
                @"
                    SELECT DISTINCT
                         RS.NUM_CONCURSO_1 as NumConcurso1,
	                     RS.DAT_CONCURSO_1 as DataConcurso1,
	                     RS.NUM_SORTEADOS_1 as NumSorteados1,
	                     RS.QTD_GANHADORES_QUINA_1 as QtdeGanhadoresQuina1,
	                     RS.VALOR_GANHADORES_QUINA_1 as ValorGanhadoresQuina1, 
	                     RS.QTD_GANHADORES_QUADRA_1 as QtdeGanhadoresQuadra1,
	                     RS.VALOR_GANHADORES_QUADRA_1 as ValorGanhadoresQuadra1, 
	                     RS.QTD_GANHADORES_TERNO_1 as QtdeGanhadoresTerno1,
	                     RS.VALOR_GANHADORES_TERNO_1 as ValorGanhadoresTerno1, 
	                     RS.VALOR_ACUMULADO_1 as ValorAcumulado1,
	                     RS.NUM_CONCURSO_2 as NumConcurso2,
	                     RS.DAT_CONCURSO_2 as DataConcurso2,
	                     RS.NUM_SORTEADOS_2 as NumSorteados2,
	                     RS.QTD_GANHADORES_QUINA_2 as QtdeGanhadoresQuina2,
	                     RS.VALOR_GANHADORES_QUINA_2 as ValorGanhadoresQuina2, 
	                     RS.QTD_GANHADORES_QUADRA_2 as QtdeGanhadoresQuadra2,
	                     RS.VALOR_GANHADORES_QUADRA_2 as ValorGanhadoresQuadra2, 
	                     RS.QTD_GANHADORES_TERNO_2 as QtdeGanhadoresTerno2,
	                     RS.VALOR_GANHADORES_TERNO_2 as ValorGanhadoresTerno2, 
	                     RS.VALOR_ACUMULADO_2 as ValorAcumulado2
                    FROM 
                         RESULTADO_DUPLASENA RS
                    ORDER BY 1 desc; 
                ");

                if (DuplaSena == null)
                    return null;

                Jogo jogo = new Jogo();
                return jogo;
            }
        }

        /// <summary>
        /// SalvarResultadoDuplaSena
        /// </summary>
        /// <param name="data"></param>
        public async Task<bool> SalvarResultadoDuplaSena(List<Jogo> lista)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"INSERT INTO RESULTADO_DUPLASENA 
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
	                                VALOR_ACUMULADO_2 
                                ) VALUES 
                                (
                                   	@NUM_CONCURSO_1 ,
	                                @DAT_CONCURSO_1 ,
	                                @NUM_SORTEADOS_1 ,
	                                @QTD_GANHADORES_QUINA_1 ,
	                                @VALOR_GANHADORES_QUINA_1, 
	                                @QTD_GANHADORES_QUADRA_1 ,
	                                @VALOR_GANHADORES_QUADRA_1, 
	                                @QTD_GANHADORES_TERNO_1 ,
	                                @VALOR_GANHADORES_TERNO_1, 
	                                @VALOR_ACUMULADO_1 ,
	                                @NUM_CONCURSO_2 ,
	                                @DAT_CONCURSO_2 ,
	                                @NUM_SORTEADOS_2 ,
	                                @QTD_GANHADORES_QUINA_2 ,
	                                @VALOR_GANHADORES_QUINA_2, 
	                                @QTD_GANHADORES_QUADRA_2 ,
	                                @VALOR_GANHADORES_QUADRA_2, 
	                                @QTD_GANHADORES_TERNO_2 ,
	                                @VALOR_GANHADORES_TERNO_2, 
	                                @VALOR_ACUMULADO_2  
                                )";
                    var ultimoConcurso = lista[0];
                    var penultimoConcurso = lista[1];
                    var sena1 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(6)).Select(s => s).FirstOrDefault();
                    var quina1 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(5)).Select(s => s).FirstOrDefault();
                    var quadra1 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(4)).Select(s => s).FirstOrDefault();
                    var terno1 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(3)).Select(s => s).FirstOrDefault();

                    var sena2 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(6)).Select(s => s).FirstOrDefault();
                    var quina2 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(5)).Select(s => s).FirstOrDefault();
                    var quadra2 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(4)).Select(s => s).FirstOrDefault();
                    var terno2 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(3)).Select(s => s).FirstOrDefault();
                    var resultId = await connection.ExecuteAsync(sql, new
                    {
                        NUM_CONCURSO_1 = ultimoConcurso.numero_concurso,
                        DAT_CONCURSO_1 = Convert.ToDateTime(ultimoConcurso.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS_1 = Utils.FormataListaRetornaStringFormatada(ultimoConcurso.dezenas),
                        QTD_GANHADORES_SENA_1 = sena1.quantidade_ganhadores,
                        VALOR_GANHADORES_SENA_1 = sena1.valor_total,
                        QTD_GANHADORES_QUINA_1 = quina1.quantidade_ganhadores,
                        VALOR_GANHADORES_QUINA_1 = quina1.valor_total,
                        QTD_GANHADORES_QUADRA_1 = quadra1.quantidade_ganhadores,
                        VALOR_GANHADORES_QUADRA_1 = quadra1.valor_total,
                        QTD_GANHADORES_TERNO_1 = terno1.quantidade_ganhadores,
                        VALOR_GANHADORES_TERNO_1 = terno1.valor_total,
                        VALOR_ACUMULADO_1 = ultimoConcurso.valor_acumulado,
                        NUM_CONCURSO_2 = penultimoConcurso.numero_concurso,
                        DAT_CONCURSO_2 = Convert.ToDateTime(penultimoConcurso.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS_2 = Utils.FormataListaRetornaStringFormatada(penultimoConcurso.dezenas),
                        QTD_GANHADORES_SENA_2 = sena2.quantidade_ganhadores,
                        VALOR_GANHADORES_SENA_2 = sena2.valor_total,
                        QTD_GANHADORES_QUINA_2 = quina2.quantidade_ganhadores,
                        VALOR_GANHADORES_QUINA_2 = quina2.valor_total,
                        QTD_GANHADORES_QUADRA_2 = quadra2.quantidade_ganhadores,
                        VALOR_GANHADORES_QUADRA_2 = quadra2.valor_total,
                        QTD_GANHADORES_TERNO_2 = terno2.quantidade_ganhadores,
                        VALOR_GANHADORES_TERNO_2 = terno2.valor_total,
                        VALOR_ACUMULADO_2 = penultimoConcurso.valor_acumulado
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
        public async Task<bool> VerificaExistenciaConcurso(List<Jogo> lista)
        {
            foreach (var item in lista)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    var DuplaSena = await connection.QueryFirstOrDefaultAsync<uldiario.Entidades.DuplaSena>(
                       @"SELECT DISTINCT
                         	RS.NUM_CONCURSO_1 as NumConcurso1,
	                        RS.DAT_CONCURSO_1 as DataConcurso1,
	                        RS.NUM_SORTEADOS_1 as NumSorteados1,
	                        RS.QTD_GANHADORES_QUINA_1 as QtdeGanhadoresQuina1,
	                        RS.VALOR_GANHADORES_QUINA_1 as ValorGanhadoresQuina1, 
	                        RS.QTD_GANHADORES_QUADRA_1 as QtdeGanhadoresQuadra1,
	                        RS.VALOR_GANHADORES_QUADRA_1 as ValorGanhadoresQuadra1, 
	                        RS.QTD_GANHADORES_TERNO_1 as QtdeGanhadoresTerno1,
	                        RS.VALOR_GANHADORES_TERNO_1 as ValorGanhadoresTerno1, 
	                        RS.VALOR_ACUMULADO_1 as ValorAcumulado1,
	                        RS.NUM_CONCURSO_2 as NumConcurso2,
	                        RS.DAT_CONCURSO_2 as DataConcurso2,
	                        RS.NUM_SORTEADOS_2 as NumSorteados2,
	                        RS.QTD_GANHADORES_QUINA_2 as QtdeGanhadoresQuina2,
	                        RS.VALOR_GANHADORES_QUINA_2 as ValorGanhadoresQuina2, 
	                        RS.QTD_GANHADORES_QUADRA_2 as QtdeGanhadoresQuadra2,
	                        RS.VALOR_GANHADORES_QUADRA_2 as ValorGanhadoresQuadra2, 
	                        RS.QTD_GANHADORES_TERNO_2 as QtdeGanhadoresTerno2,
	                        RS.VALOR_GANHADORES_TERNO_2 as ValorGanhadoresTerno2, 
	                        RS.VALOR_ACUMULADO_2 as ValorAcumulado2
                       FROM 
                            RESULTADO_DUPLASENA RS
                       WHERE
                            RS.NUM_CONCURSO_1 = " + item.numero_concurso + ";"
                    );

                    if (DuplaSena == null)
                        return true;

                }
            }
            return false;
        }

        #endregion

    }
}