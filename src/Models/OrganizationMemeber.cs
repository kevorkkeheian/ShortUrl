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
    public enum OrganizationMemberType { 
        Owner,
        Admin,
        Member,
        Viewer
    }
    public class OrganizationMember
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrganizationMemberId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string ShortUrlUserId { get; set; }
        public ShortUrlUser ShortUrlUser { get; set; }

        public OrganizationMemberType Type { get; set; }

    }
}
