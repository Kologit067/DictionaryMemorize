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
using DictionaryLibrary.Model;
using System.Xml.Linq;
using System.IO;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryLearnRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryLearnRepository
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
        public DictionaryLearnRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<DictionaryLearn> List
        {
            get
            {
                return dictionaryContext.DictionaryLearns;
            }
        }
        // //------------------------------------------------------------------------------------------------------------------------------
        //public bool SaveBookWord(Dictionary<int, List<WordCount>> pWordCountDictionary)
        //{
        //    error = null;
        //    try
        //    {
        //        DataTable addedWords = new DataTable();
        //        addedWords.Columns.Add("BookId", System.Type.GetType("System.Int32"));
        //        addedWords.Columns.Add("Word", System.Type.GetType("System.String"));
        //        addedWords.Columns.Add("Count", System.Type.GetType("System.Int32"));

        //        foreach (var wd in pWordCountDictionary)
        //        {
        //            int lBookId = wd.Key;
        //            foreach (var w in wd.Value)
        //                addedWords.Rows.Add(lBookId, w.Word, w.Count);
        //        }

        //        SqlConnection connection = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
        //        connection.Open();
        //        try
        //        {
        //            SqlCommand addCommand = new SqlCommand("addBookWord", connection);
        //            addCommand.CommandType = CommandType.StoredProcedure;
        //            addCommand.CommandTimeout = 1000;
        //            SqlParameter tvpParam = addCommand.Parameters.AddWithValue("@Words", addedWords);
        //            tvpParam.SqlDbType = SqlDbType.Structured;
        //            tvpParam.TypeName = "dbo.BookWordType";
        //            addCommand.ExecuteNonQuery();
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }

        //        connection = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
        //        connection.Open();
        //        try
        //        {
        //            SqlCommand addCommand = new SqlCommand("CreateWordStatistics", connection);
        //            addCommand.CommandType = CommandType.StoredProcedure;
        //            addCommand.CommandTimeout = 700;
        //            addCommand.ExecuteNonQuery();
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex;
        //        return false;
        //    }
        //}
        //------------------------------------------------------------------------------------------------------------------------------
        //public void Add(Book pBook)
        //{
        //    dictionaryContext.Books.Add(pBook);
        //    dictionaryContext.SaveChanges();
        //}
        //------------------------------------------------------------------------------------------------------------------------------
        public void DeleteBook(string pDictionaryName)
        {
            
            SqlConnection con = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = @"  
  DELETE  dlw
  FROM [dbo].[DictionaryLearnWord] dlw
  INNER JOIN [dbo].[DictionaryLearn] dl
  ON dlw.[DictionaryLearnId] = dl.[DictionaryLearnId]
  WHERE dl.DictionaryName = '" + pDictionaryName + @"'
  DELETE  FROM [dbo].[DictionaryLearn] 
  WHERE dl.DictionaryName = '" + pDictionaryName + "'"                               ;
            try
            {
                con.Open();
                try
                {
                    com.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
            }
            
            /*
            DictionaryLearn lDictionaryLearn = dictionaryContext.DictionaryLearns.Where(d => d.DictionaryName.ToLower() == pDictionaryName.ToLower()).FirstOrDefault();
            if (lDictionaryLearn != null)
            {
                List<DictionaryLearnWord> words = lDictionaryLearn.Words.ToList();
                foreach (DictionaryLearnWord w in words)
                {
                    dictionaryContext.Entry(w).State = System.Data.Entity.EntityState.Deleted;    
//                    lDictionaryLearn.Words.Remove(w);
                }
                dictionaryContext.SaveChanges();
            }
            */

        }
        //------------------------------------------------------------------------------------------------------------------------------
        public bool Add(string pDictionaryName, List<Word> pWords)
        {
            error = null;
            var localDictionaryContext = new DictionaryContext("name=Vocabulary");
            localDictionaryContext.Database.Log = (s) =>
                {
                    using (StreamWriter sw = File.AppendText("DictionaryContext.log"))
                    {
                        sw.WriteLine(s);
                    }    
                };
            try
            {
                if (string.IsNullOrEmpty(pDictionaryName))
                    throw new ArgumentException("Name of Dictionary can not be empty.", "pDictionaryName");
                DictionaryLearn lDictionaryLearn = localDictionaryContext.DictionaryLearns.Where(d => d.DictionaryName.ToLower() == pDictionaryName.ToLower()).FirstOrDefault();
                if (lDictionaryLearn == null)
                {
                    lDictionaryLearn = new DictionaryLearn() { DictionaryName = pDictionaryName, Words = new List<DictionaryLearnWord>() };
                    localDictionaryContext.DictionaryLearns.Add(lDictionaryLearn);
                }
//                lDictionaryLearn.Words.Clear();
                var wordForDelete = lDictionaryLearn.Words.Where(wd => !pWords.Any(w => wd.Native == w.Native)).ToList();
                foreach (Word w in pWords)
                {
                    DictionaryLearnWord dlw = lDictionaryLearn.Words.Where(wd => wd.Native.ToLower() == w.Native.ToLower()).FirstOrDefault();
                    if (dlw == null)
                    {
                        dlw = new DictionaryLearnWord() { DictionaryLearn = lDictionaryLearn, Native = w.Native, Translation = w.Translation };
                        lDictionaryLearn.Words.Add(dlw);
                    }
                    else
                    {
                        dlw.Translation = w.Translation;
                    }
                }
                foreach (var w in wordForDelete)
                    lDictionaryLearn.Words.Remove(w);
                localDictionaryContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        internal void SaveToFile(string pNewDictionaryName, List<Word> pWords)
        {
            XDocument docDictionary = CreateXMLFromDictionary(pNewDictionaryName, pWords);
            docDictionary.Save(pNewDictionaryName + ".xml");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static XDocument CreateXMLFromDictionary(string pNewDictionaryName, List<Word> pWords)
        {
            XDocument d = null;
            try
            {
                d = new XDocument(
                    new XElement("Dictionaries",
                        new XElement("Dictionary",
                            new XElement("DictionaryName", pNewDictionaryName),
                    from w in pWords
                    select new XElement("Word",
                        new XElement("Native", w.Native),
                        new XElement("Translation", w.Translation))
                        )));
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            return d;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        internal Tuple<string, List<Word>> LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                XElement elDictionary = XElement.Load(filename);
                return CreateDictionaryFromXML(elDictionary);
            }
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static Tuple<string, List<Word>>  CreateDictionaryFromXML(XElement elDictionary)
        {
//            Dictionary<string, List<Word>> wordDictionaries = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Word>>();
            IEnumerable<XElement> dictionaries = from el in elDictionary.Elements("Dictionary") select el;
            foreach (XElement el in dictionaries)
            {
                try
                {
                    XElement dictNameElement = (from e in el.Elements("DictionaryName") select e).FirstOrDefault();
                    string dictName = (string)dictNameElement;
                    List<Word> wordList = new System.Collections.Generic.List<Word>();
                    IEnumerable<XElement> wordsElement = from e in el.Elements("Word") select e;
                    foreach (XElement e in wordsElement)
                    {
                        XElement nativeElement = (from eo in e.Elements("Native") select eo).FirstOrDefault();
                        XElement translationElement = (from et in e.Elements("Translation") select et).FirstOrDefault();
                        Word w = new Word() { Native = (string)nativeElement, Translation = (string)translationElement };
                        wordList.Add(w);
                    }
                    return Tuple.Create(dictName, wordList);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return null;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
