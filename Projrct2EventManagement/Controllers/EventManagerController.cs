using Projrct2EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projrct2EventManagement.Controllers
{
    public class EventManagerController : Controller
    {
        ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();

        // GET: Customer
        public ActionResult ManagerNavigate()
        {
            return View();
        }
        public ActionResult AddEVentsandDecoration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEVentsandDecoration(EventsAndDecoration image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            // image.Id = 90;
            image.DecorationImage = "~/Image/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            image.ImageFile.SaveAs(fileName);

            using (ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1())
            {
                db.EventsAndDecorations.Add(image);
                db.SaveChanges();
            }
            ModelState.Clear();
            string message = "Events dded Successfully";
            ViewBag.Mesage = message;
            return View();
        }
        [HttpGet]
        public ActionResult EventandDecorationView()
        {

            ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();
            var image = db.EventsAndDecorations.ToList();
            return View(image);
        }
        //public ActionResult DeleteProducts(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var eventsAndDecoration = db.EventsAndDecorations.Find(id);

        //    if (eventsAndDecoration == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    string currentImg = Request.MapPath(eventsAndDecoration.DecorationImage);
        //    db.Entry(eventsAndDecoration).State = EntityState.Deleted;
        //    if (db.SaveChanges() > 0)
        //    {
        //        if (System.IO.File.Exists(currentImg))
        //        {
        //            System.IO.File.Delete(currentImg);
        //        }
        //        TempData["msg"] = "Data Deleted";
        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}


        public ActionResult Delete(string id)
        {
           /* if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            EventsAndDecoration eventsAndDecoration = db.EventsAndDecorations.Find(id);
            if (eventsAndDecoration == null)
            {
                return HttpNotFound();
            }
            return View(eventsAndDecoration);
        }

         [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EventsAndDecoration eventsAndDecoration = db.EventsAndDecorations.Find(id);
            db.EventsAndDecorations.Remove(eventsAndDecoration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewOrderDetails()
        {

            ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();
            var list = db.Orders.ToList();
            return View(list);
        }

    }
}



