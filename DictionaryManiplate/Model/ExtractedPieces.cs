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
    // class ExtractedPieces
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("ExtractedPieces")]
    public class ExtractedPieces
    {
        public ExtractedPieces()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int ExtractedPiecesId { get; set; }
        [MaxLength(200)]
        public string ExtractedPiecesText { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
