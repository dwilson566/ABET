using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class OutcomesContext : DbContext
    {
        public OutcomesContext (DbContextOptions<OutcomesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp1.Models.StudentOutcome> StudentOutcome { get; set; }

        public DbSet<WebApp1.Models.CourseLearningOutcome> CourseLearningOutcome { get; set; }
    }
}
