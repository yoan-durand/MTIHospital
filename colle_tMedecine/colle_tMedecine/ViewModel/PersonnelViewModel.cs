using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace colle_tMedecine.ViewModel
{
    class PersonnelViewModel : BaseViewModel
    {
        #region Attribut
        private List<Model.User> _allUser;
        private ObservableCollection<Model.User> _listUser;
        private string _search;
        private bool _isAdmin;
        #endregion

        #region Command
        private ICommand _newUser;
        private ICommand _supprUser;
        private ICommand _searchUser;
        #endregion

        #region Getter/setter
        public ObservableCollection<Model.User> ListUser
        {
            get { return this._listUser; }
            set {
                    if (this._listUser != value)
                    {
                        this._listUser = value;
                        OnPropertyChanged("ListUser");
                    }
                }
        }

        public List<Model.User> AllUser
        {
            get { return this._allUser; }
            set { this._allUser = value; }
        }

        public bool IsAdmin
        {
            get { return this._isAdmin; }
            set 
            {
                if (this._isAdmin != value)
                {
                    this._isAdmin = value;
                    OnPropertyChanged("IsAdmin");
                }
            }
        }

        public string Search
        {
            get { return this._search; }
            set { this._search = value; }
        }

        public ICommand NewUser
        {
            get { return this._newUser; }
            set { this._newUser = value; }
        }

        public ICommand SupprUser
        {
            get { return this._supprUser; }
            set { this._supprUser = value; }
        }

        public ICommand SearchUser
        {
            get { return this._searchUser; }
            set { this._searchUser = value; }
        }
        #endregion

        #region Construtor
        public PersonnelViewModel()
        {
            _newUser = new RelayCommand(param => ShowNewUser(), param => true);
            _supprUser = new RelayCommand(DeleteUser);
            _searchUser = new RelayCommand(param => SearchUserAction(), param => true);
             View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
             object datacontext = mainwindow.DataContext;
            
            ViewModel.MainWindow main = (ViewModel.MainWindow) datacontext;
            if (main.ConnectedUser.Role.Equals("Medecin"))
            {
                this._isAdmin = true;
            }
            else
            {
                this._isAdmin = false;
            }

            FillListUser();
        }

        #endregion
        public void FillListUser()
        {
            ServiceUser.ServiceUserClient service = new ServiceUser.ServiceUserClient();
            ServiceUser.User[] listUser = service.GetListUser();
            _allUser = new List<Model.User>();
           

            foreach(ServiceUser.User user in listUser)
            {
                Model.User userModel = new Model.User {
                    Login = user.Login,
                    Password = user.Pwd,
                    Name = user.Name,
                    Firstname = user.Firstname, 
                    Pic = user.Picture, 
                    Role = user.Role,
                    Co = user.Connected};
                userModel.Name = FirstUpper(userModel.Name);
                userModel.Firstname = FirstUpper(userModel.Firstname);
                userModel.Role = FirstUpper(userModel.Role);
                this._allUser.Add(userModel);
            }
            ListUser = new ObservableCollection<Model.User>(_allUser);
        }

        public string FirstUpper(string str)
        {
            string s = str[0].ToString();

            s = s.ToUpper();
            for (int i = 1; i < str.Length; i++)
            {
                s += str[i].ToString();
            }
            return s;
        }

        public void ShowNewUser()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow)mainwindow.DataContext;
            mainwindowVM.ViewStack.Add((UserControl)mainwindow.contentcontrol.Content);
            View.Nouveau_Personnel view = new colle_tMedecine.View.Nouveau_Personnel();
            ViewModel.Nouveau_PersonnelViewModel vm = new colle_tMedecine.ViewModel.Nouveau_PersonnelViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        public void DeleteUser(object param)
        {
            ServiceUser.ServiceUserClient service = new ServiceUser.ServiceUserClient();
            Model.User user = (Model.User)param;
            this._allUser.Remove(user);
            if (service.DeleteUser(user.Login))
            {
                ListUser = new ObservableCollection<Model.User>(this._allUser);
            }

        }

        public void SearchUserAction()
        {
            if (string.IsNullOrEmpty(this._search))
            {
                ListUser = new ObservableCollection<Model.User>(this._allUser);
                return;
            }
            string[] tabStr = this._search.ToLower().Split(' ');
           List<Model.User> userList = new List<Model.User>();

            foreach (Model.User user in this._allUser)
            {
                foreach (string s in tabStr)
                {
                    if (user.Name.ToLower().Contains(s) || user.Firstname.ToLower().Contains(s) || user.Role.ToLower().Contains(s))
                    {
                        userList.Add(user);
                        break;
                    }
                }
            }
            ListUser = new ObservableCollection<Model.User>(userList);
            
                       
        }

    }
}
