﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationGiorgia.Models;

namespace WebApplicationGiorgia.Data
{
    public class WebApplicationGiorgiaContext : DbContext
    {
        public WebApplicationGiorgiaContext (DbContextOptions<WebApplicationGiorgiaContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationGiorgia.Models.Book> Book { get; set; } = default!;

        public DbSet<WebApplicationGiorgia.Models.Publisher> Publisher { get; set; }

        public DbSet<WebApplicationGiorgia.Models.Author> Author { get; set; }

        public DbSet<WebApplicationGiorgia.Models.Category> Category { get; set; }

        public DbSet<WebApplicationGiorgia.Models.Member> Member { get; set; }

        public DbSet<WebApplicationGiorgia.Models.Borrowing> Borrowing { get; set; }
    }
}
