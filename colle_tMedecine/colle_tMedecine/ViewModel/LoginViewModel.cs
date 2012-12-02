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
            bool isValid = true;
            //Call service
         /*   colle_tMedecineServices.ServiceUser.ServiceUserClient clientService = new colle_tMedecineServices.ServiceUser.ServiceUserClient();
            Model.User user = new Model.User();
            user.Login = "ratus";
            user.Password = "1234";
            user.Role = "Medecin";
            user.Name = "roux";
            user.Firstname = "roger";

            clientService.AddUser(user);
            isValid = clientService.Connect(_loginInput, _passwordInput);*/

            if (isValid)
            {
                View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

                ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow)mainwindow.DataContext;
                mainwindowVM.MenuIsActive = true;
               // mainwindowVM.ConnectedUser = 

                View.Patients view = new colle_tMedecine.View.Patients();
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
