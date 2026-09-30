using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryMemorize.Properties;
using DictionaryMemorize.Model;
using DictionaryLibrary.ViewModel;

namespace DictionaryMemorize.ViewModel
{
    //-------------------------------------------------------------------------------------------------------------------
    // class SettingsViewModel
    //-------------------------------------------------------------------------------------------------------------------
    class SettingsViewModel : ViewModelBase
    {
        private Settings settings;
        private List<string> dictionaryNames = new List<string>();
        //-------------------------------------------------------------------------------------------------------------------
        public SettingsViewModel(Settings pSettings)
        {
            this.settings = pSettings;
            foreach (var d in WordUsersHistory.WordDictionary)
            {
                dictionaryNames.Add(d.Key);
            }
            OnPropertyChanged("DictionaryNames");
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string DictionaryName
        {
            get
            {
                return settings.DictionaryName;
            }
            set
            {
                settings.DictionaryName = value;
                OnPropertyChanged("DictionaryName");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<string> DictionaryNames
        {
            get
            {
                return dictionaryNames;
            }
            set
            {
                dictionaryNames = value;
                OnPropertyChanged("DictionaryNames");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsDirect
        {
            get
            {
                return settings.IsDirect;
            }
            set
            {
                settings.IsDirect = value;
                OnPropertyChanged("IsDirect");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
