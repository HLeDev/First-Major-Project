//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuildResources
{
    using System;
    using System.Collections.Generic;
    
    public partial class GStorage
    {
        public decimal GSItemID { get; set; }
        public string GSItemType { get; set; }
        public string GSItemDescription { get; set; }
        public decimal Qty { get; set; }
        public decimal GuildID { get; set; }
    
        public virtual GuildIdentifier GuildIdentifier { get; set; }
    }
}