//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnowledgeBox.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public System.Guid Cart_Id { get; set; }
        public System.DateTime Cart_Date { get; set; }
        public int Item_Id { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
