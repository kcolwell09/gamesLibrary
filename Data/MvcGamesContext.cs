using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesLibrary.Models;

namespace gamesLibrary.Data
{
    public class MvcGameContext : DbContext
    {
        public MvcGameContext(DbContextOptions<MvcGameContext> options) : base(options)
        {

        }

        public DbSet<Games> Game { get; set; }
    }
}
