using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Areas.Identity.Data;
using ShortUrl.Data;
using ShortUrl.Models;

namespace ShortUrl.Pages.URL
{
    public class IndexModel : PageModel
    {
        private readonly ShortUrl.Data.ShortUrlContext _context;
        private readonly UserManager<ShortUrlUser> _userManager;

        public IndexModel(ShortUrl.Data.ShortUrlContext context,
                    UserManager<ShortUrlUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<RedirectUrl> RedirectUrl { get;set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            RedirectUrl = await _context.RedirectUrl.Where(r => r.ShortUrlUserId == userId).ToListAsync();
        }
    }
}
