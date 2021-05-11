using System;

namespace uldiario.Entidades
{
    public class MegaSena
    {
        public int CodResultadoMegaSena { get; set; }
        public int NumConcurso { get; set; }
        public string DataConcurso { get; set; }
        public string NumSorteados { get; set; }
        public int QtdeGanhadoresSena { get; set; }
        public decimal ValorGanhadoresSena { get; set; }
        public int QtdeGanhadoresQuina { get; set; }
        public decimal ValorGanhadoresQuina { get; set; }
        public int QtdeGanhadoresQuadra { get; set; }
        public decimal ValorGanhadoresQuadra { get; set; }
        public decimal ValorAcumulado { get; set; }
    }
}