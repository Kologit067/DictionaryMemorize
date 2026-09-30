using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManiplate.Model;
using System.Data.SqlClient;
using DictionaryManipulate.TextPocess;
using System.Data;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class FieldRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class FieldRepository
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
        public FieldRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
            try
            {
                dictionaryContext.Database.Connection.Open();
                dictionaryContext.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string="data source=OKOLOMIYETS-N\CRM;initial catalog=Vocabulary;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
            //            dictionaryContext = new DictionaryContext("name=Vocabulary");
            //SqlConnection con = new SqlConnection("Data Source=OKOLOMIYETS-N\\CRM;Initial Catalog=Vocabulary;Integrated Security=true");
            //dictionaryContext = new DictionaryContext(con, true);

        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IEnumerable<Field> List
        {
            get
            {
                return dictionaryContext.Fields;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Field> GetCollection()
        {
            ObservableCollection<Field> collection = new ObservableCollection<Field>();
            foreach (Field f in dictionaryContext.Fields)
                collection.Add(f);
            return collection;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        /*
        public bool SaveFieldWord(Dictionary<int, List<WordCount>> pWordCountDictionary)
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
         */ 
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
