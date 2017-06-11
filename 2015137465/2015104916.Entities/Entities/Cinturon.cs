using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public class Cinturon
    {
        public int CodigoCinturon { set; get; }
        public string NumeroSerie { set; get; }
        public int Metraje { set; get; }
        public int CodigoAsiento { get; set; }

        public Asiento Asiento { set; get; }
    }
}
