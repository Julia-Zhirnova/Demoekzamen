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
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Page
    {
        public Avtorization()
        {
            InitializeComponent();
            
        }

        private void BtnInLogin_Click(object sender, RoutedEventArgs e)
        {
            var userObj = Model.uchet_zayavokEntities.GetContext().Users.FirstOrDefault(x =>
                x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
            if (userObj == null)
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Model.uchet_zayavokEntities.CurentUser = userObj;
                    if (userObj.RoleID == 1)
                    {
                        Classes.manager.MainFrame.Navigate(new Ispolnitel());
                    }
                    else if(userObj.RoleID == 2)
                    {
                        Classes.manager.MainFrame.Navigate(new Client());
                    }
                    else if (userObj.RoleID == 3)
                    {
                        Classes.manager.MainFrame.Navigate(new Ispolnitel());
                    }
                    else
                    {
                        MessageBox.Show("Данные не обнаружены!", "Уведомление",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                    }                               
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            
        }
    }
}
