using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseUI.Models
{
    public enum WardType
    {
        Cardiology, ICU, Neurology, Oncology, Maternity 
    }
    public class WardDataModel
    {
        private string _wardType;
        private WardType _wardNumber;
    }
}
