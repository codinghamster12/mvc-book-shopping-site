using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore1.Models;


namespace bookstore1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Index()
        {
            ProductDBHandle dbhandle = new ProductDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetProduct());

        }
        
        public ActionResult Dashboard()
        {
            return View();

        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Book bmodel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ProductDBHandle pdb = new ProductDBHandle();
                    if (pdb.AddProduct(bmodel))
                    {
                        ViewBag.Message = "Product Details Added Successfully";
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

    

    // GET: Admin/Edit/5
 
    public ActionResult Edit(int id)
        {

        ProductDBHandle pdb = new ProductDBHandle();
        return View(pdb.GetProduct().Find(bmodel => bmodel.Id == id));

    }

    // POST: Admin/Edit/5
    
    [HttpPost]
        public ActionResult Edit(int id, Book bmodel)
        {
            try
            {
                ProductDBHandle pdb = new ProductDBHandle();
                pdb.UpdateDetails(bmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Admin/Delete/5

            
        public ActionResult Delete(int id)
        {
            try
            {
                ProductDBHandle pdb = new ProductDBHandle();
                if (pdb.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Product Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    


// POST: Admin/Delete/5

[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: AdminSignUp/Create
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(User admin)
        {
            try
            {
                // TODO: Add insert logic here


                UserDBHandle udb = new UserDBHandle();
                if (udb.validateAdmin(admin) == true)
                {
                   
                    ModelState.Clear();
                    Session["Firstname"] = admin.Firstname;
                    return View("Dashboard");
                    
                }
                else
                {
                    ViewBag.Message = "Restricted Access";
                    
                    ModelState.Clear();
                }

                return View();

            }
            catch
            {
                return View();
            }
        }
    }
}
