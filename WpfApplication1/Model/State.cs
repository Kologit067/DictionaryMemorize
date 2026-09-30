using System;
using System.Collections.Generic;
using System.Windows;
using DictionaryLibrary.Model;


namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class State
    //-------------------------------------------------------------------------------------------------------------------
    public class State
    {
        private List<Word> wordList = new List<Word>();
        private List<Word> incorrectWord = new List<Word>();
        private List<Word> correctWord = new List<Word>();
        private int errorLevel = 0;
        private int passNumber = 0;
        private int doneNumber = 0;
        private int errorLevelCurrent = 0;
        private int passNumberCurrent = 0;
        private int doneNumberCurrent = 0;
        private int attemptNumber = 1;
        private int remainNumber = 0;
        private int wordFormsVisible = (int)Visibility.Hidden;
        private int answerState;
        private bool isComplete = true;
        private bool isWorkOnMistakes = false;
        private int workOnMistakeRegim = 0;
        private decimal errorLevelValue;
        private decimal errorLevelRelation;
        private decimal consolidatedErrorLevelValue;
        private decimal consolidatedErrorLevelRelation;
        //-------------------------------------------------------------------------------------------------------------------
        public State()
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
        public State(int pErrorLevel, int pPassNumber, int pDoneNumber, int pErrorLevelCurrent, int pPassNumberCurrent,
            int pDoneNumberCurrent, int pAttemptNumber, int pRemainNumber, int pWordFormsVisible, int pAnswerState, bool pIsComplete,
            bool pIsWorkOnMistakes, int pWorkOnMistakeRegim, decimal pErrorLevelValue, decimal pErrorLevelRelation,
            decimal pConsolidatedErrorLevelValue, decimal pConsolidatedErrorLevelRelation)
        {
            errorLevel = pErrorLevel;
            passNumber = pPassNumber;
            doneNumber = pDoneNumber;
            errorLevelCurrent = pErrorLevelCurrent;
            passNumberCurrent = pPassNumberCurrent;
            doneNumberCurrent = pDoneNumberCurrent;
            attemptNumber = pAttemptNumber;
            remainNumber = pRemainNumber;
            wordFormsVisible = pWordFormsVisible;
            answerState = pAnswerState;
            isComplete = pIsComplete;
            isWorkOnMistakes = pIsWorkOnMistakes;
            workOnMistakeRegim = pWorkOnMistakeRegim;
            errorLevelValue = pErrorLevelValue;
            errorLevelRelation = pErrorLevelRelation;
            consolidatedErrorLevelValue = pConsolidatedErrorLevelValue;
            consolidatedErrorLevelRelation = pConsolidatedErrorLevelRelation;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public State(List<Word> pWords)
        {
            Initialize(pWords);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Initialize(List<Word> pWords)
        {
            wordList = new List<Word>(pWords);
            incorrectWord = new List<Word>();
            correctWord = new List<Word>();
            errorLevel = 0;
            passNumber = 0;
            doneNumber = 0;
            errorLevelCurrent = 0;
            passNumberCurrent = 0;
            doneNumberCurrent = 0;
            attemptNumber = 1;
            remainNumber = 0;
            wordFormsVisible = (int)Visibility.Hidden;
            answerState = 0;
            isComplete = false;
            remainNumber = WordList.Count;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<Word> WordList
        {
            get
            {
                return wordList;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<Word> IncorrectWord
        {
            get
            {
                return incorrectWord;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<Word> CorrectWord
        {
            get
            {
                return correctWord;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevel
        {
            get
            {
                return errorLevel;
            }
            set
            {
                errorLevel = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumber
        {
            get
            {
                return passNumber;
            }
            set
            {
                passNumber = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int DoneNumber
        {
            get
            {
                return doneNumber;
            }
            set
            {
                doneNumber = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevelCurrent
        {
            get
            {
                return errorLevelCurrent;
            }
            set
            {
                errorLevelCurrent = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumberCurrent
        {
            get
            {
                return passNumberCurrent;
            }
            set
            {
                passNumberCurrent = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int DoneNumberCurrent
        {
            get
            {
                return doneNumberCurrent;
            }
            set
            {
                doneNumberCurrent = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int AttemptNumber
        {
            get
            {
                return attemptNumber;
            }
            set
            {
                attemptNumber = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int RemainNumber
        {
            get
            {
                return remainNumber;
            }
            set
            {
                remainNumber = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int WordFormsVisible
        {
            get
            {
                return wordFormsVisible;
            }
            set
            {
                wordFormsVisible = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int AnswerState
        {
            get
            {
                return answerState;
            }
            set
            {
                answerState = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
            set
            {
                isComplete = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsWorkOnMistakes
        {
            get
            {
                return isWorkOnMistakes;
            }
            set
            {
                isWorkOnMistakes = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int WorkOnMistakeRegim
        {
            get
            {
                return workOnMistakeRegim;
            }
            set
            {
                workOnMistakeRegim = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ErrorLevelValue
        {
            get
            {
                return errorLevelValue;
            }
            set
            {
                errorLevelValue = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ErrorLevelRelation
        {
            get
            {
                return errorLevelRelation;
            }
            set
            {
                errorLevelRelation = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidatedErrorLevelValue
        {
            get
            {
                return consolidatedErrorLevelValue;
            }
            set
            {
                consolidatedErrorLevelValue = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidatedErrorLevelRelation
        {
            get
            {
                return consolidatedErrorLevelRelation;
            }
            set
            {
                consolidatedErrorLevelRelation = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
