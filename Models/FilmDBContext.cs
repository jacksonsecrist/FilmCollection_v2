using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection_v2.Models
{
    public class FilmDBContext : DbContext
    {
        public FilmDBContext (DbContextOptions<FilmDBContext> options) : base(options)
        {

        }

        public DbSet<Film> Films { get; set; }
    }
}
