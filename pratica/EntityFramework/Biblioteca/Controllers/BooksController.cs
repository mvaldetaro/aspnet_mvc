using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class BooksController : ApiController
    {
        private DataContext _dataContext;

        public BooksController()
        {
            _dataContext = new DataContext();
        }

        public IEnumerable<Book> Get()
        {
            return _dataContext.Books;
        }

        public void Post(Book book)
        {
            if(book != null)
            {
                _dataContext.Books.Add(book);
                _dataContext.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {

            if(disposing && _dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }

            base.Dispose(disposing);
        }
    }
}