using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;

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
        private List<BitmapImage> _pictures;
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

        public List<BitmapImage> Pictures
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
            Pictures = new List<BitmapImage>();
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
            obs.Pictures = ConverttobyteArray().ToArray();
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

        private List<byte[]> ConverttobyteArray()
        {
            List<byte[]> newlistimg = new List<byte[]>();
            foreach (BitmapImage img in Pictures)
            {
                int stride = img.PixelWidth * ((img.Format.BitsPerPixel + 7) / 8);
                byte[] bmpPixels = new byte[img.PixelHeight * stride];
                img.CopyPixels(bmpPixels, stride, 0);
                newlistimg.Add(bmpPixels);
            }
            return newlistimg;
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

        private void image_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

        private void image_Drop(object sender, DragEventArgs e)
        {
            List<BitmapImage> listimage = new List<BitmapImage>();
            foreach (BitmapImage img in Pictures)
            {
                listimage.Add(img);
            }

            string fpath = (string)e.Data.GetData(DataFormats.Text);
            BitmapImage tmpImage = new BitmapImage((new Uri(fpath)));
            listimage.Add(tmpImage);
            Pictures = listimage;

        }
    }
}
