using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DictionaryMemorize.Model;
using System.Windows;
using System.Windows.Input;
using DictionaryLibrary.ViewModel;
using DictionaryLibrary.Model;
using System.Speech.Synthesis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Data;
using System.ComponentModel;
using DictionaryMemorize.Infrastructure;
using System.Diagnostics;
using DictionaryLibrary.Common;
using System.Speech.Recognition;
//using Microsoft.Speech.Recognition;

namespace DictionaryMemorize.ViewModel
{
    public enum AnswerState { Answer, Correction };
    public enum WorkOnMistakeRegimEnum { ErrorLevelValue, ErrorLevelRelation, ConsolidatedErrorLevelValue, ConsolidatedErrorLevelRelation };
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryViewModel
    //-------------------------------------------------------------------------------------------------------------------
    class DictionaryViewModel : ViewModelBase, ISetFocusQueriable, ISavable, IScrollIntoViewAction
    {
        private const string SPEECHGROUPFIILENAME = "SpeechGroups.bin";
        private ObservableCollection<WordViewModel> wordList;
        private ObservableCollection<WordViewModel> incorrectWord;
        private ObservableCollection<WordViewModel> correctWord;
        private ObservableCollection<SpeechGroupViewModel> speechGroups;
        private ObservableCollection<InstalledVoice> installedVoices;
        private SpeechGroupViewModel selectedSpeechGroup;
        private SpeechPraseViewModel selectedSpeechPhrase;
        private InstalledVoice selectedInstalledVoice;
        private int selectedSpeechIndexPhrase;
        private bool isWordListEnable = true;
        private WordViewModel selectedItem;
        private int selectedIndex;
        private SettingsViewModel settings;
        private UsersHistory users = WordUsersHistory.Users;
        private WordStatistic selectedWordStatistic;
        private int selectedPanelIndex;
        private bool isChangeMistakeRegim = false;
        private bool isListPhraseExpanded = false;
        private string listOfSpeechPhrase;
        private DictionaryHistory selectedDictionaryComparison;
        private int speechPause = 1500;
        private int paragraphPause = 1000;
        private int sentencePause = 500;
        private int speechRepeat = 1;
        private bool? isSpeechCycle = false;
        private bool? isOnlySelected = false;
        private bool? isTurnOnSpeaker = true;

        public event Action<Object> MainGridScrollIntoView;
        public event Action SpeechPhraseScrollIntoView;

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        //-------------------------------------------------------------------------------------------------------------------
        public event Action QuerySetFocus;
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryViewModel()
        {
            Settings = new SettingsViewModel(DictionaryMemorize.Properties.Settings.Default);
            PropertyChanging += Settings_PropertyChanging;
            PropertyChanged += Settings_PropertyChanged;
        }
        //-------------------------------------------------------------------------------------------------------------------
        static DictionaryViewModel()
        {
            Word.IsDirect = DictionaryMemorize.Properties.Settings.Default.IsDirect;
            Word.DictionaryName = DictionaryMemorize.Properties.Settings.Default.DictionaryName;
            Word.DictionaryDirectory = DictionaryMemorize.Properties.Settings.Default.DictionaryDirectory;
            Word.Initialize();
            WordUsersHistory.Initialize();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public IEnumerable<string> DictionaryNames
        {
            get
            {
                return Settings.DictionaryNames.OrderBy(n => n);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public IEnumerable<string> DictionaryNamesForProtocol
        {
            get
            {
                return CurrentHistory.DictionaryNamesForProtocol;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string DictionaryName
        {
            get
            {
                return CurrentHistory.CurrentDictionary;
            }
            set
            {
                CurrentHistory.CurrentDictionary = value;
                OnPropertyChanged("DictionaryName");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public WordStatistic SelectedWordStatistic
        {
            get
            {
                return selectedWordStatistic;
            }
            set
            {
                selectedWordStatistic = value;
                OnPropertyChanged("SelectedWordStatistic");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsDirect
        {
            get
            {
                return CurrentHistory.IsDirect;
            }
            set
            {
                CurrentHistory.IsDirect = value;
                OnPropertyChanged("IsDirect");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevel
        {
            get
            {
                return DictionaryState.ErrorLevel;
            }
            set
            {
                DictionaryState.ErrorLevel = value;
                OnPropertyChanged("ErrorLevel");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumber
        {
            get
            {
                return DictionaryState.PassNumber;
            }
            set
            {
                DictionaryState.PassNumber = value;
                OnPropertyChanged("PassNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int DoneNumber
        {
            get
            {
                return DictionaryState.DoneNumber;
            }
            set
            {
                DictionaryState.DoneNumber = value;
                OnPropertyChanged("DoneNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ErrorLevelCurrent
        {
            get
            {
                return DictionaryState.ErrorLevelCurrent;
            }
            set
            {
                DictionaryState.ErrorLevelCurrent = value;
                OnPropertyChanged("ErrorLevelCurrent");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int PassNumberCurrent
        {
            get
            {
                return DictionaryState.PassNumberCurrent;
            }
            set
            {
                DictionaryState.PassNumberCurrent = value;
                OnPropertyChanged("PassNumberCurrent");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int DoneNumberCurrent
        {
            get
            {
                return DictionaryState.DoneNumberCurrent;
            }
            set
            {
                DictionaryState.DoneNumberCurrent = value;
                OnPropertyChanged("DoneNumberCurrent");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Visibility WordFormsVisible
        {
            get
            {
                return (Visibility)DictionaryState.WordFormsVisible;
            }
            set
            {
                DictionaryState.WordFormsVisible = (int)value;
                IsWordListEnable = value == Visibility.Visible ? false : true;
                OnPropertyChanged("WordFormsVisible");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsWordListEnable
        {
            get
            {
                return isWordListEnable;
            }
            set
            {
                isWordListEnable = value;
                OnPropertyChanged("IsWordListEnable");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool? IsTurnOnSpeaker
        {
            get
            {
                return isTurnOnSpeaker;
            }
            set
            {
                isTurnOnSpeaker = value;
                OnPropertyChanged("IsTurnOnSpeaker");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        //        Work on mistakes
        public bool IsWorkOnMistakes
        {
            get
            {
                return DictionaryState.IsWorkOnMistakes;
            }
            set
            {
                DictionaryState.IsWorkOnMistakes = value;
                OnPropertyChanged("IsWorkOnMistakes");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsWorkOnMistakesForProtocol
        {
            get
            {
                return CurrentDictionaryHistoryForProtocol.State?.IsWorkOnMistakes ?? false;
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.State.IsWorkOnMistakes = value;
                OnPropertyChanged("IsWorkOnMistakesForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public WorkOnMistakeRegimEnum WorkOnMistakeRegim
        {
            get
            {
                return (WorkOnMistakeRegimEnum)DictionaryState.WorkOnMistakeRegim;
            }
            set
            {
                DictionaryState.WorkOnMistakeRegim = (int)value;
                OnPropertyChanged("WorkOnMistakeRegim");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public WorkOnMistakeRegimEnum WorkOnMistakeRegimForProtocol
        {
            get
            {
                return (WorkOnMistakeRegimEnum)(CurrentDictionaryHistoryForProtocol.State?.WorkOnMistakeRegim ?? 0);
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.State.WorkOnMistakeRegim = (int)value;
                OnPropertyChanged("WorkOnMistakeRegimForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ErrorLevelValue
        {
            get
            {
                return DictionaryState.ErrorLevelValue;
            }
            set
            {
                DictionaryState.ErrorLevelValue = value;
                OnPropertyChanged("ErrorLevelValue");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ErrorLevelRelation
        {
            get
            {
                return DictionaryState.ErrorLevelRelation;
            }
            set
            {
                DictionaryState.ErrorLevelRelation = value;
                OnPropertyChanged("ErrorLevelRelation");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidatedErrorLevelValue
        {
            get
            {
                return DictionaryState.ConsolidatedErrorLevelValue;
            }
            set
            {
                DictionaryState.ConsolidatedErrorLevelValue = value;
                OnPropertyChanged("ConsolidatedErrorLevelValue");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidatedErrorLevelRelation
        {
            get
            {
                return DictionaryState.ConsolidatedErrorLevelRelation;
            }
            set
            {
                DictionaryState.ConsolidatedErrorLevelRelation = value;
                OnPropertyChanged("ConsolidatedErrorLevelRelation");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ErrorLevelValueForProtocol
        {
            get
            {
                return CurrentDictionaryHistoryForProtocol.State?.ErrorLevelValue ?? 0;
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.State.ErrorLevelValue = value;
                OnPropertyChanged("ErrorLevelValueForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ErrorLevelRelationForProtocol
        {
            get
            {
                return CurrentDictionaryHistoryForProtocol.State?.ErrorLevelRelation ?? 0;
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.State.ErrorLevelRelation = value;
                OnPropertyChanged("ErrorLevelRelationForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidatedErrorLevelValueForProtocol
        {
            get
            {
                return CurrentDictionaryHistoryForProtocol.State?.ConsolidatedErrorLevelValue ?? 0;
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.State.ConsolidatedErrorLevelValue = value;
                OnPropertyChanged("ConsolidatedErrorLevelValueForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public decimal ConsolidatedErrorLevelRelationForProtocol
        {
            get
            {
                return CurrentDictionaryHistoryForProtocol.State?.ConsolidatedErrorLevelRelation ?? 0;
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.State.ConsolidatedErrorLevelRelation = value;
                OnPropertyChanged("ConsolidatedErrorLevelRelationForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsErrorLevelValueActive
        {
            get
            {
                if (WorkOnMistakeRegimEnum.ErrorLevelValue == WorkOnMistakeRegimForProtocol)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    WorkOnMistakeRegimForProtocol = WorkOnMistakeRegimEnum.ErrorLevelValue;
                OnPropertyChanged("IsErrorLevelValueActive");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsErrorLevelRelationActive
        {
            get
            {
                if (WorkOnMistakeRegimEnum.ErrorLevelRelation == WorkOnMistakeRegimForProtocol)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    WorkOnMistakeRegimForProtocol = WorkOnMistakeRegimEnum.ErrorLevelRelation;
                OnPropertyChanged("IsErrorLevelRelationActive");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsConsolidatedErrorLevelValueIsActive
        {
            get
            {
                if (WorkOnMistakeRegimEnum.ConsolidatedErrorLevelValue == WorkOnMistakeRegimForProtocol)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    WorkOnMistakeRegimForProtocol = WorkOnMistakeRegimEnum.ConsolidatedErrorLevelValue;
                OnPropertyChanged("IsConsolidatedErrorLevelValueIsActive");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsConsolidatedErrorLevelRelationIsActive
        {
            get
            {
                if (WorkOnMistakeRegimEnum.ConsolidatedErrorLevelRelation == WorkOnMistakeRegimForProtocol)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    WorkOnMistakeRegimForProtocol = WorkOnMistakeRegimEnum.ConsolidatedErrorLevelRelation;
                OnPropertyChanged("IsConsolidatedErrorLevelRelationIsActive");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int AttemptNumber
        {
            get
            {
                return DictionaryState.AttemptNumber;
            }
            set
            {
                DictionaryState.AttemptNumber = value;
                OnPropertyChanged("AttemptNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int RemainNumber
        {
            get
            {
                return DictionaryState.RemainNumber;
            }
            set
            {
                DictionaryState.RemainNumber = value;
                OnPropertyChanged("RemainNumber");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public WordViewModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryHistory SelectedDictionaryComparison
        {
            get
            {
                return selectedDictionaryComparison;
            }
            set
            {
                selectedDictionaryComparison = value;
                OnPropertyChanged("SelectedDictionaryComparison");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SelectedPanelIndex
        {
            get
            {
                return selectedPanelIndex;
            }
            set
            {
                OnPropertyChanging("SelectedPanelIndex");
                selectedPanelIndex = value;
                OnPropertyChanged("SelectedPanelIndex");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public AnswerState State
        {
            get
            {
                return (AnswerState)DictionaryState.AnswerState;
            }
            set
            {
                DictionaryState.AnswerState = (int)value;
                OnPropertyChanged("State");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SpeechPause
        {
            get
            {
                return speechPause;
            }
            set
            {
                speechPause = value;
                OnPropertyChanged("SpeechPause");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int ParagraphPause
        {
            get
            {
                return paragraphPause;
            }
            set
            {
                paragraphPause = value;
                OnPropertyChanged("ParagraphPause");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SentencePause
        {
            get
            {
                return sentencePause;
            }
            set
            {
                sentencePause = value;
                OnPropertyChanged("SentencePause");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SpeechRepeat
        {
            get
            {
                return speechRepeat;
            }
            set
            {
                speechRepeat = value;
                OnPropertyChanged("SpeechRepeat");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool? IsSpeechCycle
        {
            get
            {
                return isSpeechCycle;
            }
            set
            {
                isSpeechCycle = value;
                OnPropertyChanged("IsSpeechCycle");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool? IsOnlySelected
        {
            get
            {
                return isOnlySelected;
            }
            set
            {
                isOnlySelected = value;
                OnPropertyChanged("IsOnlySelected");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<SpeechGroupViewModel> SpeechGroups
        {
            get
            {
                return speechGroups;
            }
            set
            {
                speechGroups = value;
                OnPropertyChanged("SpeechGroups");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public SpeechGroupViewModel SelectedSpeechGroup
        {
            get
            {
                return selectedSpeechGroup;
            }
            set
            {
                selectedSpeechGroup = value;
                OnPropertyChanged("SelectedSpeechGroup");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public SpeechPraseViewModel SelectedSpeechPhrase
        {
            get
            {
                return selectedSpeechPhrase;
            }
            set
            {
                selectedSpeechPhrase = value;
                OnPropertyChanged("SelectedSpeechPhrase");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SelectedSpeechIndexPhrase
        {
            get
            {
                return selectedSpeechIndexPhrase;
            }
            set
            {
                selectedSpeechIndexPhrase = value;
                OnPropertyChanged("SelectedSpeechIndexPhrase");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WordViewModel> WordList
        {
            get
            {
                return wordList;
            }
            set
            {
                wordList = value;
                OnPropertyChanged("WordList");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WordViewModel> IncorrectWord
        {
            get
            {
                return incorrectWord;
            }
            set
            {
                incorrectWord = value;
                OnPropertyChanged("IncorrectWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WordViewModel> CorrectWord
        {
            get
            {
                return correctWord;
            }
            set
            {
                correctWord = value;
                OnPropertyChanged("CorrectWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsListPhraseExpanded 
        {
            get
            {
                return isListPhraseExpanded;
            }
            set
            {
                isListPhraseExpanded = value;
                OnPropertyChanged("IsListPhraseExpanded");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string ListOfSpeechPhrase
        {
            get
            {
                return listOfSpeechPhrase;
            }
            set
            {
                listOfSpeechPhrase = value;
                OnPropertyChanged("ListOfSpeechPhrase");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        //public bool IsFirstFieldFocused
        //{
        //    get
        //    {
        //        return isFirstFieldFocused;
        //    }
        //    set
        //    {
        //        isFirstFieldFocused = value;
        //        OnPropertyChanged("IsFirstFieldFocused");
        //    }
        //}
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<InstalledVoice> InstalledVoices
        {
            get
            {
                return installedVoices;
            }
            set
            {
                installedVoices = value;
                OnPropertyChanged("InstalledVoices");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public InstalledVoice SelectedInstalledVoice
        {
            get
            {
                return selectedInstalledVoice;
            }
            set
            {
                selectedInstalledVoice = value;
                OnPropertyChanged("SelectedInstalledVoice");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public SettingsViewModel Settings
        {
            get
            {
                return settings;
            }
            set
            {
                settings = value;
                OnPropertyChanged("Settings");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool isAdditionalSettingExpanded = false;
        public bool IsAdditionalSettingExpanded
        {
            get
            {
                return isAdditionalSettingExpanded;
            }
            set
            {
                isAdditionalSettingExpanded = value;
                OnPropertyChanged("IsAdditionalSettingExpanded");
            }
        }
        
        //-------------------------------------------------------------------------------------------------------------------
        private double speedRatio;
        public double SpeedRatio
        {
            get
            {
                return speedRatio;
            }
            set
            {
                speedRatio = value;
                OnPropertyChanged("SpeedRatio");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool isPauseEqualDuration;
        public bool IsPauseEqualDuration
        {
            get
            {
                return isPauseEqualDuration;
            }
            set
            {
                isPauseEqualDuration = value;
                OnPropertyChanged("IsPauseEqualDuration");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool isCustomPauses;
        public bool IsCustomPauses
        {
            get
            {
                return isCustomPauses;
            }
            set
            {
                isCustomPauses = value;
                OnPropertyChanged("IsCustomPauses");
            }
        }
    //-------------------------------------------------------------------------------------------------------------------
        public string User
        {
            get
            {
                return DictionaryMemorize.Properties.Settings.Default.User;
            }
            //set
            //{
            //    DictionaryMemorize.Properties.Settings.Default.User = value;
            //    OnPropertyChanged("User");
            //}
        }
        //-------------------------------------------------------------------------------------------------------------------
        public History CurrentHistory
        {
            get
            {
                History history = null;
                if (users.UsersData.Keys.Contains(User))
                    history = users.UsersData[User];
                else
                {
                    history = new History(User);
                    users.UsersData.Add(User, history);
                }
                return history;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string CurrentDictionary
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentHistory.CurrentDictionary))
                    CurrentHistory.CurrentDictionary = DictionaryMemorize.Properties.Settings.Default.DictionaryName ?? "";
                return CurrentHistory.CurrentDictionary;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string CurrentDictionaryForProtocol
        {
            get
            {
                return CurrentHistory.CurrentDictionaryForProtocol;
            }
            set
            {
                CurrentHistory.CurrentDictionaryForProtocol = value;
                OnPropertyChanged("CurrentDictionaryForProtocol");
                OnPropertyChanged("CurrentDictionaryHistoryForProtocol");
                OnPropertyChanged("ErrorLevelValueForProtocol");
                OnPropertyChanged("ErrorLevelRelationForProtocol");
                OnPropertyChanged("ConsolidatedErrorLevelValueForProtocol");
                OnPropertyChanged("ConsolidatedErrorLevelRelationForProtocol");
                OnPropertyChanged("IsErrorLevelValueActive");
                OnPropertyChanged("IsErrorLevelRelationActive");
                OnPropertyChanged("IsConsolidatedErrorLevelValueIsActive");
                OnPropertyChanged("IsConsolidatedErrorLevelRelationIsActive");
                OnPropertyChanged("IsWorkOnMistakesForProtocol");
                OnPropertyChanged("NumberWordInDictionaryForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int NumberWordInDictionaryForProtocol
        {
            get
            {
                return CurrentDictionaryHistoryForProtocol.NumberWordInDictionary;
            }
            set
            {
                CurrentDictionaryHistoryForProtocol.NumberWordInDictionary = value;
                OnPropertyChanged("NumberWordInDictionaryForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryHistory CurrentDictionaryHistory
        {
            get
            {
                if (!CurrentHistory.DictionaryHistories.ContainsKey(CurrentDictionary))
                {
                    CurrentHistory.DictionaryHistories.Add(CurrentDictionary, new DictionaryHistory(CurrentDictionary));
                }
                return CurrentHistory.DictionaryHistories[CurrentDictionary];
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public IEnumerable<DictionaryHistory> Dictionaries
        {
            get
            {
                return CurrentHistory.DictionaryHistories.Values;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryHistory CurrentDictionaryHistoryForProtocol
        {
            get
            {
                if (!CurrentHistory.DictionaryHistories.ContainsKey(CurrentDictionaryForProtocol))
                {
                    CurrentHistory.DictionaryHistories.Add(CurrentDictionaryForProtocol, new DictionaryHistory(CurrentDictionaryForProtocol));
                }
                return CurrentHistory.DictionaryHistories[CurrentDictionaryForProtocol];
            }
            set
            {
                if (!CurrentHistory.DictionaryHistories.ContainsKey(CurrentDictionaryForProtocol))
                {
                    CurrentHistory.DictionaryHistories.Add(CurrentDictionaryForProtocol, new DictionaryHistory(CurrentDictionaryForProtocol));
                }
                CurrentHistory.DictionaryHistories[CurrentDictionaryForProtocol] = value;
                OnPropertyChanged("CurrentDictionaryHistoryForProtocol");
                OnPropertyChanged("ErrorLevelValueForProtocol");
                OnPropertyChanged("ErrorLevelRelationForProtocol");
                OnPropertyChanged("ConsolidatedErrorLevelValueForProtocol");
                OnPropertyChanged("ConsolidatedErrorLevelRelationForProtocol");
                OnPropertyChanged("IsErrorLevelValueActive");
                OnPropertyChanged("IsErrorLevelRelationActive");
                OnPropertyChanged("IsConsolidatedErrorLevelValueIsActive");
                OnPropertyChanged("IsConsolidatedErrorLevelRelationIsActive");
                OnPropertyChanged("IsWorkOnMistakesForProtocol");
                OnPropertyChanged("NumberWordInDictionaryForProtocol");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public State DictionaryState
        {
            get
            {
                if (CurrentDictionaryHistory.State == null)
                {
                    CurrentDictionaryHistory.State = new State();
                }
                return CurrentDictionaryHistory.State;
            }
        }
        private Seans currentSeans;
        //-------------------------------------------------------------------------------------------------------------------
        public void Initialize()
        {
            List<Word> Words;
            CurrentHistory.CurrentDictionary = Word.GetDictionary(DictionaryName, out Words);
            if (Words == null)
                return;

            int lTotalCount = Words.Count;
            IEnumerable<Word> wordsAfterFilter = Words;
            if (IsWorkOnMistakes)
            {
                switch (WorkOnMistakeRegim)
                {
                    case WorkOnMistakeRegimEnum.ErrorLevelValue:
                        wordsAfterFilter = from w in Words
                                           join ws in CurrentDictionaryHistory.WordStatistics on w.Native equals ws.NativeWord
                                           where ws.PartOfIncorrect >= ErrorLevelValue
                                           select w;
                        break;
                    case WorkOnMistakeRegimEnum.ErrorLevelRelation:
                        int lPartOfError = (int)(lTotalCount * ErrorLevelRelation);
                        var q = from w in Words
                                join ws in CurrentDictionaryHistory.WordStatistics on w.Native equals ws.NativeWord
                                orderby ws.PartOfIncorrect descending
                                select w;
                        wordsAfterFilter = q.Take(lPartOfError);
                        break;
                    case WorkOnMistakeRegimEnum.ConsolidatedErrorLevelValue:
                        wordsAfterFilter = from w in Words
                                           join ws in CurrentDictionaryHistory.WordStatistics on w.Native equals ws.NativeWord
                                           where ws.PartOfConsolidateIncorrect >= ConsolidatedErrorLevelValue
                                           select w;
                        break;
                    case WorkOnMistakeRegimEnum.ConsolidatedErrorLevelRelation:
                        lPartOfError = (int)(lTotalCount * ConsolidatedErrorLevelRelation);
                        q = from w in Words
                                join ws in CurrentDictionaryHistory.WordStatistics on w.Native equals ws.NativeWord
                                orderby ws.PartOfConsolidateIncorrect descending
                                select w;
                        wordsAfterFilter = q.Take(lPartOfError);
                        break;
                }
            }

            if (!DictionaryState.IsComplete)
            {
                //WordList = new ObservableCollection<WordViewModel>(wordsAfterFilter.Where(v =>
                //    DictionaryState.WordList.Any(wl => wl.Native == v.Native) &&
                //    DictionaryState.IncorrectWord.All(wl => wl.Native != v.Native) &&
                //    DictionaryState.CorrectWord.All(wl => wl.Native != v.Native)).Select(v => new WordViewModel(v)));
                WordList = new ObservableCollection<WordViewModel>(wordsAfterFilter.Where(v =>
                    DictionaryState.IncorrectWord.All(wl => wl.Native != v.Native) &&
                    DictionaryState.CorrectWord.All(wl => wl.Native != v.Native)).Select(v => new WordViewModel(v)));
                IncorrectWord = new ObservableCollection<WordViewModel>(wordsAfterFilter.Where(v => DictionaryState.IncorrectWord.Any(wl => wl.Native == v.Native)).Select(v => new WordViewModel(v)));
                CorrectWord = new ObservableCollection<WordViewModel>(wordsAfterFilter.Where(v => DictionaryState.CorrectWord.Any(wl => wl.Native == v.Native)).Select(v => new WordViewModel(v)));
                //                RemainNumber = WordList.Count;
                if (CurrentDictionaryHistory.Seanses.Count > 0)
                    currentSeans = CurrentDictionaryHistory.Seanses[CurrentDictionaryHistory.Seanses.Count - 1];
            }
            else
            {
                DictionaryState.Initialize(wordsAfterFilter.ToList());
                WordList = new ObservableCollection<WordViewModel>(wordsAfterFilter.Select(v => new WordViewModel(v)));
                IncorrectWord = new ObservableCollection<WordViewModel>();
                CorrectWord = new ObservableCollection<WordViewModel>();
            }
            if (currentSeans == null)
            {
                currentSeans = new Seans(IsWorkOnMistakes);
                CurrentDictionaryHistory.Seanses.Add(currentSeans);
            }
            CurrentDictionaryHistory.NumberWordInDictionary = lTotalCount;
            RemainNumber = WordList.Count;
            DictionaryState.IsComplete = false;
            SelectedIndex = 0;
            OnPropertyChanged("ErrorLevel");
            OnPropertyChanged("PassNumber");
            OnPropertyChanged("DoneNumber");
            OnPropertyChanged("ErrorLevelCurrent");
            OnPropertyChanged("PassNumberCurrent");
            OnPropertyChanged("DoneNumberCurrent");
            OnPropertyChanged("WordFormsVisible");
            OnPropertyChanged("AttemptNumber");
            OnPropertyChanged("RemainNumber");
            OnPropertyChanged("IsWorkOnMistakes");
            IsWordListEnable = WordFormsVisible == Visibility.Visible ? false : true;
            isChangeMistakeRegim = false;
            foreach (var ch in CurrentHistory.DictionaryHistories)
            {
                ch.Value.NumberWordInDictionary = Word.GetDictionaryCount(ch.Value.DictionaryName);
            }
            OnPropertyChanged("NumberWordInDictionaryForProtocol");
            ReadSpeechGroups();
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnSpeechPhraseScrollIntoView()
        {
            Action handler = SpeechPhraseScrollIntoView;
            if (handler != null)
                handler();
        }
        private SpeechRecognizer speechRecognizer = null;
        private StringBuilder speechAccumulator = new StringBuilder();
        private SpeechRecognitionEngine speechRecognitionEngine = null;
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand startRecognizeCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand StartRecognizeCommand
        {
            get
            {
                if (startRecognizeCommand == null)
                {
                    startRecognizeCommand = new DelegateCommand(StartRecognizeAction, CanStartRecognizeAction);
                }
                return startRecognizeCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void StartRecognizeAction()
        {
            //if (speechRecognizer == null)
            //{
            //    speechRecognizer = new SpeechRecognizer();
            //    var dictionary = new DictationGrammar();
            //    speechRecognizer.LoadGrammar(dictionary);
            //    speechRecognizer.SpeechRecognized += SpeechRecognizer_SpeechRecognized;
            //}
            if (speechRecognitionEngine == null)
            {
                speechRecognitionEngine = new SpeechRecognitionEngine();
                speechRecognitionEngine.SetInputToDefaultAudioDevice();
                var dictionary = new DictationGrammar();
                speechRecognitionEngine.LoadGrammarCompleted += SpeechRecognitionEngine_LoadGrammarCompleted; ;
                speechRecognitionEngine.LoadGrammar(dictionary);
                speechRecognitionEngine.SpeechRecognized += SpeechRecognizer_SpeechRecognized;
                speechRecognitionEngine.AudioStateChanged += SpeechRecognitionEngine_AudioStateChanged;
                speechRecognitionEngine.SpeechDetected += SpeechRecognitionEngine_SpeechDetected;
                speechRecognitionEngine.SpeechRecognitionRejected += SpeechRecognitionEngine_SpeechRecognitionRejected; ;
                speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            speechAccumulator.Clear();
        }

        private void SpeechRecognitionEngine_LoadGrammarCompleted(object sender, LoadGrammarCompletedEventArgs e)
        {
            Console.WriteLine(e.Error);
            Console.WriteLine(e.Grammar);
        }

        private void SpeechRecognitionEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine(e.Result);
        }

        private void SpeechRecognitionEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Console.WriteLine(e.AudioPosition.Milliseconds);
        }

        private void SpeechRecognitionEngine_AudioStateChanged(object sender, AudioStateChangedEventArgs e)
        {
            Console.WriteLine(e.AudioState.ToString());
        }

        //-------------------------------------------------------------------------------------------------------------------
        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                speechAccumulator.Append(e.Result.Text).Append(" ");
            }
        }

        //-------------------------------------------------------------------------------------------------------------------
        private bool CanStartRecognizeAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand stopRecognizeCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand StopRecognizeCommand
        {
            get
            {
                if (stopRecognizeCommand == null)
                {
                    stopRecognizeCommand = new DelegateCommand(StopRecognizeAction, CanStopRecognizeAction);
                }
                return stopRecognizeCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void StopRecognizeAction()
        {
            SelectedItem.NativeAnswer = speechAccumulator.ToString();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanStopRecognizeAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand acceptCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AcceptCommand
        {
            get
            {
                if (acceptCommand == null)
                {
                    acceptCommand = new DelegateCommand(AcceptAction, CanAcceptAction);
                }
                return acceptCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AcceptAction()
        {
            if (CorrectWord.Count == 0 && IncorrectWord.Count == 0)
            {
                currentSeans.StartTime = DateTime.Now;
            }
            WordViewModel lCurrentWord = selectedItem as WordViewModel;
            if (lCurrentWord != null)
            {
                int lCurrentErrorLevel = 0;
                lCurrentErrorLevel += !string.IsNullOrEmpty(lCurrentWord.NativeAnswer) && lCurrentWord.Native.Trim().ToLower().Replace("-"," ") == lCurrentWord.NativeAnswer.Trim().ToLower().Replace("-", " ") ? 0 : 1;
                if (lCurrentErrorLevel == 0)
                {
                    GotoNextWord();
                }
                else
                {
                    if (State == AnswerState.Answer)
                    {
                        State = AnswerState.Correction;
                        WordFormsVisible = Visibility.Visible;
                        ErrorLevel += lCurrentErrorLevel << (AttemptNumber - 1);
                        ErrorLevelCurrent += lCurrentErrorLevel << (AttemptNumber - 1);
                    }
                    else
                    {
                    }
                }
                if (IsTurnOnSpeaker.HasValue && IsTurnOnSpeaker.Value)
                    synthesizer.SpeakAsync( lCurrentWord.Native);
            }
            else if (WordList.Count > 0)
            {
                SelectedIndex = 0;
            }
            if (WordList.Count == 0 && IncorrectWord.Count == 0)
            {
                DictionaryState.IsComplete = true;
                AttemptData attemptData = new AttemptData(ErrorLevelCurrent, PassNumberCurrent, 0);
                currentSeans.Attempts.Add(attemptData);
                currentSeans.ErrorLevel = ErrorLevel;
                currentSeans.EndTime = DateTime.Now;
                currentSeans = new Seans(IsWorkOnMistakes);
                if (object.ReferenceEquals(CurrentDictionaryHistory,CurrentDictionaryHistoryForProtocol))
                    CurrentDictionaryHistoryForProtocol.Seanses.Add(currentSeans);
                else
                    CurrentDictionaryHistory.Seanses.Add(currentSeans);

            }
            OnQuerySetFocus();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void GotoNextWord()
        {
            if (State == AnswerState.Answer)
            {
                PassNumber++;
                PassNumberCurrent++;
                if (SelectedItem is WordViewModel)
                    CurrentDictionaryHistory.AddWordStatistic((SelectedItem as WordViewModel).Word, AttemptNumber, AttemptNumber == 1);
                MoveWordToCorrect(SelectedItem as WordViewModel);
            }
            else
            {
                MoveWordToInCorrect(SelectedItem as WordViewModel);
            }
            RemainNumber--;
            DoneNumber++;
            DoneNumberCurrent++;
            State = AnswerState.Answer;
            WordFormsVisible = Visibility.Hidden;
            SelectedIndex = 0;
//            IsFirstFieldFocused = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void MoveWordToCorrect(WordViewModel word)
        {
            if (word != null)
            {
                CorrectWord.Add(word);
                DictionaryState.CorrectWord.Add(word.Word);
                WordList.Remove(word);
                DictionaryState.WordList.Remove(word.Word);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void MoveWordToInCorrect(WordViewModel word)
        {
            if (word != null)
            {
                IncorrectWord.Add(SelectedItem as WordViewModel);
                DictionaryState.IncorrectWord.Add(word.Word);
                WordList.Remove(word);
                DictionaryState.WordList.Remove(word.Word);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAcceptAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand nextAttemptCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand NextAttemptCommand
        {
            get
            {
                if (nextAttemptCommand == null)
                {
                    nextAttemptCommand = new DelegateCommand(NextAttemptAction, CanNextAttemptAction);
                }
                return nextAttemptCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NextAttemptAction()
        {
            AttemptData attemptData = new AttemptData(ErrorLevelCurrent, PassNumberCurrent, IncorrectWord.Count);
            currentSeans.Attempts.Add(attemptData);
            ErrorLevelCurrent = 0;
            PassNumberCurrent = 0;
            DoneNumberCurrent = 0;
            AttemptNumber++;
            foreach (var v in IncorrectWord)
            {
                v.NativeAnswer = "";
                WordList.Add(v);
                DictionaryState.WordList.Add(v.Word);
            }

            RemainNumber = WordList.Count;
            IncorrectWord.Clear();
            DictionaryState.IncorrectWord.Clear();
            OnQuerySetFocus();
            Save();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanNextAttemptAction()
        {
            return WordList != null && IncorrectWord != null && WordList.Count == 0 && IncorrectWord.Count > 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand newSeansCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand NewSeansCommand
        {
            get
            {
                if (newSeansCommand == null)
                {
                    newSeansCommand = new DelegateCommand(NewSeansAction, CanNewSeansAction);
                }
                return newSeansCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NewSeansAction()
        {
            Initialize();
            //ErrorLevelCurrent = 0;
            //PassNumberCurrent = 0;
            //DoneNumberCurrent = 0;
            //ErrorLevel = 0;
            //PassNumber = 0;
            //DoneNumber = 0;
            //AttemptNumber = 0;
            

            foreach (var v in CorrectWord)
            {
                v.NativeAnswer = "";
                WordList.Add(v);
                DictionaryState.WordList.Add(v.Word);
            }

            RemainNumber = WordList.Count;
            IncorrectWord.Clear();
            DictionaryState.IncorrectWord.Clear();
            CorrectWord.Clear();
            DictionaryState.CorrectWord.Clear();
            Save();

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanNewSeansAction()
        {
            return CorrectWord != null && IncorrectWord != null && CorrectWord.Count > 0 && IncorrectWord.Count == 0 && WordList.Count == 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void OnQuerySetFocus()
        {
            Action handle = QuerySetFocus;
            if (handle != null)
                handle();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DictionaryName" || e.PropertyName == "IsDirect")
            {
                currentSeans = null;
                Initialize();
            }
            else if (e.PropertyName == "IsWorkOnMistakesForProtocol" || e.PropertyName == "ErrorLevelValueForProtocol" ||
                e.PropertyName == "ErrorLevelRelationForProtocol" || e.PropertyName == "IsWorkOnMistakesForProtocol" || e.PropertyName == "WorkOnMistakeRegimForProtocol" ||
                e.PropertyName == "ConsolidatedErrorLevelValueForProtocol" || e.PropertyName == "ConsolidatedErrorLevelRelationForProtocol")
            {
                isChangeMistakeRegim = true;
            }
            else if (e.PropertyName == "SelectedInstalledVoice" )
            {
                synthesizer.SelectVoice(SelectedInstalledVoice.VoiceInfo.Name);
                speechSynthesizerAsTask.Synthesizer.SelectVoice(SelectedInstalledVoice.VoiceInfo.Name);
            }
            else if (e.PropertyName == "SpeedRatio")
            {
                synthesizer.Rate = (int)SpeedRatio;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Settings_PropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {

            if (e.PropertyName == "SelectedPanelIndex" && SelectedPanelIndex == 1)
            {
                if (isChangeMistakeRegim)
                {
                    Initialize();
                }
                if (currentSeans != null)
                    currentSeans.IsWorkOnMistakes = IsWorkOnMistakes;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void Save()
        {
            WordUsersHistory.SaveUsersHistory(); 
            SaveSpeechGroups();
            
        }
        //-------------------------------------------------------------------------------------------------------------------

        internal void Start()
        {
            //foreach(var dict in Word.WordDictionaries.Keys)
            //{
            //    CurrentHistory.DictionaryHistories.ContainsKey()
            //}
            
            Initialize();
            InstalledVoices = new ObservableCollection<InstalledVoice>();
            foreach (var iv in synthesizer.GetInstalledVoices())
            {
                InstalledVoices.Add(iv);
            }
            var david = InstalledVoices.FirstOrDefault(v => v.VoiceInfo.Name.ToLower().Contains("david"));
            if (david != null)
                SelectedInstalledVoice = david;
            else if (InstalledVoices.Count > 0)
                SelectedInstalledVoice = InstalledVoices[0];
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void WordStatistic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                WordStatisticDragDropCommand.Execute(sender);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<object> wordStatisticDragDropCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand WordStatisticDragDropCommand
        {
            get
            {
                if (wordStatisticDragDropCommand == null)
                {
                    wordStatisticDragDropCommand = new DelegateCommand<object>(WordStatisticDragDropAction, CanWordStatisticDragDropAction);
                }
                return wordStatisticDragDropCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void WordStatisticDragDropAction(object sender)
        {
            DataObject dataObject = new DataObject();
//            dataObject.SetData("WordStatistic", SelectedWordStatistic);
            dataObject.SetData(DataFormats.StringFormat, "_");

            DragDrop.DoDragDrop(sender as DependencyObject, dataObject, DragDropEffects.Copy);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanWordStatisticDragDropAction(object sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void errorLevelValue_Drop(object sender, DragEventArgs e)
        {
            ErrorLevelValueDropCommand.Execute(e.Data);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void errorLevelRelation_Drop(object sender, DragEventArgs e)
        {
            ErrorLevelRelationDropCommand.Execute(e.Data);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void consolidatedErrorLevelValue_Drop(object sender, DragEventArgs e)
        {
            ConsolidatedErrorLevelDropCommand.Execute(e.Data);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void consolidatedErrorLevelRelation_Drop(object sender, DragEventArgs e)
        {
            ConsolidatedErrorLevelRelationDropCommand.Execute(e.Data);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> errorLevelValueDropCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ErrorLevelValueDropCommand
        {
            get
            {
                if (errorLevelValueDropCommand == null)
                {
                    errorLevelValueDropCommand = new DelegateCommand<IDataObject>(ErrorLevelValueDropAction, CanErrorLevelValueDropAction);
                }
                return errorLevelValueDropCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ErrorLevelValueDropAction(IDataObject pData)
        {

//            WordStatistic wordStatistic = (WordStatistic)pData.GetData("WordStatistic");
            ErrorLevelValueForProtocol = SelectedWordStatistic.PartOfIncorrect;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanErrorLevelValueDropAction(IDataObject sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> errorLevelRelationDropCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ErrorLevelRelationDropCommand
        {
            get
            {
                if (errorLevelRelationDropCommand == null)
                {
                    errorLevelRelationDropCommand = new DelegateCommand<IDataObject>(ErrorLevelRelationDropAction, CanErrorLevelRelationDropAction);
                }
                return errorLevelRelationDropCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ErrorLevelRelationDropAction(IDataObject pData)
        {
            WordStatistic wordStatistic = SelectedWordStatistic; // (WordStatistic)pData.GetData("WordStatistic");
            int worseCount = CurrentDictionaryHistoryForProtocol.WordStatistics.Where(w => w.PartOfIncorrect >= wordStatistic.PartOfIncorrect).Count();
            int comCount = CurrentDictionaryHistoryForProtocol.WordStatistics.Count();
            ErrorLevelRelationForProtocol = Math.Round((decimal)worseCount / (decimal)comCount, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanErrorLevelRelationDropAction(IDataObject sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> consolidatedErrorLevelDropCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ConsolidatedErrorLevelDropCommand
        {
            get
            {
                if (consolidatedErrorLevelDropCommand == null)
                {
                    consolidatedErrorLevelDropCommand = new DelegateCommand<IDataObject>(ConsolidatedErrorLevelDropAction, CanConsolidatedErrorLevelDropAction);
                }
                return consolidatedErrorLevelDropCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ConsolidatedErrorLevelDropAction(IDataObject pData)
        {

            WordStatistic wordStatistic = SelectedWordStatistic; // (WordStatistic)pData.GetData("WordStatistic");
            ConsolidatedErrorLevelValueForProtocol = wordStatistic.PartOfConsolidateIncorrect;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanConsolidatedErrorLevelDropAction(IDataObject sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> consolidatedErrorLevelRelationDropCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ConsolidatedErrorLevelRelationDropCommand
        {
            get
            {
                if (consolidatedErrorLevelRelationDropCommand == null)
                {
                    consolidatedErrorLevelRelationDropCommand = new DelegateCommand<IDataObject>(ConsolidatedErrorLevelRelationDropAction, CanConsolidatedErrorLevelRelationDropAction);
                }
                return consolidatedErrorLevelRelationDropCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ConsolidatedErrorLevelRelationDropAction(IDataObject pData)
        {

            WordStatistic wordStatistic = SelectedWordStatistic; // (WordStatistic)pData.GetData("WordStatistic");
            int worseCount = CurrentDictionaryHistoryForProtocol.WordStatistics.Where(w => w.PartOfConsolidateIncorrect >= wordStatistic.PartOfConsolidateIncorrect).Count();
            int comCount = CurrentDictionaryHistoryForProtocol.WordStatistics.Count();
            ConsolidatedErrorLevelRelationForProtocol = Math.Round((decimal)worseCount / (decimal)comCount, 2);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanConsolidatedErrorLevelRelationDropAction(IDataObject sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> setDictionaryInBothListCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand SetDictionaryInBothListCommand
        {
            get
            {
                if (setDictionaryInBothListCommand == null)
                {
                    setDictionaryInBothListCommand = new DelegateCommand<IDataObject>(SetDictionaryInBothListAction, CanSetDictionaryInBothListAction);
                }
                return setDictionaryInBothListCommand;
            }
        }
        /*
        Information for developers (use Text Visualizer to read this):
This exception was thrown because the generator for control 'System.Windows.Controls.DataGrid Items.Count:12' with name '(unnamed)' 
         * has received sequence of CollectionChanged events that do not agree with the current state of the Items collection.  
         * The following differences were detected:
  Accumulated count 11 is different from actual count 12.  [Accumulated count is (Count at last Reset + #Adds - #Removes since last Reset).]

One or more of the following sources may have raised the wrong events:
     System.Windows.Controls.ItemContainerGenerator
      System.Windows.Controls.ItemCollection
       System.Windows.Data.ListCollectionView
        System.Collections.Generic.List`1[[DictionaryMemorize.Model.Seans, WpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
(The starred sources are considered more likely to be the cause of the problem.)

The most common causes are 
         * (a) changing the collection or its Count without raising a corresponding event, and 
         * (b) raising an event with an incorrect index or item parameter.

The exception's stack trace describes how the inconsistencies were detected, not how they occurred.  
         * To get a more timely exception, set the attached property 'PresentationTraceSources.TraceLevel' on the generator to value 'High' 
         * and rerun the scenario.  One way to do this is to run a command similar to the following:
   System.Diagnostics.PresentationTraceSources.SetTraceLevel(myItemsControl.ItemContainerGenerator, System.Diagnostics.PresentationTraceLevel.High)
from the Immediate window.  This causes the detection logic to run after every CollectionChanged event, so it will slow down the application.
        */
        //-------------------------------------------------------------------------------------------------------------------
        private void SetDictionaryInBothListAction(IDataObject pData)
        {
            if (SelectedDictionaryComparison != null)
            {
                DictionaryName = SelectedDictionaryComparison.DictionaryName;
                CurrentDictionaryForProtocol = SelectedDictionaryComparison.DictionaryName;
                SelectedPanelIndex = 0;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanSetDictionaryInBothListAction(IDataObject sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> addSpeechGroupCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddSpeechGroupCommand
        {
            get
            {
                if (addSpeechGroupCommand == null)
                {
                    addSpeechGroupCommand = new DelegateCommand<IDataObject>(AddSpeechGroupAction, CanAddSpeechGroupAction);
                }
                return addSpeechGroupCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddSpeechGroupAction(IDataObject pData)
        {
            SpeechGroupViewModel newGroup = new SpeechGroupViewModel() { Title = "new group" };
            SpeechGroups.Add(newGroup);
            SelectedSpeechGroup = newGroup;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddSpeechGroupAction(IDataObject sender)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> deleteSpeechGroupCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand DeleteSpeechGroupCommand
        {
            get
            {
                if (deleteSpeechGroupCommand == null)
                {
                    deleteSpeechGroupCommand = new DelegateCommand<IDataObject>(DeleteSpeechGroupAction, CanDeleteSpeechGroupAction);
                }
                return deleteSpeechGroupCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void DeleteSpeechGroupAction(IDataObject pData)
        {
            if (MessageBox.Show("Are yoy sure?", "Data willbe deleted.", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                SpeechGroups.Remove(SelectedSpeechGroup);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanDeleteSpeechGroupAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> addSpeechPhraseCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddSpeechPhraseCommand
        {
            get
            {
                if (addSpeechPhraseCommand == null)
                {
                    addSpeechPhraseCommand = new DelegateCommand<IDataObject>(AddSpeechPhraseAction, CanAddSpeechPhraseAction);
                }
                return addSpeechPhraseCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddSpeechPhraseAction(IDataObject pData)
        {
            var newPrase = new SpeechPraseViewModel() { Text = "new phrase" };
            SelectedSpeechGroup.Phrases.Add(newPrase);
            SelectedSpeechPhrase = newPrase;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddSpeechPhraseAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> insertSpeechPhraseCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand InsertSpeechPhraseCommand
        {
            get
            {
                if (insertSpeechPhraseCommand == null)
                {
                    insertSpeechPhraseCommand = new DelegateCommand<IDataObject>(InsertSpeechPhraseAction, CanInsertSpeechPhraseAction);
                }
                return insertSpeechPhraseCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void InsertSpeechPhraseAction(IDataObject pData)
        {
            var newPrase = new SpeechPraseViewModel() { Text = "new phrase" };
            SelectedSpeechGroup.Phrases.Insert(SelectedSpeechIndexPhrase + 1, newPrase);
            SelectedSpeechPhrase = newPrase;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanInsertSpeechPhraseAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> deleteSpeechPhraseCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand DeleteSpeechPhraseCommand
        {
            get
            {
                if (deleteSpeechPhraseCommand == null)
                {
                    deleteSpeechPhraseCommand = new DelegateCommand<IDataObject>(DeleteSpeechPhraseAction, CanDeleteSpeechPhraseAction);
                }
                return deleteSpeechPhraseCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void DeleteSpeechPhraseAction(IDataObject pData)
        {
            if (MessageBox.Show("Are yoy sure?", "Data willbe deleted.", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                SelectedSpeechGroup.Phrases.Remove(SelectedSpeechPhrase);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanDeleteSpeechPhraseAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null && SelectedSpeechPhrase != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> playPhraseCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand PlayPhraseCommand
        {
            get
            {
                if (playPhraseCommand == null)
                {
                    playPhraseCommand = new DelegateCommand<IDataObject>(PlayPhraseAction, CanPlayPhraseAction);
                }
                return playPhraseCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void PlayPhraseAction(IDataObject pData)
        {
            if (!IsCustomPauses)
            {
                synthesizer.SpeakAsync(SelectedSpeechPhrase.Text);
            }
            else
            {
                PromptBuilder promptBuilder = new PromptBuilder();

                ProcessPhrase(promptBuilder, SelectedSpeechPhrase);
                ctsPlay = new CancellationTokenSource();
                try
                {
                    Prompt p = await speechSynthesizerAsTask.SpeakAsync(new Prompt(promptBuilder), ctsPlay.Token);
                }
                catch (OperationCanceledException oce)
                {
                    return;
                }
                catch (Exception ce)
                {
                    MessageBox.Show(ce.Message);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanPlayPhraseAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null && SelectedSpeechPhrase != null;
        }
        
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> playPhrasesListCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand PlayPhrasesListCommand
        {
            get
            {
                if (playPhrasesListCommand == null)
                {
                    playPhrasesListCommand = new DelegateCommand<IDataObject>(PlayPhrasesListAction, CanPlayPhrasesListAction);
                }
                return playPhrasesListCommand;
            }
        }
        private CancellationTokenSource ctsPlay = null;
//        private CancellationTokenSource ctsOnePlay = null;
        private SpeechSynthesizerAsTask speechSynthesizerAsTask = new SpeechSynthesizerAsTask();
        //-------------------------------------------------------------------------------------------------------------------
        private async void PlayPhrasesListAction(IDataObject pData)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(SelectedSpeechGroup.Phrases);
            view.MoveCurrentToFirst();

            ctsPlay = new CancellationTokenSource();

            Task task = new Task(async () =>
            {
                try
                {
                    do
                    {
                        if (IsCustomPauses)
                        {
                            foreach (SpeechPraseViewModel currentSpeech in SelectedSpeechGroup.Phrases)
                            {
                                if (!(IsOnlySelected ?? false) || currentSpeech.IsChecked)
                                {
                                    for (int i = 0; i < SpeechRepeat; i++)
                                    {
                                        if (ctsPlay.Token.IsCancellationRequested)
                                            break;
                                        //                 ctsOnePlay = new CancellationTokenSource();
                                        SelectedSpeechPhrase = currentSpeech;

                                        Stopwatch sw = new Stopwatch();
                                        sw.Start();
                                        try
                                        {
                                            Prompt p = await speechSynthesizerAsTask.SpeakAsync(SelectedSpeechPhrase.Text, ctsPlay.Token);
                                        }
                                        catch (OperationCanceledException oce)
                                        {
                                            break;
                                        }
                                        long pause = sw.ElapsedMilliseconds;
                                        sw.Stop();
                                        //                                    synthesizer.Speak(SelectedSpeechPhrase.Text);
                                        //                                    ctsPlay.Token.ThrowIfCancellationRequested();
                                        if (IsPauseEqualDuration)
                                            Thread.Sleep((int)pause);
                                        else
                                            Thread.Sleep(SpeechPause);
                                    }
                                    Application.Current.Dispatcher.Invoke(
                                    (Action)(() =>
                                    {
                                        //                            view.MoveCurrentToNext();
                                        SelectedSpeechPhrase = currentSpeech; // view.CurrentItem as SpeechPrase;
                                        OnSpeechPhraseScrollIntoView();
                                    }));
                                }
                            }
                        }
                        else
                        {
                            PromptBuilder promptBuilder = new PromptBuilder();
                            foreach (SpeechPraseViewModel currentSpeech in SelectedSpeechGroup.Phrases)
                            {
                                if (!(IsOnlySelected ?? false) || currentSpeech.IsChecked)
                                {
                                    ProcessPhrase(promptBuilder, currentSpeech);
                                }
                            }

                            try
                            {
                                Prompt p = await speechSynthesizerAsTask.SpeakAsync(new Prompt(promptBuilder), ctsPlay.Token);
                            }
                            catch (OperationCanceledException oce)
                            {
                                break;
                            }
                            catch (Exception ce)
                            {
                                MessageBox.Show(ce.Message);
                            }
                        }
                        if (ctsPlay.Token.IsCancellationRequested)
                            break;
                    } while (IsSpeechCycle ?? false);
                }
                catch (OperationCanceledException oce)
                {
                    
                }
                catch (Exception ce)
                {
                    MessageBox.Show(ce.Message);
                }
                ctsPlay = null;
            },
            ctsPlay.Token);

            task.Start();

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation canceled");
            }
            // Check for other exceptions. 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ProcessPhrase(PromptBuilder promptBuilder,SpeechPraseViewModel speech)
        {
            for (int i = 0; i < SpeechRepeat; i++)
            {
                string[] paragraphs = speech.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var paragraph in paragraphs)
                {
                    promptBuilder.StartParagraph();
                    string[] sentences = paragraph.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var sentence in sentences)
                    {
                        promptBuilder.StartSentence();
                        promptBuilder.AppendText(sentence);
                        promptBuilder.EndSentence();
                        promptBuilder.AppendBreak(new TimeSpan(0, 0, 0, 0, SentencePause));
                    }
                    promptBuilder.EndParagraph();
                    promptBuilder.AppendBreak(new TimeSpan(0, 0, 0, 0, ParagraphPause));
                }
                promptBuilder.AppendBreak(new TimeSpan(0, 0, 0, 0, SpeechPause));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanPlayPhrasesListAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> addListOfSpeechPhraseCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddListOfSpeechPhraseCommand
        {
            get
            {
                if (addListOfSpeechPhraseCommand == null)
                {
                    addListOfSpeechPhraseCommand = new DelegateCommand<IDataObject>(AddListOfSpeechPhraseAction, CanAddListOfSpeechPhraseAction);
                }
                return addListOfSpeechPhraseCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddListOfSpeechPhraseAction(IDataObject pData)
        {
            if (!string.IsNullOrWhiteSpace(ListOfSpeechPhrase))
            {
            string[] listSpeech = ListOfSpeechPhrase.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string speech in listSpeech)
                if (!string.IsNullOrWhiteSpace(speech))
                    SelectedSpeechGroup.Phrases.Add(new SpeechPraseViewModel() { Text = speech });
            IsListPhraseExpanded = false;
            ListOfSpeechPhrase = "";
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddListOfSpeechPhraseAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null && !string.IsNullOrWhiteSpace(ListOfSpeechPhrase);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> addSpeechPhraseAsOneCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddSpeechPhraseAsOneCommand
        {
            get
            {
                if (addSpeechPhraseAsOneCommand == null)
                {
                    addSpeechPhraseAsOneCommand = new DelegateCommand<IDataObject>(AddSpeechPhraseAsOneAction, CanAddSpeechPhraseAsOneAction);
                }
                return addSpeechPhraseAsOneCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddSpeechPhraseAsOneAction(IDataObject pData)
        {
            if (!string.IsNullOrWhiteSpace(ListOfSpeechPhrase))
            {
                SelectedSpeechGroup.Phrases.Add(new SpeechPraseViewModel() { Text = ListOfSpeechPhrase });
                IsListPhraseExpanded = false;
                ListOfSpeechPhrase = "";
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddSpeechPhraseAsOneAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null && !string.IsNullOrWhiteSpace(ListOfSpeechPhrase);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> stopSpeechCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand StopSpeechCommand
        {
            get
            {
                if (stopSpeechCommand == null)
                {
                    stopSpeechCommand = new DelegateCommand<IDataObject>(StopSpeechAction, CanStopSpeechAction);
                }

                return stopSpeechCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void StopSpeechAction(IDataObject pData)
        {
            if (ctsPlay != null && ctsPlay.Token.CanBeCanceled)
                ctsPlay.Cancel();
            if (synthesizer.State == SynthesizerState.Speaking)
                synthesizer.SpeakAsyncCancelAll();
//            ctsOnePlay.Cancel();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanStopSpeechAction(IDataObject sender)
        {
            return ctsPlay != null && ctsPlay.Token.CanBeCanceled || synthesizer.State == SynthesizerState.Speaking;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ReadSpeechGroups()
        {
            try
            {
                if (File.Exists(SPEECHGROUPFIILENAME))
                {
                    using (Stream stream = new FileStream(SPEECHGROUPFIILENAME, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {

                        IFormatter bs = new BinaryFormatter();
                        List<SpeechGroup> groups = (List<SpeechGroup>)bs.Deserialize(stream);
                        SpeechGroups = SpeechGroupViewModel.CreateSpeechGroupViewModelList(groups);
                    }
                }
                else
                {
                    SpeechGroups = new ObservableCollection<SpeechGroupViewModel>();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SaveSpeechGroups()
        {
            try
            {
                List<SpeechGroup> groups = SpeechGroupViewModel.CreateSpeechGroupList(SpeechGroups);
                using (Stream stream = new FileStream(SPEECHGROUPFIILENAME, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    IFormatter bs = new BinaryFormatter();
                    bs.Serialize(stream, groups);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}

