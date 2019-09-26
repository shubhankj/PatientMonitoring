using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HospitalDatabaseUI.Models;

namespace HospitalDatabaseUI.ViewModels
{
    using Commands;
    using System.Windows;

    class PatientDataViewModel
    {
        public PatientDataModel patientDataModel { get; set; }
        public ICommand GetPatientDataCommand { get; set; }
        public ICommand UpdatePatientDataCommand { get; set; }

        public PatientDataViewModel()
        {
            patientDataModel = new PatientDataModel();
            GetPatientDataCommand = new Command(GetPatientData, IsPatientExists);
            UpdatePatientDataCommand = new Command(UpdatePatientData, IsPatientExists);
        }

        private bool IsPatientExists(object parameter)
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            return client.IsPatientExists(patientDataModel.PatientID);
        }

        public void GetPatientData()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            var model = client.GetPatientDetails(patientDataModel.PatientID);
            patientDataModel.PatientName = model.PatientName;
            patientDataModel.PatientGender = model.PatientGender;
            patientDataModel.PatientAge = model.PatientAge;
            patientDataModel.PatientContact = model.PatientContact;
        }

        public void UpdatePatientData()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            if (client.UpdatePatientDetails(patientDataModel.PatientID, patientDataModel.PatientName, patientDataModel.PatientGender, patientDataModel.PatientAge, patientDataModel.PatientContact))
                MessageBox.Show("Patient Details Updated");
            else
                MessageBox.Show("Unexpected Error Occured!");
        }
    }
}
