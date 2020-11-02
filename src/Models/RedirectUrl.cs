using Microsoft.EntityFrameworkCore;
using ShortUrl.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ShortUrl.Data;

namespace ShortUrl.Models
{
    
    public class RedirectUrl
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string RedirectUrlId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Name { get; set; }
        public string RedirectTo { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ShortUrlUserId { get; set; }
        public ShortUrlUser ShortUrlUser { get; set; } //Created By


        //Check and return if Slug already exists
        public async Task<bool> slugExist(string slug, ShortUrlContext context) {
            return await context.RedirectUrl.AnyAsync(r => r.Slug == slug);
        }
    }
}
