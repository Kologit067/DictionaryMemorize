using Speech.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Speech.Data.Contracts.DAO
{
    public class SpeechPhraseDao : IEntityDao
    {
        public long Id => SpeechPhraseId;
        public long SpeechPhraseId { get; set; }
        public long SpeechGroupId { get; set; }
        public string Phrase { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual SpeechGroupDao SpeechGroup { get; set; }

    }
}
