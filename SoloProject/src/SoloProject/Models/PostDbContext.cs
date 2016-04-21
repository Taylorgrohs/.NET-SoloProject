using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoloProject.Models
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SoloProject;integrated security = true");
        }
    }
}
