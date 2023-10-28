using laboratorio3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio3.Data
{
    public class AsignaturaContext : DbContext
    {
        public DbSet<asignaturas> asignaturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=awita28;Database=lab3;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
