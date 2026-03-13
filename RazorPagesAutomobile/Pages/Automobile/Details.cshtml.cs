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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesAutomobile.Data.RazorPagesAutomobileContext _context;

        public DetailsModel(RazorPagesAutomobile.Data.RazorPagesAutomobileContext context)
        {
            _context = context;
        }

        public Automobile Automobile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobile.FirstOrDefaultAsync(m => m.Id == id);

            if (automobile is not null)
            {
                Automobile = automobile;

                return Page();
            }

            return NotFound();
        }
    }
}
