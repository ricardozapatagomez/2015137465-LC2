using _2015104916.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015104916.API.DTO
{
    public class PropietarioDTO
    {
        public int CodigoPropietario { set; get; }
        public string Dni { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Licencia { set; get; }
        
    }
}