using GuestBook.DAL;
using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBook.Controllers
{
    public class TamuController : Controller
    {
        // GET: Tamu
        public ActionResult Index()
        {
            using (TamuDAL service = new TamuDAL())
            {
                
                var model = service.GetData().ToList();
                if (TempData["Pesan"] != null)
                {
                    ViewBag.Pesan = TempData["Pesan"].ToString();
                }
                return View(model);
            }
        }
        public ActionResult Search(string txtSearch)
        {
            using (TamuDAL svCat = new TamuDAL())
            {
                var results = svCat.Search(txtSearch).ToList();
                return View("Index", results);
            }
        }

        public ActionResult IndexUser()
        {
            string username = Session["username"].ToString();
            using (TamuDAL service = new TamuDAL())
            {
                return View(service.GetDataByUsername(username).ToList());
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            if (Session["username"] == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["username"] = User.Identity.Name;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tamu tamu)
        {
            
            using (TamuDAL service = new TamuDAL())
            {
                
                    service.Add(tamu); 
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            using (TamuDAL services = new TamuDAL())
            {
                var result = services.GetDataById(id);
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit(Tamu tamu)
        {
            using (TamuDAL services = new TamuDAL())
            {
               
                    services.Edit(tamu);

            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            using (TamuDAL service = new TamuDAL())
            {
             
                    service.Delete(id);
                    
            }
            return RedirectToAction("Index");
        }
    }
}