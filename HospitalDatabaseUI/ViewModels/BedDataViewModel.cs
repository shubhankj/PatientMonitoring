using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HospitalDatabaseUI.Models;

namespace HospitalDatabaseUI.ViewModels
{
    class BedDataViewModel
    {
        public BedDataModel bedDataModel { get; set; }
        public ICommand RegisterBedCommand { get; set; }
        public ICommand UpdateBedCommand { get; set; }

        public BedDataViewModel()
        {
            bedDataModel = new BedDataModel();
            RegisterBedCommand = new Commands.Command(RegisterBed, CanRegister);
            UpdateBedCommand = new Commands.Command(UpdateBedDetails, CanUpdate);
        }

        private bool CanRegister(object parameter)
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            return !client.IsBedExist(bedDataModel.BedNumber)&&client.IsWardExist(bedDataModel.WardNumber);
        }
        public void RegisterBed()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            client.InsertBedInformation(bedDataModel.BedNumber, bedDataModel.WardNumber);
            MessageBox.Show("Bed Registered");
        }

        private bool CanUpdate(object parameter)
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            return client.IsBedExist(bedDataModel.BedNumber) && client.IsWardExist(bedDataModel.WardNumber);
        }
        public void UpdateBedDetails()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            client.UpdateBedInformation(bedDataModel.BedNumber, bedDataModel.WardNumber, bedDataModel.Availability);
            MessageBox.Show("Bed Details Updated");
        }
    }
}
