﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gDrive
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatieDBEntities : DbContext
    {
        public DatieDBEntities()
            : base("name=DatieDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_Comment> tbl_Comment { get; set; }
        public DbSet<tbl_District> tbl_District { get; set; }
        public DbSet<tbl_Image> tbl_Image { get; set; }
        public DbSet<tbl_Main_Course> tbl_Main_Course { get; set; }
        public DbSet<tbl_Rate> tbl_Rate { get; set; }
        public DbSet<tbl_Shop> tbl_Shop { get; set; }
        public DbSet<tbl_User> tbl_User { get; set; }
    }
}
