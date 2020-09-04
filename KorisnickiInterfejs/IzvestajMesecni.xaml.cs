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
using Microsoft.Reporting.WinForms;

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for IzvestajMesecni.xaml
    /// </summary>
    public partial class IzvestajMesecni : Window
    {
        public IzvestajMesecni()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.rvMesecni.RefreshReport();
        }

        private void BtnIzvestaj_Click(object sender, RoutedEventArgs e)
        {
            this.rvMesecni.LocalReport.ReportPath = "../../IzvestajMesecni.rdlc";
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("Mesec",tbMesec.Text));
            rvMesecni.LocalReport.SetParameters(reportParameters);
            this.rvMesecni.RefreshReport();
        }
    }
}
