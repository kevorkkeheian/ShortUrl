using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShortUrl.Data;
using Microsoft.EntityFrameworkCore;

namespace ShortUrl.Pages
{
    public class RedirectModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ShortUrlContext _context;

        public RedirectModel(ILogger<IndexModel> logger,
                    ShortUrlContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            if(!String.IsNullOrEmpty(slug))
            {
                var redirectLink = await _context.RedirectUrl.FirstOrDefaultAsync(r => r.Slug == slug);
                if(redirectLink != null) {
                    var url = redirectLink.RedirectTo;
                    return RedirectTo(url);
                }
                 return Page();   
                
                
                
            }
            else
            {
                return Page();
            }
        }

        public IActionResult RedirectTo(string url)
        {
            string link = url;
            return Redirect(link);
        }
    }
}
