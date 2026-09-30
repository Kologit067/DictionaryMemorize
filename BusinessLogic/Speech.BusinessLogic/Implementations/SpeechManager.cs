using Speech.BusinessLogic.Contracts.Interfaces;
using Speech.BusinessLogic.Contracts.Objects;
using Speech.BusinessLogic.Mappings;
using Speech.Data.Contracts.DAO;
using Speech.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.BusinessLogic.Implementations
{
    public class SpeechManager : ISpeechManager
    {
        private readonly ISpeechRepository _speechRepository;

        public SpeechManager(ISpeechRepository speechRepository)
        {
            _speechRepository = speechRepository;
        }

        public async Task<IEnumerable<SpeechGroup>> GetSpeechList()
        {
            return (await _speechRepository.GetSpeechList()).Map();
        }

        public async Task<(string Error, IEnumerable<SpeechGroup> SpeechGroup)> UpdateSpeechGroups(IEnumerable<SpeechGroup> speeches, List<long> dirtyGroup, List<long> dirtyPhrase)
        {
            var list = speeches.ToEntity().ToList();
            (string Error, IEnumerable<SpeechGroupDao> SpeechGroup) result = await _speechRepository.UpdateSpeechGroups(list, dirtyGroup, dirtyPhrase);
            return (result.Error, result.SpeechGroup.Map());
        }

        public async Task<string> DeleteSpeechGroup(SpeechGroup speech)
        {
            var result = speech.ToEntity();
            return await _speechRepository.DeleteSpeechGroup(result);
        }

        public async Task<string> DeleteSpeechPhrase(SpeechPhrase phrase)
        {
            var result = phrase.ToEntity();
            return await _speechRepository.DeleteSpeechPhrase(result);
        }

    }
}
