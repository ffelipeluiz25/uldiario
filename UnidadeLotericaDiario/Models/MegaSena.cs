using System;
namespace UnidadeLotericaDiario.Models
{
    public class MegaSena
    {
        public int NumConcurso { get; set; }
        public string DatConcurso { get; set; }
        public string NumSorteados { get; set; }
        public string QtdeGanhadoresSena { get; set; }
        public string ValorGanhadoresSena { get; set; }
        public string QtdeGanhadoresQuina { get; set; }
        public string ValorGanhadoresQuina { get; set; }
        public string QtdeGanhadoresQuadra { get; set; }
        public string ValorGanhadoresQuadra { get; set; }
        public string ValorAcumulado { get; set; }
    }
}