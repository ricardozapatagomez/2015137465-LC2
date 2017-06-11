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
    public class AsientoConfiguration : EntityTypeConfiguration<Asiento>
    {
        public AsientoConfiguration()
       {
           //Table Configuration
           ToTable("Asientos");
            HasKey(t => t.CodigoAsiento);
            Property(a => a.CodigoAsiento)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relationship Configuration
            HasRequired(c => c.Carro)
                .WithMany(c => c.Asientos)
                .HasForeignKey(c => c.CodigoCarro);
            

        }
    }
}
