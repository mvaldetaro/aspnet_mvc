﻿using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Biblioteca
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}