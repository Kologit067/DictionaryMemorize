using Speech.BusinessLogic.Contracts.Objects;
using Speech.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.BusinessLogic.Mappings
{
    public static class SpeechPhraseMappings
    {
        public static SpeechPhrase Map(this SpeechPhraseDao input)
        {
            return input == null
                ? null
                : new SpeechPhrase()
                {
                    SpeechPhraseId = input.SpeechPhraseId,
                    SpeechGroupId = input.SpeechGroupId,
                    Phrase = input.Phrase,
                    IsDeleted = input.IsDeleted,
                    RowVersion = input.RowVersion
                };
        }
        public static SpeechPhraseDao ToEntity(this SpeechPhrase input)
        {
            return input == null
                ? null
                : new SpeechPhraseDao()
                {
                    SpeechPhraseId = input.SpeechPhraseId,
                    SpeechGroupId = input.SpeechGroupId,
                    Phrase = input.Phrase,
                    IsDeleted = input.IsDeleted,
                    RowVersion = input.RowVersion
                };
        }

        public static IEnumerable<SpeechPhrase> Map(this IEnumerable<SpeechPhraseDao> input) => input?.Select(i => i.Map());

        public static IEnumerable<SpeechPhraseDao> ToEntity(this IEnumerable<SpeechPhrase> input) => input?.Select(i => i.ToEntity());


    }
}
