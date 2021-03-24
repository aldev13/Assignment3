//Model Context for Database Set up

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MovieModelDbContext : DbContext
    {
        public MovieModelDbContext (DbContextOptions<MovieModelDbContext> options) : base (options)
        { }

        public DbSet<MovieModel> movies { get; set; }
    }
}
