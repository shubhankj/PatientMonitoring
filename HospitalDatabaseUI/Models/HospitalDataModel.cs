using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseUI.Models
{
    class HospitalDataModel:INotifyPropertyChanged
    {
        private int _noOfBeds;
        private int _noOfWards;
        private int _availableBeds;
        public int NoOfBeds { get => _noOfBeds; set { _noOfBeds = value; OnPropertyChanged("NoOfBeds"); } }
        public int NoOfWards { get => _noOfWards; set { _noOfWards = value; OnPropertyChanged("NoOfWards"); } }
        public int AvailableBeds { get => _availableBeds; set { _availableBeds = value; OnPropertyChanged("AvailableBeds"); } }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
