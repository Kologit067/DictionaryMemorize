using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
    public class AttemptDao : IEntityDao
    {
        public int Id => AttemptId;
        public int AttemptId { get; set; }
        public int SeansId { get; set; }
        public int ErrorLevel { get; set; }
        public int PassNumber { get; set; }
        public int RemainNumber { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual SeansDao Seans { get; set; }
    }
}
