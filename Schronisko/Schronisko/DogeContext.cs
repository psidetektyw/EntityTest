using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schronisko.Models;

namespace Schronisko
{
    public class DogeContext: DbContext
        {
         public DbSet<Dog> Dogs { get; set; }
         public DbSet<Ogon> Ogons { get; set; }
        // public DbSet<Post> Posts { get; set; }

        public DogeContext(DbContextOptions<DogeContext> options): base(options)
        {
        }

        public DogeContext()
        {
        }

        
    }

    public class Dog
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public int NumberOfWows { get; set; }

        //public Ogon Ogon { get; set; }
    }
}
