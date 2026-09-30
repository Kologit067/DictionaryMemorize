using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class AttemptStatisticDao : IEntityDao
    {
        public int Id => AttemptStatisticId;
        public int AttemptStatisticId { get; set; }
        public int WordStatisticId { get; set; }
        public int AttemptNumber { get; set; }
        public int Count { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual WordStatisticDao WordStatistic { get; set; }
    }
 }
