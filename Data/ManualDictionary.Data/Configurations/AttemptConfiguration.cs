using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Configurations
{
    public class AttemptConfiguration : EntityTypeConfiguration<AttemptDao>
    {
          public AttemptConfiguration()
        {
            HasKey(c => c.AttemptId);
            ToTable("Attempt");
            Property(e => e.AttemptId).HasColumnName("AttemptId");
            Property(e => e.SeansId).HasColumnName("SeansId");
            Property(e => e.ErrorLevel).HasColumnName("ErrorLevel");
            Property(e => e.PassNumber).HasColumnName("PassNumber");
            Property(e => e.RemainNumber).HasColumnName("RemainNumber");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasRequired(s => s.Seans).WithMany(e => e.Attempts).HasForeignKey(e => e.AttemptId);
        }
    }
}
