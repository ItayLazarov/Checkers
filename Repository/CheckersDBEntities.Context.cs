﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CheckersDBEntities : DbContext
    {
        public CheckersDBEntities()
            : base("name=CheckersDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BoardTile> BoardTiles { get; set; }
        public virtual DbSet<GameManagment> GameManagments { get; set; }
        public virtual DbSet<PawnColor> PawnColors { get; set; }
        public virtual DbSet<PawnType> PawnTypes { get; set; }
    }
}