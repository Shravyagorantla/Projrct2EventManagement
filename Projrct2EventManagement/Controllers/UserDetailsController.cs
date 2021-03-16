using Projrct2EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projrct2EventManagement.Controllers
{
    public class UserDetailsController : Controller
    {
        ProjectEventManagementEntities1 db = new ProjectEventManagementEntities1();
        // GET: UserDetails
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDetail userDetail)
        {

            db.UserDetails.Add(userDetail);
            db.SaveChanges();
            var user = db.UserDetails.Single(u => u.UserName == userDetail.UserName);
            if (user.Role == "EventManager")
            {
                EventManager eventManager = new EventManager(user.Name, user.Email, user.Password, user.UserName);
                db.EventManagers.Add(eventManager);
                db.SaveChanges();
            }
            if (user.Role == "Customer")
            {
                Customer customer = new Customer(user.Name, user.UserName, user.Email, user.Password);
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetail userDetail)
        {
            try
            {
                UserDetail ud = db.UserDetails.Single(x => userDetail.UserName == userDetail.UserName && x.Name==userDetail.Name && x.Password == userDetail.Password && x.Role == userDetail.Role && x.Email == userDetail.Email);
                if (ud != null)
                {
                    if (ud.Role == "EventManager")

                    {

                        return RedirectToAction("ManagerNavigate", "EventManager");
                    }
                    if (ud.Role == "Customer")

                    {

                        return RedirectToAction("CustomerNavigate", "Customer");
                    }
                }
            }
            catch
            {
                ViewBag.Message = "User not found... Please enter correct details";
            }
            return View();


        }

    }
}

