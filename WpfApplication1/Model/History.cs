using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class History
    //-------------------------------------------------------------------------------------------------------------------
    public class History
    {
        private string userName;
        private bool isDirect;
        private string currentDictionaryForProtocol = DictionaryMemorize.Properties.Settings.Default.DictionaryName;
        private string currentDictionary;
        private Dictionary<string, DictionaryHistory> dictionaryHistories = new Dictionary<string, DictionaryHistory>();
        //-------------------------------------------------------------------------------------------------------------------
        public IEnumerable<string> DictionaryNamesForProtocol
        {
            get
            {
                return dictionaryHistories.Keys.OrderBy(d => d);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsDirect
        {
            get
            {
                return isDirect;
            }
            set
            {
                isDirect = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string CurrentDictionary
        {
            get
            {
                return currentDictionary;
            }
            set
            {
                currentDictionary = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string CurrentDictionaryForProtocol
        {
            get
            {
                return currentDictionaryForProtocol;
            }
            set
            {
                currentDictionaryForProtocol = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Dictionary<string, DictionaryHistory> DictionaryHistories
        {
            get
            {
                return dictionaryHistories;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public History(string pUserName)
        {
            userName = pUserName;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
