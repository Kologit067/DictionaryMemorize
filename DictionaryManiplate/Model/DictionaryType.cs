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
    // class DictionaryType
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("DictionaryType")]
    public class DictionaryType
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryType()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int DictionaryTypeId { get; set; }
        public string DictionaryTypeName { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
        public virtual ICollection<Dictionary> Dictionaries { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
