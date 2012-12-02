using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecine.Services
{
    class Patient : ServicePatient.IServicePatient
    {
        public ServicePatient.Patient[] GetListPatient()
        {
            try
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
            catch
            {
                throw new TimeoutException();
            }
        }

        public ServicePatient.Patient GetPatient(int id)
        {
            try
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
            catch
            {
                throw new TimeoutException();
            }
        }

        public bool AddPatient(ServicePatient.Patient user)
        {
            try
            {

                using (ServicePatient.ServicePatientClient client = new ServicePatient.ServicePatientClient())
                {
                    return client.AddPatient(user);
                }
            }
            catch
            {
                throw new TimeoutException();
            }
        }

        public bool DeletePatient(int id)
        {
            try
            {
                using (ServicePatient.ServicePatientClient client = new ServicePatient.ServicePatientClient())
                {
                    return client.DeletePatient(id);
                }
            }
            catch
            {
                throw new TimeoutException();
            }
        }
    }
}
