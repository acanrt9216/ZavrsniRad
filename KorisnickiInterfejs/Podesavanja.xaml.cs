using Biblioteka;
using MahApps.Metro;
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
    /// Interaction logic for Podesavanja.xaml
    /// </summary>
    public partial class Podesavanja : Window
    {
        public Podesavanja()
        {
            InitializeComponent();

        }

        private void BtnSacuvajPromene_Click(object sender, RoutedEventArgs e)
        {
                
            ThemeManager.AddAccent("Yellow", new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/Yellow.xaml"));
            ThemeManager.AddAccent("Green", new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/Green.xaml"));
            ThemeManager.AddAppTheme("BaseDark", new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseDark.xaml"));
            ThemeManager.AddAppTheme("BaseLight", new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml"));
            if (cbBojaBG.IsChecked==true)
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Yellow"),ThemeManager.GetAppTheme("BaseDark"));
            }
            else
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Green"), ThemeManager.GetAppTheme("BaseLight"));
            }
                this.Close();
            }
    }
}
