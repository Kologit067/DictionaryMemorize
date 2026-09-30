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
    // class FieldWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("FieldWord")]
    public class FieldWord
    {
        public FieldWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int FieldWordId { get; set; }
        [MaxLength(200)]
        public string Word { get; set; }
        public int Count { get; set; }

        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
