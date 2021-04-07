using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Identity.Data;
using WebApp1.Data;

namespace WebApp1.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public IndexModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WebApp1User> WebApp1User { get;set; }
        public class Contact
{
    public int ContactId { get; set; }

    // user ID from AspNetUser table.
    public string OwnerID { get; set; }

    public string Email { get; set; }

    public ContactStatus Status { get; set; }
}

    public enum ContactStatus
    {   
    Submitted,
    Approved,
    Rejected
    }


        public async Task OnGetAsync()
        {
            WebApp1User = await _context.Users.ToListAsync();
        }
    }
}
