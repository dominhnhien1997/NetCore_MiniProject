using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class CacheContext : DbContext
    {
        public CacheContext(DbContextOptions<CacheContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

    }
}