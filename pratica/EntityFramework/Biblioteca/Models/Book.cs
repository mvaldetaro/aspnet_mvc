using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}