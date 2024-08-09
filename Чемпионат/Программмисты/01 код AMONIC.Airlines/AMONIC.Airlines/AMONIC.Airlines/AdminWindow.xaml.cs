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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Load();
            LoadData();
        }

        //Здесь мы описали сразу общий метод для фильтрации
        private void LoadData()
        {
            //Получаем выбранный объект из выпадающего списка
            Offices office = CmbOffices.SelectedItem as Offices;
            //Выполняем фильтрацию пользователей по выбранному офису
            UsersGrid.ItemsSource = Helper.context.Users
                .Where(x => x.OfficeID == office.ID || office.ID == 0).ToList();
        }

        private void Load()
        {
            //Получаем данные о офисах
            var offices = Helper.context.Offices.ToList();
            //К этой коллекции добавляем еще один объект Offices, то индексу 0
            offices.Insert(0, new Offices() { Title = "All offices" });
            //Теперь добавляем нашему выпадающему списку
            CmbOffices.ItemsSource = offices;
        }

        //Обработчик событий TextBlock, который напоминает клик кнопки
        private void TbAddUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Экземпляр нового окна
            AddUserWindow addUserWindow = new AddUserWindow();
            //Переход на это окно с блокировкой состояния текущего
            addUserWindow.ShowDialog();
            //После того как закроем addUserWindow
            //Будет вызван метод LoadData
            LoadData();
        }

        private void TbExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Закрытие приложения
            Application.Current.Shutdown();
        }

        private void CmbOffices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //При изменение выбранного элемента в выпадающем списке, вызываем метод LoadData
            LoadData();
        }

        private void BtnChangeRole_Click(object sender, RoutedEventArgs e)
        {
            //Ключевое слово is проверяет относится ли объект к определенному типу
            //Проверяем является ли выбранный элемент из DataGrid типом Users, если да то создаем переменную
            if (UsersGrid.SelectedItem is Users user)
            {
                //Создаём экземпляр окна и передаем параметр в констркутор, а именно наш объект user
                EditRoleWindow editRoleWindow = new EditRoleWindow(user);
                //Открываем окно с блокированием текущего
                editRoleWindow.ShowDialog();
                //После закрытия окна вызываем метод LoadData
                LoadData();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)

        {//Проверяем является ли выбранный элемент из DataGrid типом Users, если да то создаем переменную
            if (UsersGrid.SelectedItem is Users user)
            {
                //Меняем статус аккаунта, на противоположный
                user.Active = !user.Active;
                //Сохраняем изменения
                Helper.context.SaveChanges();
                LoadData();
            }
        }
    }
}
