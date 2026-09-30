using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLibrary.Common
{
    //-------------------------------------------------------------------------------------------------------------------
    // class ISetFocusQueriable
    //-------------------------------------------------------------------------------------------------------------------
    public interface ISetFocusQueriable
    {
        event Action QuerySetFocus;
    }
    //-------------------------------------------------------------------------------------------------------------------
}
