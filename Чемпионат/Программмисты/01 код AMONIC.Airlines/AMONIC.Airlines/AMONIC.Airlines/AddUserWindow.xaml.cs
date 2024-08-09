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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            //Так как у нас добавление, а это создание нового объекта
            //Инициализируем новый объект, источнику данных (DataContext)
            DataContext = new Users();
            //Заполняем выпающий список, коллекцией оффисов из базы данных
            CmbOffices.ItemsSource = Helper.context.Offices.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые значения у элементов управления(элементов ввода)
            if (string.IsNullOrEmpty(TbEmail.Text) || string.IsNullOrEmpty(TbFirstName.Text)
                || string.IsNullOrEmpty(TbLastName.Text) || CmbOffices.SelectedIndex == -1
                || string.IsNullOrEmpty(PbPassword.Password) || !DpBirthdate.SelectedDate.HasValue)
            {
                //Если хотя бы одно поле не будет заполненно, то будет выведено сообщение
                MessageBox.Show("Проверьте заполненность полей!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                //и закончена работа метода
                return;
            }
            //Так как DataContext, имеет тип данных object, его надо преобразовать к типу класса Users
            //Преобразовываем для того, чтобы можно было обращаться к атрибутам объекта Users
            //Для этого есть ключевые слова as
            var user = DataContext as Users;
            //В базе данных у нас должны храниться хешированые пароли
            //Метод Md5Hash, возвращает хешированую строку из первоначальной строки
            //Свойству Password, задаем херированую строку, а передаем в этот метод пароль из элемента ввода PasswordBox
            user.Password = Helper.Md5Hash(PbPassword.Password);
            //Так как администратор может создавать только пользователей, то RoleID, поставим, 2—это ID роли пользователя
            user.RoleID = 2;
            //Также после добавления сразу ставится статус учетной записи, как активный
            user.Active = true;
            //Добавляем пользователя в коллекцию
            Helper.context.Users.Add(user);
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
    }
}
