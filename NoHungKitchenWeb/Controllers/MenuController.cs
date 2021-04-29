using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoHungKitchenWeb.Models;

namespace NoHungKitchenWeb.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Master()
        {
            ViewBag.KitchenId = Session["KitchenId"];
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.KitchenId = Session["KitchenId"];
            return View();
        }

        public ActionResult MenuList()
        {
            return View();
        }
        public ActionResult SaveMenu(MenuModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];

                }
                return Json(new { message = (new MenuModel().SaveMenu(fb, model)) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetMenuList(int KitchenId, int Category)
        {
            try
            {
                return Json(new { model = (new MenuModel().GetMenuList(KitchenId, Category)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteMenu(int Id)
        {
            try
            {
                return Json(new { model = (new MenuModel().deleteMenu(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

    }
}

