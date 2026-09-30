using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DictionaryLibrary.ViewModel;
using System.Windows.Input;
using DictionaryManiplate.Repository;
using DictionaryManiplate.Model;
using System.Collections.ObjectModel;
using DictionaryLibrary.Common;
using DictionaryManipulate.TextPocess;
using DictionaryLibrary.Model;
using DictionaryManiplate.ViewModel;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using DictionaryLibrary.Contract;
using DictionaryManiplate.Contract;

namespace DictionaryManipulate.ViewModel
{
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryManipulateViewModel
    //-------------------------------------------------------------------------------------------------------------------
    public class DictionaryManipulateViewModel : ViewModelBase, IErrorAction,
        IScrollIntoViewAction, IOnLoadAction, IFocusable
    {
        private bool isTraceWordSearchInDictionaryManualChanges = true;
        private string author;
        private string title;
        private string content;
        private BookRepository bookRepository;
        private DictionaryLearnRepository dictionaryLearnRepository;
        private BookWordRepository bookWordRepository;
        private FieldRepository fieldRepository;
        private WordExceptionRepository wordExceptionRepository;
        private AuthorRepository authorRepository;
        private WordRepository wordRepository;
        private DictionaryRepository dictionaryRepository;
        private DictionaryWordRepository dictionaryWordRepository;
        private DictionaryLearnCandidatWordRepository dictionaryLearnCandidatWordRepository;
        private ExtractedPiecesRepository extractedPiecesRepository;
        private int selectedFieldIndex;
        private Field selectedField;
        private Field selectedBookField;
        private Book selectedBookFieldBook;
        private BookWord selectedBookFieldBookWord;
        private Author selectedBookAuthor;
        private Book selectedBookAuthorBook;
        private BookWord selectedBookAuthorBookWord;
        private Field selectedWordField;
 //       private Book selectedWordFieldBook;
        private BookWord selectedWordFieldWord;
        private TotalWord selectedTotalWord;
        private DictionaryWord selectedWordFromDictionary;
        private Dictionary wordSelectedDictionary;
        private Field selectedFieldForDictionary;
        private Author selectedAuthorForDictionary;
        private Book selectedBookForDictionary;
        private ObservableCollection<Field> fields;
        private ObservableCollection<Field> bookFields;
        private ObservableCollection<Book> bookFieldsBooks;
        private ObservableCollection<BookWord> bookFieldsBookWords;
        private ObservableCollection<Author> bookAuthors;
        private ObservableCollection<Book> bookAuthorsBooks;
        private ObservableCollection<BookWord> bookAuthorsBookWords;
        private ObservableCollection<Field> wordFields;
        private ObservableCollection<FieldWord> wordFieldsWords;
        private ObservableCollection<TotalWord> totalWords;
        private ObservableCollection<Dictionary> dictionaryList;
        private ObservableCollection<DictionaryWord> wordFromDictionaryList;
        private ObservableCollection<WordInBooks> wordInBooksList;
        private ObservableCollection<Field> fieldsForDictionary;
        private ObservableCollection<Author> authorsForDictionary;
        private ObservableCollection<Book> booksForDictionary;
        private ObservableCollection<DictionaryLearnCandidatWord> learnCandidatWords;
        private ObservableCollection<DictionaryLearnWordViewModel> learnCandidatManualWords;
        private DictionaryLearnCandidatWord selectedWordForDictionary;
        private ObservableCollection<DictionaryLearnWordViewModel> wordDictionaryCreate;
        private DictionaryLearnWordViewModel selectedWordDictionaryCreate;
        private ObservableCollection<DictionaryLearnWordViewModel> wordDictionaryException;
        private ObservableCollection<DictionaryWord> foundedWords;
        private DictionaryLearnWordViewModel selectedWordDictionaryException;
        public event Action<Exception> ErrorOccur;
        public event Action<Object> MainGridScrollIntoView;
        public event Action SpeechPhraseScrollIntoView;
        public event Action<string> ChangeFocus;
        private DictionaryContext dictionaryContext;
        private DictionaryWord selectedFoundedWord;
        private string dictionaryTypeName;
        private string dictionaryName;
        private TextProcessViewModel textProcessModel;
        private string directory;
        private string wordSearchInDictionary;
        private string wordSearchInDictionaryManual;
        private DictionaryWord selectedWordSearchInDictionary;
        private string newDictionaryName;
        private double newDictionaryCreatingRate;
        private double newDictionaryCreatingTop;
        private int newDictionaryCreatingTabIndex;
        private bool isRateSelectWordDictionary;
        private bool isTopSelectWordDictionary;
        private bool isAddCandidateenable = true;
        private TextProcess shortDictionaryAsTree;
        private List<DictionaryWord> shortDictionary;
        private string textForManualProcessing;
        private bool isShortDictionaryAsTreeReady;
        private bool isSpaceAsSeparatorManualVocabulary;
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Field> Fields
        {
            get
            {
                return fields;
            }
            set
            {
                fields = value;
                OnPropertyChanged("Fields");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Field> BookFields
        {
            get
            {
                return bookFields;
            }
            set
            {
                bookFields = value;
                OnPropertyChanged("BookFields");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Book> BookFieldsBooks
        {
            get
            {
                return bookFieldsBooks;
            }
            set
            {
                bookFieldsBooks = value;
                OnPropertyChanged("BookFieldsBooks");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<BookWord> BookFieldsBookWords
        {
            get
            {
                return bookFieldsBookWords;
            }
            set
            {
                bookFieldsBookWords = value;
                OnPropertyChanged("BookFieldsBookWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Author> BookAuthors
        {
            get
            {
                return bookAuthors;
            }
            set
            {
                bookAuthors = value;
                OnPropertyChanged("BookAuthors");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Book> BookAuthorsBooks
        {
            get
            {
                return bookAuthorsBooks;
            }
            set
            {
                bookAuthorsBooks = value;
                OnPropertyChanged("BookAuthorsBooks");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<BookWord> BookAuthorsBookWords
        {
            get
            {
                return bookAuthorsBookWords;
            }
            set
            {
                bookAuthorsBookWords = value;
                OnPropertyChanged("BookAuthorsBookWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Field> WordFields
        {
            get
            {
                return wordFields;
            }
            set
            {
                wordFields = value;
                OnPropertyChanged("WordFields");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Field> FieldsForDictionary
        {
            get
            {
                return fieldsForDictionary;
            }
            set
            {
                fieldsForDictionary = value;
                OnPropertyChanged("FieldsForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Author> AuthorsForDictionary
        {
            get
            {
                return authorsForDictionary;
            }
            set
            {
                authorsForDictionary = value;
                OnPropertyChanged("AuthorsForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Book> BooksForDictionary
        {
            get
            {
                return booksForDictionary;
            }
            set
            {
                booksForDictionary = value;
                OnPropertyChanged("BooksForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<FieldWord> WordFieldsWords
        {
            get
            {
                return wordFieldsWords;
            }
            set
            {
                wordFieldsWords = value;
                OnPropertyChanged("WordFieldsWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<DictionaryLearnCandidatWord> LearnCandidatWords
        {
            get
            {
                return learnCandidatWords;
            }
            set
            {
                learnCandidatWords = value;
                OnPropertyChanged("LearnCandidatWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<DictionaryLearnWordViewModel> LearnCandidatManualWords
        {
            get
            {
                return learnCandidatManualWords;
            }
            set
            {
                learnCandidatManualWords = value;
                OnPropertyChanged("LearnCandidatManualWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<TotalWord> TotalWords
        {
            get
            {
                return totalWords;
            }
            set
            {
                totalWords = value;
                OnPropertyChanged("TotalWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<Dictionary> DictionaryList
        {
            get
            {
                return dictionaryList;
            }
            set
            {
                dictionaryList = value;
                OnPropertyChanged("DictionaryList");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<DictionaryWord> WordFromDictionaryList
        {
            get
            {
                return wordFromDictionaryList;
            }
            set
            {
                wordFromDictionaryList = value;
                OnPropertyChanged("WordFromDictionaryList");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<WordInBooks> WordInBooksList
        {
            get
            {
                return wordInBooksList;
            }
            set
            {
                wordInBooksList = value;
                OnPropertyChanged("WordInBooksList");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<DictionaryManiplate.ViewModel.DictionaryLearnWordViewModel> WordDictionaryCreate
        {
            get
            {
                return wordDictionaryCreate;
            }
            set
            {
                wordDictionaryCreate = value;
                OnPropertyChanged("WordDictionaryCreate");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryLearnWordViewModel SelectedWordDictionaryCreate
        {
            get
            {
                return selectedWordDictionaryCreate;
            }
            set
            {
                selectedWordDictionaryCreate = value;
                OnPropertyChanged("SelectedWordDictionaryCreate");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<DictionaryManiplate.ViewModel.DictionaryLearnWordViewModel> WordDictionaryException
        {
            get
            {
                return wordDictionaryException;
            }
            set
            {
                wordDictionaryException = value;
                OnPropertyChanged("WordDictionaryException");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public ObservableCollection<DictionaryWord> FoundedWords
        {
            get
            {
                return foundedWords;
            }
            set
            {
                foundedWords = value;
                OnPropertyChanged("FoundedWords");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryLearnWordViewModel SelectedWordDictionaryException
        {
            get
            {
                return selectedWordDictionaryException;
            }
            set
            {
                selectedWordDictionaryException = value;
                OnPropertyChanged("SelectedWordDictionaryException");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Field SelectedField
        {
            get
            {
                return selectedField;
            }
            set
            {
                selectedField = value;
                OnPropertyChanged("SelectedField");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int SelectedFieldIndex
        {
            get
            {
                return selectedFieldIndex;
            }
            set
            {
                selectedFieldIndex = value;
                OnPropertyChanged("SelectedFieldIndex");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool? foundedWordsIsFocused;
        public bool? FoundedWordsIsFocused {
            get {
                return foundedWordsIsFocused;
            }
            set {
                foundedWordsIsFocused = value;
                OnPropertyChanged("FoundedWordsIsFocused");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool? wordSearchInDictionaryManualIsFocused;
        public bool? WordSearchInDictionaryManualIsFocused {
            get {
                return wordSearchInDictionaryManualIsFocused;
            }
            set {
                wordSearchInDictionaryManualIsFocused = value;
                OnPropertyChanged("WordSearchInDictionaryManualIsFocused");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int NewDictionaryCreatingTabIndex
        {
            get
            {
                return newDictionaryCreatingTabIndex;
            }
            set
            {
                newDictionaryCreatingTabIndex = value;
                OnPropertyChanged("NewDictionaryCreatingTabIndex");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Field SelectedBookField
        {
            get
            {
                return selectedBookField;
            }
            set
            {
                selectedBookField = value;
                OnPropertyChanged("SelectedBookField");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Book SelectedBookFieldBook
        {
            get
            {
                return selectedBookFieldBook;
            }
            set
            {
                selectedBookFieldBook = value;
                OnPropertyChanged("SelectedBookFieldBook");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public BookWord SelectedBookFieldBookWord
        {
            get
            {
                return selectedBookFieldBookWord;
            }
            set
            {
                selectedBookFieldBookWord = value;
                OnPropertyChanged("SelectedBookFieldBookWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Author SelectedBookAuthor
        {
            get
            {
                return selectedBookAuthor;
            }
            set
            {
                selectedBookAuthor = value;
                OnPropertyChanged("SelectedBookAuthor");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Book SelectedBookAuthorBook
        {
            get
            {
                return selectedBookAuthorBook;
            }
            set
            {
                selectedBookAuthorBook = value;
                OnPropertyChanged("SelectedBookAuthorBook");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public BookWord SelectedBookAuthorBookWord
        {
            get
            {
                return selectedBookAuthorBookWord;
            }
            set
            {
                selectedBookAuthorBookWord = value;
                OnPropertyChanged("SelectedBookAuthorBookWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Field SelectedWordField
        {
            get
            {
                return selectedWordField;
            }
            set
            {
                selectedWordField = value;
                OnPropertyChanged("SelectedWordField");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public BookWord SelectedWordFieldWord
        {
            get
            {
                return selectedWordFieldWord;
            }
            set
            {
                selectedWordFieldWord = value;
                OnPropertyChanged("SelectedWordFieldWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public TotalWord SelectedTotalWord
        {
            get
            {
                return selectedTotalWord;
            }
            set
            {
                selectedTotalWord = value;
                OnPropertyChanged("SelectedTotalWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryWord SelectedWordFromDictionary
        {
            get
            {
                return selectedWordFromDictionary;
            }
            set
            {
                selectedWordFromDictionary = value;
                OnPropertyChanged("SelectedWordFromDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Dictionary WordSelectedDictionary
        {
            get
            {
                return wordSelectedDictionary;
            }
            set
            {
                wordSelectedDictionary = value;
                OnPropertyChanged("WordSelectedDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Field SelectedFieldForDictionary
        {
            get
            {
                return selectedFieldForDictionary;
            }
            set
            {
                selectedFieldForDictionary = value;
                OnPropertyChanged("SelectedFieldForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Author SelectedAuthorForDictionary
        {
            get
            {
                return selectedAuthorForDictionary;
            }
            set
            {
                selectedAuthorForDictionary = value;
                OnPropertyChanged("SelectedAuthorForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public Book SelectedBookForDictionary
        {
            get
            {
                return selectedBookForDictionary;
            }
            set
            {
                selectedBookForDictionary = value;
                OnPropertyChanged("SelectedBookForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryLearnCandidatWord SelectedWordForDictionary
        {
            get
            {
                return selectedWordForDictionary;
            }
            set
            {
                selectedWordForDictionary = value;
                OnPropertyChanged("SelectedWordForDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string DictionaryTypeName
        {
            get
            {
                return dictionaryTypeName;
            }
            set
            {
                dictionaryTypeName = value;
                OnPropertyChanged("DictionaryTypeName");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string DictionaryName
        {
            get
            {
                return dictionaryName;
            }
            set
            {
                dictionaryName = value;
                OnPropertyChanged("DictionaryName");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string Directory
        {
            get
            {
                return directory;
            }
            set
            {
                directory = value;
                OnPropertyChanged("Directory");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public TextProcessViewModel TextProcessModel
        {
            get
            {
                return textProcessModel;
            }
            set
            {
                textProcessModel = value;
                OnPropertyChanged("TextProcessModel");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string WordSearchInDictionary
        {
            get
            {
                return wordSearchInDictionary;
            }
            set
            {
                wordSearchInDictionary = value;
                OnPropertyChanged("WordSearchInDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryWord SelectedWordSearchInDictionary
        {
            get
            {
                return selectedWordSearchInDictionary;
            }
            set
            {
                selectedWordSearchInDictionary = value;
                OnPropertyChanged("SelectedWordSearchInDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string WordSearchInDictionaryManual
        {
            get
            {
                return wordSearchInDictionaryManual;
            }
            set
            {
                wordSearchInDictionaryManual = value;
                OnPropertyChanged("WordSearchInDictionaryManual");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public double NewDictionaryCreatingRate
        {
            get
            {
                return newDictionaryCreatingRate;
            }
            set
            {
                newDictionaryCreatingRate = value;
                OnPropertyChanged("NewDictionaryCreatingRate");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public double NewDictionaryCreatingTop
        {
            get
            {
                return newDictionaryCreatingTop;
            }
            set
            {
                newDictionaryCreatingTop = value;
                OnPropertyChanged("NewDictionaryCreatingTop");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string NewDictionaryName
        {
            get
            {
                return newDictionaryName;
            }
            set
            {
                newDictionaryName = value;
                OnPropertyChanged("NewDictionaryName");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsTopSelectWordDictionary
        {
            get
            {
                return isTopSelectWordDictionary;
            }
            set
            {
                isTopSelectWordDictionary = value;
                OnPropertyChanged("IsTopSelectWordDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsRateSelectWordDictionary
        {
            get
            {
                return isRateSelectWordDictionary;
            }
            set
            {
                isRateSelectWordDictionary = value;
                OnPropertyChanged("IsRateSelectWordDictionary");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsAddCandidateenable
        {
            get
            {
                return isAddCandidateenable;
            }
            set
            {
                isAddCandidateenable = value;
                OnPropertyChanged("IsAddCandidateenable");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public string TextForManualProcessing
        {
            get
            {
                return textForManualProcessing;
            }
            set
            {
                textForManualProcessing = value;
                OnPropertyChanged("TextForManualProcessing");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsShortDictionaryAsTreeReady
        {
            get
            {
                return isShortDictionaryAsTreeReady;
            }
            set
            {
                isShortDictionaryAsTreeReady = value;
                OnPropertyChanged("IsShortDictionaryAsTreeReady");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool IsSpaceAsSeparatorManualVocabulary 
        {
            get
            {
                return isSpaceAsSeparatorManualVocabulary;
            }
            set
            {
                isSpaceAsSeparatorManualVocabulary = value;
                OnPropertyChanged("IsSpaceAsSeparatorManualVocabulary");
            }
        }
        
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryWord SelectedFoundedWord
        {
            get
            {
                return selectedFoundedWord;
            }
            set
            {
                selectedFoundedWord = value;
                OnPropertyChanged("SelectedFoundedWord");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryManipulateViewModel()
        {

            dictionaryContext = new DictionaryContext("name=Vocabulary");
            bookRepository = new BookRepository(dictionaryContext);
            dictionaryLearnRepository = new DictionaryLearnRepository(dictionaryContext);
            bookWordRepository = new BookWordRepository(dictionaryContext);
            fieldRepository = new FieldRepository(dictionaryContext);
            wordExceptionRepository = new WordExceptionRepository(dictionaryContext);
            authorRepository = new AuthorRepository(dictionaryContext);
            wordRepository = new WordRepository(dictionaryContext);
            dictionaryRepository = new DictionaryRepository(dictionaryContext);
            dictionaryWordRepository = new DictionaryWordRepository(dictionaryContext);
            dictionaryLearnCandidatWordRepository = new DictionaryLearnCandidatWordRepository(dictionaryContext);
            extractedPiecesRepository = new ExtractedPiecesRepository(dictionaryContext);
            Fields = fieldRepository.GetCollection();
            BookFields = fieldRepository.GetCollection();
            WordFields = fieldRepository.GetCollection();
            FieldsForDictionary = fieldRepository.GetCollection();
            AuthorsForDictionary = authorRepository.GetCollection();
            BookAuthors = authorRepository.GetCollection();
            TotalWords = wordRepository.GetCollection();
            DictionaryList = dictionaryRepository.GetCollectionOfENG_RUS();
            TextProcessModel = new TextProcessViewModel();
            WordInBooksList = new ObservableCollection<WordInBooks>();
            LearnCandidatWords = new ObservableCollection<DictionaryLearnCandidatWord>();
            WordDictionaryCreate = new ObservableCollection<DictionaryLearnWordViewModel>();
            WordDictionaryException = new ObservableCollection<DictionaryLearnWordViewModel>();
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryException) as ListCollectionView;
            lcv.SortDescriptions.Add(new SortDescription("Native", ListSortDirection.Ascending));
            FoundedWords = new ObservableCollection<DictionaryWord>();
            LearnCandidatManualWords = new ObservableCollection<DictionaryLearnWordViewModel>();

            PropertyChanged += DictionaryManipulateViewModel_PropertyChanged;
        }
        //-------------------------------------------------------------------------------------------------------------------
        static DictionaryManipulateViewModel()
        {
            Word.IsDirect = DictionaryManiplate.Properties.Settings.Default.IsDirect;
            Word.DictionaryName = DictionaryManiplate.Properties.Settings.Default.DictionaryName;
            Word.DictionaryDirectory = DictionaryManiplate.Properties.Settings.Default.DictionaryDirectory;
            Word.Initialize();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void DictionaryManipulateViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedBookField")
            {
                BookFieldsBooks = new ObservableCollection<Book>();
                foreach (var b in SelectedBookField.Books)
                    bookFieldsBooks.Add(b);
            }
            if (e.PropertyName == "SelectedBookFieldBook")
            {
                BookFieldsBookWords = new ObservableCollection<BookWord>();
                if (SelectedBookFieldBook != null)
                {
                    foreach (var w in SelectedBookFieldBook.BookWords.OrderByDescending(w => w.Count))
                        BookFieldsBookWords.Add(w);
                }
            }
            if (e.PropertyName == "SelectedBookAuthor")
            {
                BookAuthorsBooks = new ObservableCollection<Book>();
                foreach (var b in SelectedBookAuthor.Books)
                    bookAuthorsBooks.Add(b);
            }
            if (e.PropertyName == "SelectedBookAuthorBook")
            {
                BookAuthorsBookWords = new ObservableCollection<BookWord>();
                if (SelectedBookAuthorBook != null)
                {
                    foreach (var w in SelectedBookAuthorBook.BookWords.OrderByDescending(w => w.Count))
                        BookAuthorsBookWords.Add(w);
                }
            }
            if (e.PropertyName == "SelectedWordField")
            {
                WordFieldsWords = new ObservableCollection<FieldWord>();
                if (SelectedWordField != null)
                {
                    foreach (var w in SelectedWordField.FieldWords.OrderByDescending(w => w.Count))
                        WordFieldsWords.Add(w);
                }
            }
            if (e.PropertyName == "WordSelectedDictionary")
            {
                CreateWordFromDictionaryList();
            }
            if (e.PropertyName == "SelectedAuthorForDictionary")
            {
                BooksForDictionary = new ObservableCollection<Book>();
                if (SelectedAuthorForDictionary != null)
                {
                    foreach (var b in SelectedAuthorForDictionary.Books)
                        BooksForDictionary.Add(b);
                }
            }
            if (e.PropertyName == "SelectedFieldForDictionary")
            {
                BooksForDictionary = new ObservableCollection<Book>();
                if (SelectedFieldForDictionary != null)
                {
                    foreach (var b in SelectedFieldForDictionary.Books)
                        BooksForDictionary.Add(b);
                }
            }
            if (e.PropertyName == "WordSearchInDictionaryManual")
            {
                if (isTraceWordSearchInDictionaryManualChanges && shortDictionaryAsTree != null)
                {
                    SelectedWordSearchInDictionary = null;
                    CreateListAsync(WordSearchInDictionaryManual, 5);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void CreateListAsync(string pStartWord, int pMaxCount = 5)
        {
            List<IDictionaryWord> list = await shortDictionaryAsTree.CreateListAsync(pStartWord, pMaxCount);
            FoundedWords.Clear();
            foreach (var w in list)
                if (w != null)
                    FoundedWords.Add(new DictionaryWord()
                    {
                        DictionaryWordId = w.DictionaryWordId,
                        Native = w.Native,
                        Translation = w.Translation,
                        Transcription = w.Transcription,
                        ShortTranslation = w.ShortTranslation,
                        DictionaryId = w.DictionaryId
                    });
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void CreateWordFromDictionaryList()
        {
            if (WordSelectedDictionary != null)
            {
                //WordFromDictionaryList = dictionaryWordRepository.GetWordOfDictionaryCollection(WordSelectedDictionary.DictionaryId);
                Task<List<DictionaryWord>> task = new Task<List<DictionaryWord>>(() => dictionaryWordRepository.GetWordOfDictionaryCollection(WordSelectedDictionary.DictionaryId));
                task.Start();
                List<DictionaryWord> list = await task;
                WordFromDictionaryList = list.ConvertToObservableCollection();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand addBookCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddBookCommand
        {
            get
            {
                if (addBookCommand == null)
                {
                    addBookCommand = new DelegateCommand(AddBookCommandAction, CanAddBookCommandAction);
                }
                return addBookCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddBookCommandAction()
        {
            if (SelectedField == null)
                SelectedField = Fields[selectedFieldIndex];
            if (bookRepository.Add(SelectedField, Author, Title, Content))
            {
                Title = "";
                Content = "";
            }
            else
            {
                OnErrorOccur(bookRepository.Error);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddBookCommandAction()
        {
//            if (!string.IsNullOrEmpty(Author) && !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Content))
                return true;
//            return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnErrorOccur(Exception error)
        {
            Action<Exception> handler = ErrorOccur;
            if (handler != null)
                handler(error);
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnErrorOccur(string controlName) {
            Action<string> handler = ChangeFocus;
            if (handler != null)
                handler(controlName);
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnMainGridScrollIntoView(object item)
        {
            Action<object> handler = MainGridScrollIntoView;
            if (handler != null)
                handler(item);
        }
        //-------------------------------------------------------------------------------------------------------------------
        protected virtual void OnChangeFocus(string controlName) {
            Action<string> handler = ChangeFocus;
            if (handler != null)
                handler(controlName);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand addDictionaryCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddDictionaryCommand
        {
            get
            {
                if (addDictionaryCommand == null)
                {
                    addDictionaryCommand = new DelegateCommand(AddDictionaryCommandAction, CanAddDictionaryCommandAction);
                }
                return addDictionaryCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddDictionaryCommandAction()
        {
//            dictionaryContext.SaveChanges();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
//            dlg.InitialDirectory = ConfigurationsDirectory;
            dlg.DefaultExt = ".xdxf"; // Default dictname extension
            dlg.Filter = "Text documents (.xdxf)|*.xdxf"; // Filter files by extension 

            // Show open dictname dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open dictname dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Directory = Path.GetDirectoryName(filename);
                DictionaryContext context = new DictionaryContext("name=Vocabulary");
                DictionaryRepository dicRepository = new DictionaryRepository(context);
                DirectoryInfo di = new DirectoryInfo(Directory);
                FileInfo[] files = di.GetFiles("*.xdxf", SearchOption.AllDirectories);
                foreach (var fi in files)
                {
                    IEnumerable<DictionaryWord> words = XmlRepository.ProcessXDXFFile(fi.FullName, dicRepository);
                    dicRepository.Add(words);
//                    dictionaryContext.SaveChanges();
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddDictionaryCommandAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand booksProcessCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand BooksProcessCommand
        {
            get
            {
                if (booksProcessCommand == null)
                {
                    booksProcessCommand = new DelegateCommand(BooksProcessAction, CanBooksProcessAction);
                }
                return booksProcessCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void BooksProcessAction()
        {
            Dictionary<int,List<WordCount>> lWordCountDictionary = new Dictionary<int,List<WordCount>>();
            foreach (var b in bookRepository.List)
            {
                TextProcess textProcess = new TextProcess();
                textProcess.AddTextToTree(b.Content);
                List<WordCount> lWordCountList = textProcess.CreateList();
                lWordCountDictionary.Add(b.BookId, lWordCountList);
            }
            bookRepository.SaveBookWord(lWordCountDictionary);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanBooksProcessAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand newBooksProcessCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand NewBooksProcessCommand
        {
            get
            {
                if (newBooksProcessCommand == null)
                {
                    newBooksProcessCommand = new DelegateCommand(NewBooksProcessAction, CanNewBooksProcessAction);
                }
                return newBooksProcessCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NewBooksProcessAction()
        {
            Dictionary<int, List<WordCount>> lWordCountDictionary = new Dictionary<int, List<WordCount>>();
            foreach (var b in bookRepository.GetUnProcessedBooks())
            {
                TextProcess textProcess = new TextProcess();
                textProcess.AddTextToTree(b.Content);
                List<WordCount> lWordCountList = textProcess.CreateList();
                lWordCountDictionary.Add(b.BookId, lWordCountList);
            }
            bookRepository.SaveBookWord(lWordCountDictionary);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanNewBooksProcessAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand saveCustomdoctionarureCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand SaveCustomdoctionarureCommand
        {
            get
            {
                if (saveCustomdoctionarureCommand == null)
                {
                    saveCustomdoctionarureCommand = new DelegateCommand(SaveCustomdoctionarureAction, CanSaveCustomdoctionarureAction);
                }
                return saveCustomdoctionarureCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SaveCustomdoctionarureAction()
        {
            if (Word.WordDictionaries.Count == 0)
            {
                Word.LoadDictionary();
            }
            foreach(var wd in Word.WordDictionaries)
            {
                dictionaryLearnRepository.Add(wd.Key, wd.Value);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanSaveCustomdoctionarureAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand wordSearchInDictionaryCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand WordSearchInDictionaryCommand
        {
            get
            {
                if (wordSearchInDictionaryCommand == null)
                {
                    wordSearchInDictionaryCommand = new DelegateCommand(WordSearchInDictionaryAction, CanWordSearchInDictionaryAction);
                }
                return wordSearchInDictionaryCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void WordSearchInDictionaryAction()
        {
            DictionaryWord word = WordFromDictionaryList.Where(w => w.Native.StartsWith(WordSearchInDictionary)).FirstOrDefault();
            if (word != null)
            {
                SelectedWordFromDictionary = word;
                OnMainGridScrollIntoView(word);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanWordSearchInDictionaryAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand wordSearchShowBooksCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand WordSearchShowBooksCommand
        {
            get
            {
                if (wordSearchShowBooksCommand == null)
                {
                    wordSearchShowBooksCommand = new DelegateCommand(WordSearchShowBooksAction, CanWordSearchShowBooksAction);
                }
                return wordSearchShowBooksCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void WordSearchShowBooksAction()
        {
            if (SelectedWordFromDictionary != null)
            {
                WordInBooksList = dictionaryWordRepository.GetWordInBooksList(SelectedWordFromDictionary.Native, false);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanWordSearchShowBooksAction()
        {
            if (SelectedWordFromDictionary != null)
                return true;
            else
                return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand wordSearchShowBooksExtCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand WordSearchShowBooksExtCommand
        {
            get
            {
                if (wordSearchShowBooksExtCommand == null)
                {
                    wordSearchShowBooksExtCommand = new DelegateCommand(WordSearchShowBooksExtAction, CanWordSearchShowBooksExtAction);
                }
                return wordSearchShowBooksExtCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void WordSearchShowBooksExtAction()
        {
            if (SelectedWordFromDictionary != null)
            {
                WordInBooksList = dictionaryWordRepository.GetWordInBooksList(SelectedWordFromDictionary.Native, true);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanWordSearchShowBooksExtAction()
        {
            if (SelectedWordFromDictionary != null)
                return true;
            else
                return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand addCandidateWordsCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddCandidateWordsCommand
        {
            get
            {
                if (addCandidateWordsCommand == null)
                {
                    addCandidateWordsCommand = new DelegateCommand(AddCandidateWordsAction, CanAddCandidateWordsAction);
                }
                return addCandidateWordsCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void AddCandidateWordsAction()
        {
            if (SelectedBookForDictionary != null)
            {
                IsAddCandidateenable = false;
                LearnCandidatWords.Clear();
                int lBookId = SelectedBookForDictionary.BookId;
                Task<List<DictionaryLearnCandidatWord>> task = new Task<List<DictionaryLearnCandidatWord>>(() => dictionaryLearnCandidatWordRepository.GetCandidatWordByBookOrderedByCount(lBookId));
                task.Start();
//                List<DictionaryLearnCandidatWord> list = dictionaryLearnCandidatWordRepository.GetCandidatWordByBookOrderedByCount(SelectedBookForDictionary.BookId);
                List<DictionaryLearnCandidatWord> list = await task;
                foreach (var b in list)
                    LearnCandidatWords.Add(b);
                IsAddCandidateenable = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddCandidateWordsAction()
        {
            return IsAddCandidateenable;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand addCandidateWordsfromGroupCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddCandidateWordsfromGroupCommand
        {
            get
            {
                if (addCandidateWordsfromGroupCommand == null)
                {
                    addCandidateWordsfromGroupCommand = new DelegateCommand(AddCandidateWordsfromGroupAction, CanAddCandidateWordsfromGroupAction);
                }
                return addCandidateWordsfromGroupCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void AddCandidateWordsfromGroupAction()
        {
            List<int> sb = new List<int>();
            foreach (Book b in BooksForDictionary)
                if (b.IsSelected)
                    sb.Add(b.BookId);
            if (SelectedBookForDictionary != null)
            {
                IsAddCandidateenable = false;
                LearnCandidatWords.Clear();
                Task<List<DictionaryLearnCandidatWord>> task = new Task<List<DictionaryLearnCandidatWord>>(() => dictionaryLearnCandidatWordRepository.GetCandidatWordByBooks(sb));
                task.Start();
                //                List<DictionaryLearnCandidatWord> list = dictionaryLearnCandidatWordRepository.GetCandidatWordByBookOrderedByCount(SelectedBookForDictionary.BookId);
                List<DictionaryLearnCandidatWord> list = await task;
                foreach (var b in list)
                    LearnCandidatWords.Add(b);
                IsAddCandidateenable = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddCandidateWordsfromGroupAction()
        {
            return IsAddCandidateenable;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand setRateAndTopCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand SetRateAndTopCommand
        {
            get
            {
                if (setRateAndTopCommand == null)
                {
                    setRateAndTopCommand = new DelegateCommand(SetRateAndTopAction, CanSetRateAndTopAction);
                }
                return setRateAndTopCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SetRateAndTopAction()
        {
            if (SelectedWordForDictionary != null)
            {
                NewDictionaryCreatingRate = SelectedWordForDictionary.Count;
                NewDictionaryCreatingTop = LearnCandidatWords.OrderByDescending(c => c.Count).ThenBy(c => c.Native).TakeWhile(c => c.Native != SelectedWordForDictionary.Native).Count();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanSetRateAndTopAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand createDictionaryForProcessCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CreateDictionaryForProcessCommand
        {
            get
            {
                if (createDictionaryForProcessCommand == null)
                {
                    createDictionaryForProcessCommand = new DelegateCommand(CreateDictionaryForProcessAction, CanCreateDictionaryForProcessAction);
                }
                return createDictionaryForProcessCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void CreateDictionaryForProcessAction()
        {
            WordDictionaryCreate.Clear();

            Task<List<DictionaryLearnCandidatWord>> task = new Task<List<DictionaryLearnCandidatWord>>(() =>
            {
                IEnumerable<DictionaryLearnCandidatWord> query = null;
                if (IsRateSelectWordDictionary)
                {
                    query = LearnCandidatWords.Where(w => w.Count >= NewDictionaryCreatingRate);
                }
                else
                {
                    query = LearnCandidatWords.OrderByDescending(c => c.Count).ThenBy(c => c.Native).Take((int)NewDictionaryCreatingTop);
                }
                return query.ToList();
            });
            task.Start();
            //                List<DictionaryLearnCandidatWord> list = dictionaryLearnCandidatWordRepository.GetCandidatWordByBookOrderedByCount(SelectedBookForDictionary.BookId);
            List<DictionaryLearnCandidatWord> list = await task;
            foreach (var w in list)
            {
                WordDictionaryCreate.Add(new DictionaryManiplate.ViewModel.DictionaryLearnWordViewModel() { Native = w.Native, ShortTranslation = w.ShortTranslation, Translation = w.Translation });
            }

            NewDictionaryCreatingTabIndex = 1;
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryCreate) as ListCollectionView;
            lcv.SortDescriptions.Add(new SortDescription("Native", ListSortDirection.Ascending));
            NewDictionaryName = SelectedBookForDictionary.Author.AuthorName + " " + SelectedBookForDictionary.BookName;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCreateDictionaryForProcessAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand createDictionaryFileCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CreateDictionaryFileCommand
        {
            get
            {
                if (createDictionaryFileCommand == null)
                {
                    createDictionaryFileCommand = new DelegateCommand(CreateDictionaryFileAction, CanCreateDictionaryFileAction);
                }
                return createDictionaryFileCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CreateDictionaryFileAction()
        {
            try {
//
                List<Word> lWords = new List<Word>();
                foreach (DictionaryLearnWordViewModel w in WordDictionaryCreate) {
                    lWords.Add(new Word() { Native = w.Native, Translation = w.ShortTranslation.Trim() });
                }
                dictionaryLearnRepository.SaveToFile(NewDictionaryName, lWords);
                dictionaryLearnRepository.DeleteBook(NewDictionaryName);
                dictionaryLearnRepository.Add(NewDictionaryName, lWords);
            } catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCreateDictionaryFileAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand createExceptionListCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CreateExceptionListCommand
        {
            get
            {
                if (createExceptionListCommand == null)
                {
                    createExceptionListCommand = new DelegateCommand(CreateExceptionListAction, CanCreateExceptionListAction);
                }
                return createExceptionListCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CreateExceptionListAction()
        {
            wordExceptionRepository.SaveWordException(WordDictionaryException);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCreateExceptionListAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand filterWordDictionaryCreateCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FilterWordDictionaryCreateCommand
        {
            get
            {
                if (filterWordDictionaryCreateCommand == null)
                {
                    filterWordDictionaryCreateCommand = new DelegateCommand(FilterWordDictionaryCreateAction, CanFilterWordDictionaryCreateAction);
                }
                return filterWordDictionaryCreateCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FilterWordDictionaryCreateAction()
        {
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryCreate) as ListCollectionView;
            lcv.Filter = w => !(((DictionaryLearnWordViewModel)w).Native.EndsWith("s") || ((DictionaryLearnWordViewModel)w).Native.EndsWith("ed") || ((DictionaryLearnWordViewModel)w).Native.EndsWith("ing"));
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFilterWordDictionaryCreateAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand filterDerivationOnlyWordDictionaryCreateCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FilterDerivationOnlyWordDictionaryCreateCommand
        {
            get
            {
                if (filterDerivationOnlyWordDictionaryCreateCommand == null)
                {
                    filterDerivationOnlyWordDictionaryCreateCommand = new DelegateCommand(FilterDerivationOnlyWordDictionaryCreateAction, CanFilterDerivationOnlyWordDictionaryCreateAction);
                }
                return filterDerivationOnlyWordDictionaryCreateCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FilterDerivationOnlyWordDictionaryCreateAction()
        {
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryCreate) as ListCollectionView;
            lcv.Filter = w => (((DictionaryLearnWordViewModel)w).Native.EndsWith("s") || ((DictionaryLearnWordViewModel)w).Native.EndsWith("ed") || ((DictionaryLearnWordViewModel)w).Native.EndsWith("ing"));
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFilterDerivationOnlyWordDictionaryCreateAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand clearFilterWordDictionaryCreateCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ClearFilterWordDictionaryCreateCommand
        {
            get
            {
                if (clearFilterWordDictionaryCreateCommand == null)
                {
                    clearFilterWordDictionaryCreateCommand = new DelegateCommand(ClearFilterWordDictionaryCreateAction, CanClearFilterWordDictionaryCreateAction);
                }
                return clearFilterWordDictionaryCreateCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ClearFilterWordDictionaryCreateAction()
        {
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryCreate) as ListCollectionView;
            lcv.Filter = w => true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanClearFilterWordDictionaryCreateAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand removeUnproperPiecesCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand RemoveUnproperPiecesCommand
        {
            get
            {
                if (removeUnproperPiecesCommand == null)
                {
                    removeUnproperPiecesCommand = new DelegateCommand(RemoveUnproperPiecesAction, CanRemoveUnproperPiecesAction);
                }
                return removeUnproperPiecesCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void RemoveUnproperPiecesAction()
        {
            var extractedPieces = extractedPiecesRepository.GetCollection();
            for ( int i = 0; i < WordDictionaryCreate.Count; i++)
            {
                foreach (var ep in extractedPieces)
                    WordDictionaryCreate[i].ShortTranslation = WordDictionaryCreate[i].ShortTranslation.Replace(ep.ExtractedPiecesText, "");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanRemoveUnproperPiecesAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand nativeIntoClipboardCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand NativeIntoClipboardCommand
        {
            get
            {
                if (nativeIntoClipboardCommand == null)
                {
                    nativeIntoClipboardCommand = new DelegateCommand(NativeIntoClipboardAction, CanNativeIntoClipboardAction);
                }
                return nativeIntoClipboardCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void NativeIntoClipboardAction()
        {
            if (SelectedWordDictionaryCreate != null)
            {
                Clipboard.SetData(DataFormats.Text, SelectedWordDictionaryCreate.Native);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanNativeIntoClipboardAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand readManualDictionaryfromFileCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ReadManualDictionaryfromFileCommand
        {
            get
            {
                if (readManualDictionaryfromFileCommand == null)
                {
                    readManualDictionaryfromFileCommand = new DelegateCommand(ReadManualDictionaryfromFileAction, CanReadManualDictionaryfromFileAction);
                }
                return readManualDictionaryfromFileCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ReadManualDictionaryfromFileAction()
        {
//            dictionaryContext.SaveChanges();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml"; 
            dlg.Filter = "Text documents (.xml)|*.xml"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                Tuple<string, List<Word>> dict = dictionaryLearnRepository.LoadFromFile(filename);
                NewDictionaryName = dict.Item1;
                List<Word> lWords = dict.Item2;
                WordDictionaryCreate.Clear();
                foreach (Word w in lWords)
                {
                    WordDictionaryCreate.Add(new DictionaryLearnWordViewModel() { Native = w.Native, Translation = w.Translation.Trim(), ShortTranslation = w.Translation.Trim() });
                }

            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanReadManualDictionaryfromFileAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand fromDictionaryToExceptionCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FromDictionaryToExceptionCommand
        {
            get
            {
                if (fromDictionaryToExceptionCommand == null)
                {
                    fromDictionaryToExceptionCommand = new DelegateCommand(FromDictionaryToExceptionAction, CanFromDictionaryToExceptionAction);
                }
                return fromDictionaryToExceptionCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FromDictionaryToExceptionAction()
        {
            if (SelectedWordDictionaryCreate != null)
            {
                WordDictionaryException.Add(SelectedWordDictionaryCreate);
                WordDictionaryCreate.Remove(SelectedWordDictionaryCreate);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFromDictionaryToExceptionAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand fromDictionaryToExceptionAllCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FromDictionaryToExceptionAllCommand
        {
            get
            {
                if (fromDictionaryToExceptionAllCommand == null)
                {
                    fromDictionaryToExceptionAllCommand = new DelegateCommand(FromDictionaryToExceptionAllAction, CanFromDictionaryToExceptionAllAction);
                }
                return fromDictionaryToExceptionAllCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FromDictionaryToExceptionAllAction()
        {
            while (WordDictionaryCreate.Count > 0)
            {
                WordDictionaryException.Add(WordDictionaryCreate[0]);
                WordDictionaryCreate.RemoveAt(0);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFromDictionaryToExceptionAllAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand fromExceptionToDictionaryCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FromExceptionToDictionaryCommand
        {
            get
            {
                if (fromExceptionToDictionaryCommand == null)
                {
                    fromExceptionToDictionaryCommand = new DelegateCommand(FromExceptionToDictionaryAction, CanFromExceptionToDictionaryAction);
                }
                return fromExceptionToDictionaryCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FromExceptionToDictionaryAction()
        {
            if (SelectedWordDictionaryException != null)
            {
                WordDictionaryCreate.Add(SelectedWordDictionaryException);
                WordDictionaryException.Remove(SelectedWordDictionaryException);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFromExceptionToDictionaryAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand fromExceptionToDictionaryAllCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand FromExceptionToDictionaryAllCommand
        {
            get
            {
                if (fromExceptionToDictionaryAllCommand == null)
                {
                    fromExceptionToDictionaryAllCommand = new DelegateCommand(FromExceptionToDictionaryAllAction, CanFromExceptionToDictionaryAllAction);
                }
                return fromExceptionToDictionaryAllCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void FromExceptionToDictionaryAllAction()
        {
            while (WordDictionaryException.Count > 0)
            {
                WordDictionaryCreate.Add(WordDictionaryException[0]);
                WordDictionaryException.RemoveAt(0);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanFromExceptionToDictionaryAllAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand addCandidateWordManualCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand AddCandidateWordManualCommand
        {
            get
            {
                if (addCandidateWordManualCommand == null)
                {
                    addCandidateWordManualCommand = new DelegateCommand(AddCandidateWordManualAction, CanAddCandidateWordManualAction);
                }
                return addCandidateWordManualCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void AddCandidateWordManualAction()
        {
            if (SelectedWordSearchInDictionary != null)
            {
                LearnCandidatManualWords.Add(new DictionaryLearnWordViewModel() { 
                    Native = SelectedWordSearchInDictionary.Native,
                    Translation = SelectedWordSearchInDictionary.Translation,
                    ShortTranslation = SelectedWordSearchInDictionary.ShortTranslation});
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanAddCandidateWordManualAction()
        {
            return SelectedWordSearchInDictionary != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand processTextAddCandidateWordsCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ProcessTextAddCandidateWordsCommand
        {
            get
            {
                if (processTextAddCandidateWordsCommand == null)
                {
                    processTextAddCandidateWordsCommand = new DelegateCommand(ProcessTextAddCandidateWordsAction, CanProcessTextAddCandidateWordsAction);
                }
                return processTextAddCandidateWordsCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void ProcessTextAddCandidateWordsAction()
        {
            try {
                List<string> separators = new List<string> { ",", ";", Environment.NewLine, "\n" };
                if (IsSpaceAsSeparatorManualVocabulary)
                    separators.Add(" ");
                string[] words = TextForManualProcessing.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).Distinct().ToArray();
                List<IDictionaryWord> list = await shortDictionaryAsTree.CreateListFromListAsync(words);
                foreach (var word in list) {
                    LearnCandidatManualWords.Add(new DictionaryLearnWordViewModel() {
                        Native = word.Native,
                        Translation = word.Translation,
                        ShortTranslation = word.ShortTranslation
                    });
                }
            } catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanProcessTextAddCandidateWordsAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand processListtAddCandidateWordsCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ProcessListAddCandidateWordsCommand
        {
            get
            {
                if (processListtAddCandidateWordsCommand == null)
                {
                    processListtAddCandidateWordsCommand = new DelegateCommand(ProcessListAddCandidateWordsAction, CanProcessListAddCandidateWordsAction);
                }
                return processListtAddCandidateWordsCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ProcessListAddCandidateWordsAction()
        {
            try
            {
                string[] separators = new string[] { Environment.NewLine, "\n" };
                string russionLetters = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
                string[] words = TextForManualProcessing.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).Distinct().ToArray();

                foreach (var word in words)
                {
                    StringBuilder wordAsList = new StringBuilder(word);
                    int? firstRussian = word.Select((l,i) => new { Letter = l, Index = i}).FirstOrDefault(p => russionLetters.Any(r => r == p.Letter))?.Index;
                    if (firstRussian.HasValue)
                    {
                        string native = word.Substring(0, firstRussian.Value - 1).Trim();
                        string translation = word.Substring(firstRussian.Value).Trim();
                        LearnCandidatManualWords.Add(new DictionaryLearnWordViewModel()
                        {
                            Native = native,
                            Translation = translation,
                            ShortTranslation = translation
                        });
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanProcessListAddCandidateWordsAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand processList2AddCandidateWordsCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ProcessList2AddCandidateWordsCommand
        {
            get
            {
                if (processList2AddCandidateWordsCommand == null)
                {
                    processList2AddCandidateWordsCommand = new DelegateCommand(ProcessList2AddCandidateWordsAction, CanProcessList2AddCandidateWordsAction);
                }
                return processList2AddCandidateWordsCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ProcessList2AddCandidateWordsAction()
        {
            try
            {
                string[] separators = new string[] { Environment.NewLine, "\n" };
                string[] lineseparators = new string[] {"(", "-" };
                string russionLetters = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
                string[] words = TextForManualProcessing.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()).Distinct().ToArray();

                foreach (var word in words)
                {
                    StringBuilder wordAsList = new StringBuilder(word);
                    int? firstRussian = word.Select((l, i) => new { Letter = l, Index = i }).FirstOrDefault(p => russionLetters.Any(r => r == p.Letter))?.Index;
                    if (firstRussian.HasValue)
                    {
                        string nativePart = word.Substring(0, firstRussian.Value - 1).Trim();
                        string[] nativeArr = nativePart.Split(lineseparators, StringSplitOptions.RemoveEmptyEntries);
                        string native = nativeArr[0].Trim();
                        string translation = word.Substring(firstRussian.Value).Trim();
                        bool isExist = LearnCandidatManualWords.Any(w => w.Native.ToLower() == native.ToLower());
                        if (!isExist)
                        {
                            LearnCandidatManualWords.Add(new DictionaryLearnWordViewModel()
                            {
                                Native = native,
                                Translation = translation,
                                ShortTranslation = translation
                            });
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanProcessList2AddCandidateWordsAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand clearCandidateWordsCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ClearCandidateWordsCommand
        {
            get
            {
                if (clearCandidateWordsCommand == null)
                {
                    clearCandidateWordsCommand = new DelegateCommand(ClearCandidateWordsAction, CanClearCandidateWordsAction);
                }
                return clearCandidateWordsCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ClearCandidateWordsAction()
        {
            try
            {

                LearnCandidatManualWords.Clear();
      
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanClearCandidateWordsAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand createManualDictionaryForProcessCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CreateManualDictionaryForProcessCommand
        {
            get
            {
                if (createManualDictionaryForProcessCommand == null)
                {
                    createManualDictionaryForProcessCommand = new DelegateCommand(CreateManualDictionaryForProcessAction, CanCreateManualDictionaryForProcessAction);
                }
                return createManualDictionaryForProcessCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CreateManualDictionaryForProcessAction()
        {
            WordDictionaryCreate.Clear();

            foreach (var w in LearnCandidatManualWords) {
                WordDictionaryCreate.Add(new DictionaryManiplate.ViewModel.DictionaryLearnWordViewModel() { Native = w.Native, ShortTranslation = w.ShortTranslation, Translation = w.Translation });
            }

            NewDictionaryCreatingTabIndex = 1;
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryCreate) as ListCollectionView;
            lcv.SortDescriptions.Add(new SortDescription("Native", ListSortDirection.Ascending));
            NewDictionaryName = "Custom_dictionary";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCreateManualDictionaryForProcessAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand ccreateManualDictionaryWithoutClearingCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CreateManualDictionaryWithoutClearingCommand
        {
            get
            {
                if (ccreateManualDictionaryWithoutClearingCommand == null)
                {
                    ccreateManualDictionaryWithoutClearingCommand = new DelegateCommand(CreateManualDictionaryWithoutClearingAction, CanCreateManualDictionaryWithoutClearingAction);
                }
                return ccreateManualDictionaryWithoutClearingCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CreateManualDictionaryWithoutClearingAction()
        {
            foreach (var w in LearnCandidatManualWords) {
                WordDictionaryCreate.Add(new DictionaryManiplate.ViewModel.DictionaryLearnWordViewModel() { Native = w.Native, ShortTranslation = w.ShortTranslation, Translation = w.Translation });
            }

            NewDictionaryCreatingTabIndex = 1;
            ListCollectionView lcv = CollectionViewSource.GetDefaultView(WordDictionaryCreate) as ListCollectionView;
            lcv.SortDescriptions.Add(new SortDescription("Native", ListSortDirection.Ascending));
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCreateManualDictionaryWithoutClearingAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<Object> selectFoundedWordsCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand SelectFoundedWordsCommand
        {
            get
            {
                if (selectFoundedWordsCommand == null)
                {
                    selectFoundedWordsCommand = new DelegateCommand<Object>(SelectFoundedWordsAction, CanSelectFoundedWordsAction);
                }
                return selectFoundedWordsCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SelectFoundedWordsAction(object obj)
        {
            KeyEventArgs e = obj as KeyEventArgs;
            if (e != null && e.Key == Key.Enter)
            {
                SelectedWordSearchInDictionary = SelectedFoundedWord;
                isTraceWordSearchInDictionaryManualChanges = false;
                WordSearchInDictionaryManual = SelectedWordSearchInDictionary.Native;
                isTraceWordSearchInDictionaryManualChanges = true;
                FoundedWords.Clear();
 //               WordSearchInDictionaryManualIsFocused = true;
                OnChangeFocus("txtWordSearchInDictionaryManual");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanSelectFoundedWordsAction(object obj)
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private DelegateCommand<Object> wordSearchInDictionaryManualKeyDownCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand WordSearchInDictionaryManualKeyDownCommand {
            get {
                if (wordSearchInDictionaryManualKeyDownCommand == null) {
                    wordSearchInDictionaryManualKeyDownCommand = new DelegateCommand<Object>(WordSearchInDictionaryManualKeyDownAction, CanWordSearchInDictionaryManualKeyDownAction);
                }
                return wordSearchInDictionaryManualKeyDownCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void WordSearchInDictionaryManualKeyDownAction(Object obj) {
            KeyEventArgs e = obj as KeyEventArgs;
            if (e != null && e.Key == Key.Down) {
                OnChangeFocus("lbFoundedWords");
                //FoundedWordsIsFocused = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanWordSearchInDictionaryManualKeyDownAction(Object e) {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------
        public async void OnLoad()
        {
            IsShortDictionaryAsTreeReady = false;
            try
            {
                Task<List<IDictionaryWord>> task = new Task<List<IDictionaryWord>>(() => dictionaryWordRepository.GetWordOfDictionary36Collection());
//                Task<List<IDictionaryWord>> task = new Task<List<IDictionaryWord>>(() => dictionaryWordRepository.GetWordOfIDictionaryCollection(13));

                task.Start();
                List<IDictionaryWord> shortDictionary = await task;
                shortDictionaryAsTree = new TextProcess();
                shortDictionaryAsTree.AddTextToTree(shortDictionary);
            }
            finally
            {
                IsShortDictionaryAsTreeReady = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
