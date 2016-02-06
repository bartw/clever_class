﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverClass.Domain.Business.Entity
{
    public class ClassGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassGroup>().ToTable("ClassGroup");

            modelBuilder.Entity<ClassGroup>().HasKey(cg => cg.Id);
            modelBuilder.Entity<ClassGroup>().Property(cg => cg.Id).HasColumnName("Id");
            modelBuilder.Entity<ClassGroup>().Property(cg => cg.Name).HasColumnName("Name");
        }
    }
}
