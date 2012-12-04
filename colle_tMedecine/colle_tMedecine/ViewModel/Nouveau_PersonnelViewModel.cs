﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.IO;
using colle_tMedecine.ServiceUser;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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

        private ICommand _addImage;

        public ICommand AddImage
        {
            get { return this._addImage; }
            set { this._addImage = value; }
        }

        private byte[] _pict;

        public byte[] Pict
        {
            get {return _pict;}
            set {_pict = value;}
        }

        private Image _picture;

        public Image Picture
        {
            get { return _picture; }
            set { 
                    _picture = value;
                    OnPropertyChanged("Picture");
                }
        }

        public Nouveau_PersonnelViewModel()
        {
            Pict = new byte[0];
            Picture = new Image();
            _addCommand = new RelayCommand(param => addUser(), param => true);
            _addImage = new RelayCommand (param => AddImageAction(), param => true);
            
        }

        private void addUser()
        {
            ServiceUserClient service = new ServiceUserClient();
            User new_user = new User();
            string[] roleTab = this._roleInput.Split(' ');

            new_user.Connected = false;
            new_user.Firstname = _firstNameInput;
            new_user.Name = _nameInput;
            new_user.Role = roleTab[roleTab.Length - 1];
            new_user.Pwd = _passwordInput;
            new_user.Login = _loginInput;
            new_user.Picture = Pict;
            
            if (service.AddUser(new_user))
            {
                View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

                View.Personnel view = new colle_tMedecine.View.Personnel();
                ViewModel.PersonnelViewModel vm = new colle_tMedecine.ViewModel.PersonnelViewModel();
                view.DataContext = vm;
                mainwindow.contentcontrol.Content = view;
            }
            


        }

        public void AddImageAction()
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Images|*.png;*.gif;*.jpg";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] filePath = dlg.FileNames;
                StreamReader  sr = new StreamReader(filePath[0]);
                BinaryReader read = new BinaryReader(sr.BaseStream);
                Pict = read.ReadBytes((int)sr.BaseStream.Length);
                
                
            }
            dlg.Dispose();

            MemoryStream stream = new MemoryStream(Pict);
            stream.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = stream;
            bi.EndInit();

            ImageSource imgsrc = bi;
            Picture = new Image();
            Picture.Source = imgsrc;
        }
        

        
        
    }
}
