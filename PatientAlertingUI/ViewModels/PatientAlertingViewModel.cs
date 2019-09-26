using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PatientAlertingUI.Models;

namespace PatientAlertingUI.ViewModels
{
    class PatientAlertingViewModel
    {
        public static PatientAlertingModel patient1AlertingModel{ get; set; }
        public static PatientAlertingModel patient2AlertingModel{ get; set; }
        public static PatientAlertingModel patient3AlertingModel{ get; set; }
        public static PatientAlertingModel patient4AlertingModel{ get; set; }
        public static PatientAlertingModel patient5AlertingModel{ get; set; }
        public static PatientAlertingModel patient6AlertingModel{ get; set; }

        public PatientAlertingViewModel()
        {
            patient1AlertingModel = new PatientAlertingModel(101);
            patient2AlertingModel = new PatientAlertingModel(102);
            patient3AlertingModel = new PatientAlertingModel(103);
            patient4AlertingModel = new PatientAlertingModel(104);
            patient5AlertingModel = new PatientAlertingModel(105);
            patient6AlertingModel = new PatientAlertingModel(106);
        }

        public static void InvokePatientAlert(PatientAlertingModel patientAlertingModel)
        {
            string message;

            DataStoreService.PatientDbQueryClient dbQueryClient = new DataStoreService.PatientDbQueryClient();
            patientAlertingModel.PatientID = dbQueryClient.GetAdmittedPatientID(patientAlertingModel.BedNumber).ToString();

            MonitoringService.ControllerClient monitoringClient = new MonitoringService.ControllerClient();
            string jsonData = monitoringClient.GenerateVitalSignAsJson(patientAlertingModel.PatientID);

            AlertingService.AlertingControllerClient alertingClient = new AlertingService.AlertingControllerClient();
            alertingClient.ValidatePatientVitalSigns(patientAlertingModel.PatientID, jsonData, out message);

            patientAlertingModel.AlertMessage = message;
        }

        public static void ResetAlert(PatientAlertingModel patientAlertingModel)
        {
            patientAlertingModel.RecentAlertMessage = patientAlertingModel.AlertMessage;
            patientAlertingModel.AlertMessage = "";
        }

        public static void UndoReset(PatientAlertingModel patientAlertingModel)
        {
            patientAlertingModel.AlertMessage = patientAlertingModel.RecentAlertMessage;
        }

        public static void DischargePatient(PatientAlertingModel patientAlertingModel)
        {
            DataStoreService.PatientDbQueryClient dbQueryClient = new DataStoreService.PatientDbQueryClient();
            dbQueryClient.Discharge(int.Parse(patientAlertingModel.PatientID));
            patientAlertingModel.AlertMessage = "";
        }
    }
}
