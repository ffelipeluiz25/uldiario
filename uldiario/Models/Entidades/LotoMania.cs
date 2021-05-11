using System;

namespace uldiario.Entidades
{
    public class LotoMania
    {
        public int CodResultadoMegaSena { get; set; }
        public int NumConcurso { get; set; }
        public string DataConcurso { get; set; }
        public string NumSorteados { get; set; }
        public int QtdeGanhadores20pts { get; set; }
        public decimal ValorGanhadores20pts { get; set; }
        public int QtdeGanhadores19pts { get; set; }
        public decimal ValorGanhadores19pts { get; set; }
        public int QtdeGanhadores18pts { get; set; }
        public decimal ValorGanhadores18pts { get; set; }
        public int QtdeGanhadores17pts { get; set; }
        public decimal ValorGanhadores17pts { get; set; }
        public int QtdeGanhadores16pts { get; set; }
        public decimal ValorGanhadores16pts { get; set; }
        public int QtdeGanhadores15pts { get; set; }
        public decimal ValorGanhadores15pts { get; set; }
        public int QtdeGanhadores0pts { get; set; }
        public decimal ValorGanhadores0pts { get; set; }
        public decimal ValorAcumulado { get; set; }
    }
}