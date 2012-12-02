using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace colle_tMedecine.ViewModel
{
    class PatientsViewModel : BaseViewModel
    {
        #region Command
            private ICommand _newPatient;
            private ICommand _patientSheet;
            private ICommand _supprPatient;
        #endregion

        #region Attributs

            private ObservableCollection<Model.Patient> _listPatient;

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
        
        public ObservableCollection<Model.Patient> ListPatient
        {
            get { return this._listPatient; }
            set { this._listPatient = value; }
        }
        #endregion

        #region Construtor
        public PatientsViewModel()
        {
            _newPatient = new RelayCommand(param => ShowNewPatient(), param => true);
            _patientSheet = new RelayCommand (ShowPatientSheet);
            _supprPatient = new RelayCommand(DeletePatient);
            ObservableCollection<Model.Patient> _listPatient = new ObservableCollection<Model.Patient>();
            FillListPatient();
        }
        #endregion

        public void ShowNewPatient()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Nouveau_patient view = new colle_tMedecine.View.Nouveau_patient();
            ViewModel.Nouveau_patientViewModel vm = new colle_tMedecine.ViewModel.Nouveau_patientViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        public void ShowPatientSheet(object param)
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;
            
            Model.Patient pat = (Model.Patient) param;
      
            View.Fiche_Patient view = new colle_tMedecine.View.Fiche_Patient();
            ViewModel.Fiche_PatientViewModel vm = new colle_tMedecine.ViewModel.Fiche_PatientViewModel(pat);
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        public void DeletePatient(object param)
        {
            Model.Patient patient = (Model.Patient)param;
            ListPatient.Remove(patient);
            ServicePatient.ServicePatientClient service = new ServicePatient.ServicePatientClient();
            service.DeletePatient(patient.Id);
        }

        public void FillListPatient()
        {
            ServicePatient.ServicePatientClient service = new ServicePatient.ServicePatientClient();
            ServicePatient.Patient[] listPatient = service.GetListPatient();
            ObservableCollection<Model.Patient> listModel = new ObservableCollection<Model.Patient>();
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

                patient.Name = FirstUpper(patient.Name);
                patient.Firstname = FirstUpper(patient.Firstname);
                patient.Birthday = pat.Birthday.ToString("0:dd/MM/yyyy");

                listModel.Add(patient);
            }
            ListPatient = listModel;
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
    }
}
