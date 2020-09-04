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
    /// Interaction logic for IzvestajRadnik.xaml
    /// </summary>
    public partial class IzvestajRadnik : Window
    {
        public IzvestajRadnik()
        {
            InitializeComponent();
            rvRadnik.Load += Window_Loaded;
        }

        private void Window_Loaded(object sender,EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource izvestajDS = new
                Microsoft.Reporting.WinForms.ReportDataSource();
            DSRadnik dsRadnik = new DSRadnik();

            dsRadnik.BeginInit();
            izvestajDS.Name = "DataSetRadnik";
            //Name of the report dataset in our .RDLC file

            izvestajDS.Value = dsRadnik.Radnik;
            this.rvRadnik.LocalReport.DataSources.Add(izvestajDS);

            this.rvRadnik.LocalReport.ReportPath = "../../IzvestajRadnik.rdlc";
            dsRadnik.EndInit();

            //fill data into WpfApplication4DataSet
            KorisnickiInterfejs.DSRadnikTableAdapters.RadnikTableAdapter
            radnikTableAdapter = new
            KorisnickiInterfejs.DSRadnikTableAdapters.RadnikTableAdapter();

            radnikTableAdapter.ClearBeforeFill = true;
            radnikTableAdapter.Fill(dsRadnik.Radnik);
            rvRadnik.RefreshReport();
        }
    }
}
