using ManualDictionary.Data.Contracts.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.Data.Contracts.Interfactes
{
    public interface IManualDictionaryRepository
    {
        Task<string> UpdateDictionariesAndHistories(List<DictionaryDao> dictionaries, List<UsersHistoryDao> usersHistories);
    }
}
