using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HospitalDatabaseUI.Models
{
    public class PatientDataModel : INotifyPropertyChanged
    {
        private int _patientID = 93;
        private string _patientName = "sj";
        private string _patientGender;
        private int _patientAge;
        private long _patientContact;

        public int PatientID { get => _patientID; set { _patientID = value; OnPropertyChanged("PatientID"); } }
        public string PatientName { get => _patientName; set { _patientName = value; OnPropertyChanged("PatientName"); } }
        public string PatientGender { get => _patientGender; set { _patientGender = value; OnPropertyChanged("PatientGender"); } }
        public int PatientAge { get => _patientAge; set { _patientAge = value; OnPropertyChanged("PatientAge"); } }
        public long PatientContact { get => _patientContact; set { _patientContact = value; OnPropertyChanged("PatientContact"); } }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
