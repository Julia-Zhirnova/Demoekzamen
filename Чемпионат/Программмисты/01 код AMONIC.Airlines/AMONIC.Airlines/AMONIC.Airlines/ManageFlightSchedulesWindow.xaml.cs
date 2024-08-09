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

namespace AMONIC.Airlines
{
    /// <summary>
    /// Логика взаимодействия для ManageFlightSchedulesWindow.xaml
    /// </summary>
    public partial class ManageFlightSchedulesWindow : Window
    {
        private List<string> _listSort = new List<string>()
        {
            "Date and Time","Economy Price","Confirmed"
        };
        public ManageFlightSchedulesWindow()
        {
            InitializeComponent();
            Load();
            LoadData();
        }

        private void LoadData()
        {
            var from = CmbFrom.SelectedItem as Airports;
            var to = CmbTo.SelectedItem as Airports;
            var sortBy = CmbSortBy.Text;
            var outbound = DpOutbound.SelectedDate;
            var flightNumber = TbFlightNumber.Text;

            var query = Helper.context.Schedules.ToList()
                .Where(x => (x.Routes.Airports.ID == from.ID || from.ID == 0)
                && (x.Routes.Airports1.ID == to.ID || to.ID == 0)
                && (x.FlightNumber == flightNumber || flightNumber == "")).ToList();
            if (outbound.HasValue)
            {
                query = query.Where(x => x.Date == outbound.Value).ToList();
            }
        }

        private void Load()
        {
            List<Airports> airports = Helper.context.Airports.ToList();
            airports.Insert(0, new Airports() { IATACode = "All Airports" });
            CmbFrom.ItemsSource = airports;
            CmbTo.ItemsSource = airports;
            CmbSortBy.ItemsSource = _listSort;
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
