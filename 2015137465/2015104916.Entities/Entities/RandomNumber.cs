using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public class RandomNumber
    {
        public int Generate()
        {
            Random r= new Random();
            int i = r.Next(11111, 99999);
            return i;
        }
    }
}
