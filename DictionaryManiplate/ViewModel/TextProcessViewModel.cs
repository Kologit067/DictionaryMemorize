using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManipulate.TextPocess;
using DictionaryManipulate.ViewModel;
using System.Windows.Input;
using System.Text.RegularExpressions;
using DictionaryLibrary.ViewModel;

namespace DictionaryManipulate.ViewModel
{
    //-------------------------------------------------------------------------------------------------------------------
    // class TextProcessViewModel
    //-------------------------------------------------------------------------------------------------------------------
    public class TextProcessViewModel : ViewModelBase
    {
        private string textToProcess;
        private List<WordCount> wordCountList;
        //-------------------------------------------------------------------------------------------------------------------
        public string TextToProcess
        {
            get
            {
                return textToProcess;
            }
            set
            {
                textToProcess = value;
                OnPropertyChanged("TextToProcess");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<WordCount> WordCountList
        {
            get
            {
                return wordCountList;
            }
            set
            {
                wordCountList = value;
                OnPropertyChanged("WordCountList");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public TextProcessViewModel()
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand textProcessCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand TextProcessCommand
        {
            get
            {
                if (textProcessCommand == null)
                {
                    textProcessCommand = new DelegateCommand(TextProcessAction, CanTextProcessAction);
                }
                return textProcessCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void TextProcessAction()
        {
            Task<List<WordCount>> task = new Task<List<WordCount>>(() =>
            {
                return TextProcessTreeApproach(TextToProcess);
            });
            task.Start();
            //                List<DictionaryLearnCandidatWord> list = dictionaryLearnCandidatWordRepository.GetCandidatWordByBookOrderedByCount(SelectedBookForDictionary.BookId);
            List<WordCount> list = await task;
            WordCountList = list;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<WordCount> TextProcessTreeApproach(string pTextToProcess)
        {
            TextProcess textProcess = new TextProcess();
            List<WordCount> result = textProcess.TextProcessT(pTextToProcess);
            return result;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<WordCount> TextProcessDictionaryApproach(string pTextToProcess)
        {
            List<WordCount> lWordCountList = new List<WordCount>();
            Dictionary<string, int> wordDictionary = new Dictionary<string, int>();
            string[] words = DictionaryManipulate.TextPocess.TextProcess.CreateInitialWordList(pTextToProcess);
            foreach (string w in words)
            {
                string word = w.ToLower();
                if (wordDictionary.ContainsKey(word))
                    wordDictionary[word]++;
                else
                    wordDictionary.Add(word, 1);
            }
            foreach (var p in wordDictionary)
            {
                lWordCountList.Add(new WordCount(p.Key, p.Value));
            }
            lWordCountList.Sort();
            return lWordCountList;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanTextProcessAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
