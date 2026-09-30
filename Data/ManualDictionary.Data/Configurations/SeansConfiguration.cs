using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class SeansConfiguration : EntityTypeConfiguration<SeansDao>
    {
        public SeansConfiguration()
        {
            HasKey(c => c.SeansId);
            ToTable("Seans");
            Property(e => e.SeansId).HasColumnName("SeansId");
            Property(e => e.DictionaryHistoryId).HasColumnName("DictionaryHistoryId");
            Property(e => e.StartTime).HasColumnName("StartTime");
            Property(e => e.EndTime).HasColumnName("EndTime");
            Property(e => e.ErrorLevel).HasColumnName("ErrorLevel");
            Property(e => e.IsWorkOnMistakes).HasColumnName("IsWorkOnMistakes");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasMany(e => e.Attempts).WithRequired(e => e.Seans).HasForeignKey(e => e.SeansId);
            HasRequired(s => s.DictionaryHistory)
                .WithMany(e => e.Seanses).
                HasForeignKey(e => e.DictionaryHistoryId);
        }
    }
}
