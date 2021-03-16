using Projrct2EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Projrct2EventManagement.Controllers
{
    public class CustomerController : Controller
    {
        ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();
        // GET: Customer
        public ActionResult CustomerNavigate()
        {
            return View();
        }
        public ActionResult ViewEventsList()
        {
            ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();


            var image = db.EventsAndDecorations;
            return View(image);



        }


        //public ActionResult ViewOrderDetails()
        //{
        //   int  = TempData.Peek("EventType").ToString();
        //    var data = db.Orders.Where(d => d. Event== EventType);
        //    return View(data);
        //}
        public ActionResult PlaceOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PlaceOrder(Order orders)
        {
            using (var context = new ProjectEventManagementEntities1())
            {
                db.Orders.Add(orders);
                db.SaveChanges();


            }
            string message = "Order placed successfully";
            ViewBag.Message = message;
            return View();



        }
        public ActionResult OrderDetailsView()
        {

            ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();
            var list = db.Orders.ToList();
            return View(list);
        }

        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }
       
    }


}


    