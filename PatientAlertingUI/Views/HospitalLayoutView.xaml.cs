using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using PatientAlertingUI.ViewModels;
using PatientAlertingUI.Models;

namespace PatientAlertingUI.Views
{
    /// <summary>
    /// Interaction logic for HospitalLayoutView.xaml
    /// </summary>
    public partial class HospitalLayoutView : Window
    {
        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;
        public HospitalLayoutView()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            thread1 = new Thread(() => CallToBedThread(PatientAlertingViewModel.patient1AlertingModel, 15));
            thread1.Start();
            thread2 = new Thread(() => CallToBedThread(PatientAlertingViewModel.patient2AlertingModel, 56));
            thread2.Start();
            thread3 = new Thread(() => CallToBedThread(PatientAlertingViewModel.patient3AlertingModel, 23));
            thread3.Start();
            thread4 = new Thread(() => CallToBedThread(PatientAlertingViewModel.patient4AlertingModel, 35));
            thread4.Start();
        }

        public static void CallToBedThread(PatientAlertingModel model, int seconds)
        {
            while (true)
            {
                if (DateTime.Now.Second%seconds==0 && model.AlertMessage=="")
                {
                    PatientAlertingViewModel.InvokePatientAlert(model);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
            thread4.Abort();
        }

        private void Reset1(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.ResetAlert(PatientAlertingViewModel.patient1AlertingModel);
        }

        private void Undo1(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.UndoReset(PatientAlertingViewModel.patient1AlertingModel);
        }

        private void Discharge1(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.DischargePatient(PatientAlertingViewModel.patient1AlertingModel);
            thread1.Abort();
        }

        private void Reset2(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.ResetAlert(PatientAlertingViewModel.patient2AlertingModel);
        }

        private void Undo2(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.UndoReset(PatientAlertingViewModel.patient2AlertingModel);
        }

        private void Discharge2(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.DischargePatient(PatientAlertingViewModel.patient2AlertingModel);
            thread2.Abort();
        }

        private void Reset3(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.ResetAlert(PatientAlertingViewModel.patient3AlertingModel);
        }

        private void Undo3(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.UndoReset(PatientAlertingViewModel.patient3AlertingModel);
        }

        private void Discharge3(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.DischargePatient(PatientAlertingViewModel.patient3AlertingModel);
            thread3.Abort();
        }

        private void Reset4(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.ResetAlert(PatientAlertingViewModel.patient4AlertingModel);
        }

        private void Undo4(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.UndoReset(PatientAlertingViewModel.patient4AlertingModel);
        }

        private void Discharge4(object sender, RoutedEventArgs e)
        {
            PatientAlertingViewModel.DischargePatient(PatientAlertingViewModel.patient4AlertingModel);
            thread4.Abort();
        }
    }
}
