using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.BusinessLogic.Contracts.Objects
{
    public class SpeechPhrase
    {
        public long SpeechPhraseId { get; set; }
        public long SpeechGroupId { get; set; }
        public string Phrase { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
