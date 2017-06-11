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
    public class LlantaConfiguration : EntityTypeConfiguration<Llanta>
    {
        public LlantaConfiguration()
       {
           //Table Configuration
           ToTable("Llantas");
           HasKey(c => c.CodigoLlanta);
            Property(a => a.CodigoLlanta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Relationship Configuration
            HasRequired(c => c.Carro)
               .WithMany(c => c.Llantas);

       }
    }
}
