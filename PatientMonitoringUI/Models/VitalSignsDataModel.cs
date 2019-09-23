using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitoringUI.Models
{
    class VitalSignsDataModel:INotifyPropertyChanged
    {
        public enum VitalSignType
        {
            SPO2, Temperature, PulseRate
        }
        private List<VitalSignType> _patientVitalSigns;
        public List<VitalSignType> PatientVitalSigns { get => _patientVitalSigns; set { _patientVitalSigns = value; OnPropertyChanged("PatientVitalSigns "); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
