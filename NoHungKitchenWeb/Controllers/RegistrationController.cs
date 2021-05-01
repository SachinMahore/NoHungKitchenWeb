using NoHungKitchenWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoHungKitchenWeb.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveRegistration(RegistrationModel model)
        {
            try
            {
                HttpPostedFileBase fb0 = null;
                HttpPostedFileBase fb1 = null;
                HttpPostedFileBase fb2 = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb0 = Request.Files[0];
                    fb1 = Request.Files[1];
                    fb2 = Request.Files[2];
                }
                return Json(new { message = (new RegistrationModel().SaveRegistration(fb0,fb1,fb2, model)) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)


            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}