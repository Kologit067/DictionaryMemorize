using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManiplate.Model;
using System.ComponentModel.DataAnnotations.Schema;
using DictionaryManipulate.TextPocess;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryLearnCandidatWordRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryLearnCandidatWordRepository
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
        public DictionaryLearnCandidatWordRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public List<DictionaryLearnCandidatWord> GetCandidatWordByBookOrderedByCount(int pBookId)
        {
            IEnumerable<DictionaryLearnCandidatWord> words = dictionaryContext.DictionaryLearnCandidatWords.Where( cw => cw.BookId == pBookId).OrderByDescending(w => w.Count).ThenBy(w => w.Native);

            return words.ToList();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<DictionaryLearnCandidatWord> GetCandidatWordByBook(int pBookId)
        {
            IEnumerable<DictionaryLearnCandidatWord> words = dictionaryContext.DictionaryLearnCandidatWords.Where( cw => cw.BookId == pBookId);

            return words;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public List<DictionaryLearnCandidatWord> GetCandidatWordByBooks(List<int> pBooks)
        {
            List<DictionaryLearnCandidatWord> words = dictionaryContext.DictionaryLearnCandidatWords.Where(cw => pBooks.Contains(cw.BookId)).ToList();


            var group = from w in words
                        group w by new { w.Native, w.Translation, w.ShortTranslation} into g
                        select new DictionaryLearnCandidatWord() { Native = g.Key.Native, Translation = g.Key.Translation, ShortTranslation = g.Key.ShortTranslation, Count = g.Sum(wi => wi.Count) };

            return group.OrderByDescending(w => w.Count).ThenBy(w => w.Native).ToList();
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
