
using Microsoft.EntityFrameworkCore;
using PracticeProjMVC.Models;

namespace PracticeProjMVC.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
    }
}