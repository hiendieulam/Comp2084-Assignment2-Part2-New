namespace Book_Store.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bookstore : DbContext
    {
        public Bookstore()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.author_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.prise)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.publish_name)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.company_name)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.publisher_id)
                .WillCascadeOnDelete(false);
        }
    }
}
