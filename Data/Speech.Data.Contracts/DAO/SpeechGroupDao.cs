using Speech.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Speech.Data.Contracts.DAO
{
    public class SpeechGroupDao : IEntityDao
    {
        public long Id => SpeechGroupId;
        public long SpeechGroupId { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<SpeechPhraseDao> SpeechPhrases { get; set; }

    }
}
