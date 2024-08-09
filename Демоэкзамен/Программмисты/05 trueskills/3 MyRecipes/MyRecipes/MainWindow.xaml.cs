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

namespace MyRecipes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Models.MyRecipesEntities context = new Models.MyRecipesEntities();
            var categories = context.Category.Where(x => x.Name.Length <= 5).OrderByDescending(x => x.Name).Select(x => x.Id + ": " + x.Name).ToList();

            var avgCost = context.Ingredient.Max(x => x.Cost);

            var secondPageIngredients = context.Ingredient.ToList().Skip(10).Take(10).Select(x => x.Id + ": " + x.Name).ToList();

            var firstCategory = context.Category.FirstOrDefault();


            /*Models.Category category = new Models.Category
            {
                Id=6,
                Name="Напитки"
            };
            context.Category.Add(category);
            context.SaveChanges();*/
            var category = context.Category.FirstOrDefault(x => x.Id == 6);
            /*category.Name = "Напиток";
            context.SaveChanges();*/

            //context.Category.Remove(category);
           // context.SaveChanges();
        }

        private void BtnDishes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageListDishes());
        }

        private void BtnIngredients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageListIngredients());
        }

        private void BtnCaptcha_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageCaptcha()); 
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
