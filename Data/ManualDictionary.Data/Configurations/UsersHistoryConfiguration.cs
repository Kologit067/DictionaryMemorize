using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class UsersHistoryConfiguration : EntityTypeConfiguration<UsersHistoryDao>
    {
         public UsersHistoryConfiguration()
        {
            HasKey(c => c.AttemptStatisticId);
            ToTable("AttemptStatistic");
            Property(e => e.AttemptStatisticId).HasColumnName("AttemptStatisticId");
            Property(e => e.UsersHistoryId).HasColumnName("UsersHistoryId");
            Property(e => e.UserName).HasColumnName("UserName");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasMany(e => e.DictionaryHistories).WithRequired(e => e.UsersHistory).HasForeignKey(e => e.UsersHistoryId);
        }
    }
}
