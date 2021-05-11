using System;
namespace uldiario.Entidades
{
    public class DiaDeSorte
    {
        public int CodResultadoMegaSena { get; set; }
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
        public string NumMesSorteado { get; set; }
        public string NumGanhadores { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorAcumulado { get; set; }
    }
}