using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Data;
using ShortUrl.Models;

namespace ShortUrl.Pages.URL
{
    public class DeleteModel : PageModel
    {
        private readonly ShortUrl.Data.ShortUrlContext _context;

        public DeleteModel(ShortUrl.Data.ShortUrlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RedirectUrl RedirectUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RedirectUrl = await _context.RedirectUrl.FirstOrDefaultAsync(m => m.RedirectUrlId == id);

            if (RedirectUrl == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RedirectUrl = await _context.RedirectUrl.FindAsync(id);

            if (RedirectUrl != null)
            {
                _context.RedirectUrl.Remove(RedirectUrl);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
