using DictionaryLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DictionarySpeech.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DictionarySpeechView : Window
    {
        public DictionarySpeechView()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            IScrollIntoViewAction scrollIntoViewAction = (IScrollIntoViewAction)DataContext;
            if (scrollIntoViewAction != null)
            {
                scrollIntoViewAction.SpeechPhraseScrollIntoView += () =>
                {
                    SpeechPhraseScrollIntoView();
                };
            }
            ISavable saveModel = DataContext as ISavable;
            if (saveModel != null)
            {
                this.Closing += (s, ev) => saveModel.Save(); ;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SpeechPhraseScrollIntoView()
        {
            try
            {
                lbSpeechPhrase.ScrollIntoView(lbSpeechPhrase.SelectedItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
