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

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for IzvestajOdeljenje.xaml
    /// </summary>
    public partial class IzvestajOdeljenje : Window
    {
        public IzvestajOdeljenje()
        {
            InitializeComponent();
            rvOdeljenja.Load += Window_Loaded;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource izvestajDS = new
                Microsoft.Reporting.WinForms.ReportDataSource();
            DSOdeljenje dsOdeljenje= new DSOdeljenje();

            dsOdeljenje.BeginInit();
            izvestajDS.Name = "DataSetOdeljenje";
            //Name of the report dataset in our .RDLC file

            izvestajDS.Value = dsOdeljenje.Odeljenje;
            this.rvOdeljenja.LocalReport.DataSources.Add(izvestajDS);

            this.rvOdeljenja.LocalReport.ReportPath = "../../IzvestajOdeljenje.rdlc";
            dsOdeljenje.EndInit();

            //fill data into WpfApplication4DataSet
            KorisnickiInterfejs.DSOdeljenjeTableAdapters.OdeljenjeTableAdapter
            odeljenjeTableAdapter = new
            KorisnickiInterfejs.DSOdeljenjeTableAdapters.OdeljenjeTableAdapter();

            odeljenjeTableAdapter.ClearBeforeFill = true;
            odeljenjeTableAdapter.Fill(dsOdeljenje.Odeljenje);
            rvOdeljenja.RefreshReport();
        }
    }
}
