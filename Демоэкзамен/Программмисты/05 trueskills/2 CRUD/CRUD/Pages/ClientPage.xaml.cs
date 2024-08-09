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

namespace CRUD.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            DGridCRUDclients.ItemsSource = Models.CRUDEntities.GetContext().clients.ToList();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditClientsPage(null));
        }

        private void BtnDelClient_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemoving = DGridCRUDclients.SelectedItems.Cast<Models.clients>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Models.CRUDEntities.GetContext().clients.RemoveRange(clientsForRemoving);
                    Models.CRUDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridCRUDclients.ItemsSource = Models.CRUDEntities.GetContext().clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditClientsPage((sender as Button).DataContext as Models.clients));
        }
    }
}
