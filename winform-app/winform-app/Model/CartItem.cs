//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace winform_app.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
