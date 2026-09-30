using DictionaryManiplate.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DictionaryManiplate.Model
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("DictionaryWord")]
    public class DictionaryWord : IDictionaryWord
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
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
    //------------------------------------------------------------------------------------------------------------------------------
}
