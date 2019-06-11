using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal2.Models;

namespace MyScriptureJournal2.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal2.Models.MyScriptureJournal2Context _context;

        public IndexModel(MyScriptureJournal2.Models.MyScriptureJournal2Context context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string OrderBy { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;

        public SelectList Book { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from s in _context.Scripture
                                           orderby s.Book
                                           select s.Book;

            var scriptures = from s in _context.Scripture select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
            }

            if(!string.IsNullOrEmpty(OrderBy))
            {
                switch (OrderBy)
                {
                    case "book":
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;
                    case "date":
                        scriptures = scriptures.OrderBy(s => s.Accessed);
                        break;
                    default:
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;
                }
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
        /*public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["BookSortParm"] = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var scriptures = from s in _context.Scripture select s;

            switch (sortOrder)
            {
                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scriptures = scriptures.OrderByDescending(s => s.Accessed);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Accessed);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }
            return View(await scriptures.AsNoTracking().ToListAsync());
        }

        private IActionResult View(List<Scripture> list)
        {
            throw new NotImplementedException();
        } */
    } 
}
