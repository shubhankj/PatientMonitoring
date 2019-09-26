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
        private Dictionary<string, bool> _vitalSigns = new Dictionary<string, bool>{ { "SPO2", false}, {"PulseRate", false}, { "Temperature", false } };

        public Dictionary<string, bool> VitalSigns { get => _vitalSigns; set { _vitalSigns = value; OnPropertyChanged("VitalSigns"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
