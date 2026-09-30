using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManiplate.Model
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class WordInBooks
    //------------------------------------------------------------------------------------------------------------------------------
    public class WordInBooks
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public WordInBooks()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public WordInBooks(string pBookName, string pAuthorName, string pFieldName, int pCount)
        {
            BookName = pBookName;
            AuthorName = pAuthorName;
            FieldName = pFieldName;
            Count = pCount;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string FieldName { get; set; }
        public int Count { get; set; }
        public double CountRelation { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
