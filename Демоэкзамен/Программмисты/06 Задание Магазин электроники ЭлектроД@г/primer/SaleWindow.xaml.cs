using DesktopSaleApp.Classes;
using DesktopSaleApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Threading;

namespace DesktopSaleApp
{
    /// <summary>
    /// Логика взаимодействия для SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        private List<PriceListTable> allItems;
        private DispatcherTimer timer;

        /// <summary>
        /// При открытие окна, учитывается список данных пользователя и присваивает данные TextBox
        /// </summary>
        public SaleWindow(User user)
        {
            InitializeComponent();
            allItems = Models.Use_r4Entities1.GetContext().PriceListTable.ToList();
            var categoryes = Use_r4Entities1.GetContext().Categorys.ToList();
            CategorysBox.ItemsSource = categoryes;
            CategorysBox.DisplayMemberPath = "CategoryName";
            CategorysBox.SelectedValuePath = "CategoryID";
            RefreshItems();
            FIOBoxxxxx.Text = user.MiddleName + user.FirstName + user.LastName;
            RoleBoxUser.Text = user.RoleID.ToString();
            if (RoleBoxUser.Text == "1")
            {
                RoleBoxUser.Text = "Менеджер";
            }
            else if (RoleBoxUser.Text == "2")
            {
                RoleBoxUser.Text = "Кладовщик";
            }
            else if (RoleBoxUser.Text == "3")
            {
                RoleBoxUser.Text = "Продавец";
            }
            else if (RoleBoxUser.Text == "4")
            {
                RoleBoxUser.Text = "Покупатель";
            }
            BitmapImage image = new BitmapImage(new Uri(user.PhotoPath, UriKind.RelativeOrAbsolute));
            UserPhoto.Source = image;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); //  интервал на 5 секунд
            timer.Tick += Timer_Tick; // Обработчик события Tick
            timer.Start(); 
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            
            WorkingTimer.Text = timer.Interval.ToString();
        }
        /// <summary>
        /// Кнопка добавления в корзину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddToCart(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK");
        }
        private void OnTextBlockLoaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null && textBlock.Text == "1")
            {
                textBlock.Text = "Ярославская область, город Люберцы, ул. Косиора, 29";
            }
            else if (textBlock != null && textBlock.Text == "2")
            {
                textBlock.Text = "Рязанская область, город Мытищи, пл. Будапештсткая, 69";

            }
            else if (textBlock != null && textBlock.Text == "3")
            {
                textBlock.Text = "Новосибирская область, город Можайск, спуск Космонавтов, 37";
            }
        }

        private void TextBlock_LoadedCategory(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null && textBlock.Text == "1")
            {
                textBlock.Text = "Микросхемы зарубежные 0…-9…";
            }
           
           

            
        }
        private void RefreshItems()
        {
            var currentItems = allItems.ToList();
            string searchText = TbSearchBox.Text.ToLower();
            currentItems = currentItems.Where(p => p.Article.ToLower().Contains(searchText) || p.ItemName.ToLower().Contains(searchText) || p.Cost.ToString().Contains(searchText)).ToList();
            ItemsView.ItemsSource = currentItems;

            var selectedCategory = CategorysBox.SelectedItem as Categorys;
            if (selectedCategory != null)
            {
                int selectedCategoryId = selectedCategory.CategoryID;
                currentItems = currentItems.Where(p => p.CategoryID == selectedCategoryId).ToList();
                ItemsView.ItemsSource = currentItems;
            }
            if (currentItems.Count == 0)
            {
                MessageBox.Show("Ничего не найдено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void CategorysBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            RefreshItems();
        }

        private void TbSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshItems();
            
        }

        private void TbSearchBox_MouseEnter(object sender, MouseEventArgs e)
        {
            GuideForEnterBox.Visibility = Visibility.Visible;
        }

        private void TbSearchBox_MouseLeave(object sender, MouseEventArgs e)
        {
            GuideForEnterBox.Visibility = Visibility.Collapsed;
        }

        private void Descripton_Click(object sender, RoutedEventArgs e)
        {
            var loginpage = new MainWindow();
            loginpage.Show();
            this.Close();
        }

        private void Available_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(ItemsView, "PDF списка товаров");
            }

        }
        private bool entered = false;

        private void Available_MouseEnter(object sender, MouseEventArgs e)
        {
            if(entered== false)
            {
                MessageBox.Show("Данные которые в данный момент отображаются на экране будут помещены в pdf документ", "Предупреждение", MessageBoxButton.OK);
                entered = true;
            }
           
            
        }

        private void ItemsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = ItemsView.SelectedItem as PriceListTable;
            if(selecteditem != null)
            {
                ItemNameBoxxx.Text = selecteditem.ItemName;
                ItemCostBox.Text = selecteditem.Cost.ToString();
                ItemCountBox.Text = selecteditem.Count.ToString();              
                    if(selecteditem.Count > 0)
                {
                    ItemCanOrderBox.Text = "Есть ";
                }
                else
                {
                    ItemCanOrderBox.Text = "Нет";
                }
                
            }
        }
    }
}
