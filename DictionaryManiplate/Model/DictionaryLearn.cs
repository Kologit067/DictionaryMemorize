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
    // class DictionaryLearn
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("DictionaryLearn")]
    public class DictionaryLearn
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryLearn()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int DictionaryLearnId { get; set; }
        public string DictionaryName { get; set; }

        //------------------------------------------------------------------------------------------------------------------------------
        public virtual ICollection<DictionaryLearnWord> Words { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return DictionaryName;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
