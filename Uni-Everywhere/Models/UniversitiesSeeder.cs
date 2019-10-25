using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Uni_Everywhere.Models
{
    public class UniversitiesSeeder<T> : DropCreateDatabaseAlways<Uni_EverywhereContext>
    {

        
        protected override void Seed(Uni_EverywhereContext context)
        {


            var Unies = new List<University>();

            Unies.Add(new University() { Name = "Limkokwing University", ImagePath = "/Images/Uni/Limkokwing.jpg", score = 7 ,description="Createivity University located at Cyberjaya"});
            Unies.Add(new University() { Name = "APU University", ImagePath = "/Images/Uni/apu.jpg", score = 7 });
            Unies.Add(new University() { Name = "Multimedia University ", ImagePath = "/Images/Uni/MMU.png", score = 7 });
            Unies.Add(new University() { Name = "University Of Malaya", ImagePath = "/Images/Uni/UM.jpeg", score = 7 });
            Unies.Add(new University() { Name = "Universiti Putra Malaysia", ImagePath = "/Images/Uni/upm.jpg", score = 7 });
            Unies.Add(new University() { Name = "Universiti Technology Malaysia", ImagePath = "/Images/Uni/UTM.jfif", score = 7 });
            Unies.Add(new University() { Name = "Universiti Putra Malaysia", ImagePath = "/Images/Uni/upm.jpg", score = 7 });



            foreach (var uni in Unies)
            {
                context.Universities.Add(uni);
            }

        }
    }
}