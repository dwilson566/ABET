using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.StudentOutcomes
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp1.Data.OutcomesContext _context;

        public DeleteModel(WebApp1.Data.OutcomesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentOutcome StudentOutcome { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentOutcome = await _context.StudentOutcome.FirstOrDefaultAsync(m => m.Id == id);

            if (StudentOutcome == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentOutcome = await _context.StudentOutcome.FindAsync(id);

            if (StudentOutcome != null)
            {
                _context.StudentOutcome.Remove(StudentOutcome);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
