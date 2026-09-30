using Speech.BusinessLogic.Contracts.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.BusinessLogic.Contracts.Interfaces
{
    public interface ISpeechManager
    {
        Task<IEnumerable<SpeechGroup>> GetSpeechList();
        Task<(string Error, IEnumerable<SpeechGroup> SpeechGroup)> UpdateSpeechGroups(IEnumerable<SpeechGroup> speeches, List<long> dirtyGroup, List<long> dirtyPhrase);
        Task<string> DeleteSpeechGroup(SpeechGroup speech);
        Task<string> DeleteSpeechPhrase(SpeechPhrase phrase);

    }
}
