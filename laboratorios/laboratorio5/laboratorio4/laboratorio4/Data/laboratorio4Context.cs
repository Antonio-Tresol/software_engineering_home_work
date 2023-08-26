using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using laboratorio4.Models;

namespace laboratorio4.Data {
    public class laboratorio4Context : DbContext {
        public laboratorio4Context (DbContextOptions<laboratorio4Context> options)
            : base(options) { }

        public DbSet<Movie> Movie { get; set; } = default!;

        public DbSet<laboratorio4.Models.Song> Song { get; set; } = default!;
    }
}
