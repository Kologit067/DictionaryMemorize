using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class WordStatisticConfiguration : EntityTypeConfiguration<WordStatisticDao>
    {

        public WordStatisticConfiguration()
        {
            HasKey(c => c.WordStatisticId);
            ToTable("WordStatistic");
            Property(e => e.WordStatisticId).HasColumnName("WordStatisticId");
            Property(e => e.DictionaryHistoryId).HasColumnName("DictionaryHistoryId");
            Property(e => e.Word).HasColumnName("Word");
            Property(e => e.Number).HasColumnName("Number");
            Property(e => e.IncorrectNumber).HasColumnName("IncorrectNumber");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasMany(e => e.AttemptStatistics).WithRequired(e => e.WordStatistic).HasForeignKey(e => e.WordStatisticId);
            HasRequired(s => s.DictionaryHistory)
                .WithMany(e => e.WordStatistics).
                HasForeignKey(e => e.DictionaryHistoryId);

        }
    }
}
