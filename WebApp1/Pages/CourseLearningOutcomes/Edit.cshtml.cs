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

namespace WebApp1.Pages.CourseLearningOutcomes
{
    public class EditModel : PageModel
    {
        private readonly WebApp1.Data.OutcomesContext _context;

        public EditModel(WebApp1.Data.OutcomesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CourseLearningOutcome CourseLearningOutcome { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseLearningOutcome = await _context.CourseLearningOutcome.FirstOrDefaultAsync(m => m.Id == id);

            if (CourseLearningOutcome == null)
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

            _context.Attach(CourseLearningOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseLearningOutcomeExists(CourseLearningOutcome.Id))
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

        private bool CourseLearningOutcomeExists(int id)
        {
            return _context.CourseLearningOutcome.Any(e => e.Id == id);
        }
    }
}
