using System;
using System.Collections.Generic;
using DictionaryMemorize.Model;
using DictionaryLibrary.ViewModel;

namespace DictionaryMemorize.ViewModel
{
    //-------------------------------------------------------------------------------------------------------------------
    // class UserViewModel
    //-------------------------------------------------------------------------------------------------------------------
    public class UserViewModel : ViewModelBase
    {
        private UsersHistory users = WordUsersHistory.Users;
        //-------------------------------------------------------------------------------------------------------------------
        public string User
        {
            get
            {
                return DictionaryMemorize.Properties.Settings.Default.User;
            }
            set
            {
                DictionaryMemorize.Properties.Settings.Default.User = value;
                OnPropertyChanged("User");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public IEnumerable<string> Users
        {
            get
            {
                return users.UsersData.Keys;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
 