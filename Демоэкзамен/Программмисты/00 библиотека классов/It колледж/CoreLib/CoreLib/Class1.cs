using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public static class utils
    {
        // Вычисление среднего арифметического значения оценки в меньшую сторону 
        public static double MinAVG(string[] marks)
        {
            Console.WriteLine("String length: {0}", marks.Length);
            int[] mass = new int[marks.Length];
            double res = 0, sum = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                mass[i] = Convert.ToInt32(marks[i]);
                Console.WriteLine(mass[i]);
                sum = sum + mass[i];
            }
            if (mass.Length != 0) res = sum / mass.Length;
            else return -1;
            Console.WriteLine(res);
            int modres = Convert.ToInt32(res);
            Console.WriteLine(modres);
            modres = (int)res;
            return modres;
        }

        // Генерация номера студенческого билета в формате: yyyy.group.initial
        public static string GetStudNumber(int year, int group, string fio)
        {
            string[] s = fio.Replace(".", "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string LastName = s[0];
            string Name = s[1];
            string FatherName = s[2];
            Console.WriteLine("{0}.{1}.{2}{3}{4}", year, group, LastName[0], Name[0], FatherName[0]);
            string res = "The End";
            return res;
        }

        // Генерация оценок, посещаемости на 10 дней вперед, начиная с текущей даты со списком переданных студентов 
        public static List<Mark> GetMarks(DateTime now, List<string> students)
        {
            int n = students.Count;
            List<Mark> marks = new List<Mark>();

            for (int j = 0; j < 30; j++)
            {

                DateTime currentDate = DateTime.Now;
                DateTime date = currentDate.AddDays(j);
                Console.WriteLine("Day {0}: {1}", j + 1, date);

                for (int i = 0; i < n; i++)
                {
                    var random = new Random();
                    var marking = new List<string>{
                    "5", "4", "3", "2",
                    "отсутствует", "прогуливает", "болеет"
                    };

                    int index = random.Next(marking.Count);
                    Console.WriteLine("ФИО: {0}; Оценка: {1}", students[i], marking[index]);

                    Mark test_mark = new Mark();
                    test_mark.date = date;
                    test_mark.Estimation = marking[index];
                    test_mark.student = students[i];
                    //test_mark1.Print();
                    marks.Add(test_mark);

                }

            }


            marks.ForEach(p => Console.WriteLine($"" +
                $"Студент: {p.student}, Дата выставленной отметки: {p.date}, Оценка: {p.Estimation}"));

            return marks;
        }
        // Вычисление количество прогулов за месяц за период
        public static int GetCountTruancy(List<Mark> marks)
        {
            DateTime date1 = new DateTime(2022, 03, 20, 0, 0, 0);
            var Truancy = from p in marks where p.Estimation == "прогуливает" where p.date >= date1 select p;
            int count = 0;
            foreach (Mark mark in Truancy)
            {
                Console.WriteLine($"Студент: {mark.student}, Оценка: {mark.Estimation}");
                count += 1;
            }
            Console.WriteLine($"Количество прогулов: {count}");
            return count;
        }
        // Вычисление количество пропусков по болезни за месяц за период
        public static int GetCountDicease(List<Mark> marks)
        {
            DateTime date1 = new DateTime(2022, 03, 25, 0, 0, 0);
            var Truancy = from p in marks where p.Estimation == "болеет" where p.date >= date1 select p;
            int count = 0;
            foreach (Mark mark in Truancy)
            {
                Console.WriteLine($"Студент: {mark.student}, Оценка: {mark.Estimation}");
                count += 1;
            }
            Console.WriteLine($"Количество болезней: {count}");
            return count;
        }
    }
}
