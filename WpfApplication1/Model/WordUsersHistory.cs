using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Windows;
using DictionaryLibrary.Model;

namespace DictionaryMemorize.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class WordUsersHistory
    //-------------------------------------------------------------------------------------------------------------------
    public class WordUsersHistory
    {
        public string Native { get; set; }
        public string Translation { get; set; }
        //        private static DictionaryCreator dictionaryCreator = new DictionaryCreator();
        public static Dictionary<string, List<Word>> WordDictionary = Word.WordDictionaries;
        public static UsersHistory Users = new UsersHistory();
        //-------------------------------------------------------------------------------------------------------------------
        static WordUsersHistory()
        {
            try
            {
                LoadUsersHistory();
                //LoadDictionary();
                //CreateDictionaryFromXML();
                //SaveDictionary();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void Initialize()
        {
            try
            {
                LoadUsersHistory();
                //LoadDictionary();
                //CreateDictionaryFromXML();
                //SaveDictionary();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void LoadUsersHistory()
        {
            if (File.Exists("UsersHistory.xml"))
            {
                XElement elDictionary = XElement.Load(@"UsersHistory.xml");
                CreateUsersHistoryFromXML(elDictionary);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static void CreateUsersHistoryFromXML(XElement elUsersHistory)
        {
            try
            {
                Users.UsersData.Clear();
                IEnumerable<XElement> histories = from el in elUsersHistory.Elements("History") select el;
                foreach (XElement el in histories)
                {
                    XElement userNameElement = (from e in el.Elements("UserName") select e).FirstOrDefault();
                    string userName = (string)userNameElement;
                    XElement currentDictionaryElement = (from e in el.Elements("CurrentDictionary") select e).FirstOrDefault();
                    string currentDictionary = (string)currentDictionaryElement;
                    XElement currentDictionaryForProtocolElement = (from e in el.Elements("CurrentDictionaryForProtocol") select e).FirstOrDefault();
                    string currentDictionaryForProtocol = "";
                    if (currentDictionaryForProtocolElement != null)
                        currentDictionaryForProtocol = (string)currentDictionaryForProtocolElement;
                    XElement isDirectElement = (from e in el.Elements("IsDirect") select e).FirstOrDefault();
                    bool isDirect = isDirectElement == null ? false : (bool)isDirectElement;
                    History lHistory = new History(userName);
                    lHistory.CurrentDictionary = currentDictionary;
                    lHistory.CurrentDictionaryForProtocol = currentDictionaryForProtocol;
                    lHistory.IsDirect = isDirect;
                    Users.UsersData.Add(userName, lHistory);
                    IEnumerable<XElement> dhElement = from e in el.Elements("DictionaryHistory") select e;
                    foreach (XElement dhe in dhElement)
                    {
                        XElement dnElement = (from eo in dhe.Elements("DictionaryName") select eo).FirstOrDefault();
                        DictionaryHistory dh = new DictionaryHistory((string)dnElement);
                        if (!Word.WordDictionaries.ContainsKey(dh.DictionaryName))
                            continue;
                        lHistory.DictionaryHistories.Add(dh.DictionaryName, dh);
                        XElement snssElements = (from eo in dhe.Elements("Seanses") select eo).FirstOrDefault();
                        IEnumerable<XElement> snsElements = from e in snssElements.Elements("Seans") select e;
                        foreach (XElement snse in snsElements)
                        {

                            XElement stElement = (from e in snse.Elements("StartTime") select e).FirstOrDefault();
                            DateTime st = (DateTime)stElement;
                            XElement etElement = (from e in snse.Elements("EndTime") select e).FirstOrDefault();
                            DateTime et = (DateTime)etElement;
                            XElement elElement = (from e in snse.Elements("ErrorLevel") select e).FirstOrDefault();
                            int erl = (int)elElement;
                            XElement imElement = (from e in snse.Elements("IsWorkOnMistakes") select e).FirstOrDefault();
                            bool eim = false;
                            if (imElement != null)
                                eim = (bool)imElement;
                            Seans sns = new Seans(st, et, erl, eim);
                            dh.Seanses.Add(sns);
                            IEnumerable<XElement> atpElements = from e in snse.Elements("Attempt") select e;
                            foreach (XElement atpe in atpElements)
                            {

                                XElement eraElement = (from e in atpe.Elements("ErrorLevel") select e).FirstOrDefault();
                                int era = (int)eraElement;
                                XElement psnlement = (from e in atpe.Elements("PassNumber") select e).FirstOrDefault();
                                int psn = (int)psnlement;
                                XElement rmnElement = (from e in atpe.Elements("RemainNumber") select e).FirstOrDefault();
                                int rmn = (int)rmnElement;
                                AttemptData atp = new AttemptData(era, psn, rmn);
                                sns.Attempts.Add(atp);
                            }
                        }
                        XElement sttElement = (from e in dhe.Elements("State") select e).FirstOrDefault();
                        if (sttElement != null)
                        {
                            XElement elsElement = (from e in sttElement.Elements("ErrorLevel") select e).FirstOrDefault();
                            int els = (int)elsElement;
                            XElement pnsElement = (from e in sttElement.Elements("PassNumber") select e).FirstOrDefault();
                            int pns = (int)pnsElement;
                            XElement dnsElement = (from e in sttElement.Elements("DoneNumber") select e).FirstOrDefault();
                            int dns = (int)dnsElement;
                            XElement elcsElement = (from e in sttElement.Elements("ErrorLevelCurrent") select e).FirstOrDefault();
                            int elcs = (int)elcsElement;
                            XElement pncsElement = (from e in sttElement.Elements("PassNumberCurrent") select e).FirstOrDefault();
                            int pncs = (int)pncsElement;
                            XElement dncsElement = (from e in sttElement.Elements("DoneNumberCurrent") select e).FirstOrDefault();
                            int dncs = (int)dncsElement;
                            XElement ansElement = (from e in sttElement.Elements("AttemptNumber") select e).FirstOrDefault();
                            int ans = (int)ansElement;
                            XElement rnsElement = (from e in sttElement.Elements("RemainNumber") select e).FirstOrDefault();
                            int rns = (int)rnsElement;
                            XElement wfvElement = (from e in sttElement.Elements("WordFormsVisible") select e).FirstOrDefault();
                            int wfv = (int)wfvElement;
                            XElement assElement = (from e in sttElement.Elements("State") select e).FirstOrDefault();
                            int ass = (int)assElement;
                            XElement icElement = (from e in sttElement.Elements("IsComplete") select e).FirstOrDefault();
                            bool isComplete = (bool)icElement;
                            XElement iwmElement = (from e in sttElement.Elements("IsWorkOnMistakes") select e).FirstOrDefault();
                            bool isWorkOnMistakes = false;
                            if (iwmElement != null)
                                isWorkOnMistakes = (bool)iwmElement;
                            XElement wmrElement = (from e in sttElement.Elements("WorkOnMistakeRegim") select e).FirstOrDefault();
                            int workOnMistakeRegim = 0;
                            if (wmrElement != null)
                                workOnMistakeRegim = (int)wmrElement;
                            XElement elwElement = (from e in sttElement.Elements("ErrorLevelValue") select e).FirstOrDefault();
                            decimal errorLevelValue = 0;
                            if (elwElement != null)
                                errorLevelValue = (decimal)elwElement;
                            XElement elrElement = (from e in sttElement.Elements("ErrorLevelRelation") select e).FirstOrDefault();
                            decimal errorLevelRelation = 0;
                            if (elrElement != null)
                                errorLevelRelation = (decimal)elrElement;
                            XElement cevElement = (from e in sttElement.Elements("ConsolidatedErrorLevelValue") select e).FirstOrDefault();
                            decimal consolidatedErrorLevelValue = 0;
                            if (cevElement != null)
                                consolidatedErrorLevelValue = (decimal)cevElement;
                            XElement cerElement = (from e in sttElement.Elements("ConsolidatedErrorLevelRelation") select e).FirstOrDefault();
                            decimal consolidatedErrorLevelRelation = 0;
                            if (cerElement != null)
                                consolidatedErrorLevelRelation = (decimal)cerElement;
                            State lState = new State(els, pns, dns, elcs, pncs, dncs, ans, rns, wfv, ass,
                                isComplete, isWorkOnMistakes, workOnMistakeRegim, errorLevelValue, errorLevelRelation, 
                                consolidatedErrorLevelValue, consolidatedErrorLevelRelation);
                            dh.State = lState;
                            IEnumerable<XElement> wlsElements = from e in sttElement.Elements("Word") select e;
                            foreach (XElement wlse in wlsElements)
                            {
                                string native = (string)wlse;
                                //XElement nativeElement = (from e in wlse.Elements("Native") select e).FirstOrDefault();
                                //string native = (string)nativeElement;
                                //XElement translationElement = (from e in wlse.Elements("Translation") select e).FirstOrDefault();
                                //string translation = (string)translationElement;
                                Word word = new Word() { Native = native, Translation = native };
                                lState.WordList.Add(word);
                            }
                            IEnumerable<XElement> iwsElements = from e in sttElement.Elements("IncorrectWord") select e;
                            foreach (XElement iwse in iwsElements)
                            {
                                string native = (string)iwse;
                                //XElement nativeElement = (from e in iwse.Elements("Native") select e).FirstOrDefault();
                                //string native = (string)nativeElement;
                                //XElement translationElement = (from e in iwse.Elements("Translation") select e).FirstOrDefault();
                                //string translation = (string)translationElement;
                                //Word word = new Word() { Native = native, Translation = translation };
                                Word word = new Word() { Native = native, Translation = native };
                                lState.IncorrectWord.Add(word);
                            }
                            IEnumerable<XElement> cwsElements = from e in sttElement.Elements("CorrectWord") select e;
                            foreach (XElement cwse in cwsElements)
                            {
                                string native = (string)cwse;
                                //XElement nativeElement = (from e in cwse.Elements("Native") select e).FirstOrDefault();
                                //string native = (string)nativeElement;
                                //XElement translationElement = (from e in cwse.Elements("Translation") select e).FirstOrDefault();
                                //string translation = (string)translationElement;
                                //Word word = new Word() { Native = native, Translation = translation };
                                Word word = new Word() { Native = native, Translation = native };
                                lState.CorrectWord.Add(word);
                            }
                        }
                        XElement wssElements = (from e in dhe.Elements(@"WordStatistics") select e).FirstOrDefault();
                        if (wssElements != null)
                        {
                            IEnumerable<XElement> wsElements = from e in wssElements.Elements(@"WordStatistic") select e;
                            foreach (XElement wse in wsElements)
                            {
                                XElement numElement = (from e in wse.Elements("Number") select e).FirstOrDefault();
                                int num = (int)numElement;
                                XElement inumElement = (from e in wse.Elements("IncorrectNumber") select e).FirstOrDefault();
                                int inum = (int)inumElement;
                                XElement wordElement = (from e in wse.Elements("Word") select e).FirstOrDefault();
                                string word = (string)wordElement;
                                WordStatistic wst = new WordStatistic(word, num, inum);
                                dh.WordStatistics.Add(wst);
                                IEnumerable<XElement> wseElements = from e in wse.Elements("AttemptStatistic") select e;
                                foreach (XElement wlse in wseElements)
                                {
                                    XElement atnElement = (from e in wlse.Elements("AttemptNumber") select e).FirstOrDefault();
                                    int atn = (int)atnElement;
                                    XElement countElement = (from e in wlse.Elements("Count") select e).FirstOrDefault();
                                    int count = (int)countElement;
                                    wst.AttemptStatistic.Add(atn, count);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void SaveUsersHistory()
        {
            XDocument docUsersHistory = CreateXMLFromUsersHistory();
            docUsersHistory.Save("UsersHistory.xml");
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static XDocument CreateXMLFromUsersHistory()
        {
            XDocument d = null;
            try
            {
                d = new XDocument(
                    new XElement("UsersHistory",
                    from ud in Users.UsersData.Values
                    select new XElement("History",
                        new XElement("UserName", ud.UserName),
                        new XElement("CurrentDictionary", ud.CurrentDictionary),
                        new XElement("CurrentDictionaryForProtocol", ud.CurrentDictionaryForProtocol),
                        new XElement("IsDirect", ud.IsDirect),
                        from dh in ud.DictionaryHistories.Values
                        where dh.State != null
                        select new XElement("DictionaryHistory",
                            new XElement("DictionaryName", dh.DictionaryName),
                            new XElement("Seanses",
                                from ss in dh.Seanses
                                select new XElement("Seans",
                                    new XElement("StartTime", ss.StartTime),
                                    new XElement("EndTime", ss.EndTime),
                                    new XElement("ErrorLevel", ss.ErrorLevel),
                                    new XElement("IsWorkOnMistakes", ss.IsWorkOnMistakes),
                                    from tt in ss.Attempts
                                    select new XElement("Attempt",
                                        new XElement("ErrorLevel", tt.ErrorLevel),
                                        new XElement("PassNumber", tt.PassNumber),
                                        new XElement("RemainNumber", tt.RemainNumber))
                                    )),
                            new XElement("State",
                                new XElement("AttemptNumber", dh.State?.AttemptNumber ?? 0),
                                new XElement("DoneNumber", dh.State.DoneNumber),
                                new XElement("DoneNumberCurrent", dh.State?.DoneNumberCurrent ?? 0),
                                new XElement("ErrorLevel", dh.State?.ErrorLevel ?? 0),
                                new XElement("ErrorLevelCurrent", dh.State?.ErrorLevelCurrent ?? 0),
                                new XElement("PassNumber", dh.State?.PassNumber ?? 0),
                                new XElement("PassNumberCurrent", dh.State?.PassNumberCurrent ?? 0),
                                new XElement("RemainNumber", dh.State?.RemainNumber ?? 0),
                                new XElement("State", dh.State?.AnswerState ?? 0),
                                new XElement("WordFormsVisible", dh.State?.WordFormsVisible ?? 0),
                                new XElement("IsComplete", dh.State?.IsComplete ?? true),
                                new XElement("IsWorkOnMistakes", dh.State?.IsWorkOnMistakes ?? false),
                                new XElement("WorkOnMistakeRegim", dh.State?.WorkOnMistakeRegim ?? 0) ,
                                new XElement("ErrorLevelValue", dh.State?.ErrorLevelValue ?? 0),
                                new XElement("ErrorLevelRelation", dh.State?.ErrorLevelRelation ?? 0),
                                new XElement("ConsolidatedErrorLevelValue", dh.State?.ConsolidatedErrorLevelValue ?? 0),
                                new XElement("ConsolidatedErrorLevelRelation", dh.State?.ConsolidatedErrorLevelRelation ?? 0),
                                from wl in dh.State?.WordList ?? new List<Word>()
                                select new XElement("Word", wl.Native),
                                from wl in dh.State?.CorrectWord ?? new List<Word>()
                                select new XElement("CorrectWord", wl.Native),
                                from wl in dh.State?.IncorrectWord ?? new List<Word>()
                                select new XElement("IncorrectWord", wl.Native)
                                ),
                            new XElement("WordStatistics",
                                from ws in dh.WordStatistics
                                select new XElement("WordStatistic",
                                    new XElement("Word", ws.NativeWord),
                                    new XElement("Number", ws.Number),
                                    new XElement("IncorrectNumber", ws.IncorrectNumber),
                                    from ast in ws.AttemptStatistic
                                    select new XElement("AttemptStatistic",
                                        new XElement("AttemptNumber", ast.Key),
                                        new XElement("Count", ast.Value)
                                        )
                                    )
                                )
                             )
                )));
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());

                using (StreamWriter w = File.AppendText("dictionary.log"))
                {
                    w.WriteLine(e.ToString());
                }

                MessageBox.Show(e.ToString());
            }
            return d;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static string GetDictionary(string pName, out List<Word> pWords)
        {
            if (!string.IsNullOrEmpty(pName) && WordDictionary.ContainsKey(pName))
            {
                if (DictionaryMemorize.Properties.Settings.Default.IsDirect)
                {
                    pWords = WordDictionary[pName];
                    return pName;
                }
                List<Word> lResult = new System.Collections.Generic.List<Word>();
                foreach (var w in WordDictionary[pName])
                {
                    Word lWord = new Word() { Native = w.Translation, Translation = w.Native };
                    lResult.Add(lWord);
                }
                pWords = lResult;
                return pName;
            }
            if (WordDictionary.ContainsKey(DictionaryMemorize.Properties.Settings.Default.DictionaryName))
            {
                pWords = WordDictionary[DictionaryMemorize.Properties.Settings.Default.DictionaryName];
                return DictionaryMemorize.Properties.Settings.Default.DictionaryName;
            }
            string name = WordDictionary.Keys.FirstOrDefault();
            if (name == null)
            {
                pWords = null;
                return null;
            }
            pWords = WordDictionary[name];
            return name;
        }
        //-------------------------------------------------------------------------------------------------------------------
        //public static int GetDictionaryCount(string pName)
        //{
        //    if (!string.IsNullOrEmpty(pName) && WordDictionaries.ContainsKey(pName))
        //    {
        //        return WordDictionaries[pName].Count;
        //    }
        //    return 0;
        //}
        //-------------------------------------------------------------------------------------------------------------------
        //public static void LoadDictionary()
        //{
        //    WordDictionaries.Clear();
        //    DirectoryInfo di = new DirectoryInfo(DictionaryMemorize.Properties.Settings.Default.DictionaryDirectory);
        //    FileInfo[] files = di.GetFiles("*.xml");
        //    foreach (FileInfo file in files)
        //    {
        //        XElement elDictionary = XElement.Load(file.FullName);
        //        CreateDictionaryFromXML(elDictionary);
        //    }
        //}
        //-------------------------------------------------------------------------------------------------------------------
        //public static void SaveDictionary()
        //{
        //    XDocument docDictionary = CreateXMLFromDictionary();
        //    docDictionary.Save("Dictionary.xml");
        //}
        //-------------------------------------------------------------------------------------------------------------------
        //public static XDocument CreateXMLFromDictionary()
        //{
        //    XDocument d = new XDocument(
        //        new XElement("Dictionaries",
        //        from el in WordDictionaries
        //        select new XElement("Dictionary",
        //            new XElement("DictionaryName", el.Key),
        //            from w in el.Value
        //            select new XElement("Word",
        //                new XElement("Native", w.Native),
        //                new XElement("Translation", w.Translation)))
        //    ));
        //    return d;
        //}
        ////-------------------------------------------------------------------------------------------------------------------
        //public static void CreateDictionaryFromXML(XElement elDictionary)
        //{
        //    IEnumerable<XElement> dictionaries = from el in elDictionary.Elements("Dictionary") select el;
        //    foreach (XElement el in dictionaries)
        //    {
        //        try
        //        {
        //            XElement dictNameElement = (from e in el.Elements("DictionaryName") select e).FirstOrDefault();
        //            string dictName = (string)dictNameElement;
        //            List<Word> wordList = new System.Collections.Generic.List<Word>();
        //            if (WordDictionaries.ContainsKey(dictName))
        //            {
        //                MessageBox.Show("Dictionary " + dictName + " is already added!", "Dictionary process error");
        //            }
        //            else
        //            {
        //                WordDictionaries.Add(dictName, wordList);
        //                IEnumerable<XElement> wordsElement = from e in el.Elements("Word") select e;
        //                foreach (XElement e in wordsElement)
        //                {
        //                    XElement nativeElement = (from eo in e.Elements("Native") select eo).FirstOrDefault();
        //                    XElement translationElement = (from et in e.Elements("Translation") select et).FirstOrDefault();
        //                    Word w = new Word() { Native = (string)nativeElement, Translation = (string)translationElement };
        //                    wordList.Add(w);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString(), "Dictionary process error");
        //        }
        //    }
        //}
        ////-------------------------------------------------------------------------------------------------------------------
        //public override string ToString()
        //{
        //    return Native + " - " + Translation;
        //}
        //-------------------------------------------------------------------------------------------------------------------
        //private static void CreateDictionaryFromXML()
        //{
        //    //DictionaryCreator.CreatePronouns(WordDictionaries);
        //    //DictionaryCreator.CreateAnimalFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateFoodFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateFruitsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateTransportFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateNumbersFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateColorsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateQuestionsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateAnatomyFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateWeekDaysFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateDayFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateMonthFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateBasicWordPictureFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateBasicCommonFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateBasicActionFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateBasicQualityFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateBasicOppositeFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishCulinaryFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishAnatomyFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishAppearanceFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishTownFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishGrammarFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishTreeFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishHomeFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishAnimalsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishHealthFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishBelongingsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishArtFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishCareerFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishComputerFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishBushesFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishFurnitureFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishMusicFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishInsectsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishClothingFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishProfessionsFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishCharacterFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateStudyEnglishColorFromHTML(WordDictionaries);
        //    //DictionaryCreator.CreateNativeEnglishPrepositionsFromHTML(WordDictionaries);

        //}
        ////-------------------------------------------------------------------------------------------------------------------
        //static public List<Word> CreateAnimalFromHTML()
        //{

        //    try
        //    {
        //        List<Word> lWords = new List<Word>();
        //        if (WordDictionaries.ContainsKey("Animal"))
        //            lWords = WordDictionaries["Animal"];
        //        string pattern = @"<p>.nbsp..nbsp.\s+\d+\S\s+(\S+)\s(.ndash.|-)\s+(\S+)</p>";
        //        foreach (Match match in Regex.Matches(stringAnimalHTML, pattern))
        //        {

        //            Word v = new Word() { Native = match.Groups[1].Value, Translation = match.Groups[3].Value };
        //            if ( !lWords.Any( c => c.Native == v.Native))
        //                lWords.Add(v);
        //        }
        //        if (WordDictionaries.ContainsKey("Animal"))
        //            WordDictionaries["Animal"] = lWords;
        //        else
        //            WordDictionaries.Add("Animal", lWords);
        //        return lWords;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e.ToString());
        //        throw;
        //    }
        //}
        //-------------------------------------------------------------------------------------------------------------------
    }
}
