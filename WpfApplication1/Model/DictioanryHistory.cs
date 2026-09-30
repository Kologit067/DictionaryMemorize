using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DictionaryLibrary.Model;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryHistory
    //-------------------------------------------------------------------------------------------------------------------
    public class DictionaryHistory
    {
        private string dictionaryName;
        private ObservableCollection<Seans> seanses = new ObservableCollection<Seans>();
        private State state;
        private int numberWordInDictionary;
//        private Dictionary<string, WordStatistic> wordStatistics = new Dictionary<string, WordStatistic>();
        private ObservableCollection<WordStatistic> wordStatistics = new ObservableCollection<WordStatistic>();
        public const int NumberOfLastSeansForCalculation = 10;
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryHistory(string pDictionaryName)
        {
            dictionaryName = pDictionaryName;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string DictionaryName
        {
            get
            {
                return dictionaryName;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Seans> Seanses
        {
            get
            {
                return seanses;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public State State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int NumberWordInDictionary
        {
            get
            {
                return numberWordInDictionary;
            }
            set
            {
                numberWordInDictionary = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WordStatistic> WordStatistics
        {
            get
            {
                return wordStatistics;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DateTime? LastSeanseDate
        {
            get
            {
                return Seanses.Where(s => s.Attempts.Count > 0 && s.Attempts[0].InputNumber == NumberWordInDictionary).OrderBy(s => s.EndTime).Select(s => s.EndTime).LastOrDefault();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal AverageIncorrectNumberBySeanse
        {
            get
            {
                var query = Seanses.Where(s => s.Attempts.Count > 0 && s.Attempts[0].InputNumber == NumberWordInDictionary);
                if (query.Count() == 0)
                    return 0;
                decimal sumIncorrectNumber = (decimal)query.OrderByDescending(s => s.EndTime).Take(NumberOfLastSeansForCalculation).Average(s => s.ErrorLevel);
                if (NumberWordInDictionary == 0)
                    return 0;
                return Math.Round(sumIncorrectNumber / NumberWordInDictionary, 3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal IncorrectNumber
        {
            get
            {
                decimal sumIncorrectNumber = (decimal)WordStatistics.Where(ws => ws.Number != 0).Sum(ws => (decimal)ws.IncorrectNumber / (decimal)ws.Number);
                return Math.Round(sumIncorrectNumber,2);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidateIncorrectNumber
        {
            get
            {
                decimal sumIncorrectNumber = (decimal)WordStatistics.Where(ws => ws.Number != 0).Sum(ws => (decimal)ws.ConsolidateIncorrectNumber / (decimal)ws.Number);
                return Math.Round(sumIncorrectNumber,2);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal AverageIncorrectNumber
        {
            get
            {
                decimal sumIncorrectNumber = (decimal)WordStatistics.Sum(ws => ws.IncorrectNumber);
                decimal sumNumber = (decimal)WordStatistics.Sum(ws => ws.Number);
                if (sumNumber == 0)
                    return 0;
                return Math.Round( sumIncorrectNumber / sumNumber, 3);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal AverageConsolidateIncorrectNumber
        {
            get
            {
                decimal sumIncorrectNumber = (decimal)WordStatistics.Sum(ws => ws.ConsolidateIncorrectNumber);
                decimal sumNumber = (decimal)WordStatistics.Sum(ws => ws.Number);
                if (sumNumber == 0)
                    return 0;
                return Math.Round(sumIncorrectNumber / sumNumber, 3);
            }
        }
        ////-------------------------------------------------------------------------------------------------------------------
        public int CountSeanse
        {
            get
            {
                return Seanses.Where(s => s.Attempts.Count > 0 && s.Attempts[0].InputNumber == NumberWordInDictionary).Count();
            }
        }
        ////-------------------------------------------------------------------------------------------------------------------
        public int CountSeanseWithWE
        {
            get
            {
                return Seanses.Count;
            }
        }
        ////-------------------------------------------------------------------------------------------------------------------
        public int CountWord
        {
            get
            {
                return WordStatistics.Count;
            }
        }
        ////-------------------------------------------------------------------------------------------------------------------
        //public Dictionary<string, WordStatistic> WordStatistics
        //{
        //    get
        //    {
        //        return wordStatistics;
        //    }
        //}
        ////-------------------------------------------------------------------------------------------------------------------
        //public IEnumerable<WordStatistic> WordStatisticsCollection
        //{
        //    get
        //    {
        //        return wordStatistics.Values;
        //    }
        //}
        //-------------------------------------------------------------------------------------------------------------------
        public void AddWordStatistic(Word pWord, int pAttempt, bool pIsCorrect)
        {
            WordStatistic ws = wordStatistics.Where(w => w.NativeWord == pWord.Native).FirstOrDefault();
            if (ws == null)
            {
                ws = new WordStatistic(pWord.Native);
                wordStatistics.Add(ws);
            }
            ws.AddWordStatistic(pAttempt, pIsCorrect);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
