using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryManiplate.Model;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace DictionaryManiplate.Repository
{
    //------------------------------------------------------------------------------------------------------------------------------
    // class XmlRepository
    //------------------------------------------------------------------------------------------------------------------------------
    public class XmlRepository
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerable<DictionaryWord> ProcessXDXFFile(string pFileName, DictionaryRepository pDictionaryRepository)
        {
            string lTranslation = "";
            string lShortTranslation = "";
            string transcript = "";
            string native = "";
            XElement transcriptElement = null;
            XElement nativeElement = null;
            List<DictionaryWord> result = new List<DictionaryWord>();
            try
            {
                if (File.Exists(pFileName))
                {
                    XElement elDictionary = XElement.Load(pFileName);

                    XElement dictnameElement = (from e in elDictionary.Elements("full_name") select e).FirstOrDefault();
                    string dictname = (string)dictnameElement;
                    XElement xdxfElement = elDictionary;
                    if (xdxfElement.Name.LocalName != "xdxf")
                    {
                        xdxfElement = (from e in elDictionary.Elements("xdxf") select e).FirstOrDefault();
                    }
                    string dictionaryTypeName = (string)xdxfElement.Attribute("lang_from") + "-" + (string)xdxfElement.Attribute("lang_to");
                    Dictionary lDictionary = pDictionaryRepository.GetDictionary(dictionaryTypeName, dictname);

                    IEnumerable<XElement> words = from el in elDictionary.Elements("ar") select el;
                    foreach (XElement el in words)
                    {
                        lTranslation = el.Value;
                        lTranslation = el.Nodes().OfType<XText>().Aggregate(new StringBuilder(),
                              (s, c) => s.Append(c), s => s.ToString());
                        transcriptElement = (from e in el.Elements("tr") select e).FirstOrDefault();
                        transcript = (string)transcriptElement;
                        nativeElement = (from e in el.Elements("k") select e).FirstOrDefault();
                        native = (string)nativeElement;
                        if (string.IsNullOrWhiteSpace(native))
                            continue;

                        lTranslation = lTranslation.Replace(native, "");
                        lShortTranslation = lTranslation;
                        if (lTranslation.Length > 30)
                        {
                            if (dictionaryTypeName.EndsWith("RUS") || dictionaryTypeName.EndsWith("UKR") || dictionaryTypeName.EndsWith("BEL"))
                            {
                                lShortTranslation = Regex.Replace(lShortTranslation, @"[a-zA-Z]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                                lShortTranslation = Regex.Replace(lShortTranslation, @"\s\.\s", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
                            }
                            string[] lParts = lShortTranslation.Split(new char[] { ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                            lShortTranslation = "";
                            for (int i = 0; i < 3 && i < lParts.Length && (lShortTranslation + lParts[i]).Length < 40; i++)
                                if (!string.IsNullOrWhiteSpace(lParts[i]) )
                                    lShortTranslation += lParts[i] + ", ";
                            if ( lShortTranslation.Length > 2 )
                                lShortTranslation = lShortTranslation.Substring(0, lShortTranslation.Length - 2);
                            if (string.IsNullOrWhiteSpace(lShortTranslation) && lParts.Length > 0)
                                lShortTranslation = lParts[0];

                        }
                        if (native != null && native.Length > 200)
                            native = native.Substring(0, 200);
                        if (lTranslation != null && lTranslation.Length > 2000)
                            lTranslation = lTranslation.Substring(0, 2000);
                        if (lShortTranslation != null && lShortTranslation.Length > 200)
                            lShortTranslation = lShortTranslation.Substring(0, 200);
                        if (transcript != null && transcript.Length > 200)
                            transcript = transcript.Substring(0, 200);

                        //pDictionaryRepository.AddDictionaryWord(native, lTranslation, lShortTranslation, transcript, lDictionary);
                        DictionaryWord dw = new DictionaryWord() { Native = native, Translation = lTranslation, ShortTranslation = lShortTranslation, Dictionary = lDictionary, Transcription = transcript };
                        //if ( !result.Any( w => w.Dictionary.DictionaryId == dw.Dictionary.DictionaryId && w.Native == dw.Native))
                            result.Add(dw);
                    }

                }
            }
            catch (Exception exc)
            {
                Console.Write(exc.ToString());
            }

            return result;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
