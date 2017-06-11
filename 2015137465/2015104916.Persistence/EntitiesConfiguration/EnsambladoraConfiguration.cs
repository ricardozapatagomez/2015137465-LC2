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
    public class EnsambladoraConfiguration : EntityTypeConfiguration<Ensambladora>
    {
        public EnsambladoraConfiguration()
       {
           //Table Configuration
           ToTable("Ensambladoras");
           HasKey(a => a.CodigoEsambladora);
            Property(a => a.CodigoEsambladora)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(c => c.Carros)
                 .WithRequired(c => c.Ensambladora);



       }
    }
}
