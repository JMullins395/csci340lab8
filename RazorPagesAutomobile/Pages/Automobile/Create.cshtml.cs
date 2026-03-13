using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAutomobile.Data;
using RazorPagesAutomobile.Models;

namespace RazorPagesAutomobile.Pages_Automobile
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesAutomobile.Data.RazorPagesAutomobileContext _context;

        public CreateModel(RazorPagesAutomobile.Data.RazorPagesAutomobileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Automobile Automobile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Automobile.Add(Automobile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
