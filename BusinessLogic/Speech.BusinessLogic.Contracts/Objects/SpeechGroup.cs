using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.BusinessLogic.Contracts.Objects
{
    public class SpeechGroup
    {
        public long SpeechGroupId { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
        public IEnumerable<SpeechPhrase> SpeechPhrases { get; set; }
    }
}
