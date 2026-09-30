using DictionarySpeech.csproj.ViewModel;
using DictionarySpeech.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DictionarySpeech.csproj
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            DictionarySpeechView view = new DictionarySpeechView(); // создали View
            DictionarySpeechViewModel viewModel = new DictionarySpeechViewModel(); // Создали ViewModel
                                                                       
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext

            viewModel.Start();
            MainWindow = view;
            view.Show();
        }
    }
}
