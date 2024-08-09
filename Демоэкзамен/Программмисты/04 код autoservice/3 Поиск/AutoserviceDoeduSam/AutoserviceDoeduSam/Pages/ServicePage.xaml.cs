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
        
       /* private List<Tuple<string, float, float>> FilterByDiscountValuesList = new List<Tuple<string, float, float>>() {
            Tuple.Create("Все записи", 0f, 1f),
            Tuple.Create("от 0% до 5%", 0f, 0.05f),
            Tuple.Create("от 5% до 15%", 0.05f, 0.15f),
            Tuple.Create("от 15% до 30%", 0.15f, 0.3f),
            Tuple.Create("от 30% до 70%", 0.3f, 0.7f),
            Tuple.Create("от 70% до 100%", 0.7f, 1f)
        };
        public List<string> FilterByDiscountNamesList
        {
            get
            {
                return FilterByDiscountValuesList.Select(item => item.Item1).ToList();
            }
        }
        private Tuple<float, float> _CurrentDiscountFilter = Tuple.Create(float.MinValue, float.MaxValue);

        public Tuple<float, float> CurrentDiscountFilter
        {
            get
            {
                return _CurrentDiscountFilter;
            }
            set
            {
                _CurrentDiscountFilter = value;                
            }
        }*/
        public ServicePage()
        {
            InitializeComponent();

            var allTypes = Model.autoserviceEntities.GetContext().Service.ToList();
            allTypes.Insert(0, new Model.Service { Title = "Все элементы" });
            ComboType.ItemsSource = allTypes;
            CheckActual.IsChecked = true;
            
            ComboTypeCost.Items.Add("цена по возрастанию");
            ComboTypeCost.Items.Add("цена по убыванию");
            ComboTypeCost.SelectedIndex = 0;

                       
            UpdateServices();
        }
        private void UpdateServices()
        {
            var currentService = Model.autoserviceEntities.GetContext().Service.ToList();
            
            currentService = currentService.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

           
            /*  if(ComboType.SelectedIndex > 0)
             {
                currentService = currentService.Where(p => p.Discount.Contains(ComboType.SelectedItem as Model.Service)).ToList();
             }
             
             if (CheckActual.IsChecked.Value)
             {
                 currentService = currentService.Where(p => p.IsActual).ToList();
             }*/

            if (ComboTypeCost.SelectedIndex == 0)
            {
                LViewService.ItemsSource = currentService.OrderBy(p => p.Cost).ToList();
            }
            else 
            {
                LViewService.ItemsSource = currentService.OrderByDescending(p => p.Cost).ToList();
            }
                       
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
