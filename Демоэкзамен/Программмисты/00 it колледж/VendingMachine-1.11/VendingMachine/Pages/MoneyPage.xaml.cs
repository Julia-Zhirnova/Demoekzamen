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
    /// Логика взаимодействия для MoneyPage.xaml
    /// </summary>
    public partial class MoneyPage : Page
    {
        public MoneyPage()
        {
            InitializeComponent();

            var coinsList = Entities.GetContext().VendingMachineCoins.Where(p => p.VendingMachineId == 1).OrderBy( p => p.CoinsId).ToList();

            int i = 0;

            foreach (var number in coinsList)
            {
                i = i + 1;

                switch(i)
                {
                    case 1:
                        Denom1.Text= Convert.ToString(number.Coin.Denomination + " руб");
                        break;
                    case 2:
                        Denom2.Text = Convert.ToString(number.Coin.Denomination + " руб");
                        break;
                    case 3:
                        Denom3.Text = Convert.ToString(number.Coin.Denomination + " руб");
                        break;
                    case 4:
                        Denom4.Text = Convert.ToString(number.Coin.Denomination + " руб");
                        break;
                }

                switch(i)
                {
                    case 1:
                        Count1.Text = Convert.ToString(number.Count);
                        break;
                    case 2:
                        Count2.Text = Convert.ToString(number.Count);
                        break;
                    case 3:
                        Count3.Text = Convert.ToString(number.Count);
                        break;
                    case 4:
                        Count4.Text = Convert.ToString(number.Count);
                        break;
                }

                switch(i)
                {
                    case 1:
                        Check1.IsChecked = Convert.ToBoolean(number.IsActive);
                        break;
                    case 2:
                        Check2.IsChecked = Convert.ToBoolean(number.IsActive);
                        break;
                    case 3:
                        Check3.IsChecked = Convert.ToBoolean(number.IsActive);
                        break;
                    case 4:
                        Check4.IsChecked = Convert.ToBoolean(number.IsActive);
                        break;
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage());
        }
    }
}
