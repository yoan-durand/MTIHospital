using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace colle_tMedecine.ViewModel
{
    class PatientsViewModel : BaseViewModel
    {
        #region Command
            private ICommand _newPatient;
            private ICommand _patientSheet;
            private ICommand _supprPatient;
            private ICommand _searchPatient;
        #endregion

        #region Attributs
            private List<Model.Patient> _allPatient;
            private ObservableCollection<Model.Patient> _listPatient;
            private string _search;
            private bool _isAdmin;
        #endregion

        #region Getter/setter

            public ICommand NewPatient
        {
            get { return this._newPatient; }
            set { this._newPatient = value; }
        }

        public ICommand PatientSheet
        {
            get { return this._patientSheet; }
            set { this._patientSheet = value; }
        }

        public ICommand SupprPatient
        {
            get { return this._supprPatient; }
            set { this._supprPatient = value; }
        }

        public ICommand SearchPatient
        {
            get { return this._searchPatient; }
            set { this._searchPatient = value; }
        }

        public ObservableCollection<Model.Patient> ListPatient
        {
            get { return this._listPatient; }
            set
            {
                if (this._listPatient != value)
                {
                    this._listPatient = value;
                    OnPropertyChanged("ListPatient");
                }
            }
        }

        public string Search
        {
            get { return this._search; }
            set { this._search = value; }
        }

        public bool IsAdmin
        {
            get { return this._isAdmin; }
            set
            {                
                    this._isAdmin = value;
                    OnPropertyChanged("IsAdmin");            
            }
        }
        #endregion

        #region Construtor
        public PatientsViewModel()
        {
            _newPatient = new RelayCommand(param => ShowNewPatient(), param => true);
            _patientSheet = new RelayCommand (ShowPatientSheet);
            _supprPatient = new RelayCommand(DeletePatient);
            _searchPatient = new RelayCommand(param => SearchPatientAction(), param => true );
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            this._isAdmin = true;
            object datacontext = mainwindow.DataContext;
            ViewModel.MainWindow main = (ViewModel.MainWindow)datacontext;
            if (main.ConnectedUser.Role.Equals("Medecin"))
            {
               IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }
            FillListPatient();
        }
        #endregion

        public void ShowNewPatient()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow) mainwindow.DataContext;

            View.Nouveau_patient view = new colle_tMedecine.View.Nouveau_patient();
            ViewModel.Nouveau_patientViewModel vm = new colle_tMedecine.ViewModel.Nouveau_patientViewModel();
            view.DataContext = vm;

            mainwindowVM.navigate((UserControl)mainwindow.contentcontrol.Content, view);
        }

        public void ShowPatientSheet(object param)
        {
            
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            ViewModel.MainWindow mainwindowVM = (ViewModel.MainWindow)mainwindow.DataContext;

            Model.Patient pat = (Model.Patient) param;
      
            View.Fiche_Patient view = new colle_tMedecine.View.Fiche_Patient();

            ViewModel.Fiche_PatientViewModel vm = new colle_tMedecine.ViewModel.Fiche_PatientViewModel(pat);
            view.DataContext = vm;

            mainwindowVM.navigate((UserControl)mainwindow.contentcontrol.Content, view);
        }

        public void DeletePatient(object param)
        {
            
            Model.Patient patient = (Model.Patient)param;
            this._allPatient.Remove(patient);
            ServicePatient.ServicePatientClient service = new ServicePatient.ServicePatientClient();
            if (service.DeletePatient(patient.Id))
            {
                ListPatient = new ObservableCollection<Model.Patient>(_allPatient);
            }
        }

        public void FillListPatient()
        {
            ServicePatient.ServicePatientClient service = new ServicePatient.ServicePatientClient();
            ServicePatient.Patient[] listPatient = service.GetListPatient();
            this._allPatient = new List<Model.Patient>();
            List<Model.Observation> listObs = new List<Model.Observation>();

            foreach (ServicePatient.Patient pat in listPatient)
            {
                Model.Patient patient = new Model.Patient
                {
                    Birth = pat.Birthday,
                    Firstname = pat.Firstname,
                    Name = pat.Name,
                    Id = pat.Id
                };

                if (pat.Observations != null)
                {
                    foreach (ServicePatient.Observation obs in pat.Observations)
                    {
                        Model.Observation observation = new Model.Observation
                        {
                            Comments = obs.Comment,
                            Date = obs.Date,
                            Pic = obs.Pictures,
                            Prescriptions = obs.Prescription.ToList(),
                            Pressure = obs.BloodPressure,
                            Weight = obs.Weight
                        };
                        listObs.Add(observation);
                    }
                    patient.Obs = listObs;
                }

                patient.Name = FirstUpper(patient.Name);
                patient.Firstname = FirstUpper(patient.Firstname);
                patient.Birthday = pat.Birthday.ToString("dd/MM/yyyy");

                this._allPatient.Add(patient);
            }
            ListPatient = new ObservableCollection<Model.Patient>(this._allPatient);
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

        public void SearchPatientAction()
        {
            if (string.IsNullOrEmpty(this._search))
            {
                ListPatient = new ObservableCollection<Model.Patient>(this._allPatient);
                return;
            }
            string[] tabstr = this._search.ToLower().Split(' ');
            List<Model.Patient> patientList = new List<Model.Patient>();

            foreach (Model.Patient pat in this._allPatient)
            {
                foreach (string s in tabstr)
                {
                    if (pat.Name.ToLower().Contains(s) || pat.Firstname.ToLower().Contains(s) || pat.Birthday.ToLower().Contains(s))
                    {
                        patientList.Add(pat);
                        break;
                    }
                }
            }
            ListPatient = new ObservableCollection<Model.Patient>(patientList);

        }
    }
}
