using Speech.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.Data.Configurations
{
    public class SpeechPhraseConfiguration : EntityTypeConfiguration<SpeechPhraseDao>
    {
        public SpeechPhraseConfiguration()
        {
            HasKey(c => c.SpeechPhraseId);
            ToTable("SpeechPhrase");
            Property(e => e.SpeechGroupId).HasColumnName("SpeechGroupId");
            Property(e => e.Phrase).HasColumnName("Phrase");
            Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasRequired(s => s.SpeechGroup)
                            .WithMany(e => e.SpeechPhrases).
                            HasForeignKey(e => e.SpeechGroupId);

        }
    }
}
