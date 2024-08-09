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
    /// Логика взаимодействия для ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        //Коллекция с типами сортировки
        private List<string> _listSort = new List<string>()
        {
            "Date and Time", "Economy Price", "Confirmed"
        };
        public ScheduleWindow()
        {
            InitializeComponent();
            Load();
            LoadData();
        }

        private void LoadData()
        {
            //Получаем параметры фильтрации
            var from = CmbFrom.SelectedItem as Airports;
            var to = CmbTo.SelectedItem as Airports;
            var sortBy = CmbSortBy.Text;
            var outBound = DpOutbound.SelectedDate;
            var flightNumber = TbFlightNumber.Text;
            //


            //Выполняем фильтрацию с полученными параметрами
            var query = Helper.context.Schedules.ToList()
                .Where(x => (x.Routes.Airports.ID == from?.ID || from?.ID == 0)
                            && (x.Routes.Airports1.ID == to?.ID || to?.ID == 0)
                            && (x.FlightNumber == flightNumber || flightNumber == ""))
                .ToList();

            //Проверяем выбрана ли дата, если да, то фильтруем еще и по дате
            if (outBound.HasValue)
            {
                query = query.Where(x => x.Date == outBound.Value).ToList();
            }

            //Далее проверки на выбранный тип сортировки и сама сортировка
            if (sortBy == _listSort[0])
            {
                query = query.OrderByDescending(x => x.Date + x.Time).ToList();
            }
            else if (sortBy == _listSort[1])
            {
                query = query.OrderByDescending(x => x.EconomyPrice).ToList();
            }
            else if (sortBy == _listSort[2])
            {
                query = query.OrderByDescending(x => x.Confirmed).ToList();
            }

            //После всех фильтрация выводим конечную коллекцию в DataGrid
            SchedulesGrid.ItemsSource = query;
        }

        private void Load()
        {
            //Получаем коллекцию аэропортов
            List<Airports> airports = Helper.context.Airports.ToList();
            //Добавляем еще один аэропорт с индексом 0
            airports.Insert(0, new Airports() { IATACode = "All Airports" });
            //Заполняем наши выпадающии списки
            CmbFrom.ItemsSource = airports;
            CmbTo.ItemsSource = airports;
            CmbSortBy.ItemsSource = _listSort;
        }
        private void BtnApply_OnClick(object sender, RoutedEventArgs e)
        {
            //Мы можем указывать All Airports, поэтому проверяем, что текст в выпадающем списке не равен All Airports
            if (CmbFrom.Text != "All Airports" && CmbTo.Text != "All Airports")
            {
                //Если аэропорты равны, то ошибка
                if (CmbFrom.Text == CmbTo.Text)
                {
                    MessageBox.Show("Аэропорты не могут быть одинаковыми", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            LoadData();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            //Выбираем элемент из DataGrid
            if (SchedulesGrid.SelectedItem is Schedules schedule)
            {
                //И меняем ему статус
                schedule.Confirmed = !schedule.Confirmed;
                //Сохраняем изменения
                Helper.context.SaveChanges();
                LoadData();
            }
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnImport_OnClick(object sender, RoutedEventArgs e)
        {
            //Переход на новое окно
            ImportWindow importWindow = new ImportWindow();
            //Открытие окна с блокировкой текущего
            importWindow.ShowDialog();
            LoadData();
        }
    }
}
