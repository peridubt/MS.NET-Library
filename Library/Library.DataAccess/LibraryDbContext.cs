using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess;

public class LibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookDownloads> BookDownloads { get; set; }
    public DbSet<BookType> BookTypes { get; set; }
    public DbSet<BookUpdates> BookUpdates { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<UpdateType> UpdateTypes { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().HasIndex(x => x.ExternalId).IsUnique();

        // Employee - зависит от User

        // Book
        modelBuilder.Entity<Book>().HasKey(x => x.Id);
        modelBuilder.Entity<Book>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<Book>().HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);
        modelBuilder.Entity<Book>().HasOne(x => x.Publisher)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.PublisherId);
        modelBuilder.Entity<Book>().HasOne(x => x.BookType)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.BookTypeId);

        // Author
        modelBuilder.Entity<Author>().HasKey(x => x.Id);
        modelBuilder.Entity<Author>().HasIndex(x => x.ExternalId).IsUnique();

        // BookDownloads
        modelBuilder.Entity<BookDownloads>().HasKey(x => x.Id);
        modelBuilder.Entity<BookDownloads>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<BookDownloads>().HasOne(x => x.User)
            .WithMany(x => x.BookDownloads)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<BookDownloads>().HasOne(x => x.Book)
            .WithMany(x => x.BookDownloads)
            .HasForeignKey(x => x.BookId);

        // BookType
        modelBuilder.Entity<BookType>().HasKey(x => x.Id);
        modelBuilder.Entity<BookType>().HasIndex(x => x.ExternalId).IsUnique();

        // BookUpdates
        modelBuilder.Entity<BookUpdates>().HasKey(x => x.Id);
        modelBuilder.Entity<BookUpdates>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<BookUpdates>().HasOne(x => x.Book)
            .WithMany(x => x.BookUpdates)
            .HasForeignKey(x => x.BookId);
        modelBuilder.Entity<BookUpdates>().HasOne(x => x.Employee)
            .WithMany(x => x.BookUpdates)
            .HasForeignKey(x => x.EmployeeId);
        modelBuilder.Entity<BookUpdates>().HasOne(x => x.UpdateType)
            .WithMany(x => x.BookUpdates)
            .HasForeignKey(x => x.UpdateTypeId);

        // Publisher
        modelBuilder.Entity<Publisher>().HasKey(x => x.Id);
        modelBuilder.Entity<Publisher>().HasIndex(x => x.ExternalId).IsUnique();

        // UpdateType
        modelBuilder.Entity<UpdateType>().HasKey(x => x.Id);
        modelBuilder.Entity<UpdateType>().HasIndex(x => x.ExternalId).IsUnique();
    }
}