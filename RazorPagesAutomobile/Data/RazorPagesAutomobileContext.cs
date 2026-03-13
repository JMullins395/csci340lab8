using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAutomobile.Models;

namespace RazorPagesAutomobile.Data
{
    public class RazorPagesAutomobileContext : DbContext
    {
        public RazorPagesAutomobileContext (DbContextOptions<RazorPagesAutomobileContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAutomobile.Models.Automobile> Automobile { get; set; } = default!;
    }
}
