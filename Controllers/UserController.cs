using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore1.Models;

namespace bookstore1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        
        public ActionResult Login(User loginUser)
        {
            try
            {
                // TODO: Add insert logic here


                UserDBHandle udb = new UserDBHandle();
                if (udb.validateUser(loginUser) == true)
                {

                    
                    ModelState.Clear();
                    return RedirectToAction("Create", "Payment");

                }
                else
                {
                    ViewBag.Message = "Invalid Credentials";

                }

                return View();

            }
            catch
            {
                return View();
            }
        }


        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDBHandle udb = new UserDBHandle();
                    if (udb.AddUser(user))
                    {
                        ViewBag.Message = "Your account has been created";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: User/Edit/5
       
    }
}
