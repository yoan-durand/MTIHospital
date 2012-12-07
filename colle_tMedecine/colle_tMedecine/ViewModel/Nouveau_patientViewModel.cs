using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using colle_tMedecine.ServicePatient;
using System.Windows;

namespace colle_tMedecine.ViewModel
{
    class Nouveau_patientViewModel : BaseViewModel
    {

        string[] _typeErrorMessage =
        {
            "Veuillez remplir le prénom",
            "Veullez remplir le nom",
            "Veuillez indiquer la date de naissance",
            "Veuillez remplir tous les champs"
        };

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        private string _nameInput;

        public string NameInput
        {
            get { return _nameInput; }
            set
            {
                _nameInput = value;
                OnPropertyChanged("NameInput");
            }
        }
        private string _firstnameInput;

        public string FirstnameInput
        {
            get { return _firstnameInput; }
            set
            {
                _firstnameInput = value;
                OnPropertyChanged("FirstnameInput");
            }
        }

        private DateTime? _dateInput;

        public DateTime? DateInput
        {
            get { return _dateInput; }
            set
            {
                _dateInput = value;
                OnPropertyChanged("DateInput");
            }
        }

        private String _errorMessage;
        private float _showConnectError;

        public String ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public float ShowConnectError
        {
            get { return _showConnectError; }
            set
            {
                _showConnectError = value;
                OnPropertyChanged("ShowConnectError");
            }
        }

        public Nouveau_patientViewModel()
        {
            _addCommand = new RelayCommand (param => addPatient(), param => true);
            ShowConnectError = 0;
        }

        private void addPatient()
        {
            if (!string.IsNullOrEmpty(FirstnameInput) && !string.IsNullOrEmpty(NameInput) && !string.IsNullOrEmpty(DateInput.ToString()))
            {
                Patient patient = new Patient();
                patient.Birthday = _dateInput ?? DateTime.Now;
                patient.Firstname = _firstnameInput;
                patient.Name = _nameInput;
                patient.Observations = null;

                ServicePatientClient service = new ServicePatientClient();

                if (service.AddPatient(patient))
                {
                    View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

                    View.Patients view = new colle_tMedecine.View.Patients();
                    ViewModel.PatientsViewModel vm = new colle_tMedecine.ViewModel.PatientsViewModel();
                    view.DataContext = vm;
                    mainwindow.contentcontrol.Content = view;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(FirstnameInput) && !string.IsNullOrEmpty(NameInput) && !string.IsNullOrEmpty(DateInput.ToString()))
                    ErrorMessage = _typeErrorMessage[0];
                else if (!string.IsNullOrEmpty(FirstnameInput) && string.IsNullOrEmpty(NameInput) && !string.IsNullOrEmpty(DateInput.ToString()))
                    ErrorMessage = _typeErrorMessage[1];
                else if (!string.IsNullOrEmpty(FirstnameInput) && !string.IsNullOrEmpty(NameInput) && string.IsNullOrEmpty(DateInput.ToString()))
                    ErrorMessage = _typeErrorMessage[2];
                else
                    ErrorMessage = _typeErrorMessage[3];
                ShowConnectError = 1;
                ShowConnectError = 0;
            }

        }
    }
}
