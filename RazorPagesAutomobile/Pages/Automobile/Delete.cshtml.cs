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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesAutomobile.Data.RazorPagesAutomobileContext _context;

        public DeleteModel(RazorPagesAutomobile.Data.RazorPagesAutomobileContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobile.FindAsync(id);
            if (automobile != null)
            {
                Automobile = automobile;
                _context.Automobile.Remove(Automobile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
