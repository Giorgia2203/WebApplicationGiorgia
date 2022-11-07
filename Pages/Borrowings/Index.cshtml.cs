using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationGiorgia.Data;
using WebApplicationGiorgia.Models;

namespace WebApplicationGiorgia.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationGiorgia.Data.WebApplicationGiorgiaContext _context;

        public IndexModel(WebApplicationGiorgia.Data.WebApplicationGiorgiaContext context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
