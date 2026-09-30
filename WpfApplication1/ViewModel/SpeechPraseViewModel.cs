using DictionaryMemorize.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryMemorize.ViewModel
{
    public class SpeechPraseViewModel : INotifyPropertyChanged
    {
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
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
                OnPropertyChanged("IsChecked");
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

        public SpeechPraseViewModel()
        {
        }

        public SpeechPraseViewModel(SpeechPrase pSpeechPrase)
        {
            Text = pSpeechPrase.Text;
        }

        public SpeechPrase GetSpeechPrase()
        {
            return new SpeechPrase() { Text = this.Text };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
