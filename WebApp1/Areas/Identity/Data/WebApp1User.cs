using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp1.Areas.Identity.Data
{
    	// Add profile data for application users by adding properties to the WebApp1User class
    public class WebApp1User : IdentityUser
    {
        [PersonalData]
        public string FirstName{get; set;}

        [PersonalData]
        public string LastName{get; set;}        

        [PersonalData]
        public DateTime DOB{get; set;}

    }
}