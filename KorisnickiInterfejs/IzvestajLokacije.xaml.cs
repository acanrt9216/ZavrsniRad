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
    /// Interaction logic for IzvestajLokacije.xaml
    /// </summary>
    public partial class IzvestajLokacije : Window
    {
        public IzvestajLokacije()
        {
            InitializeComponent();

            rvLokacije.Load += Window_Loaded;
        }
        private void Window_Loaded(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource izvestajDS = new
            Microsoft.Reporting.WinForms.ReportDataSource();
            DSLokacije dsLokacije = new DSLokacije();

            dsLokacije.BeginInit();
            izvestajDS.Name = "DataSetLokacije";
            
                //Name of the report dataset in our .RDLC file

            izvestajDS.Value = dsLokacije.Lokacija;
            this.rvLokacije.LocalReport.DataSources.Add(izvestajDS);

            this.rvLokacije.LocalReport.ReportPath = "../../IzvestajLokacije.rdlc";
            dsLokacije.EndInit();

                //fill data into WpfApplication4DataSet
            KorisnickiInterfejs.DSLokacijeTableAdapters.LokacijaTableAdapter
            lokacijeTableAdapter = new
            KorisnickiInterfejs.DSLokacijeTableAdapters.LokacijaTableAdapter();

            lokacijeTableAdapter.ClearBeforeFill = true;
            lokacijeTableAdapter.Fill(dsLokacije.Lokacija);
            rvLokacije.RefreshReport();        }
    }
}
