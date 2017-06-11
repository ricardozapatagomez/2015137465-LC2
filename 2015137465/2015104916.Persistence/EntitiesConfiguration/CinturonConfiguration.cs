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
    public class CinturonConfiguration : EntityTypeConfiguration<Cinturon>
    {
        public CinturonConfiguration()
       {
           //Table Configuration
           ToTable("Cinturones");
           HasKey(c => c.CodigoCinturon);
            Property(a => a.CodigoCinturon)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Relationship Configuration
            HasRequired(c => c.Asiento)
                .WithMany(c => c.Cinturones)
                .HasForeignKey(c => c.CodigoAsiento);



        }
    }
}
