using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.Data;
using WebApp1.Models;

namespace WebApp1.Pages.StudentOutcomes
{
    public class CreateModel : PageModel
    {
        private readonly WebApp1.Data.OutcomesContext _context;

        public CreateModel(WebApp1.Data.OutcomesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentOutcome StudentOutcome { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentOutcome.Add(StudentOutcome);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
