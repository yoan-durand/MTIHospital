using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;

namespace colle_tMedecine.ViewModel
{
    class Fiche_PatientViewModel : BaseViewModel
    {
        private Model.Patient _patient;
        private Model.Observation _selectedObservation;
        private List<Image> _listImages;
        
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
        
        public Fiche_PatientViewModel(Model.Patient patient)
        {
            Patient = patient;
            SelectedObservation = null;
            ListImages = null;
        }

        public Model.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }
  
        
    }
}
