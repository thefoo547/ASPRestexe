using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIexe.Model;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIexe
{
    public class AppDBContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost;Database=comentario;uid=sa;pwd=123456");
        }
    }
}
