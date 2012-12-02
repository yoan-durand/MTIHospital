using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace colle_tMedecine.ViewModel
{
    class PersonnelViewModel : BaseViewModel
    {
        #region Attribut
        private ObservableCollection<Model.User> _listUser;
        #endregion

        #region Command
        public ICommand _newUser;
        #endregion

        #region Getter/setter
        public ObservableCollection<Model.User> ListUser
        {
            get { return this._listUser; }
            set { this._listUser = value; }
        }

        public ICommand NewUser
        {
            get { return this._newUser; }
            set { this._newUser = value; }
        }
        #endregion

        #region Construtor
        public PersonnelViewModel()
        {
            _newUser = new RelayCommand(param => ShowNewUser(), param => true);
            ObservableCollection<Model.User> _listUser = new ObservableCollection<Model.User>();
            FillListUser();
        }
        #endregion
        public void FillListUser()
        {
            ServiceUser.ServiceUserClient service = new ServiceUser.ServiceUserClient();
            ServiceUser.User[] listUser = service.GetListUser();
            ObservableCollection<Model.User> listModel = new ObservableCollection<Model.User>();

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
                listModel.Add(userModel);
            }
            ListUser = listModel;
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

            View.Nouveau_Personnel view = new colle_tMedecine.View.Nouveau_Personnel();
            ViewModel.Nouveau_PersonnelViewModel vm = new colle_tMedecine.ViewModel.Nouveau_PersonnelViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }
    }
}
