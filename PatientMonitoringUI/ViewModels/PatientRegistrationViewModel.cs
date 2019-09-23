using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitoringUI.Models;

namespace PatientMonitoringUI.ViewModels
{
    using Commands;
    using System.Windows;
    using System.Windows.Input;

    class PatientRegistrationViewModel
    {
        public PatientDataModel patientDataModel{ get; set; }
        public ICommand RegisterPatientDataCommand { get; set; }

        public PatientRegistrationViewModel()
        {
            patientDataModel = new PatientDataModel();
            RegisterPatientDataCommand = new Command(RegisterPatientData, CanRegisterPatient);
        }
        public bool CanRegisterPatient(object parameter)
        {
            return true;
        }

        public void RegisterPatientData()
        {
            DataStoreService.PatientDbQueryClient client = new DataStoreService.PatientDbQueryClient();
            patientDataModel.PatientId = int.Parse(client.RegisterPatient(patientDataModel.PatientContact, patientDataModel.PatientName, patientDataModel.PatientGender, patientDataModel.PatientAge));
            MessageBox.Show("Patient Registered with ID: "+ patientDataModel.PatientId);
        }
    }
}
