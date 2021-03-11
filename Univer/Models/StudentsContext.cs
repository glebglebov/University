using Microsoft.EntityFrameworkCore;
using Univer.Models.Entities;

namespace Univer.Models
{
    class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Subject> Subject { get; set; }

        public DbSet<Mark> Marks { get; set; }


        public StudentsContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
