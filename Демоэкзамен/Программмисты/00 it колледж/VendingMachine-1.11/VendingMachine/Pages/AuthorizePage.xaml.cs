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
    /// Логика взаимодействия для AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
        public AuthorizePage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MachinePage());
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string code = CodeTB.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                CodeTB.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#de1826"));
            }
            else
            {
                CodeTB.Background = Brushes.Transparent;
            }

            Models.VendingMachine authMachine = null;
            authMachine = Entities.GetContext().VendingMachines.Where(machine => machine.SecretCode == code).FirstOrDefault();

            if (authMachine != null)
            {
                Manager.MainFrame.Navigate(new AdminPage());
            }
            else
            {
                MessageBox.Show("Неверный код!");
            }
        }

        private void CodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string code = CodeTB.Text.Trim();

                if (string.IsNullOrWhiteSpace(code))
                {
                    CodeTB.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#de1826"));
                }
                else
                {
                    CodeTB.Background = Brushes.Transparent;
                }

                Models.VendingMachine authMachine = null;
                authMachine = Entities.GetContext().VendingMachines.Where(machine => machine.SecretCode == code).FirstOrDefault();

                if (authMachine != null)
                {
                    Manager.MainFrame.Navigate(new AdminPage());
                }
                else
                {
                    MessageBox.Show("Неверный код!");
                }
            }
        }
    }
}
