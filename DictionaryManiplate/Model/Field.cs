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
    // class Field
    //------------------------------------------------------------------------------------------------------------------------------
    [Table("Field")]
    public class Field
    {
        public Field()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public int FieldId { get; set; }
        [MaxLength(200)]
        public string FieldName { get; set; }
        public byte[] Tree { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<FieldWord> FieldWords { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return FieldName;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
