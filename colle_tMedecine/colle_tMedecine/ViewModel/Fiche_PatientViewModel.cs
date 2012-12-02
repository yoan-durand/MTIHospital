using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecine.ViewModel
{
    class Fiche_PatientViewModel : BaseViewModel
    {
        private colle_tMedecine.ServicePatient.Patient _patient;
        private colle_tMedecine.ServiceObservation.Observation _selectedObservation;

        public Fiche_PatientViewModel()
        {
        }


        public Fiche_PatientViewModel(colle_tMedecine.ServicePatient.Patient patient)
        {
            SelectedObservation = null;
            Patient = patient;
        }

        public colle_tMedecine.ServiceObservation.Observation SelectedObservation
        {
            get { return _selectedObservation; }
            set { _selectedObservation = value; }
        }

        public colle_tMedecine.ServicePatient.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }
  
        
    }
}
