using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace colle_tMedecine.ViewModel
{
    class PatientsViewModel : BaseViewModel
    {
        #region Command
            private ICommand _newPatient;
            private ICommand _patientSheet; 
        #endregion

        #region Getter/setter

        public ICommand NewPatient
        {
            get { return this._newPatient; }
            set { this._newPatient = value; }
        }

        public ICommand PatientSheet
        {
            get { return this._patientSheet; }
            set { this._patientSheet = value; }
        }
        #endregion

        #region Construtor
        public PatientsViewModel()
        {
            _newPatient = new RelayCommand(param => ShowNewPatient(), param => true);
            _patientSheet = new RelayCommand(param => ShowPatientSheet(), param => true);
        }
        #endregion
       

        public void ShowNewPatient()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Nouveau_patient view = new colle_tMedecine.View.Nouveau_patient();
            ViewModel.Nouveau_patientViewModel vm = new colle_tMedecine.ViewModel.Nouveau_patientViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }

        public void ShowPatientSheet()
        {
            View.MainWindow mainwindow = (View.MainWindow)Application.Current.MainWindow;

            View.Fiche_Patient view = new colle_tMedecine.View.Fiche_Patient();
            ViewModel.Fiche_PatientViewModel vm = new colle_tMedecine.ViewModel.Fiche_PatientViewModel();
            view.DataContext = vm;
            mainwindow.contentcontrol.Content = view;
        }
    }
}
