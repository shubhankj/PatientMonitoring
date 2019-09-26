using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            return client.IsPatientExists(patientDataModel.PatientId) && !client.IsPatientAllocated(patientDataModel.PatientId);
        }

        public void AdmitPatient()
        {
            PatientMonitoringService.VitalSign[] vitalSigns = new PatientMonitoringService.VitalSign[3];

            PatientMonitoringService.VitalSign vitalSign = new PatientMonitoringService.VitalSign();
            
            vitalSign.VitalSignType = PatientMonitoringService.VitalSignType.SPO2;
            vitalSign.IsPatientVitalSignEnabled = vitalSignsDataModel.VitalSigns["SPO2"];
            vitalSigns[0]=vitalSign;

            vitalSign = new PatientMonitoringService.VitalSign();
            vitalSign.VitalSignType = PatientMonitoringService.VitalSignType.PulseRate;
            vitalSign.IsPatientVitalSignEnabled = vitalSignsDataModel.VitalSigns["PulseRate"];
            vitalSigns[1]=vitalSign;

            vitalSign = new PatientMonitoringService.VitalSign();
            vitalSign.VitalSignType = PatientMonitoringService.VitalSignType.Temperature;
            vitalSign.IsPatientVitalSignEnabled = vitalSignsDataModel.VitalSigns["Temperature"];
            vitalSigns[2]=vitalSign;

            PatientMonitoringService.ControllerClient client = new PatientMonitoringService.ControllerClient();
            client.EnableVitalSignForPatient(patientDataModel.PatientId.ToString(), vitalSigns);

            int WardNumber, BedNumber;
            DataStoreService.PatientDbQueryClient queryClient = new DataStoreService.PatientDbQueryClient();
            queryClient.GetAvailableBed(patientDataModel.WardType, out WardNumber, out BedNumber);      //get ward type from user

            if (BedNumber == 0)
            {
                MessageBox.Show("No Bed Available");
                return;
            }

            patientDataModel.WardNumber = WardNumber;
            patientDataModel.BedNumber = BedNumber;

            queryClient.AllocateResourceToPatient(patientDataModel.PatientId, patientDataModel.PatientId, "", "", "", patientDataModel.WardNumber, patientDataModel.BedNumber, DateTime.Today.ToString(), patientDataModel.PatientId, "", true);                

            MessageBox.Show("Bed Number: " + patientDataModel.BedNumber + " and Ward Number: " + patientDataModel.WardNumber + " has been assigned to the Patient");
            //MessageBox.Show(client.GenerateVitalSignAsJson(patientDataModel.PatientId.ToString()));
        }
    }
}
