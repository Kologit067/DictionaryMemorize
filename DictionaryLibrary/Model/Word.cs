using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DictionaryLibrary.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class Word
    //-------------------------------------------------------------------------------------------------------------------
    public class Word
    {
        public string Native { get; set; }
        public string Translation { get; set; }
        //        private static DictionaryCreator dictionaryCreator = new DictionaryCreator();
        public static Dictionary<string, List<Word>> WordDictionaries = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<Word>>();
//        public static UsersHistory Users = new UsersHistory();
        public static bool IsDirect;
        public static string DictionaryName;
        public static string DictionaryDirectory;

        //-------------------------------------------------------------------------------------------------------------------
        static Word()
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void Initialize()
        {
            try
            {
                //                LoadUsersHistory();
                LoadDictionary();
                //CreateDictionaryFromXML();
                //SaveDictionary();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
        public static string GetDictionary(string pName, out List<Word> pWords)
        {
            if (!string.IsNullOrEmpty(pName) && WordDictionaries.ContainsKey(pName))
            {
                if (IsDirect)
                {
                    pWords = WordDictionaries[pName];
                    return pName;
                }
                List<Word> lResult = new System.Collections.Generic.List<Word>();
                foreach (var w in WordDictionaries[pName])
                {
                    Word lWord = new Word() { Native = w.Translation, Translation = w.Native };
                    lResult.Add(lWord);
                }
                pWords = lResult;
                return pName;
            }
            if (WordDictionaries.ContainsKey(DictionaryName))
            {
                pWords = WordDictionaries[DictionaryName];
                return DictionaryName;
            }
            string name = WordDictionaries.Keys.FirstOrDefault();
            if (name == null)
            {
                pWords = null;
                return null;
            }
            pWords = WordDictionaries[name];
            return name;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static int GetDictionaryCount(string pName)
        {
            if (!string.IsNullOrEmpty(pName) && WordDictionaries.ContainsKey(pName))
            {
                return WordDictionaries[pName].Count;
            }
            return 0;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void LoadDictionary()
        {
            if (!string.IsNullOrEmpty(DictionaryDirectory))
            {
                WordDictionaries.Clear();
                DirectoryInfo di = new DirectoryInfo(DictionaryDirectory);
                FileInfo[] files = di.GetFiles("*.xml");
                foreach (FileInfo file in files)
                {
                    XElement elDictionary = XElement.Load(file.FullName);
                    CreateDictionaryFromXML(elDictionary);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void SaveDictionary()
        {
            XDocument docDictionary = CreateXMLFromDictionary();
            docDictionary.Save("Dictionary.xml");
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static XDocument CreateXMLFromDictionary()
        {
            XDocument d = new XDocument(
                new XElement("Dictionaries",
                from el in WordDictionaries
                select new XElement("Dictionary",
                    new XElement("DictionaryName", el.Key),
                    from w in el.Value
                    select new XElement("Word",
                        new XElement("Native", w.Native),
                        new XElement("Translation", w.Translation)))
            ));
            return d;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void CreateDictionaryFromXML(XElement elDictionary)
        {
            IEnumerable<XElement> dictionaries = from el in elDictionary.Elements("Dictionary") select el;
            foreach (XElement el in dictionaries)
            {
                try
                {
                    XElement dictNameElement = (from e in el.Elements("DictionaryName") select e).FirstOrDefault();
                    string dictName = (string)dictNameElement;
                    List<Word> wordList = new System.Collections.Generic.List<Word>();
                    if (WordDictionaries.ContainsKey(dictName))
                    {
                       throw new Exception("Dictionary " + dictName + " is already added! Dictionary process error");
                    }
                    else
                    {
                        WordDictionaries.Add(dictName, wordList);
                        IEnumerable<XElement> wordsElement = from e in el.Elements("Word") select e;
                        foreach (XElement e in wordsElement)
                        {
                            XElement nativeElement = (from eo in e.Elements("Native") select eo).FirstOrDefault();
                            XElement translationElement = (from et in e.Elements("Translation") select et).FirstOrDefault();
                            Word w = new Word() { Native = (string)nativeElement, Translation = (string)translationElement };
                            wordList.Add(w);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return Native + " - " + Translation;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static void CreateDictionaryFromXML()
        {
            //DictionaryCreator.CreatePronouns(WordDictionaries);
            //DictionaryCreator.CreateAnimalFromHTML(WordDictionaries);
            //DictionaryCreator.CreateFoodFromHTML(WordDictionaries);
            //DictionaryCreator.CreateFruitsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateTransportFromHTML(WordDictionaries);
            //DictionaryCreator.CreateNumbersFromHTML(WordDictionaries);
            //DictionaryCreator.CreateColorsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateQuestionsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateAnatomyFromHTML(WordDictionaries);
            //DictionaryCreator.CreateWeekDaysFromHTML(WordDictionaries);
            //DictionaryCreator.CreateDayFromHTML(WordDictionaries);
            //DictionaryCreator.CreateMonthFromHTML(WordDictionaries);
            //DictionaryCreator.CreateBasicWordPictureFromHTML(WordDictionaries);
            //DictionaryCreator.CreateBasicCommonFromHTML(WordDictionaries);
            //DictionaryCreator.CreateBasicActionFromHTML(WordDictionaries);
            //DictionaryCreator.CreateBasicQualityFromHTML(WordDictionaries);
            //DictionaryCreator.CreateBasicOppositeFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishCulinaryFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishAnatomyFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishAppearanceFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishTownFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishGrammarFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishTreeFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishHomeFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishAnimalsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishHealthFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishBelongingsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishArtFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishCareerFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishComputerFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishBushesFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishFurnitureFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishMusicFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishInsectsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishClothingFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishProfessionsFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishCharacterFromHTML(WordDictionaries);
            //DictionaryCreator.CreateStudyEnglishColorFromHTML(WordDictionaries);
            //DictionaryCreator.CreateNativeEnglishPrepositionsFromHTML(WordDictionaries);

        }
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
