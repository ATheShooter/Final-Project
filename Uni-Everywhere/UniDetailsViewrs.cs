using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni_Everywhere.Models;

namespace Uni_Everywhere
{
    public class UniDetailsViewrs
    {
        public University Uni { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}