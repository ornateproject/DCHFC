using Microsoft.EntityFrameworkCore;
using ssc.Controllers;
using ssc.Models;

namespace ssc.Data
{
    public class UserDepartmentDbContext : DbContext
    {
        public UserDepartmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<UserDepartmentController> allvacancy_post { get; set;}
    }
}
