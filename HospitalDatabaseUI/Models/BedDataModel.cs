using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseUI.Models
{
    public class BedDataModel : INotifyPropertyChanged
    {
        private int _bedNumber;
        private int _wardNumber;
        private bool _availability;
        public int BedNumber { get => _bedNumber; set { _bedNumber = value; OnPropertyChanged("BedNumber"); } }
        public int WardNumber { get => _wardNumber; set { _wardNumber = value; OnPropertyChanged("WardNumber"); } }
        public bool Availability { get => _availability; set { _availability = value; OnPropertyChanged("Availability"); } }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
