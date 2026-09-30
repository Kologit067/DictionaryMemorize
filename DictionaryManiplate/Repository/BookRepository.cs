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
    // class BookRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class BookRepository
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
        public BookRepository(DictionaryContext pDictionaryContext)
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
        public IEnumerable<Book> GetUnProcessedBooks()
        {
            IEnumerable<IGrouping<int, BookWord>> bookinbookword = dictionaryContext.BookWords.ToList().GroupBy(bw => bw.BookId); 
            List<int> bookids = bookinbookword.Select((g, b) => g.Key).ToList();
            List<Book> bookList = dictionaryContext.Books.ToList();
            IEnumerable<Book> query = from b in bookList
                                      join bi in bookids on b.BookId equals bi into gj
                                      where gj.DefaultIfEmpty() == null || gj.Count() == 0
                                      select b;

            return query;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public bool SaveBookWord(Dictionary<int, List<WordCount>> pWordCountDictionary)
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
                    addCommand.CommandTimeout = 1000;
                    SqlParameter tvpParam = addCommand.Parameters.AddWithValue("@Words", addedWords);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.BookWordType";
                    addCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                connection = new SqlConnection(dictionaryContext.Database.Connection.ConnectionString);
                connection.Open();
                try
                {
                    SqlCommand addCommand = new SqlCommand("CreateWordStatistics", connection);
                    addCommand.CommandType = CommandType.StoredProcedure;
                    addCommand.CommandTimeout = 700;
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
        public void Add(Book pBook)
        {
            dictionaryContext.Books.Add(pBook);
            dictionaryContext.SaveChanges();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public bool Add(Field pField, string pAuthorName, string pBookName, string pContent)
        {
            error = null;
            try
            {
                if (string.IsNullOrEmpty(pAuthorName))
                    throw new ArgumentException("Name of Author can not be empty.", "pAuthorName");
                if (string.IsNullOrEmpty(pBookName))
                    throw new ArgumentException("Title can not be empty.", "pBookName");
                if (string.IsNullOrEmpty(pContent))
                    throw new ArgumentException("Content can not be empty.", "pContent");
                Book lBook = dictionaryContext.Books.Where(b => b.BookName.ToLower() == pBookName.ToLower() && b.Author.AuthorName.ToLower() == pAuthorName.ToLower()).FirstOrDefault();
                if (lBook != null)
                {
                    throw new InvalidOperationException("Repeated title of book " + pBookName);
                }
                Author lAuthor = dictionaryContext.Authors.Where(a => a.AuthorName.ToLower() == pAuthorName.ToLower()).FirstOrDefault();
                if (lAuthor == null)
                {
                    lAuthor = new Author() { AuthorName = pAuthorName };
                    dictionaryContext.Authors.Add(lAuthor);
                }
                lBook = new Book() { Field = pField, Author = lAuthor, BookName = pBookName, Content = pContent };
                dictionaryContext.Books.Add(lBook);
                dictionaryContext.SaveChanges();
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
