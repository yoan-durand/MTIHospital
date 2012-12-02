using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecine.ViewModel
{
    class Fiche_PatientViewModel : BaseViewModel
    {
        private colle_tMedecineServices.ServicePatient.Patient _patient;
        private colle_tMedecineServices.ServiceObservation.Observation _selectedObservation;

        public Fiche_PatientViewModel()
        {
        }

        public Fiche_PatientViewModel(colle_tMedecineServices.ServicePatient.Patient patient)
        {
            SelectedObservation = null;
            Patient = patient;
        }

        public colle_tMedecineServices.ServiceObservation.Observation SelectedObservation
        {
            get { return _selectedObservation; }
            set { _selectedObservation = value; }
        }

        public colle_tMedecineServices.ServicePatient.Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }
  
        
    }
}
