using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.Common;
using DictionaryManiplate.Model;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryContext
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryContext : DbContext 
    {
        public DictionaryContext(string pConnectionString) : base(pConnectionString) { }
        public DictionaryContext(DbConnection pConnection, bool contextOwnsConnection) : base(pConnection, contextOwnsConnection) { }
        //------------------------------------------------------------------------------------------------------------------------------
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<AuthorWord> AuthorWords { get; set; }
        public DbSet<BookWord> BookWords { get; set; }
        public DbSet<FieldWord> FieldWords { get; set; }
        public DbSet<TotalWord> TotalWords { get; set; }
        public DbSet<DictionaryWord> DictionaryWords { get; set; }
        public DbSet<DictionaryWord36> DictionaryWord36 { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<DictionaryType> DictionaryTypes { get; set; }
        public DbSet<DictionaryLearn> DictionaryLearns { get; set; }
        public DbSet<DictionaryLearnCandidatWord> DictionaryLearnCandidatWords { get; set; }
        public DbSet<ExtractedPieces> ExtractedPiecesSet { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
