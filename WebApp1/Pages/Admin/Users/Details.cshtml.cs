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
    public class DetailsModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public WebApp1User WebApp1User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebApp1User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (WebApp1User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
