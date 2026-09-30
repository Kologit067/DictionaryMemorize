using DictionaryLibrary.ViewModel;
using Speech.BusinessLogic.Contracts.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionarySpeech.csproj.ViewModel
{
    public class SpeechPhraseViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public long SpeechPhraseId { get; set; }
        public long SpeechGroupId { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }

        public bool IsDirty { get; set; }
        private string phrase;
        public string Phrase
        {
            get
            {
                return phrase;
            }
            set
            {
                phrase = value;
                IsDirty = true;
                OnPropertyChanged(nameof(Phrase));
            }
        }

        [NonSerialized]
        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SpeechPhraseViewModel()
        {
        }

        public SpeechPhraseViewModel(SpeechPhrase pSpeechPhrase)
        {
            Phrase = pSpeechPhrase.Phrase;
            SpeechGroupId = pSpeechPhrase.SpeechGroupId;
            SpeechPhraseId = pSpeechPhrase.SpeechPhraseId;
            IsDeleted = pSpeechPhrase.IsDeleted;
            RowVersion = pSpeechPhrase.RowVersion;
        }

        public SpeechPhrase GetSpeechPhrase()
        {
            return new SpeechPhrase()
            {
                Phrase = this.Phrase,
                SpeechGroupId = this.SpeechGroupId,
                SpeechPhraseId = this.SpeechPhraseId,
                IsDeleted = this.IsDeleted,
                RowVersion = this.RowVersion
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
