using Speech.BusinessLogic.Contracts.Objects;
using Speech.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speech.BusinessLogic.Mappings
{
    public static class SpeechGroupMappings
    {
        public static SpeechGroup Map(this SpeechGroupDao input)
        {
            return input == null
                ? null
                : new SpeechGroup()
                {
                    SpeechGroupId = input.SpeechGroupId,
                    Title = input.Title,
                    IsDeleted = input.IsDeleted,
                    RowVersion = input.RowVersion,
                    SpeechPhrases = input.SpeechPhrases.Map().ToList()
                };
        }
        public static SpeechGroupDao ToEntity(this SpeechGroup input)
        {
            return input == null
                ? null
                : new SpeechGroupDao()
                {
                    SpeechGroupId = input.SpeechGroupId,
                    Title = input.Title,
                    IsDeleted = input.IsDeleted,
                    RowVersion = input.RowVersion,
                    SpeechPhrases = input.SpeechPhrases.ToEntity().ToList()
                };
        }

        public static IEnumerable<SpeechGroup> Map(this IEnumerable<SpeechGroupDao> input) => input?.Select(i => i.Map());

        public static IEnumerable<SpeechGroupDao> ToEntity(this IEnumerable<SpeechGroup> input) => input?.Select(i => i.ToEntity());

    }
}
