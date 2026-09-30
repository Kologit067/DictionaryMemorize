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
    // class AuthorWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("AuthorWord")]
    public class AuthorWord
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public AuthorWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int AuthorWordId { get; set; }
        [MaxLength(200)]
        public string Word { get; set; }
        public int Count { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
