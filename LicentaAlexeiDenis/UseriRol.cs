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
    
    public partial class UseriRol
    {
        public int IdRol { get; set; }
        public Nullable<int> IdUser { get; set; }
        public string Rol { get; set; }
    
        public virtual Useri Useri { get; set; }
    }
}