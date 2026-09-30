using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class DictionaryDao : IEntityDao
    {
        public int Id => DictionaryId;
        public int DictionaryId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<DictionaryHistoryDao> DictionaryHistories { get; set; }
        public virtual ICollection<DictionaryWordDao> DictionaryWords { get; set; }
    }
}
