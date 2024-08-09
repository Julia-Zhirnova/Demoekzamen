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
    /// Логика взаимодействия для agentsPage.xaml
    /// </summary>
    public partial class EditAgentsPage : Page
    {
        private Models.agents _currentagents = new Models.agents();
        public EditAgentsPage(Models.agents sellectedAgents)
        {
            InitializeComponent();
            if (sellectedAgents != null)
            {
                _currentagents = sellectedAgents;
            }
            DataContext = _currentagents;
        }
      
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(_currentagents.FirstName))
            {
                errors.AppendLine("Укажите имя агента");
            }
            if (string.IsNullOrWhiteSpace(_currentagents.MiddleName))
            {
                errors.AppendLine("Укажите фамилию агента");
            }
            if (string.IsNullOrWhiteSpace(_currentagents.LastName))
            {
                errors.AppendLine("Укажите отчество агента");
            }
            if (_currentagents.DealShare < 0 || _currentagents.DealShare > 100)
            {
                errors.AppendLine("Доля от комиссии - число от 0 до 100");
            }           

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentagents.Id == 0)
            {
                Models.CRUDEntities.GetContext().agents.Add(_currentagents);
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
