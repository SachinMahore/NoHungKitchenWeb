using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}