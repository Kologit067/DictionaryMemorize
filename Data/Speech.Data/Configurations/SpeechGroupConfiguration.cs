
using Speech.Data.Contracts.DAO;
using System.Data.Entity.ModelConfiguration;

namespace Speech.Data.Configurations
{
    public class SpeechGroupConfiguration : EntityTypeConfiguration<SpeechGroupDao>
    {
        public SpeechGroupConfiguration()
        {
            HasKey(c => c.SpeechGroupId);
            ToTable("SpeechGroup");
            Property(e => e.Title).HasColumnName("Title");
            Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            Property(e => e.RowVersion).HasColumnName("RowVersion").IsRowVersion();

            HasMany(e => e.SpeechPhrases).WithRequired(e => e.SpeechGroup).HasForeignKey(e => e.SpeechGroupId);
        }
    }
}