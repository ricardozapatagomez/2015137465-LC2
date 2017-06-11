using _2015104916.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015104916.API.DTO
{
    public class AsientoDTO
    {
        public int CodigoAsiento { set; get; }
        public string NumeroSerie { set; get; }
        
        public int CodigoCarro { set; get; }
        public Carro Carro { set; get; }
        
    }
}