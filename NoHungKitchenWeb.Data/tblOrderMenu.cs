//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoHungKitchenWeb.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrderMenu
    {
        public long OMId { get; set; }
        public long OrderId { get; set; }
        public long MenuId { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Tax { get; set; }
    }
}
