using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Everywhere.Models
{
    public class Review 
    {

        public int Id{ get; set; }

        public string Author  { get; set; }

        public DateTime  Date { get; set; }

        public  string Content { get; set; }


        public int UniversityId { get; set; }

        
    }
}