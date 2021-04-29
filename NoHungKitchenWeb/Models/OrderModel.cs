using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoHungKitchenWeb.Models
{
    public class OrderModel
    {
        public long OrderId { get; set; }
        public int CustomerId { get; set; }
        public int KitchenId { get; set; }
        public int PackageId { get; set; }
        public Nullable<int> RiderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string DeliveryTime { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
        public string GoogleAddress { get; set; }
        public string TotalAmount { get; set; }
        public string Tax { get; set; }
        public string Discount { get; set; }
        public string PaidAmount { get; set; }
        public Nullable<int> IsSaturday { get; set; }
        public Nullable<int> IsSunday { get; set; }
    }
    public  class OrderMenu
    {
        public long OMId { get; set; }
        public long OrderId { get; set; }
        public long MenuId { get; set; }
        public int Qty { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Tax { get; set; }
    }
}