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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ShortUrlContext _context;

        public IndexModel(ILogger<IndexModel> logger,
                    ShortUrlContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public void OnGet()
        {

        }
    }
}
