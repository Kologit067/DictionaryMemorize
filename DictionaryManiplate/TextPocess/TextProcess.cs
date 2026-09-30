using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DictionaryManiplate.Model;
using DictionaryManiplate.Contract;

namespace DictionaryManipulate.TextPocess
{
    public enum TraversStepType {Sibling,Parent}
    //-------------------------------------------------------------------------------------------------------------------
    // class TextProcess
    //-------------------------------------------------------------------------------------------------------------------
    public class TextProcess
    {
        private Letter root = new Letter('a');
        //private Stack<char> wordStack = new Stack<char>();
        //private Stack<Tuple<Letter, TraversStepType>> traversStack = new Stack<Tuple<Letter, TraversStepType>>();
        //-------------------------------------------------------------------------------------------------------------------
        public TextProcess()
        {
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void WordProcess(string word, object pTag = null)
        {
            string lWord = word.ToLower();
            Letter previousParent = null;
            Letter previousSibling = null;
            Letter currentParent = root;
            Letter current = root;
            for (int i = 0; i < lWord.Length; i++)
            {
                char lCurentChar = lWord[i];
                if (current == null)
                {
                    current = new Letter(lCurentChar);
                    if (currentParent != null)
                        currentParent.Chield = current;
                    else
                    {
                        root = current;
                    }
                }
                else
                {
                    while (current != null && current.Data < lCurentChar)
                    {
                        previousSibling = current;
                        current = current.Next;
                    }
                    //if (current == null)
                    //{
                    //    current = new Letter(lCurentChar);
                    //    if (previousSibling != null)
                    //    {
                    //        previousSibling.Next = current;
                    //    }
                    //    else
                    //    {
                    //        currentParent.Chield = current;
                    //    }
                    //}
                    if (current == null || current.Data > lCurentChar)
                    {
                        Letter newLetter = new Letter(lCurentChar);
                        if (previousSibling != null)
                        {
                            previousSibling.Next = newLetter;
                        }
                        newLetter.Next = current;
                        if (previousSibling == null  )
                        {
                            if (!Object.ReferenceEquals(current, currentParent))
                            {
                                currentParent.Chield = newLetter;
                            }
                            else
                            {
                                root = newLetter;
                                currentParent = newLetter;
                            }
                        }
                        current = newLetter;
                    }
                }
                previousSibling = null;
                previousParent = currentParent;
                currentParent = current;
                current = current.Chield;
            }

            currentParent.Increment();
            currentParent.Tag = pTag;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<WordCount> CreateList()
        {
            Stack<char> wordStack = new Stack<char>();
            Stack<Tuple<Letter, TraversStepType>> traversStack = new Stack<Tuple<Letter, TraversStepType>>();
            List<WordCount> lResult = new List<WordCount>();
            Letter lCurrent = root;
            Letter lNext = null;
            while (lCurrent != null)
            {
                wordStack.Push(lCurrent.Data);
                if (lCurrent.Count > 0)
                {
                    StringBuilder lWord = new StringBuilder(wordStack.Count);
                    foreach (char c in wordStack)
                        lWord.Insert(0, c);
                    lResult.Add(new WordCount(lWord.ToString(), lCurrent.Count));
                }
                lNext = Forward(lCurrent, wordStack, traversStack);
                if (lNext == null)
                    lNext = Back(lCurrent, wordStack, traversStack);
                lCurrent = lNext;
            }
            return lResult;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<List<IDictionaryWord>> CreateListFromListAsync(string[] pWords) {
            Task<List<IDictionaryWord>> task = new Task<List<IDictionaryWord>>(() =>
                CreateListFromList(pWords));
            task.Start();
            List<IDictionaryWord> list = await task;
            return list;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<IDictionaryWord> CreateListFromList(string[] pWords) {
            List<IDictionaryWord> lResult = new List<IDictionaryWord>();
            foreach (var word in pWords) {
                var wordl = word.ToLower();
                Stack<char> wordStack = new Stack<char>();
                Stack<Tuple<Letter, TraversStepType>> traversStack = new Stack<Tuple<Letter, TraversStepType>>();
                Letter lStartletter = GotoWord(root, wordl.Trim());
                if (lStartletter != null) {
                    IDictionaryWord w = lStartletter.Tag as IDictionaryWord;
                    if (w != null)
                        lResult.Add(w);
                }
            }
            return lResult;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public async Task<List<IDictionaryWord>> CreateListAsync(string pStartWord, int pMaxCount = 5)
        {
            Task<List<IDictionaryWord>> task = new Task<List<IDictionaryWord>>(() => CreateList(pStartWord, pMaxCount));
            task.Start();
            List<IDictionaryWord> list = await task;
            return list;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<IDictionaryWord> CreateList(string pStartWord, int pMaxCount = 5)
        {
            Stack<char> wordStack = new Stack<char>();
            Stack<Tuple<Letter, TraversStepType>> traversStack = new Stack<Tuple<Letter, TraversStepType>>();
            List<IDictionaryWord> lResult = new List<IDictionaryWord>();
            Letter lStartletter = GotoWord(root, pStartWord);
            Letter lCurrent = lStartletter;
            Letter lNext = null;
            while (lCurrent != null)
            {
                wordStack.Push(lCurrent.Data);
                if (lCurrent.Count > 0)
                {
                    lResult.Add(lCurrent.Tag as IDictionaryWord);
                    if (lResult.Count >= pMaxCount)
                        return lResult;
                }
                lNext = Forward(lCurrent, wordStack,  traversStack);
                if (lNext == null)
                    lNext = Back(lCurrent, wordStack, traversStack);
                lCurrent = lNext;
                if (lStartletter.Next == lCurrent)
                    break;
            }
            return lResult;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Letter GotoWord(Letter pStartLetter, string pStartWord)
        {
            Letter lCurrentWord = pStartLetter;
            for (int i = 0; i < pStartWord.Length; i++)
            {
                while (!lCurrentWord.Data.Equals(pStartWord[i]) && lCurrentWord.Next != null)
                    lCurrentWord = lCurrentWord.Next;
                if (!lCurrentWord.Data.Equals(pStartWord[i]))
                    return null;
                if (i == pStartWord.Length - 1)
                    return lCurrentWord;
                if (lCurrentWord.Chield == null)
                    return null;
                lCurrentWord = lCurrentWord.Chield;
            }
            return lCurrentWord;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Letter Back(Letter pCurrent, Stack<char> wordStack, Stack<Tuple<Letter, TraversStepType>> traversStack)
        {
            Letter lNext = null;
            while (lNext == null && traversStack.Count > 0)
            {
                Tuple<Letter, TraversStepType> lParent = null;
                while (lParent == null && traversStack.Count > 0)
                {
                    Tuple<Letter, TraversStepType> currentFromStack = traversStack.Pop();
                    if (currentFromStack.Item2 == TraversStepType.Parent)
                        lParent = currentFromStack;
                }
                if (lParent != null)
                {
                    wordStack.Pop();
                    if (lParent.Item1.Next != null)
                    {
                        wordStack.Pop();
                        lNext = lParent.Item1.Next;
                    }
                }
            }
            return lNext;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private Letter Forward(Letter pCurrent, Stack<char> wordStack, Stack<Tuple<Letter, TraversStepType>> traversStack)
        {
            if (pCurrent.Chield != null)
            {
//                wordStack.Push(pCurrent.Data);
                traversStack.Push(new Tuple<Letter, TraversStepType>(pCurrent, TraversStepType.Parent));
                return pCurrent.Chield;
            }
            else if (pCurrent.Next != null)
            {
                wordStack.Pop();
//                wordStack.Push(pCurrent.Data);
                traversStack.Push(new Tuple<Letter, TraversStepType>(pCurrent, TraversStepType.Sibling));
                return pCurrent.Next;
            }
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Travers(Letter pCurrent, List<WordCount> lResult, Stack<char> wordStack)
        {
            wordStack.Push(pCurrent.Data);
            if (pCurrent.Count > 0)
            {
                StringBuilder lWord = new StringBuilder(wordStack.Count);
                foreach(char c in wordStack)
                    lWord.Insert(0,c);
                lResult.Add( new WordCount( lWord.ToString(), pCurrent.Count));
            }
            if (pCurrent.Chield != null)
                Travers(pCurrent.Chield, lResult, wordStack);
            wordStack.Pop();
            if (pCurrent.Next != null)
                Travers(pCurrent.Next, lResult, wordStack);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public List<WordCount> TextProcessT(string pTextToProcess)
        {
            AddTextToTree(pTextToProcess);
            List<WordCount> lWordCountList = CreateList();
            return lWordCountList;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void AddTextToTree(string pTextToProcess)
        {
            //            TextProcess textProcess = new TextProcess();
            string[] words = DictionaryManipulate.TextPocess.TextProcess.CreateInitialWordList(pTextToProcess);
            foreach (string w in words)
                WordProcess(w);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static string[] CreateInitialWordList(string pTextToProcess)
        {
            string lExcludeSymbols = " ,.\f\t\v\n\r\x85\\\"1234567890!@#$%^&*()№;%:?{}[]:-_+='|/<>~`‘↓«»" + (char)183;
            for (int i = 8200; i < 8300; i++)
                lExcludeSymbols += (char)i;
            //                (char)8217 + (char)8230 + (char)232 + (char)8211 + (char)8212 + (char)8226;
            //. $ ^ { [ ( | ) * + ? \
            //            string lTextToProcess = Regex.Replace(pTextToProcess, @"[^a-zA-Z\s\p{P}!@#%&№;%:_\-='/<>\$\*\(\)\+\|]", "",
            string lTextToProcess = Regex.Replace(pTextToProcess, @"[^a-zA-Z\s\p{P}]", "",
                                RegexOptions.None, TimeSpan.FromSeconds(1.5));

            //            string[] words = lTextToProcess.Split(new char[] { ' ', ',', '.', '\'', '"', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '(', ')', '<', '>', '?', '!', ';', ':', (char)13, (char)10 },
            string[] words = lTextToProcess.Split(lExcludeSymbols.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        //-------------------------------------------------------------------------------------------------------------------
        internal void AddTextToTree(IEnumerable<IDictionaryWord> list)
        {
            foreach (IDictionaryWord w in list)
                WordProcess(w.Native, w);
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
    // class WordCount
    //-------------------------------------------------------------------------------------------------------------------
    public class WordCount : IComparable<WordCount>, IEquatable<WordCount>
    {
        public string Word {get; set;}
        public int Count {get; set;}
        //-------------------------------------------------------------------------------------------------------------------
        public WordCount(string pWord, int pCount)
        {
            Word = pWord;
            Count = pCount;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public int CompareTo(WordCount other)
        {
            return Word.CompareTo(other.Word);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public bool Equals(WordCount other)
        {
            return Word.Equals(other.Word)  && Count == other.Count;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return Word + "(" + Count.ToString() + ")";
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
