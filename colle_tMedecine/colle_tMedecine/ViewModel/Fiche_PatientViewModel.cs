using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace colle_tMedecine.ViewModel
{
    class Fiche_PatientViewModel : BaseViewModel
    {
        private Model.Patient _patient;
        private Model.Observation _selectedObservation;
        

        public Fiche_PatientViewModel(Model.Patient patient)
        {
            SelectedObservation = null;
            Patient = patient;
        }

        public Model.Observation SelectedObservation
        {
            get { return _selectedObservation; }
            set { _selectedObservation = value; }
        }

        public Model.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }
  
        
    }
}
