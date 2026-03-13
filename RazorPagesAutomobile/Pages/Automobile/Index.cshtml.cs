using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAutomobile.Data;
using RazorPagesAutomobile.Models;

namespace RazorPagesAutomobile.Pages_Automobile
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAutomobile.Data.RazorPagesAutomobileContext _context;

        public IndexModel(RazorPagesAutomobile.Data.RazorPagesAutomobileContext context)
        {
            _context = context;
        }

        public IList<Automobile> Automobile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Automobile = await _context.Automobile.ToListAsync();
        }
    }
}
