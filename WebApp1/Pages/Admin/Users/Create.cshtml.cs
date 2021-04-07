using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.Areas.Identity.Data;
using WebApp1.Data;

namespace WebApp1.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public CreateModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WebApp1User WebApp1User { get; set; }
    
        public bool IsAdmin { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(WebApp1User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
