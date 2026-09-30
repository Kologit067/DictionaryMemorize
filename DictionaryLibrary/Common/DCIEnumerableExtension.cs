using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLibrary.Common
{
    public static class DCIEnumerableExtension
    {
        public static ObservableCollection<T> ConvertToObservableCollection<T>(this IEnumerable<T> pList)
        {
            ObservableCollection<T> result = new ObservableCollection<T>();
            foreach (T o in pList)
                result.Add(o);
            return result;
        }

    }
}
