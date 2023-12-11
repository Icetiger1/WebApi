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

    }
}
