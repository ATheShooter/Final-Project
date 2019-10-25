using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Everywhere.Identity
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }

        

        public string ReturnUrl { get; set; }
        public string Email { get; set; }
      
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}