using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uldiario.Entidades;
using uldiario.Models.EntidadesApiLoterias;
using uldiario.Util;

namespace ULDiario.Data.Repositories
{
    public class LotoFacilRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        /// <summary>
        /// LotomaniaRepository
        /// </summary>
        /// <param name="configuration"></param>
        public LotoFacilRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StringSQLServer");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// RecuperarUltimoResultadoLotoFacil
        /// </summary>
        /// <returns></returns>
        public async Task<Jogo> RecuperarUltimoResultadoLotoFacil()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var lotofacil = await connection.QueryFirstOrDefaultAsync<LotoFacil>(
                @"
                    SELECT DISTINCT
                         	RS.NUM_CONCURSO_1 as NumConcurso1, 
	                        RS.DAT_CONCURSO_1 as DataConcurso1, 
	                        RS.NUM_SORTEADOS_1 as NumSorteados1, 
	                        RS.QTD_GANHADORES_1_15PTS as QtdeGanhadores1_15pts, 
	                        RS.VALOR_GANHADORES_1_15PTS as ValorGanhadores1_15pts, 
	                        RS.QTD_GANHADORES_1_14PTS as QtdeGanhadores1_14pts,  
	                        RS.VALOR_GANHADORES_1_14PTS as ValorGanhadores1_14pts, 
	                        RS.QTD_GANHADORES_1_13PTS as QtdeGanhadores1_13pts,  
	                        RS.VALOR_GANHADORES_1_13PTS as ValorGanhadores1_13pts, 
	                        RS.QTD_GANHADORES_1_12PTS as QtdeGanhadores1_12pts,  
	                        RS.VALOR_GANHADORES_1_12PTS as ValorGanhadores1_12pts, 
	                        RS.QTD_GANHADORES_1_11PTS as QtdeGanhadores1_11pts,  
	                        RS.VALOR_GANHADORES_1_11PTS as ValorGanhadores1_11pts,
	                        RS.VALOR_ACUMULADO_1 as ValorAcumulado1, 
	                       	RS.NUM_CONCURSO_2 as NumConcurso2, 
	                        RS.DAT_CONCURSO_2 as DataConcurso2, 
	                        RS.NUM_SORTEADOS_2 as NumSorteados2, 
	                        RS.QTD_GANHADORES_2_15PTS as QtdeGanhadores2_15pts, 
	                        RS.VALOR_GANHADORES_2_15PTS as ValorGanhadores2_15pts, 
	                        RS.QTD_GANHADORES_2_14PTS as QtdeGanhadores2_14pts,  
	                        RS.VALOR_GANHADORES_2_14PTS as ValorGanhadores2_14pts, 
	                        RS.QTD_GANHADORES_2_13PTS as QtdeGanhadores2_13pts,  
	                        RS.VALOR_GANHADORES_2_13PTS as ValorGanhadores2_13pts, 
	                        RS.QTD_GANHADORES_2_12PTS as QtdeGanhadores2_12pts,  
	                        RS.VALOR_GANHADORES_2_12PTS as ValorGanhadores2_12pts, 
	                        RS.QTD_GANHADORES_2_11PTS as QtdeGanhadores2_11pts,  
	                        RS.VALOR_GANHADORES_2_11PTS as ValorGanhadores2_11pts,
	                        RS.VALOR_ACUMULADO_2 as ValorAcumulado2
                    FROM 
                          RESULTADO_LOTOFACIL RS
                    ORDER BY 1 desc; 
                ");

                if (lotofacil == null)
                    return null;

                Jogo jogo = new Jogo();
                jogo.numero_concurso = lotofacil.NumConcurso1;
                jogo.data_concurso = lotofacil.DataConcurso1;
                jogo.dezenas = new System.Collections.Generic.List<string>();
                jogo.dezenas.AddRange(lotofacil.NumSorteados1.Split(','));
                jogo.premiacao = new System.Collections.Generic.List<Premiacao>();
                ///////////////////////////15 acertos/////////////////////////////////////
                Premiacao premio15 = new Premiacao();
                premio15.nome = "15 Acertos";
                premio15.quantidade_ganhadores = lotofacil.QtdeGanhadores1_15pts;
                premio15.valor_total = lotofacil.ValorGanhadores1_15pts;
                jogo.premiacao.Add(premio15);
                ///////////////////////////15 acertos//////////////////////////////////////
                ///////////////////////////14 acertos/////////////////////////////////////
                Premiacao premio14 = new Premiacao();
                premio14.nome = "14 Acertos";
                premio14.quantidade_ganhadores = lotofacil.QtdeGanhadores1_14pts;
                premio14.valor_total = lotofacil.ValorGanhadores1_14pts;
                jogo.premiacao.Add(premio14);
                ///////////////////////////14 acertos//////////////////////////////////////
                ///////////////////////////13 acertos/////////////////////////////////////
                Premiacao premio13 = new Premiacao();
                premio13.nome = "13 Acertos";
                premio13.quantidade_ganhadores = lotofacil.QtdeGanhadores1_13pts;
                premio13.valor_total = lotofacil.ValorGanhadores1_13pts;
                jogo.premiacao.Add(premio13);
                ///////////////////////////13 acertos//////////////////////////////////////
                ///////////////////////////12 acertos/////////////////////////////////////
                Premiacao premio12 = new Premiacao();
                premio12.nome = "12 Acertos";
                premio12.quantidade_ganhadores = lotofacil.QtdeGanhadores1_12pts;
                premio12.valor_total = lotofacil.ValorGanhadores1_12pts;
                jogo.premiacao.Add(premio12);
                ///////////////////////////12 acertos//////////////////////////////////////
                ///////////////////////////11 acertos/////////////////////////////////////
                Premiacao premio11 = new Premiacao();
                premio11.nome = "11 Acertos";
                premio11.quantidade_ganhadores = lotofacil.QtdeGanhadores1_11pts;
                premio11.valor_total = lotofacil.ValorGanhadores1_11pts;
                jogo.premiacao.Add(premio11);
                ///////////////////////////11 acertos//////////////////////////////////////
                jogo.valor_acumulado = lotofacil.ValorAcumulado1;
                return jogo;
            }
        }

        /// <summary>
        /// SalvarResultadoLotoFacil
        /// </summary>
        /// <param name="data"></param>
        public async Task<bool> SalvarResultadoLotoFacil(List<Jogo> lista)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"INSERT INTO RESULTADO_LOTOFACIL 
                                (
                                   	NUM_CONCURSO_1, 
	                                DAT_CONCURSO_1, 
	                                NUM_SORTEADOS_1, 
	                                QTD_GANHADORES_1_15PTS, 
	                                VALOR_GANHADORES_1_15PTS, 
	                                QTD_GANHADORES_1_14PTS, 
	                                VALOR_GANHADORES_1_14PTS, 
	                                QTD_GANHADORES_1_13PTS, 
	                                VALOR_GANHADORES_1_13PTS, 
	                                QTD_GANHADORES_1_12PTS, 
	                                VALOR_GANHADORES_1_12PTS, 
	                                QTD_GANHADORES_1_11PTS, 
	                                VALOR_GANHADORES_1_11PTS,
	                                VALOR_ACUMULADO_1, 
	                                NUM_CONCURSO_2, 
	                                DAT_CONCURSO_2, 
	                                NUM_SORTEADOS_2, 
	                                QTD_GANHADORES_2_15PTS, 
	                                VALOR_GANHADORES_2_15PTS, 
	                                QTD_GANHADORES_2_14PTS, 
	                                VALOR_GANHADORES_2_14PTS, 
	                                QTD_GANHADORES_2_13PTS, 
	                                VALOR_GANHADORES_2_13PTS, 
	                                QTD_GANHADORES_2_12PTS, 
	                                VALOR_GANHADORES_2_12PTS, 
	                                QTD_GANHADORES_2_11PTS, 
	                                VALOR_GANHADORES_2_11PTS, 
	                                VALOR_ACUMULADO_2 
                                ) VALUES 
                                (
                                   	@NUM_CONCURSO_1, 
	                                @DAT_CONCURSO_1, 
	                                @NUM_SORTEADOS_1, 
	                                @QTD_GANHADORES_1_15PTS, 
	                                @VALOR_GANHADORES_1_15PTS, 
	                                @QTD_GANHADORES_1_14PTS, 
	                                @VALOR_GANHADORES_1_14PTS, 
	                                @QTD_GANHADORES_1_13PTS, 
	                                @VALOR_GANHADORES_1_13PTS, 
	                                @QTD_GANHADORES_1_12PTS, 
	                                @VALOR_GANHADORES_1_12PTS, 
	                                @QTD_GANHADORES_1_11PTS, 
	                                @VALOR_GANHADORES_1_11PTS,
	                                @VALOR_ACUMULADO_1, 
	                                @NUM_CONCURSO_2, 
	                                @DAT_CONCURSO_2, 
	                                @NUM_SORTEADOS_2, 
	                                @QTD_GANHADORES_2_15PTS, 
	                                @VALOR_GANHADORES_2_15PTS, 
	                                @QTD_GANHADORES_2_14PTS, 
	                                @VALOR_GANHADORES_2_14PTS, 
	                                @QTD_GANHADORES_2_13PTS, 
	                                @VALOR_GANHADORES_2_13PTS, 
	                                @QTD_GANHADORES_2_12PTS, 
	                                @VALOR_GANHADORES_2_12PTS, 
	                                @QTD_GANHADORES_2_11PTS, 
	                                @VALOR_GANHADORES_2_11PTS, 
	                                @VALOR_ACUMULADO_2 
                                )";

                    var ultimoConcurso = lista[0];
                    var penultimoConcurso = lista[1];
                    var pts1_15 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(15)).Select(s => s).FirstOrDefault();
                    var pts1_14 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(14)).Select(s => s).FirstOrDefault();
                    var pts1_13 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(13)).Select(s => s).FirstOrDefault();
                    var pts1_12 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(12)).Select(s => s).FirstOrDefault();
                    var pts1_11 = ultimoConcurso.premiacao.Where(s => s.acertos.Equals(11)).Select(s => s).FirstOrDefault();


                    var pts2_15 = penultimoConcurso.premiacao.Where(s => s.acertos.Equals(15)).Select(s => s).FirstOrDefault();
                    var pts2_14 = penultimoConcurso.premiacao.Where(s => s.acertos.Equals(14)).Select(s => s).FirstOrDefault();
                    var pts2_13 = penultimoConcurso.premiacao.Where(s => s.acertos.Equals(13)).Select(s => s).FirstOrDefault();
                    var pts2_12 = penultimoConcurso.premiacao.Where(s => s.acertos.Equals(12)).Select(s => s).FirstOrDefault();
                    var pts2_11 = penultimoConcurso.premiacao.Where(s => s.acertos.Equals(11)).Select(s => s).FirstOrDefault();

                    var resultId = await connection.ExecuteAsync(sql, new
                    {
                        NUM_CONCURSO_1 = ultimoConcurso.numero_concurso,
                        DAT_CONCURSO_1 = Convert.ToDateTime(ultimoConcurso.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS_1 = Utils.FormataListaRetornaStringFormatada(ultimoConcurso.dezenas),
                        QTD_GANHADORES_1_15PTS = pts1_15.quantidade_ganhadores,
                        VALOR_GANHADORES_1_15PTS = pts1_15.valor_total,
                        QTD_GANHADORES_1_14PTS = pts1_14.quantidade_ganhadores,
                        VALOR_GANHADORES_1_14PTS = pts1_14.valor_total,
                        QTD_GANHADORES_1_13PTS = pts1_13.quantidade_ganhadores,
                        VALOR_GANHADORES_1_13PTS = pts1_13.valor_total,
                        QTD_GANHADORES_1_12PTS = pts1_12.quantidade_ganhadores,
                        VALOR_GANHADORES_1_12PTS = pts1_12.valor_total,
                        QTD_GANHADORES_1_11PTS = pts1_11.quantidade_ganhadores,
                        VALOR_GANHADORES_1_11PTS = pts1_11.valor_total,
                        VALOR_ACUMULADO_1 = ultimoConcurso.valor_acumulado,
                        NUM_CONCURSO_2 = penultimoConcurso.numero_concurso,
                        DAT_CONCURSO_2 = Convert.ToDateTime(penultimoConcurso.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS_2 = Utils.FormataListaRetornaStringFormatada(penultimoConcurso.dezenas),
                        QTD_GANHADORES_2_15PTS = pts1_15.quantidade_ganhadores,
                        VALOR_GANHADORES_2_15PTS = pts1_15.valor_total,
                        QTD_GANHADORES_2_14PTS = pts2_14.quantidade_ganhadores,
                        VALOR_GANHADORES_2_14PTS = pts2_14.valor_total,
                        QTD_GANHADORES_2_13PTS = pts2_13.quantidade_ganhadores,
                        VALOR_GANHADORES_2_13PTS = pts2_13.valor_total,
                        QTD_GANHADORES_2_12PTS = pts2_12.quantidade_ganhadores,
                        VALOR_GANHADORES_2_12PTS = pts2_12.valor_total,
                        QTD_GANHADORES_2_11PTS = pts2_11.quantidade_ganhadores,
                        VALOR_GANHADORES_2_11PTS = pts2_11.valor_total,
                        VALOR_ACUMULADO_2 = penultimoConcurso.valor_acumulado
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro do ", ex.Message);
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
                    var lotofacil = await connection.QueryFirstOrDefaultAsync<LotoFacil>(
                       @"SELECT DISTINCT
                         	RS.NUM_CONCURSO_1 as NumConcurso1, 
	                        RS.DAT_CONCURSO_1 as DataConcurso1, 
	                        RS.NUM_SORTEADOS_1 as NumSorteados1, 
	                        RS.QTD_GANHADORES_1_15PTS as QtdeGanhadores1_15pts, 
	                        RS.VALOR_GANHADORES_1_15PTS as ValorGanhadores1_15pts, 
	                        RS.QTD_GANHADORES_1_14PTS as QtdeGanhadores1_14pts,  
	                        RS.VALOR_GANHADORES_1_14PTS as ValorGanhadores1_14pts, 
	                        RS.QTD_GANHADORES_1_13PTS as QtdeGanhadores1_13pts,  
	                        RS.VALOR_GANHADORES_1_13PTS as ValorGanhadores1_13pts, 
	                        RS.QTD_GANHADORES_1_12PTS as QtdeGanhadores1_12pts,  
	                        RS.VALOR_GANHADORES_1_12PTS as ValorGanhadores1_12pts, 
	                        RS.QTD_GANHADORES_1_11PTS as QtdeGanhadores1_11pts,  
	                        RS.VALOR_GANHADORES_1_11PTS as ValorGanhadores1_11pts,
	                        RS.VALOR_ACUMULADO_1 as ValorAcumulado1, 
	                       	RS.NUM_CONCURSO_2 as NumConcurso2, 
	                        RS.DAT_CONCURSO_2 as DataConcurso2, 
	                        RS.NUM_SORTEADOS_2 as NumSorteados2, 
	                        RS.QTD_GANHADORES_2_15PTS as QtdeGanhadores2_15pts, 
	                        RS.VALOR_GANHADORES_2_15PTS as ValorGanhadores2_15pts, 
	                        RS.QTD_GANHADORES_2_14PTS as QtdeGanhadores2_14pts,  
	                        RS.VALOR_GANHADORES_2_14PTS as ValorGanhadores2_14pts, 
	                        RS.QTD_GANHADORES_2_13PTS as QtdeGanhadores2_13pts,  
	                        RS.VALOR_GANHADORES_2_13PTS as ValorGanhadores2_13pts, 
	                        RS.QTD_GANHADORES_2_12PTS as QtdeGanhadores2_12pts,  
	                        RS.VALOR_GANHADORES_2_12PTS as ValorGanhadores2_12pts, 
	                        RS.QTD_GANHADORES_2_11PTS as QtdeGanhadores2_11pts,  
	                        RS.VALOR_GANHADORES_2_11PTS as ValorGanhadores2_11pts,
	                        RS.VALOR_ACUMULADO_2 as ValorAcumulado2
                    FROM 
                            RESULTADO_LOTOFACIL RS
                    WHERE
                            RS.NUM_CONCURSO_1 = " + item.numero_concurso + ";"
                    );

                    if (lotofacil == null)
                        return true;
                }
            }

            return false;//nao precisa inserir
        }

        #endregion

    }
}