﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UGTUTelephone
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KadrRealTestEntities : DbContext
    {
        public KadrRealTestEntities()
            : base("name=KadrRealTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<DepContact> DepContacts { get; set; }
        public virtual DbSet<DeptEmplo> DeptEmploes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}
