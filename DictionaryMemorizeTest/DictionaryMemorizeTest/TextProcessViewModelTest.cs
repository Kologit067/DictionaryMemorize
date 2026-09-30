using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionaryManipulate.ViewModel;
using System.Collections.Generic;
using DictionaryManipulate.TextPocess;
using System.Data;

namespace DictionaryMemorizeTest
{
    [TestClass]
    //----------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------
    public class TextProcessViewModelTest
    {
        private TestContext testContextInstance;
        //----------------------------------------------------------------------------------------------------------------------
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        //----------------------------------------------------------------------------------------------------------------------
        [DataSource("System.Data.SqlClient", @"Data Source=OKOLOMIYETS-N\CRM;Initial Catalog=Vocabulary;Integrated Security=True", "Book", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestTextProcess()
        {
            // arrange
            string lTextToProcess = "";
            DataRow row = TestContext.DataRow;
            lTextToProcess = row["Content"].ToString();
            int lBookTextId = (int)row["BookId"];
            TextProcessViewModel textProcessViewModel = new TextProcessViewModel();
            // act
            List<WordCount> listDictionaryApproach = textProcessViewModel.TextProcessDictionaryApproach(lTextToProcess);
            List<WordCount> listTreeApproach = textProcessViewModel.TextProcessTreeApproach(lTextToProcess);
            // assert
            Assert.AreEqual<int>(listTreeApproach.Count, listDictionaryApproach.Count);
            for (int i = 0; i < listDictionaryApproach.Count; i++)
            {
                bool l = listTreeApproach[i].Equals(listDictionaryApproach[i]);
                if (listTreeApproach[i].Word.ToLower() == "aaaa")
                    Console.WriteLine(listTreeApproach[i]);
                Assert.IsTrue(l);
//                Assert.AreEqual<WordCount>(listTreeApproach[i], listDictionaryApproach[i]);
            }
//            Assert.AreEqual<List<WordCount>>(listTreeApproach, listDictionaryApproach);
        }
        //----------------------------------------------------------------------------------------------------------------------
        [TestMethod]
        public void TestTextProcessSimple()
        {
            // arrange
            string lTextToProcess = @"Finally, here is an edition of Road to Serfdom that does justice to its monumental status in the history of liberty. It contains a foreword by the editor of the Hayek Collected Works, Bruce Caldwell. Caldwell has added helpful explanatory notes and citation corrections, among other improvements. For this reason, the publisher decided to call this the definitive edition. It truly is.
This spell-binding book is a classic in the history of liberal ideas. It was singularly responsible for launching an important debate on the relationship between political and economic freedom. It made the author a world-famous intellectual. It set a new standard for what it means to be a dissident intellectual. It warned of a new form of despotism enacted in the name of liberation. And though it appeared in 1944, it continues to have a remarkable impact. No one can consider himself well-schooled in modern political ideas without having absorbed its lessons.
What F.A. Hayek saw, and what most all his contemporaries missed, was that every step away from the free market and toward government planning represented a compromise of human freedom generally and a step toward a form of dictatorship--and this is true in all times and places. He demonstrated this against every claim that government control was really only a means of increasing social well-being. Hayek said that government planning would make society less liveable, more brutal, more despotic. Socialism in all its forms is contrary to freedom.
Nazism, he wrote, is not different in kind from Communism. Further, he showed that the very forms of government that England and America were supposedly fighting abroad were being enacted at home, if under a different guise. Further steps down this road, he said, can only end in the abolition of effective liberty for everyone.
Capitalism, he wrote, is the only system of economics compatible with human dignity, prosperity, and liberty. To the extent we move away from that system, we empower the worst people in society to manage what they do not understand.
The beauty of this book is not only in its analytics but in its style, which is unrelenting and passionate. Even today, the book remains a source of controversy. Socialists who imagine themselves to be against dictatorship cannot abide his argument, and they never stop attempting to refute it.
Misesians might find themselves disappointed that Hayek did not go far enough, and made too many compromises in the course of his argument. Even so, anyone who loves liberty cannot but feel a sense of gratitude that this book exists and remains an important part of the debate today.
The Mises Institute was honored that Hayek served as a founding member of our board of advisers, and is very pleased to offer this book again to a world that desperately needs to hear its message.
";
            TextProcessViewModel textProcessViewModel = new TextProcessViewModel();
            // act
            List<WordCount> listTreeApproach = textProcessViewModel.TextProcessTreeApproach(lTextToProcess);
            List<WordCount> listDictionaryApproach = textProcessViewModel.TextProcessDictionaryApproach(lTextToProcess);
            // assert
            Assert.AreEqual<int>(listTreeApproach.Count, listDictionaryApproach.Count);
            for (int i = 0; i < listDictionaryApproach.Count; i++)
            {
                bool l = listTreeApproach[i].Equals(listDictionaryApproach[i]);
                Assert.IsTrue(l);
                //                Assert.AreEqual<WordCount>(listTreeApproach[i], listDictionaryApproach[i]);
            }
            //            Assert.AreEqual<List<WordCount>>(listTreeApproach, listDictionaryApproach);
        }
        //----------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------
}
