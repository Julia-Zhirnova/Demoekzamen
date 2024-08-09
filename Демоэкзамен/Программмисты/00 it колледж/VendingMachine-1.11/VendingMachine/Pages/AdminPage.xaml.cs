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

namespace VendingMachine.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MachinePage());
        }

        private void BtnMoney_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MoneyPage());
        }

        private void BtnDrinks_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DrinksPage());
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ReportPage());
        }
    }
}
