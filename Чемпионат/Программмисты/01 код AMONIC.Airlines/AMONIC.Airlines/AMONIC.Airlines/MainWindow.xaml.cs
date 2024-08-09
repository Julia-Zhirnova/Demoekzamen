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
using System.Windows.Threading;

namespace AMONIC.Airlines
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Глобальные переменные

        //Переменная(счетчик) ошибок
        private int _error = 0;
        //Переменная с количеством секунд на блокировку
        private int _tick = 10;
        //Инициализированный объект
        private DispatcherTimer _timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            //Настройки таймера

            //Задаём интервал
            _timer.Interval = TimeSpan.FromSeconds(1);
            //Создаём событие
            _timer.Tick += Timer_Tick;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Проверка элементов управления(элементов ввода) на пустые поля
            if (string.IsNullOrEmpty(TbLogin.Text)
                || string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Поля не заполнены!", "Информация"
                    , MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //Переменная с хеширование пароля, который вводим из элемента ввода
            var password = Helper.Md5Hash(PbPassword.Password);

            //Находим первую позицию в базе данных соответствующих нашему запросу
            var user = Helper.context.Users.FirstOrDefault(x => x.Email == TbLogin.Text
              && x.Password == password);
            //Если по запросу находит данные, то на возвращается объект Users иначе объект будет null


            //Проверка, на то, что запрос вернул null
            if (user == null)
            {
                //Если три раза не нашёлся объект из базы данных
                if (_error == 3)
                {
                    //то блокируем кнопку
                    BtnLogin.IsEnabled = false;
                    //запускаем таймер
                    _timer.Start();
                    //и заканчиваем выполнение метода
                    return;
                }
                //Выводим сообщение для пользователя, что его данные не правильные, так как наш запрос вернул null
                MessageBox.Show("Email или пароль не правильные!", "Ошибка"
                                    , MessageBoxButton.OK, MessageBoxImage.Error);
                //Прибавляем к переменной ошибки +1
                _error += 1;
                //и заканчиваем выполнение метода
                return;
            }

            //Условие должно возвращать true, знаком !, можем ожидать false
            //Так как у пользователей, чей статус false, не могут пользоваться приложение, делаем проверку
            if (!user.Active.Value)
            {
                //Выводим сообщение пользователю, о том, что его аккаунт не активный
                MessageBox.Show("Не активный аккаунт", "Ошибка"
                                      , MessageBoxButton.OK, MessageBoxImage.Error);
                //и заканчиваем выполнение метода
                return;

            }
            //Запоминаем авторизованого пользователя
            Helper.currentUser = user;

            //Создаём запись в базе данных, о активности пользователя
            Activities activity = new Activities()
            {
                UserID = user.ID,
                LoginTime = DateTime.Now
            };
            //Добавляем запись в коллекцию
            Helper.context.Activities.Add(activity);
            //Сохраняем изменения
            Helper.context.SaveChanges();


            //Берем роль у пользователя и если RoleID=1, открываем окно администратора, если RoleID=2, то окно пользователя 
            switch (user.RoleID)
            {
                case 1:
                    //Создаём новый экземпляр окна
                    AdminWindow adminWindow = new AdminWindow();
                    //Открываем окно
                    adminWindow.Show();
                    break;
                case 2:
                    //Создаём новый экземпляр окна
                    UserWindow userWindow = new UserWindow();
                    //Открываем окно
                    userWindow.Show();
                    break;
            }
            //Закрываем текущее окно, а именно MainWindow
            Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Так как в интервале таймера, мы указали одну секунду
            //Будет вычитать из нашей переменной каждую секунду, единицу
            _tick -= 1;
            //Если переменная будет равна 0
            if (_tick == 0)
            {
                //Кнопку активируем, так как время блокировки прошло
                BtnLogin.IsEnabled = true;
                //Таймер останавливаем
                _timer.Stop();
                //Переменный присваиваем начальные значения
                _tick = 10;
                _error = 0;
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            //Выход из приложения
            Application.Current.Shutdown();
        }
    }
}
