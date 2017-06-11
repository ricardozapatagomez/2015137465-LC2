﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using _2015104916.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2015104916.Persistence.EntitiesConfiguration
{
    public class VolanteConfiguration : EntityTypeConfiguration<Volante>
    {
        public VolanteConfiguration()
       {
           //Table Configuration
           ToTable("Volantes");
           HasKey(c => c.CodigoVolante);
            Property(a => a.CodigoVolante)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Relationship Configuration
            HasRequired(c => c.Carro)
               .WithRequiredPrincipal(c => c.Volante);

       }

    }
}
