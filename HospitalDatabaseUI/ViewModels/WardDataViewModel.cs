using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HospitalDatabaseUI.Models;
using HospitalDatabaseUI.ViewModels.Commands;

namespace HospitalDatabaseUI.ViewModels
{
    class WardDataViewModel
    {
        public WardDataModel wardDataModel { get; set; }
        public ICommand RegisterWardCommand { get; set; }

        public WardDataViewModel()
        {
            wardDataModel = new WardDataModel();
            RegisterWardCommand = new Command(RegisterWard, CanRegister);
        }
        private bool CanRegister(object parameter)
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            return !client.IsWardExist(wardDataModel.WardNumber);
        }

        public void RegisterWard()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            client.InsertWardInformation(wardDataModel.WardType, wardDataModel.WardNumber);
            MessageBox.Show("Ward Registered");
        }
    }
}
