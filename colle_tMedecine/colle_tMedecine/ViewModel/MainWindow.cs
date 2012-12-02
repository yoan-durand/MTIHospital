using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace colle_tMedecine.ViewModel
{
    class MainWindow : BaseViewModel
    {
        #region Command
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

        private ICommand _newUser;

        public ICommand NewUser
        {
            get { return this._newUser; }
            set { this._newUser = value; }
        }
        #endregion

        public MainWindow ()
        {
            _showPatientList = new RelayCommand(param => showPatients(), param => true);
            _showUserList = new RelayCommand(param => showUsers(), param => true);
            _newUser = new RelayCommand(param => ShowNewUser(), param => true);

        }

        private void showPatients()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Patients view = new colle_tMedecine.View.Patients();
            ViewModel.PatientsViewModel vm = new colle_tMedecine.ViewModel.PatientsViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        private void showUsers()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Personnel view = new colle_tMedecine.View.Personnel();
            ViewModel.PersonnelViewModel vm = new colle_tMedecine.ViewModel.PersonnelViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        private void ShowNewUser()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow.DataContext;

            View.Nouveau_Personnel view = new colle_tMedecine.View.Nouveau_Personnel();
            ViewModel.Nouveau_PersonnelViewModel vm = new colle_tMedecine.ViewModel.Nouveau_PersonnelViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        
        }

    }
}
