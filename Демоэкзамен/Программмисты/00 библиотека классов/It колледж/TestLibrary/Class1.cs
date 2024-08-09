using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLibrary
{
    public static class Program
    {
        static public string GetStudNumber(int year, int group, string fio)
        {

            string[] init = fio.Split(' ');
            string i = init[0];
            string i2 = init[1];
            string i3 = init[2];
            char a = i[0];
            char b = i2[0];
            char c = i3[0];
            string studDescription = year + "." + group + "." + a + b + c;
            return studDescription;
        }



        public static List<Mark> GetMarks(DateTime now, List<string> students)
        {
            List<Mark> res = new List<Mark>();
            Random rnd = new Random();
            string d = "";
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    string[] bcv = { "Б", "П", "У", "2", "3", "4", "5" };
                    int value = rnd.Next(bcv.Length);
                    Mark mark = new Mark();
                    mark.date = now.AddDays(i);
                    mark.progul = bcv[value];
                    res.Add(mark);
                    d += Convert.ToString(res);

                }


                Console.WriteLine(students[0]);
                Console.WriteLine(GetCountDisease(res));
                Console.WriteLine(GetCountTruancy(res));
                res.ForEach(p => Console.WriteLine($"{p.date}, {p.progul} "));
            }
            

            /*List<Mark> res1 = new List<Mark>();
            for (int i = 0; i < 10; i++)
            {
                string[] bcv = { "Б", "П", "У", "2", "3", "4", "5" };
                int value = rnd.Next(bcv.Length);
                Mark mark1 = new Mark();
                mark1.date = now.AddDays(i);
                mark1.progul = bcv[value];
                res1.Add(mark1);
            }



            Console.WriteLine(students[1]);
            Console.WriteLine(GetCountDisease(res1));
            Console.WriteLine(GetCountTruancy(res1));
            res1.ForEach(p => Console.WriteLine($"{p.date}, {p.progul} "));

            List<Mark> res2 = new List<Mark>();

            for (int i = 0; i < 10; i++)
            {
                string[] bcv = { "Б", "П", "У", "2", "3", "4", "5" };
                int value = rnd.Next(bcv.Length);
                Mark mark2 = new Mark();
                mark2.date = now.AddDays(i);
                mark2.progul = bcv[value];
                res2.Add(mark2);
            }


            *//*for (int j = 0; j < 3; j++)
            {*//*
            Console.WriteLine(students[2]);
            Console.WriteLine(GetCountDisease(res2));
            Console.WriteLine(GetCountTruancy(res2));
            res2.ForEach(p => Console.WriteLine($"{p.date}, {p.progul} "));
            *//* }*/

            return  res;
        }


        public static int GetCountDisease(List<Mark> marks)
        {

            var Bol = from p in marks
                      where p.progul == "Б"
                      select p;
            int count = 0;
            foreach (Mark mark in Bol)
            {
                count++;
            }

            return count;
        }

        public static int GetCountTruancy(List<Mark> marks)
        {

            var Prog = from p in marks
                       where p.progul == "П"
                       select p;
            int count = 0;
            foreach (Mark mark in Prog)
            {
                count++;
            }

            return count;

        }
        public class Students
        {
            public int grupa;
            public int god;
            public string FIO;

        }
        public class Mark
        {
            public DateTime date;
            public string progul;
        }


    }
}