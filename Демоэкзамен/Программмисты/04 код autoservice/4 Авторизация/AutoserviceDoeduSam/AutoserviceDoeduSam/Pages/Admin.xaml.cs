using AutoserviceDoeduSam.Class;
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

namespace AutoserviceDoeduSam.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            AppConnect.modelOdb=new Models.AvtorisationEntities();
        }

        private void BtnInLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x =>
                x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
                if(userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Здравствуйте " + userObj.Role.Name + ", " + userObj.Name, "Уведомление",
                       MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (userObj.IdRole)
                        {
                            case 1:
                                Class.Manager.MainFrame.Navigate(new Administrator());
                                break;
                            case 2:
                                Class.Manager.MainFrame.Navigate(new StarshiiSmen());
                                break;
                            case 3:
                                Class.Manager.MainFrame.Navigate(new Prodavec());
                                break;
                        default:
                                MessageBox.Show("Данные не обнаружены!", "Уведомление",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;


                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnRegIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Visible;
            PsbPassword.Visibility = Visibility.Collapsed;
            TxbPassword.Text = PsbPassword.Password;
        }

        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            PsbPassword.Visibility = Visibility.Visible;
        }
    }
}
