using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public class Volante
    {
        public int CodigoVolante { set; get; }
        public string NumeroSerie{set;get;}
    
        public Carro Carro { set; get; }
        

    }
}
