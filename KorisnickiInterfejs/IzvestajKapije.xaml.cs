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
    /// Interaction logic for IzvestajKapije.xaml
    /// </summary>
    public partial class IzvestajKapije : Window
    {
        public IzvestajKapije()
        {
            InitializeComponent();
            rvKapije.Load += Window_Loaded;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource izvestajDS = new
                Microsoft.Reporting.WinForms.ReportDataSource();
            DSKapije dsKapije = new DSKapije();

            dsKapije.BeginInit();
            izvestajDS.Name = "DataSetKapije";
            //Name of the report dataset in our .RDLC file

            izvestajDS.Value = dsKapije.Kapija;
            this.rvKapije.LocalReport.DataSources.Add(izvestajDS);

            this.rvKapije.LocalReport.ReportPath = "../../IzvestajKapije.rdlc";
            dsKapije.EndInit();

            //fill data into WpfApplication4DataSet
            KorisnickiInterfejs.DSKapijeTableAdapters.KapijaTableAdapter
            kapijaTableAdapter = new
            KorisnickiInterfejs.DSKapijeTableAdapters.KapijaTableAdapter();

            kapijaTableAdapter.ClearBeforeFill = true;
            kapijaTableAdapter.Fill(dsKapije.Kapija);
            rvKapije.RefreshReport();
        }
    }
}
