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
    // class DictionaryLearnCandidatWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("vwDictionaryLearnCandidatWord")]
    public class DictionaryLearnCandidatWord
    {
        //------------------------------------------------------------------------------------------------------------------------------
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int DictionaryWordId { get; set; }
        public string Native { get; set; }
        public string ShortTranslation { get; set; }
        public int Count { get; set; }
        public string Translation { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryLearnCandidatWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
