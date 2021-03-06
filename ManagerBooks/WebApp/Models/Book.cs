//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Authors = new HashSet<Author>();
        }
    
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "ISBN deve conter apenas n�meros")]
        public string Isbn { get; set; }
        [Required]
        public string Ano { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public int SelectedAuthorId { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
