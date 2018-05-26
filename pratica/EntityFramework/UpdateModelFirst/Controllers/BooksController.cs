using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace UpdateModelFirst.Controllers
{
    public class BooksController : ApiController
    {

        public IEnumerable<Book> Get() { 

            var books = new List<Book>();

            using (var connection = new EntityConnection("name=DataContext")) {

                connection.Open();

                string esqlQuery = @"SELECT VALUE books FROM DataContext.Books AS books";

                using (var command  = connection.CreateCommand())
                {

                    command.CommandText = esqlQuery;

                    using (var dataReader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        while (dataReader.Read())
                        {
                            var book = new Book();

                            book.BookId = (int)dataReader["BookId"];
                            book.Isbn = dataReader["Isbn"] as string;
                            book.Title = dataReader["Title"] as string;

                            books.Add(book);
                        }
                    }
                }

                connection.Close();

            }

            return books;

        }

    }
}
