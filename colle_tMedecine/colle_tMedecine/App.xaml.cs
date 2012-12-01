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
            View.MainWindow window = new colle_tMedecine.View.MainWindow();

            View.Login log = new colle_tMedecine.View.Login();
            ViewModel.LoginViewModel vm = new colle_tMedecine.ViewModel.LoginViewModel();
            log.DataContext = vm;
            window.contentcontrol.Content = log;

            View.Fiche_Patient menu = new colle_tMedecine.View.Fiche_Patient();
            ViewModel.Fiche_PatientViewModel fm = new colle_tMedecine.ViewModel.Fiche_PatientViewModel();
            menu.DataContext = fm;
            window.contentcontrol.Content = menu;

            window.Show();
            // Application.Current.MainWindow.DataContext;
        }
    }
}
