using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryMemorize.Model
{
    [Serializable]
    public class SpeechGroup
    {
        public string Title { get; set; }
        public List<SpeechPrase> Phrases { get; set; }
        public SpeechGroup()
        {
            Phrases = new List<SpeechPrase>();
        }
    }
}
