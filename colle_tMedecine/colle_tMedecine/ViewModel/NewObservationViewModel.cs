using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Controls;


namespace colle_tMedecine.ViewModel
{
    class NewObservationViewModel : BaseViewModel
    {
        private ICommand _addCommand;
        private ICommand _addPresc;
        private ICommand _addImage;

        public ICommand AddImage
        {
            get { return this._addImage; }
            set { this._addImage = value; }
        }

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
        private List<Image> _pictures;
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

        public List<Image> Pictures
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
            _addImage = new RelayCommand(param => AddImageAction(), param => true);
            PatientName = String.Format("{0} {1}", patient.Name, patient.Firstname);
            Patient = patient;
            Pictures = new List<Image>();
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
            

            foreach (Image img in Pictures)
            {
                ImageSource imgsrc = img.Source;
                BitmapImage biimg = (BitmapImage)imgsrc;
                
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(biimg));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    newlistimg.Add(ms.ToArray());
                }
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

  /*      private void Image_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

        private void Image_Drop(object sender, DragEventArgs e)
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

        } */

        public void AddImageAction()
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Images|*.png;*.gif;*.jpg";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] filePath = dlg.FileNames;
                StreamReader sr = new StreamReader(filePath[0]);
                BinaryReader read = new BinaryReader(sr.BaseStream);
                byte[] Pict = read.ReadBytes((int)sr.BaseStream.Length);

                MemoryStream stream = new MemoryStream(Pict);
                stream.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = stream;
                bi.EndInit();

                ImageSource imgsrc = bi;
                Image newimg = new Image();
                newimg.Source = imgsrc;

                List<Image> listimage = new List<Image>();
                foreach (Image img in Pictures)
                {
                    listimage.Add(img);
                }


                listimage.Add(newimg);
                Pictures = listimage;
            }
            dlg.Dispose();
        }
    }
}
