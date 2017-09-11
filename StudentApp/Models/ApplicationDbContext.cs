using System.Data.Entity;

namespace StudentApp.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        public ApplicationDbContext() : base("AppDb") { }
    }
}