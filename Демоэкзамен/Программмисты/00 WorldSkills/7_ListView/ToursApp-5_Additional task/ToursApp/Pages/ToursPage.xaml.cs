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

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public ToursPage()
        {
            InitializeComponent();

            var allTypes = TourBaseEntities.GetContext().Types.ToList();
            allTypes.Insert(0, new Type { Name = "Все типы" });
            ComboType.ItemsSource = allTypes;
            CheckActual.IsChecked = true;
            ComboType.SelectedIndex = 0;

            ComboPrice.Items.Add("кол-во билетов по возратанию");
            ComboPrice.Items.Add("кол-во билетов по убыванию");
            ComboPrice.Items.Add("цена по возрастанию");
            ComboPrice.Items.Add("цена по убыванию");
            ComboPrice.SelectedIndex = 0;

            UpdateTours();
        }

        private void UpdateTours()
        {
            var currentTours = TourBaseEntities.GetContext().Tours.ToList();
            if(ComboType.SelectedIndex > 0)
            {
                currentTours = currentTours.Where(p => p.Types.Contains(ComboType.SelectedItem as Type)).ToList();
            }
            currentTours = currentTours.Where(p => p.Name.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            if (CheckActual.IsChecked.Value)
            {
                currentTours = currentTours.Where(p => p.IsActual).ToList();
            }

            if (ComboPrice.SelectedIndex == 0)
            {
                LVTours.ItemsSource = currentTours.OrderBy(p => p.TicketCount).ToList();
            }
            else if (ComboPrice.SelectedIndex == 1)
            {
                LVTours.ItemsSource = currentTours.OrderByDescending(p => p.TicketCount).ToList();
            }
            else if (ComboPrice.SelectedIndex == 2)
            {
                LVTours.ItemsSource = currentTours.OrderBy(p => p.Price).ToList();
            }
            else
            {
                LVTours.ItemsSource = currentTours.OrderByDescending(p => p.Price).ToList();
            }

            //LVTours.ItemsSource = currentTours.OrderBy(p => p.TicketCount).ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }
    }
}
