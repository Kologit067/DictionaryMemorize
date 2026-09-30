using DictionaryLibrary.ViewModel;
using Speech.BusinessLogic.Contracts.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionarySpeech.csproj.ViewModel
{
    public class SpeechGroupViewModel : ViewModelBase
    {
        public long SpeechGroupId { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsDirty { get; set; }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                IsDirty = true;
                OnPropertyChanged(nameof(Title));
            }
        }
        public ObservableCollection<SpeechPhraseViewModel> SpeechPhrases { get; set; }

        public SpeechGroupViewModel()
        {
            SpeechPhrases = new ObservableCollection<SpeechPhraseViewModel>();
        }

        public SpeechGroupViewModel(SpeechGroup pSpeechGroup)
        {
            Title = pSpeechGroup.Title;
            SpeechGroupId = pSpeechGroup.SpeechGroupId;
            IsDeleted = pSpeechGroup.IsDeleted;
            RowVersion = pSpeechGroup.RowVersion;
            SpeechPhrases = new ObservableCollection<SpeechPhraseViewModel>();
            foreach (var s in pSpeechGroup.SpeechPhrases)
                SpeechPhrases.Add(new SpeechPhraseViewModel(s));

        }

        public SpeechGroup GetSpeechGroup()
        {
            SpeechGroup result = new SpeechGroup();
            result.Title = Title;
            result.SpeechGroupId = SpeechGroupId;
            result.IsDeleted = IsDeleted;
            result.RowVersion = RowVersion;
            result.SpeechPhrases = SpeechPhrases.Select(s => s.GetSpeechPhrase()).ToList();

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

        public static void UpdateSpeechGroupViewModelList(ObservableCollection<SpeechGroupViewModel> pSpeechGroupModels, IEnumerable<SpeechGroup> pSpeechGroups)
        {
            var speechGroupList = pSpeechGroups.ToList();
            for (int i = 0; i < pSpeechGroupModels.Count; i++)
            {
                pSpeechGroupModels[i].SpeechGroupId = speechGroupList[i].SpeechGroupId;
                pSpeechGroupModels[i].RowVersion = speechGroupList[i].RowVersion;
                var speechPhraseList = speechGroupList[i].SpeechPhrases.ToList();
                for (int j = 0; j < pSpeechGroupModels[i].SpeechPhrases.Count; j++)
                {
                    pSpeechGroupModels[i].SpeechPhrases[j].SpeechPhraseId = speechPhraseList[j].SpeechPhraseId;
                    pSpeechGroupModels[i].SpeechPhrases[j].SpeechGroupId = speechPhraseList[j].SpeechGroupId;
                    pSpeechGroupModels[i].SpeechPhrases[j].RowVersion = speechPhraseList[j].RowVersion;
                }
            }
        }
    }
}
