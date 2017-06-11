using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015104916.API.DTO
{
    public class CinturonDTO
    {
        public int CodigoCinturon { set; get; }
        public string NumeroSerie { set; get; }
        public int Metraje { set; get; }
        public int CodigoAsiento { get; set; }

        public AsientoDTO Asiento { set; get; }
    }
}