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
    // class ExtractedPiecesRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class ExtractedPiecesRepository
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
        public ExtractedPiecesRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<ExtractedPieces> List
        {
            get
            {
                return dictionaryContext.ExtractedPiecesSet;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<ExtractedPieces> GetCollection()
        {
            ObservableCollection<ExtractedPieces> collection = new ObservableCollection<ExtractedPieces>();
            foreach (ExtractedPieces a in dictionaryContext.ExtractedPiecesSet)
                collection.Add(a);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
