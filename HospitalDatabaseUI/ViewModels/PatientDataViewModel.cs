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
    class PatientDataViewModel
    {
        public PatientDataModel patientDataModel { get; set; }
        public ICommand GetData { get; set; }

        public PatientDataViewModel()
        {
            patientDataModel = new PatientDataModel();
            GetData = new Command(GetPatientData, CanGetData);
        }

        private bool CanGetData(object parameter)
        {
            return true;
        }

        public void GetPatientData()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            string[] details = client.GetPatientDetails(patientDataModel.PatientID).Split(';');
            if (details.Length == 4) {
                patientDataModel.PatientName = details[0];
                patientDataModel.PatientGender = details[1];
                patientDataModel.PatientAge = int.Parse(details[2]);
                patientDataModel.PatientContact = long.Parse(details[3]);
            }
        }
    }
}
