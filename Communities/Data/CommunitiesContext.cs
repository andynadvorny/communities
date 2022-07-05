using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Communities.Models;

namespace Communities.Data
{
    public class CommunitiesContext : DbContext
    {
        public CommunitiesContext (DbContextOptions<CommunitiesContext> options)
            : base(options)
        {
        }

        public DbSet<Communities.Models.User>? User { get; set; }

        public DbSet<Communities.Models.Community>? Community { get; set; }

        public DbSet<Communities.Models.Category>? Category { get; set; }
    }
}
