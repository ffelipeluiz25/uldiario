using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using uldiario.Entidades;
using uldiario.Models.EntidadesApiLoterias;
using uldiario.Util;

namespace ULDiario.Data.Repositories
{
    public class LotoManiaRepository
    {

        #region Atributos

        string _connectionString;

        #endregion

        #region Construtor

        /// <summary>
        /// LotomaniaRepository
        /// </summary>
        /// <param name="configuration"></param>
        public LotoManiaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StringSQLServer");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// RecuperarUltimoResultadoLotoMania
        /// </summary>
        /// <returns></returns>
        public async Task<Jogo> RecuperarUltimoResultadoLotoMania()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var lotamania = await connection.QueryFirstOrDefaultAsync<LotoMania>(
                @"
                    SELECT DISTINCT
                          RS.NUM_CONCURSO AS NumConcurso, 
                          RS.DAT_CONCURSO AS DataConcurso,
                          RS.NUM_SORTEADOS AS NumSorteados,
                          RS.QTD_GANHADORES_20PTS AS QtdeGanhadores20pts,
                          RS.VALOR_GANHADORES_20PTS AS ValorGanhadores20pts,
                          RS.QTD_GANHADORES_19PTS AS QtdeGanhadores20pts,
                          RS.VALOR_GANHADORES_19PTS AS ValorGanhadores19pts,
                          RS.QTD_GANHADORES_18PTS AS QtdeGanhadores18pts,
                          RS.VALOR_GANHADORES_18PTS AS ValorGanhadores18pts,
                          RS.QTD_GANHADORES_17PTS AS QtdeGanhadores17pts,
                          RS.VALOR_GANHADORES_17PTS AS ValorGanhadores17pts,
                          RS.QTD_GANHADORES_16PTS AS QtdeGanhadores16pts,
                          RS.VALOR_GANHADORES_16PTS AS ValorGanhadores16pts,
                          RS.QTD_GANHADORES_15PTS AS QtdeGanhadores20pts,
                          RS.VALOR_GANHADORES_15PTS AS ValorGanhadores15pts,
                          RS.QTD_GANHADORES_0PTS AS QtdeGanhadores0pts,
                          RS.VALOR_GANHADORES_0PTS AS ValorGanhadores0pts,
                          RS.VALOR_ACUMULADO AS ValorAcumulado
                    FROM 
                          RESULTADO_LOTOMANIA RS
                    ORDER BY 1 desc; 
                ");

                if (lotamania == null)
                    return null;

                Jogo retorno = new Jogo();
                retorno.numero_concurso = lotamania.NumConcurso;
                retorno.data_concurso = lotamania.DataConcurso;
                retorno.dezenas = new System.Collections.Generic.List<string>();
                retorno.dezenas.AddRange(lotamania.NumSorteados.Split(','));
                retorno.premiacao = new System.Collections.Generic.List<Premiacao>();
                ///////////////////////////20pts/////////////////////////////////////
                Premiacao premio20 = new Premiacao();
                premio20.nome = "20 Acertos";
                premio20.acertos = 20;
                premio20.quantidade_ganhadores = lotamania.QtdeGanhadores20pts;
                premio20.valor_total = lotamania.ValorGanhadores20pts;
                retorno.premiacao.Add(premio20);
                ///////////////////////////20pts//////////////////////////////////////
                ///////////////////////////19pts/////////////////////////////////////
                Premiacao premio19 = new Premiacao();
                premio19.nome = "19 Acertos";
                premio19.acertos = 19;
                premio19.quantidade_ganhadores = lotamania.QtdeGanhadores19pts;
                premio19.valor_total = lotamania.ValorGanhadores19pts;
                retorno.premiacao.Add(premio19);
                ///////////////////////////19pts/////////////////////////////////////
                ///////////////////////////18pts////////////////////////////////////
                Premiacao premio18 = new Premiacao();
                premio18.nome = "18 Acertos";
                premio18.acertos = 18;
                premio18.quantidade_ganhadores = lotamania.QtdeGanhadores18pts;
                premio18.valor_total = lotamania.ValorGanhadores18pts;
                retorno.premiacao.Add(premio18);
                ///////////////////////////18pts////////////////////////////////////
                ///////////////////////////17pts////////////////////////////////////
                Premiacao premio17 = new Premiacao();
                premio17.nome = "17 Acertos";
                premio17.acertos = 17;
                premio17.quantidade_ganhadores = lotamania.QtdeGanhadores18pts;
                premio17.valor_total = lotamania.ValorGanhadores18pts;
                retorno.premiacao.Add(premio17);
                ///////////////////////////17pts////////////////////////////////////
                ///////////////////////////16pts////////////////////////////////////
                Premiacao premio16 = new Premiacao();
                premio16.nome = "16 Acertos";
                premio16.acertos = 16;
                premio16.quantidade_ganhadores = lotamania.QtdeGanhadores18pts;
                premio16.valor_total = lotamania.ValorGanhadores18pts;
                retorno.premiacao.Add(premio16);
                ///////////////////////////16pts////////////////////////////////////
                ///////////////////////////15pts////////////////////////////////////
                Premiacao premio15 = new Premiacao();
                premio15.nome = "15 Acertos";
                premio15.acertos = 15;
                premio15.quantidade_ganhadores = lotamania.QtdeGanhadores18pts;
                premio15.valor_total = lotamania.ValorGanhadores18pts;
                retorno.premiacao.Add(premio15);
                ///////////////////////////15pts////////////////////////////////////
                ///////////////////////////0pts////////////////////////////////////
                Premiacao premio0 = new Premiacao();
                premio0.nome = "0 Acertos";
                premio0.acertos = 0;
                premio0.quantidade_ganhadores = lotamania.QtdeGanhadores18pts;
                premio0.valor_total = lotamania.ValorGanhadores18pts;
                retorno.premiacao.Add(premio0);
                ///////////////////////////0pts////////////////////////////////////
                retorno.valor_acumulado = lotamania.ValorAcumulado;
                return retorno;
            }
        }

        /// <summary>
        /// SalvarResultadoLotoMania
        /// </summary>
        /// <param name="data"></param>
        public async Task<bool> SalvarResultadoLotoMania(Jogo data)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"INSERT INTO RESULTADO_LOTOMANIA 
                                (
                                    NUM_CONCURSO, 
                                    DAT_CONCURSO, 
                                    NUM_SORTEADOS, 
                                    QTD_GANHADORES_20PTS, 
                                    VALOR_GANHADORES_20PTS, 
                                    QTD_GANHADORES_19PTS, 
                                    VALOR_GANHADORES_19PTS, 
                                    QTD_GANHADORES_18PTS, 
                                    VALOR_GANHADORES_18PTS, 
                                    QTD_GANHADORES_17PTS, 
                                    VALOR_GANHADORES_17PTS, 
                                    QTD_GANHADORES_16PTS, 
                                    VALOR_GANHADORES_16PTS, 
                                    QTD_GANHADORES_15PTS, 
                                    VALOR_GANHADORES_15PTS, 
                                    QTD_GANHADORES_0PTS, 
                                    VALOR_GANHADORES_0PTS, 
                                    VALOR_ACUMULADO 
                                ) VALUES 
                                (
                                    @NUM_CONCURSO, 
                                    @DAT_CONCURSO, 
                                    @NUM_SORTEADOS, 
                                    @QTD_GANHADORES_20PTS, 
                                    @VALOR_GANHADORES_20PTS, 
                                    @QTD_GANHADORES_19PTS, 
                                    @VALOR_GANHADORES_19PTS, 
                                    @QTD_GANHADORES_18PTS, 
                                    @VALOR_GANHADORES_18PTS, 
                                    @QTD_GANHADORES_17PTS, 
                                    @VALOR_GANHADORES_17PTS, 
                                    @QTD_GANHADORES_16PTS, 
                                    @VALOR_GANHADORES_16PTS, 
                                    @QTD_GANHADORES_15PTS, 
                                    @VALOR_GANHADORES_15PTS, 
                                    @QTD_GANHADORES_0PTS, 
                                    @VALOR_GANHADORES_0PTS, 
                                    @VALOR_ACUMULADO
                                )";
                    var Vintepts = data.premiacao.Where(s => s.nome.ToLower().Contains("20")).Select(s => s).FirstOrDefault();
                    var Dezenovepts = data.premiacao.Where(s => s.nome.ToLower().Contains("19")).Select(s => s).FirstOrDefault();
                    var Dezoitepts = data.premiacao.Where(s => s.nome.ToLower().Contains("18")).Select(s => s).FirstOrDefault();
                    var Dezesetepts = data.premiacao.Where(s => s.nome.ToLower().Contains("17")).Select(s => s).FirstOrDefault();
                    var Dezeseispts = data.premiacao.Where(s => s.nome.ToLower().Contains("16")).Select(s => s).FirstOrDefault();
                    var Quinzepts = data.premiacao.Where(s => s.nome.ToLower().Contains("15")).Select(s => s).FirstOrDefault();
                    var Zeropts = data.premiacao.Where(s => s.acertos.Equals(0)).Select(s => s).FirstOrDefault();

                    var resultId = await connection.ExecuteAsync(sql, new
                    {
                        NUM_CONCURSO = data.numero_concurso,
                        DAT_CONCURSO = Convert.ToDateTime(data.data_concurso).Date.ToShortDateString(),
                        NUM_SORTEADOS = Utils.FormataListaRetornaStringFormatada(data.dezenas),
                        QTD_GANHADORES_20PTS = Vintepts.quantidade_ganhadores,
                        VALOR_GANHADORES_20PTS = Vintepts.valor_total,
                        QTD_GANHADORES_19PTS = Dezenovepts.quantidade_ganhadores,
                        VALOR_GANHADORES_19PTS = Dezenovepts.valor_total,
                        QTD_GANHADORES_18PTS = Dezoitepts.quantidade_ganhadores,
                        VALOR_GANHADORES_18PTS = Dezoitepts.valor_total,
                        QTD_GANHADORES_17PTS = Dezesetepts.quantidade_ganhadores,
                        VALOR_GANHADORES_17PTS = Dezesetepts.valor_total,
                        QTD_GANHADORES_16PTS = Dezeseispts.quantidade_ganhadores,
                        VALOR_GANHADORES_16PTS = Dezeseispts.valor_total,
                        QTD_GANHADORES_15PTS = Quinzepts.quantidade_ganhadores,
                        VALOR_GANHADORES_15PTS = Quinzepts.valor_total,
                        QTD_GANHADORES_0PTS = Zeropts.quantidade_ganhadores,
                        VALOR_GANHADORES_0PTS = Zeropts.valor_total,
                        VALOR_ACUMULADO = data.valor_acumulado
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
        /// 
        /// </summary>
        /// <param name="numero_concurso"></param>
        /// <returns></returns>
        public async Task<bool> VerificaExistenciaConcurso(int numero_concurso)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var lotamania = await connection.QueryFirstOrDefaultAsync<LotoMania>(
                @"
                    SELECT DISTINCT
                          RS.NUM_CONCURSO AS NumConcurso, 
                          RS.DAT_CONCURSO AS DataConcurso,
                          RS.NUM_SORTEADOS AS NumSorteados,
                          RS.QTD_GANHADORES_20PTS AS QtdeGanhadores20pts,
                          RS.VALOR_GANHADORES_20PTS AS ValorGanhadores20pts,
                          RS.QTD_GANHADORES_19PTS AS QtdeGanhadores20pts,
                          RS.VALOR_GANHADORES_19PTS AS ValorGanhadores19pts,
                          RS.QTD_GANHADORES_18PTS AS QtdeGanhadores18pts,
                          RS.VALOR_GANHADORES_18PTS AS ValorGanhadores18pts,
                          RS.QTD_GANHADORES_17PTS AS QtdeGanhadores17pts,
                          RS.VALOR_GANHADORES_17PTS AS ValorGanhadores17pts,
                          RS.QTD_GANHADORES_16PTS AS QtdeGanhadores16pts,
                          RS.VALOR_GANHADORES_16PTS AS ValorGanhadores16pts,
                          RS.QTD_GANHADORES_15PTS AS QtdeGanhadores20pts,
                          RS.VALOR_GANHADORES_15PTS AS ValorGanhadores15pts,
                          RS.QTD_GANHADORES_0PTS AS QtdeGanhadores0pts,
                          RS.VALOR_GANHADORES_0PTS AS ValorGanhadores0pts,
                          RS.VALOR_ACUMULADO AS ValorAcumulado
                    FROM 
                          RESULTADO_LOTOMANIA RS
                    WHERE    
                          RS.NUM_CONCURSO = " + numero_concurso + ";"
                );
                if (lotamania == null)
                    return true;
            }

            return false;//nao precisa inserir
        }

        #endregion

    }
}