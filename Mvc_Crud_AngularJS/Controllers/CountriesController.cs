using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Crud_Angularjs.Data;
using Mvc_Crud_Angularjs.Models;

namespace Mvc_Crud_Angularjs.Controllers
{
    public class CountriesController : Controller
    {
        private Mvc_Crud_AngularjsContext db = new Mvc_Crud_AngularjsContext();

        // GET: Countries
        public ActionResult Index()
        {
            return View(db.Countrys.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countrys.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //// GET: Countries/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        public JsonResult getAllData()
        {
            return Json(db.Countrys.ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
       
        public ContentResult Create( Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countrys.Add(country);
                db.SaveChanges();

                


                return new ContentResult
                {
                    Content = "your data is saved"
                };
            }

            return new ContentResult
            {
                Content = "your data  is not saved"
            } ;
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countrys.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Country_Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countrys.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countrys.Find(id);
            db.Countrys.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
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
