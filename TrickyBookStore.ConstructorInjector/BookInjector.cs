using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Models;

namespace TrickyBookStore.Main
{
    public class BookInjector
    {
        private IBookService _bookService;
        public BookInjector(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IList<Book> GetBooks(params long[] ids)
        {
            return _bookService.GetBooks(ids);
        }
    }
}
