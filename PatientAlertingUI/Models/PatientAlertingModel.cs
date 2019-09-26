using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAlertingUI.Models
{
    public class PatientAlertingModel : INotifyPropertyChanged
    {
        public PatientAlertingModel(int BedNumber)
        {
            this.BedNumber = BedNumber;
        }

        private string _patientID;
        private int _bedNumber;
        private string _alertMessage="";
        private string _recentAlertMessage="";

        public string PatientID { get => _patientID; set { _patientID = value; OnPropertyChanged("PatientID"); } }
        public int BedNumber { get => _bedNumber; set { _bedNumber = value; OnPropertyChanged("BedNumber"); } }
        public string AlertMessage { get => _alertMessage; set { _alertMessage = value; OnPropertyChanged("AlertMessage"); } }
        public string RecentAlertMessage { get => _recentAlertMessage; set { _recentAlertMessage = value; OnPropertyChanged("RecentAlertMessage"); } }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
