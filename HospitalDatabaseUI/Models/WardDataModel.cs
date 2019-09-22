using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseUI.Models
{
    public class WardDataModel : INotifyPropertyChanged
    {
        private int _wardNumber;
        private string _wardType;
        public int WardNumber { get => _wardNumber; set { _wardNumber = value; OnPropertyChanged("WardNumber"); } }
        public string WardType { get => _wardType; set { _wardType = value; OnPropertyChanged("WardType"); } }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
