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
            var model = client.GetPatientDetails(patientDataModel.PatientID);
            patientDataModel.PatientName = model.PatientName;
            patientDataModel.PatientGender = model.PatientGender;
            patientDataModel.PatientAge = model.PatientAge;
            patientDataModel.PatientContact = model.PatientContact;
        }
    }
}
