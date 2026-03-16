using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAutomobile.Data;
using RazorPagesAutomobile.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Make { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AutomobileMake { get; set; }

        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> makeQuery = from a in _context.Automobile
                                            orderby a.Make
                                            select a.Make;
            // </snippet_search_linqQuery>

            var automobiles = from m in _context.Automobile
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                automobiles = automobiles.Where(v => v.Model.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AutomobileMake))
            {
                automobiles = automobiles.Where(m => m.Make == AutomobileMake);
            }

            // <snippet_search_selectList>
            Make = new SelectList(await makeQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
            Automobile = await automobiles.ToListAsync();    
        }
    }
}
