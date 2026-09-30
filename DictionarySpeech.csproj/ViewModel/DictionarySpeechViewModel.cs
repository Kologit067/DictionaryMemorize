using DictionaryLibrary.Common;
using DictionaryLibrary.Infrastructure;
using DictionaryLibrary.ViewModel;
using DictionarySpeech.csproj.View;
using Speech.BusinessLogic.Contracts.Interfaces;
using Speech.BusinessLogic.Contracts.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Unity.AspNet.Mvc;

namespace DictionarySpeech.csproj.ViewModel
{
    public class DictionarySpeechViewModel : ViewModelBase, ISetFocusQueriable, ISavable, IScrollIntoViewAction
    {

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private CancellationTokenSource ctsPlay = null;
        private SpeechSynthesizerAsTask speechSynthesizerAsTask = new SpeechSynthesizerAsTask();

        public event Action QuerySetFocus;
        public event Action<Object> MainGridScrollIntoView;
        public event Action SpeechPhraseScrollIntoView;
        //-------------------------------------------------------------------------------------------------------------------
        private ObservableCollection<SpeechGroupViewModel> speechGroups;
        public ObservableCollection<SpeechGroupViewModel> SpeechGroups
        {
            get
            {
                return speechGroups;
            }
            set
            {
                speechGroups = value;
                OnPropertyChanged(nameof(SpeechGroups));
            }
        }
        private SpeechGroupViewModel selectedSpeechGroup;
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
                OnPropertyChanged(nameof(SelectedSpeechGroup));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private SpeechPhraseViewModel selectedSpeechPhrase;
        public SpeechPhraseViewModel SelectedSpeechPhrase
        {
            get
            {
                return selectedSpeechPhrase;
            }
            set
            {
                selectedSpeechPhrase = value;
                OnPropertyChanged(nameof(SelectedSpeechPhrase));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int selectedSpeechIndexPhrase;
        public int SelectedSpeechIndexPhrase
        {
            get
            {
                return selectedSpeechIndexPhrase;
            }
            set
            {
                selectedSpeechIndexPhrase = value;
                OnPropertyChanged(nameof(SelectedSpeechIndexPhrase));
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
                OnPropertyChanged(nameof(IsCustomPauses));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int speechRepeat = 1;
        public int SpeechRepeat
        {
            get
            {
                return speechRepeat;
            }
            set
            {
                speechRepeat = value;
                OnPropertyChanged(nameof(SpeechRepeat));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int sentencePause = 500;
        public int SentencePause
        {
            get
            {
                return sentencePause;
            }
            set
            {
                sentencePause = value;
                OnPropertyChanged(nameof(SentencePause));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int paragraphPause = 1000;
        public int ParagraphPause
        {
            get
            {
                return paragraphPause;
            }
            set
            {
                paragraphPause = value;
                OnPropertyChanged(nameof(ParagraphPause));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private int speechPause = 1500;
        public int SpeechPause
        {
            get
            {
                return speechPause;
            }
            set
            {
                speechPause = value;
                OnPropertyChanged(nameof(SpeechPause));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool? isOnlySelected = false;
        public bool? IsOnlySelected
        {
            get
            {
                return isOnlySelected;
            }
            set
            {
                isOnlySelected = value;
                OnPropertyChanged(nameof(IsOnlySelected));
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
                OnPropertyChanged(nameof(IsPauseEqualDuration));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool? isSpeechCycle = false;
        public bool? IsSpeechCycle
        {
            get
            {
                return isSpeechCycle;
            }
            set
            {
                isSpeechCycle = value;
                OnPropertyChanged(nameof(IsSpeechCycle));
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
                OnPropertyChanged(nameof(IsAdditionalSettingExpanded));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ObservableCollection<InstalledVoice> installedVoices;
        public ObservableCollection<InstalledVoice> InstalledVoices
        {
            get
            {
                return installedVoices;
            }
            set
            {
                installedVoices = value;
                OnPropertyChanged(nameof(InstalledVoices));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private InstalledVoice selectedInstalledVoice;
        public InstalledVoice SelectedInstalledVoice
        {
            get
            {
                return selectedInstalledVoice;
            }
            set
            {
                selectedInstalledVoice = value;
                OnPropertyChanged(nameof(SelectedInstalledVoice));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private string listOfSpeechPhrase;
        public string ListOfSpeechPhrase
        {
            get
            {
                return listOfSpeechPhrase;
            }
            set
            {
                listOfSpeechPhrase = value;
                OnPropertyChanged(nameof(ListOfSpeechPhrase));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool isListPhraseExpanded;
        public bool IsListPhraseExpanded
        {
            get
            {
                return isListPhraseExpanded;
            }
            set
            {
                isListPhraseExpanded = value;
                OnPropertyChanged(nameof(IsListPhraseExpanded));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private string operationResult;
        public string OperationResult
        {
            get
            {
                return operationResult;
            }
            set
            {
                operationResult = value;
                OnPropertyChanged(nameof(OperationResult));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        // Command
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
        private async void DeleteSpeechGroupAction(IDataObject pData)
        {
            if (MessageBox.Show("Are yoy sure?", "Data will be deleted.", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var group = SelectedSpeechGroup.GetSpeechGroup();
                ISpeechManager speechManager = GetSpeechManager();
                string result = await speechManager.DeleteSpeechGroup(group);
                if (string.IsNullOrEmpty(result))
                {
                    OperationResult = "Operation is completed succcessfully";
                    SpeechGroups.Remove(SelectedSpeechGroup);
                }
                else
                {
                    OperationResult = result;
                }
            }
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
            var newPhrase = new SpeechPhraseViewModel() { Phrase = "new phrase", SpeechGroupId = selectedSpeechGroup.SpeechGroupId };
            SelectedSpeechGroup.SpeechPhrases.Add(newPhrase);
            SelectedSpeechPhrase = newPhrase;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddSpeechPhraseAction(IDataObject sender)
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
        private async void DeleteSpeechPhraseAction(IDataObject pData)
        {
            if (MessageBox.Show("Are yoy sure?", "Data willbe deleted.", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var phrase = SelectedSpeechPhrase.GetSpeechPhrase();
                ISpeechManager speechManager = GetSpeechManager();
                string result = await speechManager.DeleteSpeechPhrase(phrase);
                if (string.IsNullOrEmpty(result))
                {
                    OperationResult = "Operation is completed succcessfully";
                    SelectedSpeechGroup.SpeechPhrases.Remove(SelectedSpeechPhrase);
                }
                else
                {
                    OperationResult = result;
                }
            }
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
                synthesizer.SelectVoice(SelectedInstalledVoice.VoiceInfo.Name);
                synthesizer.SpeakAsync(SelectedSpeechPhrase.Phrase);
            }
            else
            {
                PromptBuilder promptBuilder = new PromptBuilder();

                ProcessPhrase(promptBuilder, SelectedSpeechPhrase, SelectedInstalledVoice.VoiceInfo.Name);
                ctsPlay = new CancellationTokenSource();
                try
                {
                    speechSynthesizerAsTask.Synthesizer.SelectVoice(SelectedInstalledVoice.VoiceInfo.Name);
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
        //-------------------------------------------------------------------------------------------------------------------
        private async void PlayPhrasesListAction(IDataObject pData)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(SelectedSpeechGroup.SpeechPhrases);
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
                            foreach (SpeechPhraseViewModel currentSpeech in SelectedSpeechGroup.SpeechPhrases)
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
                                            speechSynthesizerAsTask.Synthesizer.SelectVoice(SelectedInstalledVoice.VoiceInfo.Name);
                                            Prompt p = await speechSynthesizerAsTask.SpeakAsync(SelectedSpeechPhrase.Phrase, ctsPlay.Token);
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
                                        SelectedSpeechPhrase = currentSpeech; // view.CurrentItem as SpeechPhrase;
                                        OnSpeechPhraseScrollIntoView();
                                    }));
                                }
                            }
                        }
                        else
                        {
                            PromptBuilder promptBuilder = new PromptBuilder();
                            foreach (SpeechPhraseViewModel currentSpeech in SelectedSpeechGroup.SpeechPhrases)
                            {
                                if (!(IsOnlySelected ?? false) || currentSpeech.IsChecked)
                                {
                                    ProcessPhrase(promptBuilder, currentSpeech, SelectedInstalledVoice.VoiceInfo.Name);
                                }
                            }

                            string xmlPrompt = promptBuilder.ToXml();
//                            xmlPrompt = xmlPrompt.Replace("xml:lang=\"ru-RU\"", "");
//                            xmlPrompt = xmlPrompt.Replace("ru-RU", "en-EN");
                            try
                            {
                                
                                speechSynthesizerAsTask.Synthesizer.SelectVoice(SelectedInstalledVoice.VoiceInfo.Name);
//                                Prompt p = await speechSynthesizerAsTask.SpeakAsync(new Prompt(promptBuilder), ctsPlay.Token);
                                Prompt p = await speechSynthesizerAsTask.SpeakAsync(xmlPrompt, ctsPlay.Token);
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
        private bool CanPlayPhrasesListAction(IDataObject sender)
        {
            return SelectedSpeechGroup != null;
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
            var newPhrase = new SpeechPhraseViewModel() { Phrase = "new phrase", SpeechGroupId = selectedSpeechGroup.SpeechGroupId };
            SelectedSpeechGroup.SpeechPhrases.Insert(SelectedSpeechIndexPhrase + 1, newPhrase);
            SelectedSpeechPhrase = newPhrase;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanInsertSpeechPhraseAction(IDataObject sender)
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
                foreach (string speech in listSpeech)
                    if (!string.IsNullOrWhiteSpace(speech))
                        SelectedSpeechGroup.SpeechPhrases.Add(new SpeechPhraseViewModel() { Phrase = speech, SpeechGroupId = selectedSpeechGroup.SpeechGroupId });
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
                SelectedSpeechGroup.SpeechPhrases.Add(new SpeechPhraseViewModel() { Phrase = ListOfSpeechPhrase, SpeechGroupId = selectedSpeechGroup.SpeechGroupId });
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
        private DelegateCommand<IDataObject> saveDataCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public DelegateCommand<IDataObject> SaveDataCommand
        {
            get
            {
                if (saveDataCommand == null)
                {
                    saveDataCommand = new DelegateCommand<IDataObject>(SaveDataAction, CanSaveDataAction);
                }
                return saveDataCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SaveDataAction(IDataObject pData)
        {
            Save();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanSaveDataAction(IDataObject pData)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<IDataObject> importDataCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public DelegateCommand<IDataObject> ImportDataCommand
        {
            get
            {
                if (importDataCommand == null)
                {
                    importDataCommand = new DelegateCommand<IDataObject>(ImportDataAction, CanImportDataAction);
                }
                return importDataCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ImportDataAction(IDataObject pData)
        {
            Import.SpeechGroupsImporter importer = new Import.SpeechGroupsImporter();
            importer.Import(SpeechGroups);
 //           Save();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanImportDataAction(IDataObject pData)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        // methods
        //-------------------------------------------------------------------------------------------------------------------

        internal void Start()
        {

            ReadSpeechGroups();
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
        public void OnQuerySetFocus()
        {
            QuerySetFocus?.Invoke();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async void Save()
        {
            List<long> dirtyGroup = speechGroups.Where(g => g.IsDirty).Select(g => g.SpeechGroupId).ToList();
            List<long> dirtyPhrase = speechGroups.SelectMany(g => g.SpeechPhrases.Where(p => p.IsDirty)).Select(p => p.SpeechPhraseId).ToList();

            var groups = SpeechGroupViewModel.CreateSpeechGroupList(SpeechGroups);
            ISpeechManager speechManager = GetSpeechManager();
            var result = await speechManager.UpdateSpeechGroups(groups, dirtyGroup, dirtyPhrase);
            SpeechGroupViewModel.UpdateSpeechGroupViewModelList(SpeechGroups, result.SpeechGroup);
            OperationResult = string.IsNullOrEmpty(result.Error) ? "Operation is completed succcessfully" : result.Error;
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnMainGridScrollIntoView(object item)
        {
            MainGridScrollIntoView?.Invoke(item);
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnSpeechPhraseScrollIntoView()
        {
            SpeechPhraseScrollIntoView?.Invoke();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ProcessPhrase(PromptBuilder promptBuilder, SpeechPhraseViewModel speech, string voice)
        {
            for (int i = 0; i < SpeechRepeat; i++)
            {
                string[] paragraphs = speech.Phrase.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var paragraph in paragraphs)
                {
                    promptBuilder.StartParagraph();
                    string[] sentences = paragraph.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var sentence in sentences)
                    {
                        promptBuilder.StartVoice(SelectedInstalledVoice.VoiceInfo.Name);
                        promptBuilder.StartSentence();
                        promptBuilder.AppendText(sentence);
                        promptBuilder.EndSentence();
                        promptBuilder.EndVoice();
                        promptBuilder.AppendBreak(new TimeSpan(0, 0, 0, 0, SentencePause));
                    }
                    promptBuilder.EndParagraph();
                    promptBuilder.AppendBreak(new TimeSpan(0, 0, 0, 0, ParagraphPause));
                }
                promptBuilder.AppendBreak(new TimeSpan(0, 0, 0, 0, SpeechPause));
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void ReadSpeechGroups()
        {
            try
            {
                ISpeechManager speechManager = GetSpeechManager();

                IEnumerable<SpeechGroup> groups = await speechManager.GetSpeechList();
                SpeechGroups = SpeechGroupViewModel.CreateSpeechGroupViewModelList(groups);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ISpeechManager GetSpeechManager()
        {

            Unity.IUnityContainer container = UnityConfig.GetConfiguredContainer();

            var resolver = new UnityDependencyResolver(container);

            ISpeechManager speechManager = (ISpeechManager)resolver.GetService(typeof(ISpeechManager)); ;

            return speechManager;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
