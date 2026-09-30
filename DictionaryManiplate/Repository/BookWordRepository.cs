using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManiplate.Model;
using DictionaryManipulate.TextPocess;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class BookWordRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class BookWordRepository
    {
        private Exception error = null;
        private DictionaryContext dictionaryContext;
        //------------------------------------------------------------------------------------------------------------------------------
        public Exception Error
        {
            get
            {
                return error;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public BookWordRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<BookWord> List
        {
            get
            {
                return dictionaryContext.BookWords;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public void Add(BookWord pBookWord)
        {
            dictionaryContext.BookWords.Add(pBookWord);
            dictionaryContext.SaveChanges();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
