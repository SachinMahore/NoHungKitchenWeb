using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoHungKitchenWeb.Data;
using System.IO;
using System.Net;
using System.Text;

namespace NoHungKitchenWeb.Models
{
    public class RegistrationModel
    {
        public int KitchenId { get; set; }
        public string KitchenName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
        public string OwnerName { get; set; }
        public string Password { get; set; }
        public string UploadDocuments { get; set; }
        public string KitchenImage { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonRole { get; set; }
        public string KitchenContactNo { get; set; }
        public string FSSAILicenseNo { get; set; }
        public string ExpiryDateOfLicense { get; set; }
        public string PanCardNo { get; set; }
        public string GSTRegNo { get; set; }

        public string SaveRegistration(HttpPostedFileBase fb, RegistrationModel model)
        {
            string Message = "";
            NoHungKitchenWebEntities db = new NoHungKitchenWebEntities();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";


            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("~/Content/images/Kitchen/");
                //filePath = HttpContext.Current.Server.MapPath("~/Content/documetns/Kitchendocuments/");
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
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/images/Kitchen/") + "/" + sysFileName;
                    //string afileName = HttpContext.Current.Server.MapPath("~/Content/documents/Kitchendocuments/") + "/" + sysFileName;

                }
            }
            var getKitchen = db.tblKitchenMasters.Where(p => p.KitchenName == model.KitchenName).FirstOrDefault();
            if (getKitchen == null)
            {
                var saveregistration = new tblKitchenMaster()
                {
                    KitchenName = model.KitchenName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    State = model.State,
                    City = model.City,
                    Pin = model.Pin,
                    Address = model.Address,
                    OwnerName = model.OwnerName,
                    Password = model.Password,
                    UploadDocuments = model.UploadDocuments,
                    KitchenImage = sysFileName,
                    ContactPerson = model.ContactPerson,
                    ContactPersonRole = model.ContactPersonRole,
                    KitchenContactNo = model.KitchenContactNo,
                    FSSAILicenseNo = model.FSSAILicenseNo,
                    ExpiryDateOfLicense = model.ExpiryDateOfLicense,
                    PanCardNo = model.PanCardNo,
                    GSTRegNo = model.GSTRegNo,

                };
                db.tblKitchenMasters.Add(saveregistration);
                db.SaveChanges();
                string mobile = model.Mobile;
                string sAPIKey = "fYMsEmpZQUewatTPf0TktQ";
                string sNumber = mobile;
                string sMessage = "Hi, " + model.OwnerName + "- NoHung KitchenId: " + saveregistration.KitchenId + " & Pass: " + model.Password ;
                string sSenderId = "BSCAKE";
                string sChannel = "trans";
                string sRoute = "8";
                // string sURL = "http://mysms.msg24.in/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderId + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "&route=" + sRoute + "";
                string sURL = "http://mysms.msg24.in/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderId + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "&route=" + sRoute + "";

                string sResponse = GetResponse(sURL);
                //Response.Write(sResponse);
                Message = model.KitchenName + " Kitchen added Successfully with KitchenId: " + saveregistration.KitchenId;
            }
            else
            {
                Message = model.KitchenName + " Kitchen Name already exist.";
            }
            return Message;
        }
        public static string GetResponse(string sUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sUrl);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}

