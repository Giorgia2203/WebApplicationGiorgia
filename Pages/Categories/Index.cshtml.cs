using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationGiorgia.Data;
using WebApplicationGiorgia.Models;
using WebApplicationGiorgia.Models.ViewModels;

namespace WebApplicationGiorgia.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationGiorgia.Data.WebApplicationGiorgiaContext _context;

        public IndexModel(WebApplicationGiorgia.Data.WebApplicationGiorgiaContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoriesIndexData CategoriesData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public int BookCategoryID { get; set; }

        public IEnumerable<Book> books;


        public async Task OnGetAsync(int? id, int? bookID)
        {
            books = new List<Book>();
            CategoriesData = new CategoriesIndexData();
            CategoriesData.Categories = await _context.Category.Include(i=> i.BookCategories)
                                                               .ThenInclude(i=>i.Book)
                                                               .ThenInclude(i=>i.Author)
                                                               .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoriesData.Categories.Where(i => i.ID == id.Value).Single();
                CategoriesData.BookCategories = category.BookCategories;

                foreach (BookCategory bookCategory in CategoriesData.BookCategories)
                {
                    Book book = bookCategory.Book;
                    books.Append(book); 
                }

                CategoriesData.Books = books;
            }
        }
    }
}
