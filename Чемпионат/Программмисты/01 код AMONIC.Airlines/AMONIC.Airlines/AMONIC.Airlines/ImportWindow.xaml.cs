using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace AMONIC.Airlines
{
    /// <summary>
    /// Логика взаимодействия для ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        public ImportWindow()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            //Класс отвечающий за диалоговое окно, для открытия файлов
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Указываем фильтр файлов для открытия
            openFileDialog.Filter = "CSV Files|*.csv";
            //Если окно открыто
            if (openFileDialog.ShowDialog() == true)
            {
               

                //Переменные для результатов 
                int success = 0;
                int duplicate = 0;
                int missing = 0;
                //Класс отвечающий за считывание файлов
                StreamReader reader = new StreamReader(openFileDialog.FileName);

                //Переменная для строки из файла
                string line = "";

                //Цикл с которой line считывает строку
                while ((line = reader.ReadLine()) != null)
                {
                    //Пример, line у нас будет равен такой строке ADD,2017-10-04,06:25,75,AUH,RUH,1,983.00,OK


                    //Далее должны раздлелить эту строку на подстроки по определенному символу
                    string[] lines = line.Split(',');
                    //Проверка на количество элементов массива, если не равен 9, то не хватает полей и переменной missing делаем +1
                    //и с помощью ключевого слова continue переходим на следующаю итерацию
                    if (lines.Length != 9)
                    {
                        missing += 1;
                        continue;
                    }
                    string operation = lines[0];
                    if (operation != "ADD" && operation != "EDIT")
                    {
                        missing += 1;
                        continue;
                    }
                    string date = lines[1];
                    if (!DateTime.TryParse(date, out DateTime dateTime))
                    {
                        missing += 1;
                        continue;
                    }
                    string time = lines[2];
                    if (!TimeSpan.TryParse(time, out TimeSpan timeSpan))
                    {
                        missing += 1;
                        continue;
                    }
                    string number = lines[3];
                    if (string.IsNullOrEmpty(number))
                    {
                        missing += 1;
                        continue;
                    }
                    string from = lines[4];
                    if (!(Helper.context.Airports.FirstOrDefault(x => x.IATACode == from) is Airports fromAirport))
                    {
                        missing += 1;
                        continue;
                    }
                    string to = lines[5];
                    if (!(Helper.context.Airports.FirstOrDefault(x => x.IATACode == to) is Airports toAirport))
                    {
                        missing += 1;
                        continue;
                    }
                    if (!(Helper.context.Routes.FirstOrDefault(x => x.Airports.ID == fromAirport.ID && x.Airports1.ID == toAirport.ID) is Routes route))
                    {
                        missing += 1;
                        continue;
                    }
                    string aircraftCode = lines[6];
                    if (!(Helper.context.Aircrafts.FirstOrDefault(x => x.ID.ToString() == aircraftCode) is Aircrafts aircraft))
                    {
                        missing += 1;
                        continue;
                    }
                    if (!decimal.TryParse(lines[7], NumberStyles.Any, new CultureInfo("en-US"), out decimal price))
                    {
                        missing += 1;
                        continue;
                    }
                    if (price < 0)
                    {
                        missing += 1;
                        continue;
                    }
                    string confirmation = lines[8];
                    if (confirmation != "OK" && confirmation != "CANCELED")
                    {
                        missing += 1;
                        continue;
                    }
                    bool confirmed = confirmation == "OK";
                    //Проверяем дублирующие данные в бд
                    var duplicateSchedule = Helper.context.Schedules.FirstOrDefault(x => x.FlightNumber == number
                      && x.Date == dateTime.Date && x.AircraftID == aircraft.ID);

                    //Если у нас операция добавления
                    if (operation == "ADD")
                    {
                        //и если есть дублирующий объект, то мы его не будет добавлять и пропустим итерацию
                        if (duplicateSchedule != null)
                        {
                            duplicate += 1;
                            continue;
                        }
                        //Иначе добавляем
                        Schedules schedule = new Schedules()
                        {
                            Date = dateTime,
                            Time = timeSpan,
                            FlightNumber = number,
                            RouteID = route.ID,
                            AircraftID = aircraft.ID,
                            EconomyPrice = price,
                            Confirmed = confirmed,
                        };
                        Helper.context.Schedules.Add(schedule);
                        Helper.context.SaveChanges();
                        success += 1;
                    }
                    //Если операция редактирования
                    if (operation == "EDIT")
                    {
                        //Меняем дублирующее расписание
                        //Если его нет, то к переменной missing +1 и пропускаем эту итерацию
                        if (duplicateSchedule == null)
                        {
                            missing += 1;
                            continue;
                        }
                        //Тут меняем атрибуты этой записи
                        duplicateSchedule.Date = dateTime;
                        duplicateSchedule.Time = timeSpan;
                        duplicateSchedule.FlightNumber = number;
                        duplicateSchedule.RouteID = route.ID;
                        duplicateSchedule.AircraftID = aircraft.ID;
                        duplicateSchedule.EconomyPrice = price;
                        duplicateSchedule.Confirmed = confirmed;
                        Helper.context.SaveChanges();
                        success += 1;
                    }
                }
                //Закрываем потом
                reader.Close();

                //Выводим результаты
                TbSuccessful.Text = success.ToString();
                TbDuplicate.Text = duplicate.ToString();
                TbMissing.Text = missing.ToString();
            }

        }
    }
}
