using EstagiosEtec.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EstagiosEtec.AcessoDados
{
    public class vagasContexto : DbContext
    {
        public DbSet<tipoVaga> tipoVagas { get; set; }
        public DbSet<descricaoVaga> descricaoVagas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));
        }

    }
}