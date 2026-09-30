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
    // class WordExceptionRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class WordExceptionRepository
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
        public WordExceptionRepository(DictionaryContext pDictionaryContext)
        {
            dictionaryContext = pDictionaryContext;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public bool SaveWordException(ObservableCollection<ViewModel.DictionaryLearnWordViewModel> pWordDictionaryException)
        {
            error = null;
            try
            {
                DataTable addedExceptions = new DataTable();
                addedExceptions.Columns.Add("Native", System.Type.GetType("System.String"));

                foreach (var w in pWordDictionaryException)
                {
                    addedExceptions.Rows.Add(w.Native);
                }

                SqlConnection connection = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
                connection.Open();
                try
                {
                    SqlCommand addCommand = new SqlCommand("addDictionaryCustomException", connection);
                    addCommand.CommandType = CommandType.StoredProcedure;
                    addCommand.CommandTimeout = 300;
                    SqlParameter tvpParam = addCommand.Parameters.AddWithValue("@Words", addedExceptions);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.WordNativeType";
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
