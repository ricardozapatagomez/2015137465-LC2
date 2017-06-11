using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.Entities
{
    public class Ensambladora
    {

        public List<Carro> Carros { set; get; }
        public int CodigoEsambladora { set; get; }
        public string Nombre { get; set; }
        public void Eliminar(Carro carro)
        {
            Carros.Remove(carro);
        }
        public void Agregar(Carro carro)
        {
            Carros.Add(carro);
        }
        public bool IniciarPersonalizacion(){
            return true;
        }

        public bool FinalizarPersonalizacion(){
            return false;       
        }
        
        public Ensambladora()
        {
            Carros = new List<Carro>();
        }

    }
}

       
