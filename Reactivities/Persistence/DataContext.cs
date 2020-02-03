﻿using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<TestHoliday> TestHolidays { get; set; }

        public DbSet<RunBuild> RunBuilds { get; set; }
        public DbSet<Wending> Wendings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Value>().
                 HasData(
                    new Value { Id = 1, Name = "Value 101" },
                    new Value { Id = 2, Name = "Value 102" },
                    new Value { Id = 3, Name = "Value 103" }
                 );
        }
    }
}