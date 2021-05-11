using System;

namespace uldiario.Entidades
{
    public class TimeMania
    {
        public int NumConcurso { get; set; }
        public string DataConcurso { get; set; }

        public string NumSorteados { get; set; }
        public int QtdeGanhadores7pts { get; set; }
        public decimal ValorGanhadores7pts { get; set; }
        public int QtdeGanhadores6pts { get; set; }
        public decimal ValorGanhadores6pts { get; set; }
        public int QtdeGanhadores5pts { get; set; }
        public decimal ValorGanhadores5pts { get; set; }
        public int QtdeGanhadores4pts { get; set; }
        public decimal ValorGanhadores4pts { get; set; }
        public int QtdeGanhadores3pts { get; set; }
        public decimal ValorGanhadores3pts { get; set; }
        public int QtdeGanhadoresTimeCoracao { get; set; }
        public decimal ValorGanhadoresTimeCoracao { get; set; }
        public string TimeSorteado { get; set; }
        public decimal ValorAcumulado { get; set; }
    }
}