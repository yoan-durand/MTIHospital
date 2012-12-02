﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using colle_tMedecineServices.ServicePatient;

namespace colle_tMedecine.ViewModel
{
    class Nouveau_patientViewModel : BaseViewModel
    {
        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        private string _nameInput;

        public string NameInput
        {
            get { return _nameInput; }
            set { _nameInput = value; }
        }
        private string _firstnameInput;

        public string FirstnameInput
        {
            get { return _firstnameInput; }
            set { _firstnameInput = value; }
        }

        private DateTime? _dateInput;

        public DateTime? DateInput
        {
            get { return _dateInput; }
            set { _dateInput = value; }
        }

        public Nouveau_patientViewModel()
        {
            _addCommand = new RelayCommand (param => addPatient(), param => true);
        }

        private void addPatient()
        {
            Patient patient = new Patient();
            patient.Birthday = _dateInput ?? DateTime.Now;
            patient.Firstname = _firstnameInput;
            patient.Name = _nameInput;
            patient.Observations = null;

            //call add service

        }
        
        
        
    }
}
