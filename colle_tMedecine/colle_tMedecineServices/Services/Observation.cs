﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colle_tMedecineServices.Services
{
    class Observation : ServiceObservation.IServiceObservation
    {
        public bool AddObservation(int idPatient, ServiceObservation.Observation obs)
        {
            using (ServiceObservation.ServiceObservationClient client = new ServiceObservation.ServiceObservationClient())
            {
                return client.AddObservation(idPatient, obs);
            }
        }
    }
}