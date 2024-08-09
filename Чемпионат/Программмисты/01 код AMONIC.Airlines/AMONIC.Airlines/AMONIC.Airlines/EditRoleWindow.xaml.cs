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
using System.Windows.Shapes;

namespace AMONIC.Airlines
{
    /// <summary>
    /// Логика взаимодействия для EditRoleWindow.xaml
    /// </summary>
    public partial class EditRoleWindow : Window
    {
        //Class с параметром user
        public EditRoleWindow(Users user)
        {
            InitializeComponent();
            //Условие если роль 1, то ставит точку у RadioButton, отвечающего за роль
            if (user.RoleID == 1)
            {
                RbAdmin.IsChecked = true;
            }
            else
            {
                RbUser.IsChecked = true;
            }
            //Заполняем выпадающий список, коллекцией офисов
            CmbOffices.ItemsSource = Helper.context.Offices.ToList();
            //Устанавливаем источник данных, наш объект user
            DataContext = user;
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            //Тернарный оператор(условие), если у RadioButton пользователя, свойство IsChecked==true, тоесть он выбран, то вернется 2 иначе 1
            int idRole = RbUser.IsChecked == true ? 2 : 1;
            //Далее преобразуем DataContext к типу Users
            var user = DataContext as Users;
            //Изменяем роль
            user.RoleID = idRole;
            //Сохраняем изменения
            Helper.context.SaveChanges();
            //Закрываем окно
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        { 
            //Закрываем окно
            Close();
        }

        private void RbUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
