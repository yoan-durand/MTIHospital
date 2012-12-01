using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecineServices.Services
{
    class Patient : ServicePatient.IServicePatient
    {
        public ServicePatient.Patient[] GetListPatient()
        {
            using (ServicePatient.ServicePatientClient client = new ServicePatient.ServicePatientClient())
            {
                ServicePatient.Patient[] listPatient = client.GetListPatient();
                if (listPatient == null || listPatient.Count() == 0)
                    throw new ArgumentNullException();
                else
                    return listPatient;
            }
        }

        public ServicePatient.Patient GetPatient(int id)
        {
            using (ServicePatient.ServicePatientClient client = new ServicePatient.ServicePatientClient())
            {
                ServicePatient.Patient patient = client.GetPatient(id);
                if (patient == null)
                    throw new ArgumentNullException();
                else
                    return patient;
            }
        }

        public bool AddPatient(ServicePatient.Patient user)
        {
            using (ServicePatient.ServicePatientClient client = new ServicePatient.ServicePatientClient())
            {
                 return client.AddPatient(user);
            }
        }

        public bool DeletePatient(int id)
        {
            using (ServicePatient.ServicePatientClient client = new ServicePatient.ServicePatientClient())
            {
                return client.DeletePatient(id);
            }
        }
    }
}
