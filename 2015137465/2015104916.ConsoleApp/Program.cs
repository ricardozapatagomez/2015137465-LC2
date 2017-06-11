using _2015104916.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2015104916.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var ensambladora = new Ensambladora();
            
           
            string opc;
            Console.WriteLine("Desea Iniciar la Personalizacion? Y(Si)/N(No)");
            opc=Console.ReadLine();

            while (true) {

            if (opc.CompareTo("Y") == 0 || opc.CompareTo("y") == 0)
            {
                ensambladora.IniciarPersonalizacion();
                Thread.Sleep(5000);
                ensambladora.FinalizarPersonalizacion();
               break;

            }
            else if (opc.CompareTo("N") == 0 || opc.CompareTo("n") == 0)
            {
                Console.WriteLine("Regrese pronto");
                break;

            }
            else
            {
                Console.WriteLine("Escriba una opcion válida");
               Console.WriteLine("Desea iniciar la personalizacion? Y(Si)/N(No)");
               opc = Console.ReadLine();
            }

           }
        }
    }
}
