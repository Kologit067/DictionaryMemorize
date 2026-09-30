using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class UsersHistoryDao : IEntityDao
    {
        public int Id => AttemptStatisticId;
        public int AttemptStatisticId { get; set; }
        public int UsersHistoryId { get; set; }
        public string UserName { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<DictionaryHistoryDao> DictionaryHistories { get; set; }
    }
 
}
