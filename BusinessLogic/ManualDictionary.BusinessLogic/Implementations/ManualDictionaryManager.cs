using ManualDictionary.BusinessLogic.Contracts.Interfaces;
using ManualDictionary.Data.Contracts.DAO;
using ManualDictionary.Data.Contracts.Interfactes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualDictionary.BusinessLogic.Implementations
{
    public class ManualDictionaryManager : IManualDictionaryManager
    {
        private readonly IManualDictionaryRepository _manualDictionaryManager;

        public ManualDictionaryManager(IManualDictionaryRepository manualDictionaryManager)
        {
            _manualDictionaryManager = manualDictionaryManager;
        }

        public async Task<string> FillDataBase()
        {
            List<DictionaryDao> dictionaries = null;
            List<UsersHistoryDao> usersHistories = null;
            string error = await _manualDictionaryManager.UpdateDictionariesAndHistories(dictionaries, usersHistories);
            return error;
        }
    }
}
