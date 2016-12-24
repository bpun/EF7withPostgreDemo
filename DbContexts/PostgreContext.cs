using EF7withPostgreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EF7withPostgreDemo.DbContexts
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons {get;set;}
    }
}
