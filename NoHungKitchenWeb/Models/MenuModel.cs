using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoHungKitchenWeb.Data;
using System.IO;

namespace NoHungKitchenWeb.Models
{
    public class MenuModel
    {

        public long MenuId { get; set; }
        public int KitchenId { get; set; }
        public string MenuTitle { get; set; }
        public int Category { get; set; }
        public string PurchasePrice { get; set; }
        public string SalePrice { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
        public string MenuPhoto { get; set; }

        public string SaveMenu(HttpPostedFileBase fb, MenuModel model)
        {
            string Message = "";
            NoHungKitchenWebEntities db = new NoHungKitchenWebEntities();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";


            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("~/Content/Images/MenuPhoto/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/Images/MenuPhoto/") + "/" + sysFileName;

                }
            }
            var savemenu = new tblMenu()
            {

                KitchenId = model.KitchenId,
                MenuTitle = model.MenuTitle,
                Category = model.Category,
                PurchasePrice = model.PurchasePrice,
                SalePrice = model.SalePrice,
                Discount = model.Discount,
                Description = model.Description,
                MenuPhoto = sysFileName,

            };
            db.tblMenus.Add(savemenu);
            db.SaveChanges();
            return Message;
        }
        public List<MenuModel> GetMenuList(int KitchenId,int Category)
        {
            NoHungKitchenWebEntities Db = new NoHungKitchenWebEntities();
            List<MenuModel> lstMenuList = new List<MenuModel>();
            var AddMenuList = Db.tblMenus.Where(p=>p.KitchenId== KitchenId && p.Category== Category).ToList();
            if (AddMenuList != null)
            {
                foreach (var MenuList in AddMenuList)
                {
                    if (MenuList.MenuPhoto == "")
                    {
                        MenuList.MenuPhoto = "menu.png";
                    }
                    lstMenuList.Add(new MenuModel()
                    {
                        MenuId = MenuList.MenuId,
                        KitchenId = MenuList.KitchenId,
                        MenuTitle = MenuList.MenuTitle,
                        Category = MenuList.Category,
                        PurchasePrice = MenuList.PurchasePrice,
                        SalePrice = MenuList.SalePrice,
                        Discount = MenuList.Discount,
                        Description = MenuList.Description,
                        MenuPhoto = MenuList.MenuPhoto,
                    });
                }

            }
            return lstMenuList;
        }
        public string deleteMenu(int Id)
        {
            string Message = "";
            NoHungKitchenWebEntities Db = new NoHungKitchenWebEntities();
            var deleteRecord = Db.tblMenus.Where(p => p.MenuId == Id).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.tblMenus.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }
    }
}
