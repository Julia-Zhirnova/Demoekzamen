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

namespace MyRecipes.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListDishes.xaml
    /// </summary>
    public partial class PageListDishes : Page
    {
        Models.MyRecipesEntities _context = new Models.MyRecipesEntities();
        public PageListDishes()
        {
            InitializeComponent();
            //GenerateRandomTags();


            //var categoriesTest=_context.Categories.ToList().Select(x => x.FullName);

            List<Models.Category> listCategories = _context.Category.ToList();
            listCategories.Insert(0, new Models.Category { Name = "Все категории" });
            CmbCategory.ItemsSource = listCategories;
            CmbCategory.SelectedIndex = 0;

            RefreshData();
        }
        private void GenerateRandomTags()
        {
            foreach (var ingr in _context.Ingredient.ToList())
            {
                Random rand = new Random();
                for (int i = 2; i <= rand.Next(2, 6); i++)
                {
                   // ingr.Tags.Add(_context.Tags.ToList().ElementAt(rand.Next(0, 5)));
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void RefreshData()
        {
            List<Models.Dish> listDishes = _context.Dish.ToList();

            // фильтрация по категориям
            if (CmbCategory.SelectedIndex != 0)
            {
                Models.Category selectedCategory = (Models.Category)CmbCategory.SelectedItem;
                listDishes = listDishes.Where(x => x.CategoryId == selectedCategory.Id).ToList();
            }

            // поиск по тексту
            var searchString = TxtSearch.Text;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listDishes = listDishes.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            // сортировка по себестоимости блюда
            listDishes = listDishes.OrderByDescending(x => x.ServingPrice).ToList();

            LViewDishes.ItemsSource = listDishes;
        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void NavigateToSelectedDish(object sender, MouseButtonEventArgs e)
        {
            Grid gridDish = sender as Grid;
            var selectedDish = gridDish.DataContext as Models.Dish;

            NavigationService.Navigate(new PageCurrentRecipe(selectedDish));
        }
    }
}

