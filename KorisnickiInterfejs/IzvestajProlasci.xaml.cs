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
    /// Interaction logic for IzvestajProlasci.xaml
    /// </summary>
    public partial class IzvestajProlasci : Window
    {
        public IzvestajProlasci()
        {
            InitializeComponent();
            rvProlasci.Load += Window_Loaded;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource izvestajDS = new
                Microsoft.Reporting.WinForms.ReportDataSource();
            DSProlasci dsProlasci = new DSProlasci();

            dsProlasci.BeginInit();
            izvestajDS.Name = "DataSetProlasci";
            //Name of the report dataset in our .RDLC file

            izvestajDS.Value = dsProlasci.Prolasci;
            this.rvProlasci.LocalReport.DataSources.Add(izvestajDS);

            this.rvProlasci.LocalReport.ReportPath = "../../IzvestajProlasci.rdlc";
            dsProlasci.EndInit();

            //fill data into WpfApplication4DataSet
            KorisnickiInterfejs.DSProlasciTableAdapters.ProlasciTableAdapter
            prolasciTableAdapter = new
            KorisnickiInterfejs.DSProlasciTableAdapters.ProlasciTableAdapter();

            prolasciTableAdapter.ClearBeforeFill = true;
            prolasciTableAdapter.Fill(dsProlasci.Prolasci);
            rvProlasci.RefreshReport();
        }
    }
}
