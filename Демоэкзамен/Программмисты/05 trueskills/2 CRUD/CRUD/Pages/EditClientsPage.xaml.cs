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
    public partial class EditClientsPage : Page
    {
        private Models.clients _currentclients = new Models.clients();
        public EditClientsPage(Models.clients sellectedClients)
        {
            InitializeComponent();
            if (sellectedClients != null)
            {
                _currentclients = sellectedClients;
            }
            DataContext = _currentclients;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

           
            if (string.IsNullOrWhiteSpace(_currentclients.Email) && !_currentclients.Phone.HasValue)
            {
                errors.AppendLine("Укажите почту или телефон клиента");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentclients.Id == 0)
            {
                Models.CRUDEntities.GetContext().clients.Add(_currentclients);
            }

            try
            {
                Models.CRUDEntities.GetContext().SaveChanges();

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
