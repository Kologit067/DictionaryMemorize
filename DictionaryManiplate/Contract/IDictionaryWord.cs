using DictionaryManiplate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryManiplate.Contract {
    public interface IDictionaryWord {
        //------------------------------------------------------------------------------------------------------------------------------
        int DictionaryWordId { get; set; }
        string Native { get; set; }
        string Translation { get; set; }
        string Transcription { get; set; }
        string ShortTranslation { get; set; }

        int DictionaryId { get; set; }
        Dictionary Dictionary { get; set; }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
