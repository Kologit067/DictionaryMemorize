using DictionaryLibrary.ViewModel;
using ManualDictionary.BusinessLogic.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity.AspNet.Mvc;

namespace ManualDictionaryDb.ViewModel
{
    public class ManualDictionaryDbViewModel : ViewModelBase
    {
        private IManualDictionaryManager _manualDictionaryManager;
        //----------------------------------------------------------------------------------------------------------------------
        public ManualDictionaryDbViewModel()
        {

            Unity.IUnityContainer container = UnityConfig.GetConfiguredContainer();

            var resolver = new UnityDependencyResolver(container);

            _manualDictionaryManager = (IManualDictionaryManager)resolver.GetService(typeof(IManualDictionaryManager));

         }
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand fillDatabaseCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FillDatabaseCommand
        {
            get
            {
                if (fillDatabaseCommand == null)
                {
                    fillDatabaseCommand = new DelegateCommand(FillDatabaseAction, CanFillDatabaseAction);
                }
                return fillDatabaseCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FillDatabaseAction()
        {
            _manualDictionaryManager.FillDataBase();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFillDatabaseAction()
        {
            return true;
        }
    }
}
