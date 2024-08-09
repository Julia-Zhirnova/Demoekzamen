using CPKiO.Classes;
using CPKiO.Models;
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

namespace CPKiO.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private Order _currentOrder = new Order();

        public AddOrderPage(Order selectedOrder)
        {
            InitializeComponent();

            if (selectedOrder != null)
            {
                _currentOrder = selectedOrder;
            }

            DataContext = _currentOrder;
            StatusCB.ItemsSource = Entities.GetContext().OrderStatus.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentOrder.id == 0)
            {
                Entities.GetContext().Orders.Add(_currentOrder);
            }

            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
