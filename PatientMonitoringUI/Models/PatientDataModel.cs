using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitoringUI.Models
{
    class PatientDataModel:INotifyPropertyChanged
    {
        private long _patientContact;
        private string _patientName;
        private string _patientGender;
        private int _patientAge;
        private int _patientId;
        private string _wardType;
        private int _wardNumber;
        private int _bedNumber;
        public string PatientName { get => _patientName; set { _patientName = value; OnPropertyChanged("PatientName"); } }
        public string PatientGender { get => _patientGender; set { _patientGender = value; OnPropertyChanged("PatientGender"); } }
        public int PatientAge { get => _patientAge; set { _patientAge = value; OnPropertyChanged("PatientAge"); } }
        public long PatientContact { get => _patientContact; set { _patientContact = value; OnPropertyChanged("PatientContact"); } }
        public int PatientId { get => _patientId; set { _patientId = value; OnPropertyChanged("PatientId"); } }
        public string WardType { get => _wardType; set { _wardType = value; OnPropertyChanged("WardType"); } }
        public int WardNumber { get => _wardNumber; set { _wardNumber = value; OnPropertyChanged("WardNumber"); } }
        public int BedNumber { get => _bedNumber; set { _bedNumber = value; OnPropertyChanged("BedNumber"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }


    }
}
