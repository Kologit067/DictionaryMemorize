using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class DictionaryWordConfiguration : EntityTypeConfiguration<DictionaryWordDao>
    {
        public DictionaryWordConfiguration()
        {
            HasKey(c => c.DictionaryWordId);
            ToTable("DictionaryWord");
            Property(e => e.DictionaryWordId).HasColumnName("DictionaryWordId");
            Property(e => e.DictionaryId).HasColumnName("DictionaryId");
            Property(e => e.Native).HasColumnName("Native");
            Property(e => e.Translation).HasColumnName("Translation");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasRequired(s => s.Dictionary)
                .WithMany(e => e.DictionaryWords).
                HasForeignKey(e => e.DictionaryId);
        }
    }
}
