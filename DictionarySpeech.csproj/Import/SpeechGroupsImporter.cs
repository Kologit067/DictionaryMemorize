using DictionaryMemorize.Model;
using DictionarySpeech.csproj.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DictionarySpeech.csproj.Import
{
    public class SpeechGroupsImporter
    {
        private const string SPEECHGROUPFIILENAME = "SpeechGroups.bin";
        //-------------------------------------------------------------------------------------------------------------------
        public void Import(ObservableCollection<SpeechGroupViewModel> speechGroups)
        {
            try
            {
                if (File.Exists(SPEECHGROUPFIILENAME))
                {
                    using (Stream stream = new FileStream(SPEECHGROUPFIILENAME, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {

                        IFormatter bs = new BinaryFormatter();
                        List<SpeechGroup> groups = (List<SpeechGroup>)bs.Deserialize(stream);
                        foreach(var group in groups)
                        {
                            if (!speechGroups.Any(sg => sg.Title == group.Title))
                            {
                                SpeechGroupViewModel speechGroup = new SpeechGroupViewModel()
                                {
                                    Title = group.Title
                                };
                                speechGroups.Add(speechGroup);
                                foreach(var phrase in group.Phrases)
                                {
                                    speechGroup.SpeechPhrases.Add(new SpeechPhraseViewModel()
                                    {
                                        Phrase = phrase.Text
                                    }
                                        );
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }

    //[Serializable]
    //public class SpeechGroup
    //{
    //    public string Title { get; set; }
    //    public List<SpeechPrase> Phrases { get; set; }
    //    public SpeechGroup()
    //    {
    //        Phrases = new List<SpeechPrase>();
    //    }
    //}

    //[Serializable]
    //public class SpeechPrase
    //{
    //    private string text;
    //    public string Text
    //    {
    //        get
    //        {
    //            return text;
    //        }
    //        set
    //        {
    //            text = value;
    //        }
    //    }

    //    [NonSerialized]
    //    private bool isChecked;
    //    public bool IsChecked
    //    {
    //        get
    //        {
    //            return isChecked;
    //        }
    //        set
    //        {
    //            isChecked = value;
    //        }
    //    }

    //    public SpeechPrase()
    //    {
    //    }

    //}
}
