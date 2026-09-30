using DictionaryManiplate.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManiplate.Model {
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryWord36
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("DictionaryWord_36_Improved_t")]
    public class DictionaryWord36 : IDictionaryWord
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryWord36()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [Key]
        public int DictionaryWordId { get; set; }
        public string Native { get; set; }
        public string Translation { get; set; }
        public string Transcription { get; set; }
        public string ShortTranslation { get; set; }

        public int DictionaryId { get; set; }
        [ForeignKey("DictionaryId")]
        public virtual Dictionary Dictionary { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
