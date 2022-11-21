using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database.entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Database
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi=> bi.BookId);

            builder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi=> bi.AuthorId);

            builder.Entity<Loan>()
                .HasOne(b => b.Book)
                .WithMany(bu => bu.Loans)
                .HasForeignKey(bi=> bi.BookId);


            builder.Entity<Loan>()
            .HasOne(b => b.User)
            .WithMany(bu => bu.Loans)
            .HasForeignKey(bu=> bu.UserId);
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }

        


    }
}