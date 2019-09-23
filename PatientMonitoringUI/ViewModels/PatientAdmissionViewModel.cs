using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PatientMonitoringUI.Models;
using PatientMonitoringUI.ViewModels.Commands;

namespace PatientMonitoringUI.ViewModels
{
    class PatientAdmissionViewModel
    {
        public VitalSignsDataModel vitalSignsDataModel { get; set; }
        public PatientDataModel patientDataModel { get; set; }
        public ICommand AdmitPatientCommand { get; set; }

        public PatientAdmissionViewModel()
        {
            vitalSignsDataModel = new VitalSignsDataModel();
            patientDataModel = new PatientDataModel();
            AdmitPatientCommand = new Command(AdmitPatient, CanAdmitPatient);
        }
        private bool CanAdmitPatient(object parameter)
        {
            DataStoreService.PatientDbQueryClient client = new DataStoreService.PatientDbQueryClient();
            return client.SearchPatientByPatientId(patientDataModel.PatientId);
        }

        public void AdmitPatient()
        {
            PatientMonitoringService.ControllerClient client = new PatientMonitoringService.ControllerClient();
            //PatientMonitoringService.VitalSign vitalSign = new PatientMonitoringService.VitalSign();
            //vitalSign.VitalSignType=vitalSignsDataModel.
            //client.EnableVitalSignForPatient(patientDataModel.PatientId, )
        }
    }
}
