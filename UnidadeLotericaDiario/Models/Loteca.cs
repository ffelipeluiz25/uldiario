using System;
using System.Collections.Generic;

namespace UnidadeLotericaDiario.Models
{
    public class Loteca
    {

        public Loteca()
        {
            ListaJogos = new List<JogosLoteca>();
        }
        public string NumConcurso { get; set; }
        public string DatConcurso { get; set; }
        public string QtdeGanhadores15pts { get; set; }
        public string ValorGanhadores15pts { get; set; }
        public string QtdeGanhadores16pts { get; set; }
        public string ValorGanhadores16pts { get; set; }
        public string ValorAcumulado { get; set; }

        public List<JogosLoteca> ListaJogos { get; set; }
    }
}