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
            window.DataContext = new ViewModel.MainWindow();

            View.Login log = new colle_tMedecine.View.Login();
            ViewModel.LoginViewModel vm = new colle_tMedecine.ViewModel.LoginViewModel();
            log.DataContext = vm;
            window.contentcontrol.Content = log;

           /* View.Nouveau_Personnel menu = new colle_tMedecine.View.Nouveau_Personnel();
            ViewModel.Nouveau_PersonnelViewModel fm = new colle_tMedecine.ViewModel.Nouveau_PersonnelViewModel();
            menu.DataContext = fm;
            window.contentcontrol.Content = menu;*/

            window.Show();
            // Application.Current.MainWindow.DataContext;
        }
    }
}
