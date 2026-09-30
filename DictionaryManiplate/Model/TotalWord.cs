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
    // class TotalWord
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("TotalWord")]
    public class TotalWord
    {
        public TotalWord()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int TotalWordId { get; set; }
        [MaxLength(200)]
        public string Word { get; set; }
        public int Count { get; set; }

        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
