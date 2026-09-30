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
    // class DictionaryLearnWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("DictionaryLearnWord")]
    public class DictionaryLearnWord
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryLearnWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int DictionaryLearnWordId { get; set; }
        public string Native { get; set; }
        public string Translation { get; set; }

        public int DictionaryLearnId { get; set; }
        [ForeignKey("DictionaryLearnId")]
        public virtual DictionaryLearn DictionaryLearn { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
