using System;
using System.Collections.Generic;
namespace uldiario.Entidades
{
    public class Loteca
    {
        public int NumConcurso { get; set; }
        public string DataConcurso { get; set; }
        public int QtdeGanhadores13pts { get; set; }
        public decimal ValorGanhadores13pts { get; set; }
        public int QtdeGanhadores14pts { get; set; }
        public decimal ValorGanhadores14pts { get; set; }
        public decimal ValorAcumulado { get; set; }
        public List<JogosLoteca> JogosLoteca { get; set; }
    }
    public class JogosLoteca
    {
        public string NumConcurso { get; set; }
        public int IndFaixa { get; set; }
        public int IndTipoResultado { get; set; }
    }
}