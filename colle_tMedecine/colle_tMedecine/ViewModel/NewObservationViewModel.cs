using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace colle_tMedecine.ViewModel
{
    class NewObservationViewModel : BaseViewModel
    {
        private ICommand _addCommand;
        private ICommand _addPresc;

        public ICommand AddPresc
        {
            get { return _addPresc; }
            set { _addPresc = value; }
        }
        
        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        private int _weight;
        private string _comment;
        private int _bloodPressure;
        private List<string> _prescriptions;
        private List<byte[]> _pictures;
        private string _patientName;
        private Model.Patient _patient;
        private DateTime _date;
        private string _prescription;

        public string Prescription
        {
            get { return _prescription; }
            set { _prescription = value;
            OnPropertyChanged("Prescription");
            }
        }
        
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }        

        public Model.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }

        public List<byte[]> Pictures
        {
            get { return _pictures; }
            set { _pictures = value;
            OnPropertyChanged("Pictures");
            }
        }

        public List<string> Prescriptions
        {
            get { return _prescriptions; }
            set { _prescriptions = value;
            OnPropertyChanged("Prescriptions");
            }
        }
        
        public int BloodPressure
        {
            get { return _bloodPressure; }
            set { _bloodPressure = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public NewObservationViewModel(Model.Patient patient)
        {
            _addCommand = new RelayCommand(param => AddObservation(), param => true);
            _addPresc = new RelayCommand(param => AddPrescription(), param => true);
            PatientName = String.Format("{0} {1}", patient.Name, patient.Firstname);
            Patient = patient;
            Pictures = new List<byte[]>();
            Date = DateTime.Now;
            Prescriptions = new List<string>();
        }

        private void AddObservation()
        {
            ServiceObservation.ServiceObservationClient client = new ServiceObservation.ServiceObservationClient();
            ServiceObservation.Observation obs = new ServiceObservation.Observation();
            obs.BloodPressure = BloodPressure;
            obs.Comment = Comment;
            obs.Prescription = Prescriptions.ToArray();
            obs.Weight = Weight;
            obs.Pictures = Pictures.ToArray();
            obs.Date = Date;

            if (client.AddObservation(Patient.Id, obs))
            {
                View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

                View.NewObservation view = new colle_tMedecine.View.NewObservation();
                ViewModel.NewObservationViewModel vm = new colle_tMedecine.ViewModel.NewObservationViewModel(Patient);
                view.DataContext = vm;
                mainwindow.contentcontrol.Content = view;
            }
        }

        private void AddPrescription()
        {
            List<string> listpres = new List<string>();
            foreach (string value in Prescriptions)
            {
                listpres.Add(value);
            }

            listpres.Add(Prescription);
            Prescription = "";
            Prescriptions = listpres;
        }
    }
}
