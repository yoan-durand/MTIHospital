using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace colle_tMedecine.ViewModel
{
    class Fiche_PatientViewModel : BaseViewModel
    {
        private ICommand _addObservation;

        public ICommand AddObservation
        {
            get { return _addObservation; }
            set { _addObservation = value; }
        }
        
        private Model.Patient _patient;
        private Model.Observation _selectedObservation;
        private List<Image> _listImages;
        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set 
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    OnPropertyChanged("IsAdmin");
                }
            }
        }
        
        public List<Image> ListImages
        {
            get { return _listImages; }
            set { _listImages = value;
            OnPropertyChanged("ListImages");
            }
        }

        public Model.Observation SelectedObservation
        {
            get { return _selectedObservation; }
            set {
                if (_selectedObservation != value)
                {
                    _selectedObservation = value;
                    UpdateImagesList(value);
                    OnPropertyChanged("SelectedObservation");
                }
            }
        }

        private void UpdateImagesList(Model.Observation value)
        {
            List<Image> limages = new List<Image>();
            if (value == null)
            {
                ListImages = limages;
            }
            else
            {
                if (value.Pic != null)
                {
                    foreach (byte[] img in value.Pic)
                    {
                        if (img == null)
                            continue;
                        MemoryStream stream = new MemoryStream(img);
                        stream.Position = 0;
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = stream;
                        bi.EndInit();

                        ImageSource imgsrc = bi;
                        Image tmp = new Image();
                        tmp.Source = imgsrc;
                        limages.Add(tmp);
                    }
                    ListImages = limages;
                }
            }
        }
        
        public Fiche_PatientViewModel(Model.Patient patient)
        {

            _addObservation = new RelayCommand(param => AddObs(), param => true);
            Patient = patient;
            if (Patient.Obs != null && Patient.Obs.Count() > 0)
                SelectedObservation = Patient.Obs.ElementAt(0);
            else
                SelectedObservation = null;
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            object datacontext = mainwindow.DataContext;

            ViewModel.MainWindow main = (ViewModel.MainWindow)datacontext;
            if (main.ConnectedUser.Role.Equals("Medecin"))
            {
                this._isAdmin = true;
            }
            else
            {
                this._isAdmin = false;
            }
            ListImages = null;
        }

        private void AddObs()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            View.NewObservation view = new colle_tMedecine.View.NewObservation();

            ViewModel.NewObservationViewModel vm = new colle_tMedecine.ViewModel.NewObservationViewModel(Patient);
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        public Model.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }
  
        
    }
}
