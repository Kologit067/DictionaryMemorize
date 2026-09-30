using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
	public class SeansDao : IEntityDao
	{
		public int Id => AttemptStatisticId;
		public int AttemptStatisticId { get; set; }
		public int SeansId { get; set; }


		public int DictionaryHistoryId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int ErrorLevel { get; set; }
		public bool IsWorkOnMistakes { get; set; }
		public byte[] RowVersion { get; set; }
		public virtual DictionaryHistoryDao DictionaryHistory { get; set; }
		public virtual ICollection<AttemptDao> Attempts { get; set; }
	}

}
