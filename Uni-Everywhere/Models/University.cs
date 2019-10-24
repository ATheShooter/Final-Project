using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni_Everywhere.Models
{
    public class University
    {


        public int Id { get; set; }
        public string  Name  { get; set; }

        public string ImagePath { get; set; }

        public int score  { get; set; }

        public string description { get; set; }

    }
}