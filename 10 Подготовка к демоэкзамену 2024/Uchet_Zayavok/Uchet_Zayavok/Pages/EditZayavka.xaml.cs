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

namespace Uchet_Zayavok.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditZayavka.xaml
    /// </summary>
    public partial class EditZayavka : Page
    {
        private Model.Zayavka _currentZayavka = new Model.Zayavka();
        public EditZayavka(Model.Zayavka sellectedZayavka)
        {
            InitializeComponent();
            EditIspolnitel.Visibility = Visibility.Hidden;
            EditManager.Visibility = Visibility.Hidden;
            StatusCB.ItemsSource = Model.uchet_zayavokEntities.GetContext().Status.ToList();

            if (sellectedZayavka != null && Model.uchet_zayavokEntities.CurentUser.ID == 3)
            {
                _currentZayavka = sellectedZayavka;
                EditIspolnitel.Visibility = Visibility.Visible;
                
            }
            else if (sellectedZayavka != null && Model.uchet_zayavokEntities.CurentUser.ID == 1)
            {
                _currentZayavka = sellectedZayavka;
                EditIspolnitel.Visibility = Visibility.Visible;
                EditManager.Visibility = Visibility.Visible;
            }
            DataContext = _currentZayavka;
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentZayavka.ID == 0)
            {
                _currentZayavka.ClientID = Model.uchet_zayavokEntities.CurentUser.ID;
                Model.uchet_zayavokEntities.GetContext().Zayavka.Add(_currentZayavka);
            }
                

            try
            {
                Model.uchet_zayavokEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
