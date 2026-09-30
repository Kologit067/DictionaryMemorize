using DictionaryMemorize.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryMemorize.ViewModel
{
    public class SpeechGroupViewModel
    {
        public string Title { get; set; }
        public ObservableCollection<SpeechPraseViewModel> Phrases { get; set; }

        public SpeechGroupViewModel()
        {
            Phrases = new ObservableCollection<SpeechPraseViewModel>();
        }

        public SpeechGroupViewModel(SpeechGroup pSpeechGroup)
        {
            Title = pSpeechGroup.Title;
            Phrases = new ObservableCollection<SpeechPraseViewModel>();
            foreach (var s in pSpeechGroup.Phrases)
                Phrases.Add(new SpeechPraseViewModel(s));
        }

        public SpeechGroup GetSpeechGroup()
        {
            SpeechGroup result = new SpeechGroup();
            result.Title = Title;
            result.Phrases = Phrases.Select(s => s.GetSpeechPrase()).ToList();

            return result;
        }

        public static ObservableCollection<SpeechGroupViewModel> CreateSpeechGroupViewModelList(IEnumerable<SpeechGroup> pSpeechGroups)
        {
            ObservableCollection<SpeechGroupViewModel> result = new ObservableCollection<SpeechGroupViewModel>();
            foreach (var g in pSpeechGroups)
                result.Add(new SpeechGroupViewModel(g));

            return result;
        }

        public static List<SpeechGroup> CreateSpeechGroupList(IEnumerable<SpeechGroupViewModel> pSpeechGroups)
        {
            List<SpeechGroup> result = new List<SpeechGroup>();
            foreach (var g in pSpeechGroups)
                result.Add(g.GetSpeechGroup());

            return result;
        }
    }
}
