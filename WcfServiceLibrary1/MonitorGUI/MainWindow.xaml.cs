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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonitorGUI.ServiceReference1;

namespace MonitorGUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MonitorServiceClient client;

        public MainWindow()
        {
            InitializeComponent();
            this.client = new MonitorServiceClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                requestNb.Content = client.NbRequest();
                execTime.Content = client.AverageExecTime();
                CityCacheTime.Content = client.getCityCacheRefreshTime();
                StationCacheTime.Content = client.getStationCacheRefreshTime();
            }
            catch (Exception ex)
            {
                Error.Content = ex.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                client.setCityCacheRefreshTime(Int32.Parse(CityTimeSet.Text));
                CityCacheTime.Content = client.getCityCacheRefreshTime();
            }catch(Exception ex)
            {
                Error.Content = ex.ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                client.setStationCacheRefreshTime(Int32.Parse(StationTimeSet.Text));
                StationCacheTime.Content = client.getStationCacheRefreshTime();
            }catch(Exception ex)
            {
                Error.Content = ex.ToString();
            }
        }
    }
}
