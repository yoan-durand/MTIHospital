using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace colle_tMedecine.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        #region Attributs
        private ICommand _connect;

        public ICommand Connect
        {
            get { return _connect; }
            set { _connect = value; }
        }

        private string _loginInput;

        public string LoginInput
        {
            get { return _loginInput; }
            set { _loginInput = value; }
        }

        private string _passwordInput;

        public string PasswordInput
        {
            get { return _passwordInput; }
            set { _passwordInput = value; }
        }


        public LoginViewModel()
        {
            _connect = new RelayCommand(param => Connecting(), param => true);

        }

        private void Connecting()
        {
            bool isValid = false;
            //Call service

            ServiceUser.ServiceUserClient clientService = new ServiceUser.ServiceUserClient();
            
            isValid = clientService.Connect(_loginInput, _passwordInput);

            if (isValid)
            {
                ServiceUser.User user = new ServiceUser.User();
                user = clientService.GetUser(this._loginInput);
                View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

                ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow)mainwindow.DataContext;
                mainwindowVM.MenuIsActive = true;

                mainwindowVM.ConnectedUser = new Model.User {   
                    Firstname = user.Firstname,
                    Name = user.Firstname,
                    Login = user.Login,
                    Password = user.Pwd,
                    Pic = user.Picture,
                    Role = user.Role,
                    Connected = true,
                    Co = true,
                    ExtensionData = user.ExtensionData
                };

                mainwindowVM.UserIdentity = user.Name + " " + user.Firstname;
                View.Patients view = new View.Patients ();
                ViewModel.PatientsViewModel vm = new colle_tMedecine.ViewModel.PatientsViewModel();
                view.DataContext = vm;
                mainwindow.contentcontrol.Content = view;
            }
            else
            {
               
            }
        }
        
        
        
        #endregion
    }
}
