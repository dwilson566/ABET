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
    public class IndexModel : PageModel
    {
        private readonly WebApp1.Data.OutcomesContext _context;

        public IndexModel(WebApp1.Data.OutcomesContext context)
        {
            _context = context;
        }

        public IList<CourseLearningOutcome> CourseLearningOutcome { get;set; }

        public async Task OnGetAsync()
        {
            CourseLearningOutcome = await _context.CourseLearningOutcome.ToListAsync();
        }
    }
}
