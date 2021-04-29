using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NoHungKitchenWeb.Data ;
using NoHungKitchenWeb.Models;

namespace NoHungKitchenWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        public NoHungKitchenWebEntities db = new NoHungKitchenWebEntities();
      
        
       
        public ActionResult LoginIn(RegistrationModel model)
        {
            var user = db.tblKitchenMasters.Where(m => m.KitchenId == model.KitchenId && m.Password == model.Password).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    Session["KitchenId"] = user.KitchenId.ToString();
                    Session["KitchenName"] = user.KitchenName.ToString();
                    Session["OwnerName"] = user.OwnerName.ToString();
                    Session["KitchenImage"] = user.KitchenImage.ToString();
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid KitchenId or password.");
                }

            }
            return View("..\\Login\\Index", model);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["KitchenId"] != null)
            {
                ViewBag.KitchenId = Session["KitchenId"];
                ViewBag.KitchenName = Session["KitchenName"];
                ViewBag.OwnerName = Session["OwnerName"];
                ViewBag.KitchenImage = Session["KitchenImage"];
                return View("..\\Dashboard\\Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Login\\Index");
        }

    }

}