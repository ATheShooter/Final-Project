using PusherServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Example;


namespace Uni_Everywhere.Models
{
    public class UniversitiesController : Controller
    {
        private Uni_EverywhereContext db = new Uni_EverywhereContext();

        // GET: Universities
        public ActionResult Index()
        {
            return View(db.Universities.ToList());
        }

        // GET: Universities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniDetailsViewrs UDV = new UniDetailsViewrs();
            UDV.Uni = db.Universities.Find(id);

            UDV.Reviews = GetReviews(id);

            if (UDV == null)
            {
                return HttpNotFound();
            }
            return View(UDV);
        }

        public IEnumerable<Review> GetReviews(int? id)
        {
            var list = (from recordset in db.Reviews
                    where recordset.UniversityId == id
                    select new
                    {
                        Author = recordset.Author,
                        Id = recordset.Id,
                        Content = recordset.Content,
                        Date = recordset.Date,
                        UniversityId = recordset.UniversityId
                    }).ToList().Select(r => new Review
                    {

                        Author = r.Author,
                        Id = r.Id,
                        Content = r.Content,
                        Date = r.Date,
                        UniversityId = r.UniversityId

                    });

            return list;
                 
        }
        // GET: Universities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImageFile,ImagePath,score,description")] UniHelper unihelper)
        {
            University university = new University();


            if (ModelState.IsValid)
            {



                string pic = System.IO.Path.GetFileName(unihelper.ImageFile.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Images/Uni/"), pic);
                unihelper.ImageFile.SaveAs(path);


                university.Id = unihelper.Id;
                university.Name = unihelper.Name;
                university.ImagePath = "~/Images/Uni/" + pic;
                // university.ImagePath = path;
                university.score = unihelper.score;
                university.description = unihelper.description;


                db.Universities.Add(university);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(university);
        }




        // POST: Universities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImagePath,score,description")] University university)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(university);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
            }

            University university = db.Universities.Find(id);
            return View(university);
        }


        // GET: Universities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            University university = db.Universities.Find(id);
            db.Universities.Remove(university);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Review([Bind(Include = "Author,Content,UniversityId")]Review data)
        {
            if(!data.Equals(null))
            {
                data.Date = DateTime.Now;
                if(data.UniversityId.Equals(null))
                    throw new ArgumentNullException("UniversityID property is null");

                System.Diagnostics.Debug.WriteLine(data.Author + " " + data.Content + "time " + data.Date);

                db.Reviews.Add(data);
                db.SaveChanges();
                  //  System.Diagnostics.Debug.WriteLine("Saved to databae succesfuly");
                }
                    
                return RedirectToAction("Details", new { id = data.UniversityId });
            }


        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}



