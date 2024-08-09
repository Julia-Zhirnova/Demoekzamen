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
using VendingMachine.Classes;
using VendingMachine.Models;

namespace VendingMachine.Pages
{
    /// <summary>
    /// Логика взаимодействия для DrinksPage.xaml
    /// </summary>
    public partial class DrinksPage : Page
    {
        public DrinksPage()
        {
            InitializeComponent();
            LB.ItemsSource = Entities.GetContext().Drinks.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage());
        }

        private void BtnAddDrink_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddDrinkPage());
        }
    }
}
