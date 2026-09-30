using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManiplate.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using DictionaryManiplate.Contract;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryWordRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryWordRepository
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
        public DictionaryWordRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<DictionaryWord> List
        {
            get
            {
                return dictionaryContext.DictionaryWords;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public List<DictionaryWord> GetWordOfDictionaryCollection(int pDictionaryId)
        {
            List<DictionaryWord> collection = new List<DictionaryWord>();
            foreach (DictionaryWord d in dictionaryContext.DictionaryWords.Where(dw => dw.DictionaryId == pDictionaryId).OrderBy(dw => dw.Native))
                collection.Add(d);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public List<IDictionaryWord> GetWordOfIDictionaryCollection(int pDictionaryId)
        {
            List<IDictionaryWord> collection = new List<IDictionaryWord>();
            foreach (DictionaryWord d in dictionaryContext.DictionaryWords.Where(dw => dw.DictionaryId == pDictionaryId).OrderBy(dw => dw.Native))
                collection.Add(d);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public List<IDictionaryWord> GetWordOfDictionary36Collection() {
            List<IDictionaryWord> collection = new List<IDictionaryWord>();
            foreach (IDictionaryWord d in dictionaryContext.DictionaryWord36.OrderBy(dw => dw.Native)) {
                d.ShortTranslation = d.ShortTranslation.Trim();
                d.Translation = d.Translation.Trim();
                collection.Add(d);
            }
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WordInBooks> GetWordInBooksList(string pNative, bool pIsExt)
        {
            ObservableCollection<WordInBooks> lResult = new ObservableCollection<WordInBooks>();
            IEnumerable<WordInBooks> bookCountQuery;
            if ( pIsExt)
                bookCountQuery = from bwa in dictionaryContext.BookWords
                                 join ba in dictionaryContext.Books on bwa.BookId equals ba.BookId
                                 group bwa by bwa.BookId into bGroup
                                 join bw in dictionaryContext.BookWords on bGroup.Key equals bw.BookId
                                 join b in dictionaryContext.Books on bw.BookId equals b.BookId
                                 join a in dictionaryContext.Authors on b.AuthorId equals a.AuthorId
                                 join f in dictionaryContext.Fields on b.FieldId equals f.FieldId
                                 join bwa in dictionaryContext.BookWords on b.BookId equals bwa.BookId
                                 where bw.Word == pNative
                                 select new WordInBooks() { BookName = b.BookName, AuthorName = a.AuthorName, FieldName = f.FieldName, Count = bw.Count, CountRelation = Math.Round((double)bw.Count / (double)bGroup.Sum(c => c.Count),6) };
            else
                bookCountQuery = from bw in dictionaryContext.BookWords
                                 join b in dictionaryContext.Books on bw.BookId equals b.BookId
                                 join a in dictionaryContext.Authors on b.AuthorId equals a.AuthorId
                                 join f in dictionaryContext.Fields on b.FieldId equals f.FieldId
                                 where bw.Word == pNative
                                 select new WordInBooks() { BookName = b.BookName, AuthorName = a.AuthorName, FieldName = f.FieldName, Count = bw.Count };

            foreach (var wib in bookCountQuery)
                lResult.Add(wib);
            return lResult;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
