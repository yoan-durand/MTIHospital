using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace colle_tMedecine
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
{
base.OnStartup(e);
View.LoginView window = new colle_tMedecine.View.LoginView();
ViewModel.LoginViewModel vm = new colle_tMedecine.ViewModel.LoginViewModel();
window.DataContext = vm;
window.Show();
}
    }
}
