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
    /// Interaction logic for IzvestajGodisnjiOdmor.xaml
    /// </summary>
    public partial class IzvestajGodisnjiOdmor : Window
    {
        public IzvestajGodisnjiOdmor()
        {
            InitializeComponent();
            rvGodisnjiOdmor.Load += Window_Loaded;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource izvestajDS = new
                Microsoft.Reporting.WinForms.ReportDataSource();
            DSGodisnjiOdmor dsGodisnjiOdmor = new DSGodisnjiOdmor();

            dsGodisnjiOdmor.BeginInit();
            izvestajDS.Name = "DataSetGodisnjiOdmor";
            //Name of the report dataset in our .RDLC file

            izvestajDS.Value = dsGodisnjiOdmor.GodisnjiOdmor;
            this.rvGodisnjiOdmor.LocalReport.DataSources.Add(izvestajDS);

            this.rvGodisnjiOdmor.LocalReport.ReportPath = "../../IzvestajGodisnjiOdmor.rdlc";
            dsGodisnjiOdmor.EndInit();

            //fill data into WpfApplication4DataSet
            KorisnickiInterfejs.DSGodisnjiOdmorTableAdapters.GodisnjiOdmorTableAdapter
            godisnjiOdmorTableAdapter = new
            KorisnickiInterfejs.DSGodisnjiOdmorTableAdapters.GodisnjiOdmorTableAdapter();

            godisnjiOdmorTableAdapter.ClearBeforeFill = true;
            godisnjiOdmorTableAdapter.Fill(dsGodisnjiOdmor.GodisnjiOdmor);
            rvGodisnjiOdmor.RefreshReport();
        }
    }
}
