using CPKiO.Classes;
using CPKiO.Models;
using CPKiO.Pages;
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
using System.Windows.Threading;

namespace CPKiO.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private int attempts = 0;

        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan duration;

        Random random = new Random();
        string symbols = "";

        public LoginPage()
        {
            InitializeComponent();

            if (App.IsGone == true)
            {
                duration = TimeSpan.FromMinutes(3);

                LoginTimerTB.Visibility = Visibility.Visible;
                LoginBlock.Visibility = Visibility.Collapsed;
                BlockedTB.Text = "Время сеанса истекло!";
                BtnLogin.IsEnabled = false;
                StartTimer();
            }
        }

        private void LogIn()
        {
            var currentSraff = Entities.GetContext().Staffs.FirstOrDefault(p => p.login == LoginTB.Text && p.password == PasswordBox.Password);

            if (currentSraff != null)
            {
                Entities.CurentStaff = currentSraff;
                if (currentSraff.role_id == 1)
                {
                    Manager.MainFrame.Navigate(new AdminPage());
                }
                else if (currentSraff.role_id == 2)
                {
                    Manager.MainFrame.Navigate(new ManagerPage());
                }
                else if (currentSraff.role_id == 3)
                {
                    Manager.MainFrame.Navigate(new SellerPage());
                }
            }
            else
            {
                attempts++;
                CheckAttemps();

            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LogIn();
            }
        }

        private void CheckAttemps()
        {
            if (attempts == 2)
            {
                CaptchaBlock.Visibility = Visibility.Visible;
                CaptchaTbBlock.Visibility = Visibility.Visible;
                UpdateCaptcha();
                MessageBox.Show("Пройдите капчу.", "Не удается войти!", MessageBoxButton.OK, MessageBoxImage.Warning);

                if (CaptchaTB.Text == symbols)
                {
                    LogIn();
                }
            }
            else
            {
                if (attempts == 3)
                {
                    duration = TimeSpan.FromSeconds(10);

                    LoginTimerTB.Visibility = Visibility.Visible;
                    LoginBlock.Visibility = Visibility.Collapsed;
                    BlockedTB.Text = "Превышено количество попыток авторизации.\nВозможность входа заблокирована.";
                    BtnLogin.IsEnabled = false;
                    StartTimer();
                }
                else
                {
                    MessageBox.Show("Пользователь с такими данными не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void StartTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (duration == TimeSpan.Zero)
            {
                timer.Stop();
                LoginTimerTB.Visibility = Visibility.Hidden;
                LoginBlock.Visibility = Visibility.Visible;
                BlockedTB.Text = "";
                CaptchaBlock.Visibility = Visibility.Collapsed;
                CaptchaTbBlock.Visibility = Visibility.Collapsed;

                BtnLogin.IsEnabled = true;
                attempts = 0;
                duration = TimeSpan.FromSeconds(10);
            }
            else
            {
                duration = duration.Add(TimeSpan.FromSeconds(-1));
                LoginTimerTB.Text = duration.ToString("c");
            }
        }

        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {
            symbols = "";
            CaptchaTB.Text = "";
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();

            GenerateSymbols(4);
            GenerateNoise(32);
        }

        private void GenerateSymbols(int count)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();

                lbl.Text = symbol;
                lbl.FontSize = random.Next(24, 32);
                lbl.RenderTransform = new RotateTransform(random.Next(-24, 24));
                lbl.Margin = new Thickness(16, 0, 16, 0);

                SPanelSymbols.Children.Add(lbl);

                symbols = symbols + symbol;
            }
        }

        private void GenerateNoise(int volumeNoise)
        {
            for (int i = 0; i < volumeNoise; i++)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb((byte)random.Next(32, 128), (byte)random.Next(0, 128), (byte)random.Next(0, 128), (byte)random.Next(0, 128)));
                border.Height = random.Next(4, 8);
                border.Width = random.Next(256, 512);

                border.RenderTransform = new RotateTransform(random.Next(0, 360));

                CanvasNoise.Children.Add(border);
                Canvas.SetLeft(border, random.Next(0, 200));
                Canvas.SetTop(border, random.Next(0, 75));


                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)random.Next(32, 64), (byte)random.Next(0, 128), (byte)random.Next(0, 128), (byte)random.Next(0, 128)));
                ellipse.Height = ellipse.Width = random.Next(20, 40);

                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, random.Next(0, 400));
                Canvas.SetTop(ellipse, random.Next(0, 100));
            }
        }

        private void ShowPassCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Collapsed; //This hides the PasswordBox
            PasswordTB.Visibility = Visibility.Visible; //This shows the TextBox

            PasswordTB.Text = PasswordBox.Password; //This sets the text to the TextBox to the password typed into the PasswordBox
            PasswordTB.Focus();
        }

        private void ShowPassCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible; //This shows the PasswordBox
            PasswordTB.Visibility = Visibility.Collapsed; //This hides the TextBox

            PasswordBox.Password = PasswordTB.Text;
            PasswordTB.Text = ""; //Clear the text
            PasswordBox.Focus();
        }
    }
}
