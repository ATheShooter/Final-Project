using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Everywhere
{
    public class UniHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }


       
        public int score { get; set; }

        public string description { get; set; }

    }
}