﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accessorie
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AccessoriesEntities : DbContext
    {
        public AccessoriesEntities()
            : base("name=AccessoriesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineType> MachineType { get; set; }
        public virtual DbSet<Patch> Patch { get; set; }
        public virtual DbSet<Repairer> Repairer { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
    }
}