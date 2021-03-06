//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LicentaAlexeiDenis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Oferte
    {
        public int Oferteid { get; set; }
        public Nullable<int> IDLicitatie { get; set; }
        public Nullable<int> IdUser { get; set; }
        [Required(ErrorMessage = "Tastati o valoare numerica")]
        public Nullable<decimal> ValoareBid { get; set; }
        public Nullable<System.DateTime> DataBid { get; set; }
    
        public virtual Licitatie Licitatie { get; set; }
        public virtual Useri Useri { get; set; }

        public Oferte()
        {
            DataBid = DateTime.Now;
        }
    }
}
