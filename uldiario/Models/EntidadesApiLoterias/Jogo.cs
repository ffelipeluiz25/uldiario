using System.Collections.Generic;
namespace uldiario.Models.EntidadesApiLoterias
{
    public class Jogo
    {
        public string nome { get; set; }
        public int numero_concurso { get; set; }
        public string data_concurso { get; set; }
        public string local_realizacao { get; set; }
        public bool rateio_processamento { get; set; }
        public List<Jogos> jogos { get; set; }
        public string nome_time_coracao { get; set; }
        public bool acumulou { get; set; }
        public decimal valor_acumulado { get; set; }
        public List<string> dezenas { get; set; }
        public List<Premiacao> premiacao { get; set; }
        public List<Local> local_ganhadores { get; set; }
        public decimal arrecadacao_total { get; set; }
        public int concurso_proximo { get; set; }
        public string data_proximo_concurso { get; set; }
        public int valor_estimado_proximo_concurso { get; set; }
        public decimal valor_final_concurso_acumulado { get; set; }
        public int numero_final_concurso_acumulado { get; set; }
        public decimal valor_acumulado_especial { get; set; }
        public string nome_acumulado_especial { get; set; }
        public bool concurso_especial { get; set; }
        public string nome_mes_sorte { get; set; }
        public string dezena_mes_sorte { get; set; }

    }

    public class Premiacao
    {
        public string nome { get; set; }
        public int quantidade_ganhadores { get; set; }
        public decimal valor_total { get; set; }
        public int acertos { get; set; }
    }

    public class Local
    {
        public string local { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public int quantidade_ganhadores { get; set; }
        public bool canal_eletronico { get; set; }
    }

    public class Jogos
    {
        public string nome_time1 { get; set; }
        public string nome_time2 { get; set; }
        public int gol_time1 { get; set; }
        public int gol_time2 { get; set; }
        public bool coluna_um { get; set; }
        public bool coluna_dois { get; set; }
        public bool coluna_meio { get; set; }
        public int jogo { get; set; }
    }

}