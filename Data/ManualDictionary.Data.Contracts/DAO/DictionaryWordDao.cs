using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class DictionaryWordDao : IEntityDao
    {
        public int Id => DictionaryWordId;
        public int DictionaryWordId { get; set; }


        public int DictionaryId { get; set; }
        public string Native { get; set; }
        public string Translation { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual DictionaryDao Dictionary { get; set; }
    }
 
}
