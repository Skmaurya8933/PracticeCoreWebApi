using Microsoft.EntityFrameworkCore;
using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SuperHero> SuperHeros { get; set; }
        public DbSet<SignupDetail> SignupDetails { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
