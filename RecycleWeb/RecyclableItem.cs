//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecycleWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class RecyclableItem
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Recyclable Type Id")]
        public int RecyclableTypeId { get; set; }
        [ForeignKey("RecyclableTypeId")]

        public decimal Weight { get; set; }

        [DisplayName("Computed Rate")]
        public decimal ComputedRate { get; set; }

        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
    
        public virtual RecyclableType RecyclableType { get; set; }
    }
}
