using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book
            {
                Name = string.Empty, // Initialize required property
                Author = string.Empty, // Initialize required property
                ISBN = string.Empty // Initialize required property
            };

            if (id == null)
            {
                return Page(); // Create new book
            }

            // Update existing book
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return NotFound();
            }

            Book = bookFromDb; // Assign only after null check
            return Page(); // Edit existing book    
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                
                if(Book.Id == 0) // Create new book
                {
                    _db.Book.Add(Book);
                }
                else // Update existing book
                {
                    _db.Book.Update(Book);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
