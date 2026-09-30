using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLibrary.Contract {
    public interface IFocusable {
        event Action<string> ChangeFocus;
    }
}
