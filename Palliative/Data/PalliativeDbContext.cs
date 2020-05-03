using Microsoft.EntityFrameworkCore;
using Palliative.Models.Article;
using Palliative.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Palliative.Data
{
    public class PalliativeDbContext : DbContext
    {

        public PalliativeDbContext(DbContextOptions<PalliativeDbContext> options)
: base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Article> Articles { get; set; }
    }
}
