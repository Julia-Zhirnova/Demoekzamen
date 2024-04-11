using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CRUD
{
    /// <summary>
    /// Логика взаимодействия для EditAgentsPage.xaml
    /// </summary>
    public partial class EditAgentsPage : Page
    {
        public OpenFileDialog ofd = new OpenFileDialog();
        private agents _currentagents = new agents();
                
        string path = "";
        private bool flag = false;
        private string _imgSource = string.Empty;
        public EditAgentsPage(agents sellectedAgents)
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
                errors.AppendLine("Укажите имя агента");
            
            if (string.IsNullOrWhiteSpace(_currentagents.MiddleName))            
                errors.AppendLine("Укажите фамилию агента");
            
            if (string.IsNullOrWhiteSpace(_currentagents.LastName))            
                errors.AppendLine("Укажите отчество агента");
            
            if (_currentagents.DealShare < 0 || _currentagents.DealShare > 100)            
                errors.AppendLine("Доля от комиссии - число от 0 до 100");
            
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentagents.Id == 0)            
                CRUDEntities.GetContext().agents.Add(_currentagents);            

            try
            {
                CRUDEntities.GetContext().SaveChanges();

                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnSaveImage_Click(object sender, RoutedEventArgs e)
        {
          //  _context.SaveChanges();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            
            string Source = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                flag = true;
                string ing = ofd.SafeFileName;
                _imgSource = Source.Replace("/bin/Debug", "/img/") + ing;
                PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                path = ofd.FileName;
                _currentagents.PhotoPath = $"/img/{ofd.SafeFileName}";
            }
        }
    }
    
}
