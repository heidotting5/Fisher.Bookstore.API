using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fisher.Bookstore.Api.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public List<Book> Titles { get; set; }

    }
}