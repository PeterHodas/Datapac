using System;
using Datapac_uloha.Models;
using Microsoft.EntityFrameworkCore;

namespace Datapac_uloha.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> zakaznik { get; set; }
        public DbSet<Notice> vypozicka { get; set; }
        public DbSet<Book> kniha { get; set; }
    }
}
