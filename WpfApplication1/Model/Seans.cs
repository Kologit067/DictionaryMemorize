using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class Seans
    //-------------------------------------------------------------------------------------------------------------------
    public class Seans
    {
        private DateTime startTime = DateTime.Now;
        private DateTime endTime = DateTime.Now;
        private int errorLevel = 0;
        private bool isWorkOnMistakes;
        private List<AttemptData> attempts = new List<AttemptData>();
        //-------------------------------------------------------------------------------------------------------------------
        public Seans(bool pIsWorkOnMistakes)
        {
            isWorkOnMistakes = pIsWorkOnMistakes;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Seans(DateTime pStartTime, DateTime pEndTime, int pErrorLevel, bool pIsWorkOnMistakes) : this(pIsWorkOnMistakes)
        {
            startTime = pStartTime;
            endTime = pEndTime;
            errorLevel = pErrorLevel;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
    //-------------------------------------------------------------------------------------------------------------------
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
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
        public List<AttemptData> Attempts
        {
            get
            {
                return attempts;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int CountOfAttempts
        {
            get
            {
                return attempts.Count();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
