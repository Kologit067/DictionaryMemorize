using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManiplate.Model;
using DictionaryManipulate.TextPocess;
using System.Data;
using System.Data.SqlClient;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class WordRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class WordRepository
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
        public WordRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<Book> List
        {
            get
            {
                return dictionaryContext.Books;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public System.Collections.ObjectModel.ObservableCollection<Model.TotalWord> GetCollection()
        {
            ObservableCollection<TotalWord> collection = new ObservableCollection<TotalWord>();
            foreach (TotalWord tw in dictionaryContext.TotalWords)
                collection.Add(tw);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
