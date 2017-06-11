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
    public class ParabrisasConfiguration : EntityTypeConfiguration<Parabrisas>
    {
        public ParabrisasConfiguration()
       {
           //Table Configuration
           ToTable("Parabrisas");
           HasKey(c => c.CodigoParabrisas);
            Property(a => a.CodigoParabrisas)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Relationship Configuration
            HasRequired(c => c.Carro)
                .WithRequiredPrincipal(c => c.Parabrisas);


       }
    }
}
