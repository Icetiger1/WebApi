using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClassLibrary
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions op) : base(op)
        {
        }

        public DbSet<UserContact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=app;Username=postgres;Password=12345678;",
                    builder => builder.EnableRetryOnFailure());
            }
        }

    }

}
