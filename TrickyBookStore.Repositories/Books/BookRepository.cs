using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories;


namespace TrickyBookStore.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        public IList<Book> GetBooks(params long[] ids)
        {
            var bookStore = Store.Books.Data;
            var books = bookStore.Where(x => ids.Contains(x.Id));
            return books.ToList();
            throw new NotImplementedException();
        }
    }
}
