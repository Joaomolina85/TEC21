using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaCartorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCartorio.Entidades
{
    public class baseContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            try
            {
                var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
            }


        }

        public DbSet<Models.Cadastro> cadastro { get; set; }

    }
}
