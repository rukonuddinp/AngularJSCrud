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
    public class PlayerInfoesController : Controller
    {
        private Mvc_Crud_AngularjsContext db = new Mvc_Crud_AngularjsContext();

        // GET: PlayerInfoes
        public ActionResult Index()
        {
            return View(db.PlayerInfoes.ToList());
        }


     
        public JsonResult getAllData()
        {

           var info =  db.PlayerInfoes.ToList().Join(
                db.Countrys.ToList(), p => p.CountId, c => c.Id, (pl, cl) => new PlayerInfo
                {
                    Id = pl.Id,
                    CountId = cl.Id,
                    Country_Name = cl.Country_Name,
                    image = pl.image,
                    IsComeFromVillage = pl.IsComeFromVillage,
                    JoiningDate = pl.JoiningDate,
                    PlayerDistrict = pl.PlayerDistrict,
                    PlayerName = pl.PlayerName
                }).ToList();

            return Json(info, JsonRequestBehavior.AllowGet );
        }

        // GET: PlayerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInfo playerInfo = db.PlayerInfoes.Find(id);
            if (playerInfo == null)
            {
                return HttpNotFound();
            }
            return View(playerInfo);
        }

        [HttpPost]
        public ContentResult UploadImage()
        {
            try
            {
                var files = Request.Files;
                var fileName = System.IO.Path.GetFileName(files[0].FileName);
                if(System.IO.File.Exists(Server.MapPath("~/Image/") + fileName))
                {
                    System.IO.File.Delete(Server.MapPath("~/Image/") + fileName);
                }
                files[0].SaveAs(Server.MapPath("~/Image/") + fileName);
                string ImagePath = "~/Image/" + fileName;
                return new ContentResult
                {
                    Content = ImagePath
                };
           
            }
            catch(Exception ex)
            {
                return new ContentResult
                {
                    Content = ""
                };
            }


            }
            



            [HttpPost] 
        public ContentResult Create( PlayerInfo playerInfo)
        {
           
            if (ModelState.IsValid)
            {
                db.PlayerInfoes.Add(playerInfo);
                db.SaveChanges();
                return new ContentResult { Content = "Success!Your data is inserted" };
            }

            return new ContentResult { Content = "Fail!your data is not inserted" };
        }

        [HttpPost]   
        public ContentResult Edit( PlayerInfo playerInfo)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(playerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return new ContentResult { Content = "Success!Your data is updated" };
            }
            return new ContentResult { Content = "Fail!your data is not update" };
        }

        [HttpPost]
        public ContentResult Delete(PlayerInfo playerInfo)
        {
            try
            {
                PlayerInfo playerInfoDel = db.PlayerInfoes.Find(playerInfo.Id);
                db.PlayerInfoes.Remove(playerInfoDel);
                db.SaveChanges();
                return new ContentResult { Content = "Success!Your data is deleted" };
            }catch
            {

            }

            return new ContentResult { Content = "Fail!Your data is not deleted" };

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
