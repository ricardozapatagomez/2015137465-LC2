using _2015104916.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015104916.API.DTO
{
    public class AutomovilDTO:Carro
    {
        public TipoAuto TipoAuto { get; set; }
    }
}