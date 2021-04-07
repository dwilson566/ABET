using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.StudentOutcomes
{
    public class EditModel : PageModel
    {
        private readonly WebApp1.Data.OutcomesContext _context;

        public EditModel(WebApp1.Data.OutcomesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentOutcomeExists(StudentOutcome.Id))
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

        private bool StudentOutcomeExists(int id)
        {
            return _context.StudentOutcome.Any(e => e.Id == id);
        }
    }
}
