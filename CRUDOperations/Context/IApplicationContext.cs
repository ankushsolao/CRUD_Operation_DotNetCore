using CRUDOperations.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CRUDOperations.Context
{
    public interface IApplicationContext
    {
        DbSet<Employee> employee { get; set; }

        void SaveChanges();
    }
}
