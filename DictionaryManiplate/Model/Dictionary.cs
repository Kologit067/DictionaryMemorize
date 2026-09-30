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
    // class Dictionary
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("Dictionary")]
    public class Dictionary
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public Dictionary()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int DictionaryId { get; set; }
        public string DictionaryName { get; set; }

        public int DictionaryTypeId { get; set; }
        [ForeignKey("DictionaryTypeId")]
        public virtual DictionaryType DictionaryType { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
        public virtual ICollection<DictionaryWord> DictionaryWords { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return DictionaryName;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
