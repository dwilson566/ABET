using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.CourseLearningOutcomes
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp1.Data.OutcomesContext _context;

        public DeleteModel(WebApp1.Data.OutcomesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseLearningOutcome = await _context.CourseLearningOutcome.FindAsync(id);

            if (CourseLearningOutcome != null)
            {
                _context.CourseLearningOutcome.Remove(CourseLearningOutcome);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
