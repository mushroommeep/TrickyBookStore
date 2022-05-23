using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Books;

namespace TrickyBookStore.Services.Books
{
    public class BookService : IBookService
    {
        IBookRepository BookRepository;

        public BookService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public IList<Book> GetBooks(params long[] ids)
        {
            return BookRepository.GetBooks(ids);
            throw new NotImplementedException();
        }
    }
}
