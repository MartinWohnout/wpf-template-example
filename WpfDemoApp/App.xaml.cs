﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var appWnd = new ExampleList();
            appWnd.DataContext = new ExampleListModel();

            appWnd.Show();
        }
    }

}
