﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using colle_tMedecine.ServiceUser;

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
            ViewModel.MainWindow windowVM = new ViewModel.MainWindow();

            windowVM.MenuIsActive = false;
            window.DataContext = windowVM;

            View.Login login_view = new colle_tMedecine.View.Login();
            ViewModel.LoginViewModel vm = new colle_tMedecine.ViewModel.LoginViewModel();
            login_view.DataContext = vm;
            window.contentcontrol.Content = login_view;
            
            

           /* View.Nouveau_Personnel menu = new colle_tMedecine.View.Nouveau_Personnel();
            ViewModel.Nouveau_PersonnelViewModel fm = new colle_tMedecine.ViewModel.Nouveau_PersonnelViewModel();
            menu.DataContext = fm;
            window.contentcontrol.Content = menu;*/


            window.Show();
            // Application.Current.MainWindow.DataContext;
        }
    }
}
