using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public class Asiento
    {
        public int CodigoAsiento { set; get; }
        public string NumeroSerie{set;get;}

        

        public List<Cinturon> Cinturones { set; get; }
        public int CodigoCarro { set; get; }
        public Carro Carro { set; get; }
        public Asiento(int a,string b,int c)
        {
            CodigoAsiento = a;
            NumeroSerie = b;
            CodigoCarro = c;
        }
        public Asiento()
        {

        }
    }
}
