using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Data;
using ShortUrl.Models;

namespace ShortUrl.Pages.URL
{
    public class EditModel : PageModel
    {
        private readonly ShortUrl.Data.ShortUrlContext _context;

        public EditModel(ShortUrl.Data.ShortUrlContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RedirectUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedirectUrlExists(RedirectUrl.RedirectUrlId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RedirectUrlExists(string id)
        {
            return _context.RedirectUrl.Any(e => e.RedirectUrlId == id);
        }
    }
}
