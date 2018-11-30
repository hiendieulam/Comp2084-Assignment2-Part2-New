using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Models
{
    public interface IBooksMock
    {
        IQueryable<Book> Books { get; }
        IQueryable<Author> Authors { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Publisher> Publishers { get; }

        Book Save(Book book);
        void Delete(Book book);
        void Dispose();
    }
}
