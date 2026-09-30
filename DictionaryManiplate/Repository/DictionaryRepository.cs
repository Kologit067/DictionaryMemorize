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

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryRepository
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
        public DictionaryRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<Dictionary> List
        {
            get
            {
                return dictionaryContext.Dictionaries;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public System.Collections.ObjectModel.ObservableCollection<Model.Dictionary> GetCollection()
        {
            ObservableCollection<Dictionary> collection = new ObservableCollection<Dictionary>();
            foreach (Dictionary d in dictionaryContext.Dictionaries)
                collection.Add(d);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        internal ObservableCollection<Dictionary> GetCollectionOfENG_RUS()
        {
            ObservableCollection<Dictionary> collection = new ObservableCollection<Dictionary>();
            foreach (Dictionary d in dictionaryContext.Dictionaries.Where(d => d.DictionaryTypeId == 1))
                collection.Add(d);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public Dictionary GetDictionary(string pDictionaryTypeName, string pDictionaryName)
        {
            error = null;
            try
            {
                if (string.IsNullOrEmpty(pDictionaryTypeName))
                    throw new ArgumentException("Name of DictionaryTypeName can not be empty.", "pDictionaryTypeName");
                if (string.IsNullOrEmpty(pDictionaryName))
                    throw new ArgumentException("DictionaryName can not be empty.", "pDictionaryName");

                DictionaryType lDictionaryType = dictionaryContext.DictionaryTypes.Where(t => t.DictionaryTypeName.ToLower() == pDictionaryTypeName.ToLower()).FirstOrDefault();
                if (lDictionaryType == null)
                {
                    lDictionaryType = new DictionaryType() { DictionaryTypeName = pDictionaryTypeName };
                    dictionaryContext.DictionaryTypes.Add(lDictionaryType);
                }
                Dictionary lDictionary = dictionaryContext.Dictionaries.Where(d => d.DictionaryName.ToLower() == pDictionaryName.ToLower() && d.DictionaryType.DictionaryTypeName.ToLower() == pDictionaryTypeName.ToLower()).FirstOrDefault();
                if (lDictionary == null)
                {
                    lDictionary = new Dictionary() { DictionaryName = pDictionaryName, DictionaryType = lDictionaryType };
                    dictionaryContext.Dictionaries.Add(lDictionary);
                }
                else
                {
                    lDictionary.DictionaryName = pDictionaryName;
                }
                dictionaryContext.SaveChanges();
                
                return lDictionary;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public bool Add(IEnumerable<DictionaryWord> pDictionaryWords)
        {
            error = null;
            try
            {
                DataTable addedWords = new DataTable();
                addedWords.Columns.Add("Native", System.Type.GetType("System.String"));
                addedWords.Columns.Add("Translation", System.Type.GetType("System.String"));
                addedWords.Columns.Add("Transcription", System.Type.GetType("System.String"));
                addedWords.Columns.Add("ShortTranslation", System.Type.GetType("System.String"));
                addedWords.Columns.Add("DictionaryId", System.Type.GetType("System.Int32"));

                foreach (DictionaryWord w in pDictionaryWords)
                    addedWords.Rows.Add(w.Native, w.Translation, w.Transcription, w.ShortTranslation, w.Dictionary.DictionaryId);

                SqlConnection connection = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
                connection.Open();
                try
                {
                    SqlCommand addCommand = new SqlCommand("addDictionaryWords", connection);
                    addCommand.CommandType = CommandType.StoredProcedure;
                    addCommand.CommandTimeout = 300;
                    SqlParameter tvpParam = addCommand.Parameters.AddWithValue("@Words", addedWords);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.DictionaryWordType";
                    addCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        ////------------------------------------------------------------------------------------------------------------------------------
        //public bool Add(IEnumerable<DictionaryWord> pDictionaryWords)
        //{
        //    error = null;
        //    try
        //    {
        //        //var newWords = pDictionaryWords.Where(w =>
        //        //    !dictionaryContext.DictionaryWords.Any(cw => String.Compare(cw.Native, w.Native, true) == 0
        //        //        && String.Compare(cw.Dictionary.DictionaryName, w.Dictionary.DictionaryName, true) == 0
        //        //        && String.Compare(cw.Dictionary.DictionaryType.DictionaryTypeName, w.Dictionary.DictionaryType.DictionaryTypeName, true) == 0)).ToList();
        //        var newWords = pDictionaryWords.Where(w => 
        //            !dictionaryContext.DictionaryWords.Any(cw => cw.Native == w.Native && cw.Dictionary.DictionaryId == w.Dictionary.DictionaryId)).ToList();
        //        foreach (DictionaryWord dw in newWords)
        //            dictionaryContext.DictionaryWords.Add(dw);
        //        dictionaryContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex;
        //        return false;
        //    }
        //}
        //------------------------------------------------------------------------------------------------------------------------------
        public bool AddDictionaryWord(string pNative, string pTranslation, string pShortTranslation, string pTranscript, Dictionary pDictionary)
        {
            error = null;
            try
            {
                //var newWords = pDictionaryWords.Where(w =>
                //    !dictionaryContext.DictionaryWords.Any(cw => String.Compare(cw.Native, w.Native, true) == 0
                //        && String.Compare(cw.Dictionary.DictionaryName, w.Dictionary.DictionaryName, true) == 0
                //        && String.Compare(cw.Dictionary.DictionaryType.DictionaryTypeName, w.Dictionary.DictionaryType.DictionaryTypeName, true) == 0)).ToList();
                //DictionaryWord dw = dictionaryContext.DictionaryWords.Where(cw => cw.Native == pNative && cw.Dictionary.DictionaryName == pDictionary.DictionaryName).FirstOrDefault();
                DictionaryWord dw = dictionaryContext.DictionaryWords.Where(cw => cw.Native == pNative && cw.Dictionary.DictionaryId == pDictionary.DictionaryId).FirstOrDefault();
                //DictionaryWord dw = dictionaryContext.DictionaryWords.Where(cw => cw.Native == pNative &&
                //    cw.Dictionary.DictionaryName == pDictionary.DictionaryName &&
                //    cw.Dictionary.DictionaryType.DictionaryTypeName == pDictionary.DictionaryType.DictionaryTypeName).FirstOrDefault();
                if (dw == null)
                {
                    dw = new DictionaryWord() { Native = pNative, Translation = pTranslation, ShortTranslation = pShortTranslation, Dictionary = pDictionary, Transcription = pTranscript };
                    dictionaryContext.DictionaryWords.Add(dw);
                }
                else
                {
                    dw.Transcription = pTranslation;
                    dw.ShortTranslation = pShortTranslation;
                    dw.Translation = pTranscript;
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
