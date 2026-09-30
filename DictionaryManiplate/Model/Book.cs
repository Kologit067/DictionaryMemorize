using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DictionaryManiplate.Model
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class Book
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("Book")]
    public class Book
    {
        public Book()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int BookId { get; set; }
        [MaxLength(200)]
        public string BookName { get; set; }
        public byte[] Tree { get; set; }
        public string Content { get; set; }

        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        public virtual ICollection<BookWord> BookWords { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
