using CRUDOperations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperations.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Employee> employee { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public void SaveChanges()
        {
            base.SaveChanges();
        }

    }
}
