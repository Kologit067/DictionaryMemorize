using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class WordStatistic
    //-------------------------------------------------------------------------------------------------------------------
    public class WordStatistic
    {
        private int number;
        private int incorrectNumber;
        private string nativeWord;
        private Dictionary<int, int> attemptStatistic = new Dictionary<int,int>();
        //-------------------------------------------------------------------------------------------------------------------
        public WordStatistic(string pNativeWord)
        {
            nativeWord = pNativeWord;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public WordStatistic(string pNativeWord, int pNumber, int pIncorrectNumber)
        {
            nativeWord = pNativeWord;
            number = pNumber;
            incorrectNumber = pIncorrectNumber;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int Number
        {
            get
            {
                return number;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string NativeWord
        {
            get
            {
                return nativeWord;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int IncorrectNumber
        {
            get
            {
                return incorrectNumber;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal PartOfIncorrect
        {
            get
            {
                return Math.Round((decimal)incorrectNumber/(decimal)number,2);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ConsolidateIncorrectNumber
        {
            get
            {
                int r = attemptStatistic.Select(a => (a.Key - 1) * a.Value).Sum();
                return r;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal PartOfConsolidateIncorrect
        {
            get
            {
                decimal r = Math.Round((decimal)ConsolidateIncorrectNumber / (decimal)number, 2);
                return r;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int MaxAttempt
        {
            get
            {
                return AttemptStatistic.Keys.Max();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Dictionary<int, int> AttemptStatistic
        {
            get
            {
                return attemptStatistic;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        internal void AddWordStatistic(int pAttempt, bool pIsCorrect)
        {
            number++;
            if (!pIsCorrect)
                incorrectNumber++;
            if (!attemptStatistic.ContainsKey(pAttempt))
                attemptStatistic.Add(pAttempt, 0);
            attemptStatistic[pAttempt]++;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
