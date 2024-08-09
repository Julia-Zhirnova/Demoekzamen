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

namespace AutoserviceDoeduSam.Pages
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
            
        public ServicePage()
        {
            InitializeComponent();

            var checkDiscount = Model.autoserviceEntities.GetContext().Service.ToList();
            checkDiscount.Insert(0, new Model.Service
            {
                Discount = 0
            });
            ComboType.ItemsSource = checkDiscount;

            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;
            UpdateServices();
        }
        private void UpdateServices()
        {
            var currentServices = Model.autoserviceEntities.GetContext().Service.ToList();
            if (ComboType.SelectedIndex > 0)
                currentServices = currentServices.Where(p => p.Discount.HasValue).ToList();
            currentServices = currentServices.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewService.ItemsSource = currentServices.OrderBy(p => p.Cost).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void Btn_Add(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.Navigate(new Pages.EditService());
        }

        private void ComboTypeCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }
    }
}
