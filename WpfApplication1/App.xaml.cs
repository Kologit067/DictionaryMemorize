using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DictionaryMemorize.View;
using DictionaryMemorize.ViewModel;

namespace DictionaryMemorize
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            DictionaryView view = new DictionaryView(); // создали View
            DictionaryViewModel viewModel = new DictionaryViewModel(); // Создали ViewModel
//            viewModel.Initialize();
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            viewModel.SelectedIndex = 0;

            UserView userView = new UserView(); // создали View
            UserViewModel userViewModel = new UserViewModel(); // Создали ViewModel
            userView.DataContext = userViewModel; // положили ViewModel во View в качестве DataContext
            userView.ShowDialog();

            viewModel.Start();
            MainWindow = view;
            view.Show();
        }
    }


}
