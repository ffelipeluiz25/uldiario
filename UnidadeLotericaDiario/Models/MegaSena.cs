using System;
namespace UnidadeLotericaDiario.Models
{
    public class MegaSena
    {
        public int NumConcurso { get; set; }
        public string DatConcurso { get; set; }
        public string NumSorteados { get; set; }
        public int QtdeGanhadoresSena { get; set; }
        public decimal ValorGanhadoresSena { get; set; }
        public int QtdeGanhadoresQuina { get; set; }
        public decimal ValorGanhadoresQuina { get; set; }
        public int QtdeGanhadoresQuadra { get; set; }
        public decimal ValorGanhadoresQuadra { get; set; }
        public decimal ValorAcumulado { get; set; }


        public string ValorGanhadoresSenaTeste { get; set; }
        public string ValorGanhadoresQuinaTeste { get; set; }
        public string ValorGanhadoresQuadraTeste { get; set; }
        public string ValorAcumuladoTeste { get; set; }

    }
}