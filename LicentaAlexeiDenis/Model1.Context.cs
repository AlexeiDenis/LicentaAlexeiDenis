﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoriiProduse> CategoriiProduse { get; set; }
        public virtual DbSet<UseriRol> UseriRol { get; set; }
        public virtual DbSet<Produse> Produse { get; set; }
        public virtual DbSet<Useri> Useri { get; set; }
        public virtual DbSet<Licitatie> Licitatie { get; set; }
        public virtual DbSet<Oferte> Oferte { get; set; }
    }
}
