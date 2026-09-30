using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class WordStatisticDao : IEntityDao
    {
        public int Id => WordStatisticId;
        public int WordStatisticId { get; set; }

        public int DictionaryHistoryId { get; set; }
        public string Word { get; set; }
        public int Number { get; set; }
        public int IncorrectNumber { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual DictionaryHistoryDao DictionaryHistory { get; set; }
        public virtual ICollection<AttemptStatisticDao> AttemptStatistics { get; set; }
    }
}
