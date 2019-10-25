using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Everywhere.Identity
{
    public class RegisterViewModel
    {
        public RegisterViewModel() { }

        public string Email { get; set; }
       
        public string Password { get; set; }
       
        public string ConfirmPassword { get; set; }
    }
}