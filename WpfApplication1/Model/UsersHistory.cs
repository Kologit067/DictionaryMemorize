using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class UsersHistory
    //-------------------------------------------------------------------------------------------------------------------
    public class UsersHistory
    {
        private Dictionary<string,History> usersData = new Dictionary<string,History>();
        //-------------------------------------------------------------------------------------------------------------------
        public Dictionary<string, History> UsersData
        {
            get
            {
                return usersData;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
