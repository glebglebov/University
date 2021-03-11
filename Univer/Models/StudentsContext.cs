using Microsoft.EntityFrameworkCore;
using Univer.Models.Entities;

namespace Univer.Models
{
    class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public StudentsContext(DbContextOptions options) : base(options)
        {

        }
    }
}
