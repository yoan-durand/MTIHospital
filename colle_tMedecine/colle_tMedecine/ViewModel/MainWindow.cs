using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace colle_tMedecine.ViewModel
{
    class MainWindow : BaseViewModel
    {

        #region Attributs
        private ICommand _showPatientList;

        public ICommand ShowPatientList
        {
            get { return _showPatientList; }
            set { _showPatientList = value; }
        }

        private ICommand _showUserList;

        public ICommand ShowUserList
        {
            get { return _showUserList; }
            set { _showUserList = value; }
        }

        private ICommand _logOut;

        public ICommand LogOut
        {
            get { return _logOut; }
            set { _logOut = value; }
        }

        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get { return _backCommand; }
            set { _backCommand = value; }
        }

        public List<UserControl> ViewStack;

        private bool _menuIsActive;

        public bool MenuIsActive
        {
            get { return _menuIsActive; }
            set {
                _menuIsActive = value;
                OnPropertyChanged("MenuIsActive");
            }
        }

        private Model.User _connectedUser;

        public Model.User ConnectedUser
        {
            get { return _connectedUser; }
            set { _connectedUser = value; }
        }
        
        #endregion


        public MainWindow ()
        {
            _showPatientList = new RelayCommand(param => showPatients(), param => true);
            _showUserList = new RelayCommand(param => showUsers(), param => true);
            _logOut = new RelayCommand(param => disconnect(), param => true);
            _backCommand = new RelayCommand(param => backView(), param => true);
            _menuIsActive = true;
            ViewStack = new List<UserControl>();
            //AddAdmin();

        }



        private void AddAdmin()
        {
            ServiceUser.ServiceUserClient clientService = new ServiceUser.ServiceUserClient();
            if (clientService.GetUser("admin") == null)
            {
                ServiceUser.User admin = new ServiceUser.User
                {
                    Firstname = "Admin",
                    Name = "Admin",
                    Pwd = "admin",
                    Login = "admin",
                    Role = "Medecin",
                    Connected = false
                };
                clientService.AddUser(admin);
            }
        }
        private void disconnect()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow) mainwindow.DataContext;
            mainwindowVM.MenuIsActive = false;
            View.Login view = new colle_tMedecine.View.Login();
            ViewModel.LoginViewModel vm = new colle_tMedecine.ViewModel.LoginViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        public void navigate(UserControl fromView, UserControl destView)
        {
            ViewStack.Add((UserControl)fromView);
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            string destType = destView.GetType().Name;
            if (destType == "Patients")
                mainwindow.patient_nav_item.Style = (Style)Application.Current.FindResource("ActiveMenuButton");
            else
                mainwindow.patient_nav_item.Style = (Style)Application.Current.FindResource("MenuButton");
            if (destType == "Personnel")
                mainwindow.personnel_nav_item.Style = (Style)Application.Current.FindResource("ActiveMenuButton");
            else
                mainwindow.personnel_nav_item.Style = (Style)Application.Current.FindResource("MenuButton");
            
            mainwindow.contentcontrol.Content = destView;
        }
       

        #region Commandes
        private void showPatients()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Patients view = new colle_tMedecine.View.Patients();
            ViewModel.PatientsViewModel vm = new colle_tMedecine.ViewModel.PatientsViewModel();
            view.DataContext = vm;

            navigate((UserControl)mainwindow.contentcontrol.Content, view);
        }

        private void showUsers()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Personnel view = new colle_tMedecine.View.Personnel();
            ViewModel.PersonnelViewModel vm = new colle_tMedecine.ViewModel.PersonnelViewModel();
            view.DataContext = vm;
            navigate((UserControl)mainwindow.contentcontrol.Content, view);

        }

        private void backView()
        {
            if (ViewStack.Count > 0)
            {
                View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
                UserControl last_view = ViewStack.Last<UserControl>();
                string destType = last_view.GetType().Name;
                if (destType == "Patients")
                    mainwindow.patient_nav_item.Style = (Style)Application.Current.FindResource("ActiveMenuButton");
                else
                    mainwindow.patient_nav_item.Style = (Style)Application.Current.FindResource("MenuButton");
                if (destType == "Personnel")
                    mainwindow.personnel_nav_item.Style = (Style)Application.Current.FindResource("ActiveMenuButton");
                else
                    mainwindow.personnel_nav_item.Style = (Style)Application.Current.FindResource("MenuButton");
                ViewStack.RemoveAt(ViewStack.Count -1);
                mainwindow.contentcontrol.Content = last_view;

            }
        }


        #endregion
    }
}
