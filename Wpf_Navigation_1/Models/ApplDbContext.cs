using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Navigation_1.Models
{
    class ApplDbContext : DbContext
    {
        public ApplDbContext() : base("DefaultConnection1")
        {
            if (!Category1s.Any())
            {
                Category1s.Add(new Category1 { Name = "Family" });
                Category1s.Add(new Category1 { Name = "Friends" });
                Category1s.Add(new Category1 { Name = "Co-workers" });
                SaveChanges();
            }
        }
        public DbSet<Contact1> Contact1s { get; set; }
        public DbSet<Category1> Category1s { get; set; }
    }
}
