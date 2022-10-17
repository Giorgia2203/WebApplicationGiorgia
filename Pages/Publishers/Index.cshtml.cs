using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationGiorgia.Data;
using WebApplicationGiorgia.Models;

namespace WebApplicationGiorgia.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationGiorgia.Data.WebApplicationGiorgiaContext _context;

        public IndexModel(WebApplicationGiorgia.Data.WebApplicationGiorgiaContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }
    }
}
