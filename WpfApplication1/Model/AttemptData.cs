using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class AttemptData
    //-------------------------------------------------------------------------------------------------------------------
    public class AttemptData
    {
        private int errorLevel = 0;
        private int passNumber = 0;
        private int remainNumber = 0;
        //-------------------------------------------------------------------------------------------------------------------
        public AttemptData(int pErrorLevel, int pPassNumber, int pRemainNumber)
        {
            errorLevel = pErrorLevel;
            passNumber = pPassNumber;
            remainNumber = pRemainNumber;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevel
        {
            get
            {
                return errorLevel;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumber
        {
            get
            {
                return passNumber;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int RemainNumber
        {
            get
            {
                return remainNumber;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int InputNumber
        {
            get
            {
                return remainNumber + passNumber;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
