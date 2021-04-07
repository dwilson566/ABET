using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp1.Pages
{
    public class RolesModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public RolesModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }


    // New Addition
    public class Contact
{
    public int ContactId { get; set; }

    // user ID from AspNetUser table.
    public string OwnerID { get; set; }

    public string Email { get; set; }

    public ContactStatus Status { get; set; }
}

    public enum ContactStatus
    {   
    Submitted,
    Approved,
    Rejected
    }

        public void OnGet()
        {
        }
    }
}