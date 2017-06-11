using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using _2015104916.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2015104916.Persistence.EntitiesConfiguration
{
    public class CarroConfiguration : EntityTypeConfiguration<Carro>
    {
        public CarroConfiguration()
       {
           //Table Configuration
           ToTable("Carros");
           HasKey(c => c.CodigoCarro);
           
            //Relationship Configuration
            Map<Bus>(m => m.Requires("Discriminator").HasValue("Bus"));
            Map<Automovil>(m => m.Requires("Discriminator").HasValue("Automovil"));

        }
    }
}
