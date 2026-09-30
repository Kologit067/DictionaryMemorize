using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class DictionaryHistoryConfiguration : EntityTypeConfiguration<DictionaryHistoryDao>
    {
		public DictionaryHistoryConfiguration()
        {
            HasKey(c => c.DictionaryHistoryId);
            ToTable("DictionaryHistory");
            Property(e => e.DictionaryHistoryId).HasColumnName("DictionaryHistoryId");
            Property(e => e.DictionaryId).HasColumnName("DictionaryId");
			Property(e => e.UsersHistoryId).HasColumnName("UsersHistoryId");
			Property(e => e.AttemptNumber).HasColumnName("AttemptNumber");
			Property(e => e.DoneNumber).HasColumnName("DoneNumber");
			Property(e => e.DoneNumberCurrent).HasColumnName("DoneNumberCurrent");
			Property(e => e.ErrorLevel).HasColumnName("ErrorLevel");
			Property(e => e.ErrorLevelCurrent).HasColumnName("ErrorLevelCurrent");
			Property(e => e.PassNumber).HasColumnName("PassNumber");
			Property(e => e.PassNumberCurrent).HasColumnName("PassNumberCurrent");
			Property(e => e.RemainNumber).HasColumnName("RemainNumber");
			Property(e => e.State).HasColumnName("State");
			Property(e => e.WordFormsVisible).HasColumnName("WordFormsVisible");
			Property(e => e.IsComplete).HasColumnName("IsComplete");
			Property(e => e.IsWorkOnMistakes).HasColumnName("IsWorkOnMistakes");
			Property(e => e.WorkOnMistakeRegim).HasColumnName("WorkOnMistakeRegim");
			Property(e => e.ErrorLevelValue).HasColumnName("ErrorLevelValue");
			Property(e => e.ErrorLevelRelation).HasColumnName("ErrorLevelRelation");
			Property(e => e.ConsolidatedErrorLevelValue).HasColumnName("ConsolidatedErrorLevelValue");
			Property(e => e.ConsolidatedErrorLevelRelation).HasColumnName("ConsolidatedErrorLevelRelation");
			Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

			HasMany(e => e.WordStatistics).WithRequired(e => e.DictionaryHistory).HasForeignKey(e => e.DictionaryHistoryId);
			HasMany(e => e.Seanses).WithRequired(e => e.DictionaryHistory).HasForeignKey(e => e.DictionaryHistoryId);
			HasRequired(s => s.Dictionary)
				.WithMany(e => e.DictionaryHistories).
				HasForeignKey(e => e.DictionaryId);
			HasRequired(s => s.UsersHistory)
				.WithMany(e => e.DictionaryHistories).
				HasForeignKey(e => e.UsersHistoryId);
		}
	}
}
