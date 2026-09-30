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
    // class Author
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("Author")]
    public class Author
    {
        public Author()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int AuthorId { get; set; }
        [MaxLength(200)]
        public string AuthorName { get; set; }
        public byte[] Tree { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<AuthorWord> AuthorWords { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
