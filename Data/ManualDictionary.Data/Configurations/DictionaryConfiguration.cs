using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class DictionaryConfiguration : EntityTypeConfiguration<DictionaryDao>
    {
        public DictionaryConfiguration()
        {
            HasKey(c => c.DictionaryId);
            ToTable("Dictionary");
            Property(e => e.DictionaryId).HasColumnName("DictionaryId");
            Property(e => e.Name).HasColumnName("Name");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasMany(e => e.DictionaryHistories).WithRequired(e => e.Dictionary).HasForeignKey(e => e.DictionaryId);
            HasMany(e => e.DictionaryWords).WithRequired(e => e.Dictionary).HasForeignKey(e => e.DictionaryId);
        }
    }
}
