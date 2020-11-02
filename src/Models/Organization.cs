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
    
    public class Organization
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrganizationId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string Name { get; set; }

        public string ShortUrlUserId { get; set; } //Created by
        public ShortUrlUser shortUrlUser { get; set;}


        public async Task<bool> organizationExist(string name, ShortUrlContext context) {
            return await context.Organization.AnyAsync(r => r.Name == name);
        }
    }
}
