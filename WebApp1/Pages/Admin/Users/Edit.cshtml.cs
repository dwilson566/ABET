using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Identity.Data;
using WebApp1.Data;

namespace WebApp1.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly WebApp1.Data.ApplicationDbContext _context;

        public EditModel(WebApp1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WebApp1User WebApp1User { get; set; }

        
        public bool IsAdmin { get; set; }

        

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WebApp1User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebApp1UserExists(WebApp1User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WebApp1UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
