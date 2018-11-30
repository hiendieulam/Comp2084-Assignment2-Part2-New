using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Models
{
    public class EFBooks : IBooksMock
    {
        private Bookstore db = new Bookstore();
        public IQueryable<Book> Books { get { return db.Books; } }

        public IQueryable<Author> Authors { get { return db.Authors; } }

        public IQueryable<Category> Categories { get { return db.Categories; } }

        public IQueryable<Publisher> Publishers { get { return db.Publishers; } }

        public void Delete(Book book)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Book Save(Book book)
        {
            if (book.id == 0)
            {
                // Insert
                db.Books.Add(book);
            }
            else
            {
                // Update
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return book;
        }
    }
}