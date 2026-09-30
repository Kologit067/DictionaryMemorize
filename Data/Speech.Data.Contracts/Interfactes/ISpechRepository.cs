using Speech.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Speech.Data.Contracts.Interfactes
{
    public interface ISpeechRepository
    {
        Task<IEnumerable<SpeechGroupDao>> GetSpeechList();
        Task<(string Error, IEnumerable<SpeechGroupDao> SpeechGroups)> UpdateSpeechGroups(IEnumerable<SpeechGroupDao> speechGroups, List<long> dirtyGroup, List<long> dirtyPhrase);
        Task<string> DeleteSpeechGroup(SpeechGroupDao speechGroup);
        Task<string> DeleteSpeechPhrase(SpeechPhraseDao speechPhrase);
    }
}
