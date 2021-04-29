using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoHungKitchenWeb.Models
{
    public class PackageModel
    {
        public int PackageID { get; set; }
        public int KitchenId { get; set; }
        public int Category { get; set; }
        public int Cuisine { get; set; }
        public int PlanType { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> IsSaturday { get; set; }
        public Nullable<int> IsSunday { get; set; }
        public decimal ActualWeeklyRate { get; set; }
        public decimal ActualMonthlyRate { get; set; }
        public decimal WeeklyRate { get; set; }
        public decimal MonthlyRate { get; set; }
        public int Status { get; set; }
    }
    public  class PackageDetail
    {
        public int PackageDetId { get; set; }
        public int PackageId { get; set; }
        public string PackageDay { get; set; }
        public string MenuIds { get; set; }
        public Nullable<decimal> PackageRate { get; set; }
        public string PackagePhoto { get; set; }
        public Nullable<int> DefaultMenuId { get; set; }
    }
}