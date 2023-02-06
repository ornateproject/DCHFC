using Microsoft.EntityFrameworkCore;
using ssc.Controllers;
using ssc.Models;
using static ssc.Models.DeptRegistration;

namespace ssc.Data
{
    public class UserDepartmentDbContext : DbContext
    {
        public UserDepartmentDbContext(DbContextOptions<UserDepartmentDbContext> options) : base(options)
        {

        }
        public DbSet<ministry> ministry_master { get; set; }
    }
}

