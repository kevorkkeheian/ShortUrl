using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShortUrl.Data;
using ShortUrl.Models;
using ShortUrl.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShortUrl.Pages.URL
{
    public class CreateModel : PageModel
    {
        private readonly ShortUrl.Data.ShortUrlContext _context;
        private readonly UserManager<ShortUrlUser> _userManager;

        public CreateModel(ShortUrl.Data.ShortUrlContext context,
                            UserManager<ShortUrlUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public string ShortUrlUserId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            ShortUrlUserId = user.Id;
            return Page();
        }

        [BindProperty]
        public RedirectUrl RedirectUrl { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var slugExist = await RedirectUrl.slugExist(RedirectUrl.Slug, _context);
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            if (slugExist == true)
            {
                ModelState.AddModelError(string.Empty, "Slug already exists! Please choost a new one.");
                
                ShortUrlUserId = userId;
                
                return Page();
            }

            RedirectUrl.ShortUrlUserId = userId;

            // TODO 1: change the code so that the user chooses the organization
            // This is will be change once the option of adding other organization per user is added
            var organization = await _context.Organization.FirstOrDefaultAsync(r => r.ShortUrlUserId == userId);
            RedirectUrl.OrganizationId = organization.OrganizationId;

            _context.RedirectUrl.Add(RedirectUrl);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
