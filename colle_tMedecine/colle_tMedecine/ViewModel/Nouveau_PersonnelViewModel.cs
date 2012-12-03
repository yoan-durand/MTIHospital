using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using colle_tMedecine.ServiceUser;

namespace colle_tMedecine.ViewModel
{
    class Nouveau_PersonnelViewModel : BaseViewModel
    {
        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        private String _nameInput;

        public String NameInput
        {
            get { return _nameInput; }
            set { _nameInput = value; }
        }

        private String _firstNameInput;

        public String FirstnameInput
        {
            get { return _firstNameInput; }
            set { _firstNameInput = value; }
        }

        private String _roleInput;

        public String RoleInput
        {
            get { return _roleInput; }
            set { _roleInput = value; }
        }
        

        private String _loginInput;

        public String LoginInput
        {
            get { return _loginInput; }
            set { _loginInput = value; }
        }

        private String _passwordInput;

        public String PasswordInput
        {
            get { return _passwordInput; }
            set { _passwordInput = value; }
        }

        private String _passwordConfirmInput;

        public String PasswordConfirmInput
        {
            get { return _passwordConfirmInput; }
            set { _passwordConfirmInput = value; }
        }

        public Nouveau_PersonnelViewModel()
        {
            _addCommand = new RelayCommand(param => addUser(), param => true);
        }

        private void addUser()
        {
            User new_user = new User();
            new_user.Connected = false;
            new_user.Firstname = _firstNameInput;
            new_user.Name = _nameInput;
            new_user.Role = _roleInput;
            new_user.Pwd = _passwordInput;
            new_user.Login = _loginInput;
            //picture
        }
        
        
    }
}
