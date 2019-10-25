using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Everywhere.Identity
{
    public class AppUser : IdentityUser
    {

        public string MyExtraProperty { get; set; }
    }
}