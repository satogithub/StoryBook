using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStory.Domain.Entities;
using System.Data.Entity;

namespace UserStory.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
