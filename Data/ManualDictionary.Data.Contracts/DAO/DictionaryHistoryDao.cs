using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.DAO
{
	public class DictionaryHistoryDao : IEntityDao
	{
		public int Id => DictionaryHistoryId;
		public int DictionaryHistoryId { get; set; }


		public int DictionaryId { get; set; }
		public int UsersHistoryId { get; set; }
		public int AttemptNumber { get; set; }
		public int DoneNumber { get; set; }
		public int DoneNumberCurrent { get; set; }
		public int ErrorLevel { get; set; }
		public int ErrorLevelCurrent { get; set; }
		public int PassNumber { get; set; }
		public int PassNumberCurrent { get; set; }
		public int RemainNumber { get; set; }
		public int State { get; set; }
		public int WordFormsVisible { get; set; }
		public bool IsComplete { get; set; }
		public int IsWorkOnMistakes { get; set; }
		public int WorkOnMistakeRegim { get; set; }
		public int ErrorLevelValue { get; set; }
		public int ErrorLevelRelation { get; set; }
		public int ConsolidatedErrorLevelValue { get; set; }
		public int ConsolidatedErrorLevelRelation { get; set; }
		public byte[] RowVersion { get; set; }
		public virtual ICollection<WordStatisticDao> WordStatistics { get; set; }
		public virtual ICollection<SeansDao> Seanses { get; set; }
		public virtual DictionaryDao Dictionary { get; set; }
		public virtual UsersHistoryDao UsersHistory { get; set; }

	}

}
