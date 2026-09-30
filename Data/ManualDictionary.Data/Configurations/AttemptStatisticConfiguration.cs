using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class AttemptStatisticConfiguration : EntityTypeConfiguration<AttemptStatisticDao>
    {
 
        public AttemptStatisticConfiguration()
        {
            HasKey(c => c.AttemptStatisticId);
            ToTable("AttemptStatistic");
            Property(e => e.AttemptStatisticId).HasColumnName("AttemptStatisticId");
            Property(e => e.WordStatisticId).HasColumnName("WordStatisticId");
            Property(e => e.AttemptNumber).HasColumnName("AttemptNumber");
            Property(e => e.Count).HasColumnName("Count");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasRequired(s => s.WordStatistic).WithMany(e => e.AttemptStatistics).HasForeignKey(e => e.AttemptStatisticId);
        }
    }
}
