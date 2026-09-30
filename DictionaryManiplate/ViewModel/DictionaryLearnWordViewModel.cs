using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DictionaryLibrary.ViewModel;
using System.Windows.Input;
using DictionaryManiplate.Repository;
using DictionaryManiplate.Model;
using System.Collections.ObjectModel;
using DictionaryLibrary.Common;
using DictionaryManipulate.TextPocess;
using DictionaryLibrary.Model;

namespace DictionaryManiplate.ViewModel
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class DictionaryLearnWordViewModel
    //------------------------------------------------------------------------------------------------------------------------------
    public class DictionaryLearnWordViewModel : ViewModelBase
    {
        private string native;
        private string translation;
        private string shortTranslation;
        //------------------------------------------------------------------------------------------------------------------------------
        public DictionaryLearnWordViewModel()
        {
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public string Native
        {
            get
            {
                return native;
            }
            set
            {
                native = value;
                OnPropertyChanged("Native");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public string Translation 
        {
            get
            {
                return translation;
            }
            set
            {
                translation = value;
                OnPropertyChanged("Translation");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public string ShortTranslation
        {
            get
            {
                return shortTranslation;
            }
            set
            {
                shortTranslation = value;
                OnPropertyChanged("ShortTranslation");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
