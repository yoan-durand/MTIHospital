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
            set
            {
                _loginInput = value;
                OnPropertyChanged("LoginInput");
            }
        }

        private string _passwordInput;

        public string PasswordInput
        {
            get { return _passwordInput; }
            set
            {
                _passwordInput = value;
                OnPropertyChanged("PasswordInput");
            }
        }
        private float _showConnectError;

        public float ShowConnectError
        {
            get { return _showConnectError; }
            set { _showConnectError = value;
            OnPropertyChanged("ShowConnectError");
            }
        }

        private String _errorMessage;

        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value;
            OnPropertyChanged("ErrorMessage");
            }
        }
        
        
#endregion

        public LoginViewModel()
        {
            _connect = new RelayCommand(param => Connecting(), param => true);
            ShowConnectError = 0;

        }

        private void Connecting()
        {
            bool isValid = false;
            //Call service

            if (!string.IsNullOrEmpty(LoginInput) && !string.IsNullOrEmpty(PasswordInput))
            {
                ServiceUser.ServiceUserClient clientService = new ServiceUser.ServiceUserClient();
            
                isValid = clientService.Connect(_loginInput, _passwordInput);

                if (isValid)
                {
                    try
                    {
                        ServiceUser.User user = new ServiceUser.User();
                        user = clientService.GetUser(this._loginInput);
                        View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

                        ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow)mainwindow.DataContext;
                        mainwindowVM.MenuIsActive = true;
                        mainwindowVM.FadeOut = false;
                        mainwindowVM.ConnectedUser = new Model.User
                        {
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
                        View.Patients view = new View.Patients();
                        ViewModel.PatientsViewModel vm = new colle_tMedecine.ViewModel.PatientsViewModel();
                        view.DataContext = vm;
                        mainwindow.contentcontrol.Content = view;
                    }
                    catch (Exception e)
                    {
                        ErrorMessage = "La connexion a échouée, réessayez plus tard";
                        ShowConnectError = 1;
                        ShowConnectError = 0;
                        throw e;
                    }
                }
                else{
                    ErrorMessage = "Identifiant ou mot de passe incorrect";
                    ShowConnectError = 1;
                    ShowConnectError = 0;
                }
            }
            else
            {
                ErrorMessage = "Identifiant ou mot de passe manquant";
                ShowConnectError = 1;
                ShowConnectError = 0;
            }
        }
        
    }
}
