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
    // class BookWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("BookWord")]
    public class BookWord
    {
        public BookWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int BookWordId { get; set; }
        [MaxLength(200)]
        public string Word { get; set; }
        public int Count { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
