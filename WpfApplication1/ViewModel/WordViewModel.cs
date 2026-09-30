using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryMemorize.Model;
using DictionaryLibrary.ViewModel;
using DictionaryLibrary.Model;

namespace DictionaryMemorize.ViewModel
{
    //-------------------------------------------------------------------------------------------------------------------
    // class WordViewModel
    //-------------------------------------------------------------------------------------------------------------------
    public class WordViewModel : ViewModelBase
    {
        private Word word;
        private string nativeAnswer;
        //-------------------------------------------------------------------------------------------------------------------
        public WordViewModel(Word pWord)
        {
            this.word = pWord;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Word Word
        {
            get
            {
                return word;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string NativeAnswer
        {
            get
            {
                return nativeAnswer;
            }
            set
            {
                nativeAnswer = value;
                OnPropertyChanged("NativeAnswer");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string Native
        {
            get
            {
                return word.Native;
            }
            set
            {
                word.Native = value;
                OnPropertyChanged("Native");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string Translation
        {
            get
            {
                return word.Translation;
            }
            set
            {
                word.Translation = value;
                OnPropertyChanged("Translation");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
