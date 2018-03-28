using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fisher.Bookstore.Api.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {
            // delete constructor code that seeded our data
        }
        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        public DbSet<Book> Books {get; set;}
        
        public DbSet<Author> Authors {get; set;}

    }
}