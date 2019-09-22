using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HospitalDatabaseUI.Models;
using HospitalDatabaseUI.ViewModels.Commands;

namespace HospitalDatabaseUI.ViewModels
{
    class HospitalDataViewModel
    {
        public HospitalDataModel hospitalDataModel { get; set; }
        public ICommand GetHospitalDataCommand { get; set; }

        public HospitalDataViewModel()
        {
            hospitalDataModel = new HospitalDataModel();
            GetHospitalDataCommand = new Command(GetHospitalData, CanGetData);
        }
        private bool CanGetData(object parameter)
        {
            return true;
        }

        public void GetHospitalData()
        {
            PatientMonitoringService.PatientDbQueryClient client = new PatientMonitoringService.PatientDbQueryClient();
            hospitalDataModel.NoOfBeds = client.GetTotalNoOfBeds();
            hospitalDataModel.NoOfWards = client.GetTotalNoOfWards();
            hospitalDataModel.AvailableBeds = client.GetNoOfAvailableBeds();
        }
    }
}
