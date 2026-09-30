using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DictionaryManipulate.View;
using DictionaryManipulate.ViewModel;

namespace DictionaryManipulate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            DictionaryManipulateView view = new DictionaryManipulateView(); // создали View
            DictionaryManipulateViewModel viewModel = new DictionaryManipulateViewModel(); // Создали ViewModel
            //            viewModel.Initialize();
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext

            view.Show();
        }
    }
}
