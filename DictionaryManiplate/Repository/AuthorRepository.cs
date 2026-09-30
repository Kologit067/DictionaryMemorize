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
    // class AuthorRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class AuthorRepository
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
        public AuthorRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<Author> List
        {
            get
            {
                return dictionaryContext.Authors;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Author> GetCollection()
        {
            ObservableCollection<Author> collection = new ObservableCollection<Author>();
            foreach (Author a in dictionaryContext.Authors)
                collection.Add(a);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public bool SaveAuthorWord(Dictionary<int, List<WordCount>> pWordCountDictionary)
        {
            error = null;
            try
            {
                DataTable addedWords = new DataTable();
                addedWords.Columns.Add("BookId", System.Type.GetType("System.Int32"));
                addedWords.Columns.Add("Word", System.Type.GetType("System.String"));
                addedWords.Columns.Add("Count", System.Type.GetType("System.Int32"));

                foreach (var wd in pWordCountDictionary)
                {
                    int lBookId = wd.Key;
                    foreach (var w in wd.Value)
                        addedWords.Rows.Add(lBookId, w.Word, w.Count);
                }

                SqlConnection connection = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
                connection.Open();
                try
                {
                    SqlCommand addCommand = new SqlCommand("addBookWord", connection);
                    addCommand.CommandType = CommandType.StoredProcedure;
                    addCommand.CommandTimeout = 300;
                    SqlParameter tvpParam = addCommand.Parameters.AddWithValue("@Words", addedWords);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.BookWordType";
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
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
