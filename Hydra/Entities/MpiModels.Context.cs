﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hydra.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MCE : DbContext
    {
        public MCE()
            : base("name=MCE")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MpiEquityChars_Test> MpiEquityChars_Test { get; set; }
        public virtual DbSet<MpiFixedIncomeChars_Test> MpiFixedIncomeChars_Test { get; set; }
        public virtual DbSet<MpiHeader_Test> MpiHeader_Test { get; set; }
        public virtual DbSet<MpiReturns_Test> MpiReturns_Test { get; set; }
        public virtual DbSet<TblAssetClass> TblAssetClasses { get; set; }
    }
}