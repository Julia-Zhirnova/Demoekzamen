using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static TestLibrary.Program;

namespace TestNaStudent
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Students students1 = new Students();
            Students students2 = new Students();
            Students students3 = new Students();
            students1.grupa = 195;
            students1.god = 2000;
            students1.FIO = "Mustafa Alibekov Magomedeminovich";
            students2.FIO = "Denis Karabchikov Viktirovich";
            students3.FIO = "Merinov Dmitry Aleksandrovich";
            DateTime now = DateTime.Now;
            List<string> students = new List<string>();
            students.Add(students1.FIO);
            students.Add(students2.FIO);
            students.Add(students3.FIO);
            students2.grupa = 195;
            students2.god = 2000;
            List<Mark> a = GetMarks(now, students);
            int testCount = -1;
            int testCount2 = 11;
            bool testBoolIsTrue = true;
            bool BoolCountTest;

            //Act   
             int count =   GetCountDisease(a);
            if (count < testCount || count > testCount2)
            {
                BoolCountTest = false;
            }
            else
            {
               BoolCountTest = true;
            }
            //Assert
            Assert.AreEqual(testBoolIsTrue, BoolCountTest);
        }
        [TestMethod]
        public void TestMethodGetStudNumberReturnTrue()
        {
            //Arrange
            Students students1 = new Students();
            Students students2 = new Students();
            Students students3 = new Students();
            students1.grupa = 195;
            students1.god = 2000;
            students1.FIO = "Mustafa Alibekov Magomedeminovich";
            students2.FIO = "Denis Karabchikov Viktirovich";
            students3.FIO = "Merinov Dmitry Aleksandrovich";
            DateTime now = DateTime.Now;
            List<string> students = new List<string>();
            students.Add(students1.FIO);
            students.Add(students2.FIO);
            students.Add(students3.FIO);
            students2.grupa = 195;
            students2.god = 2000;
            string GetStudN = "2004.195.MAM";
            //Act
            string a = GetStudNumber(2004, 195, students1.FIO);
            //Assert
            Assert.AreEqual(GetStudN, a);
        }

        [TestMethod]
        public void TestMethodGetStudNumberReturnFAlls()
        {
            //Arrange
            Students students1 = new Students();
            Students students2 = new Students();
            Students students3 = new Students();
            students1.grupa = 195;
            students1.god = 2000;
            students1.FIO = "Mustafa Alibekov Magomedeminovich";
            students2.FIO = "Denis Karabchikov Viktirovich";
            students3.FIO = "Merinov Dmitry Aleksandrovich";
            DateTime now = DateTime.Now;
            List<string> students = new List<string>();
            students.Add(students1.FIO);
            students.Add(students2.FIO);
            students.Add(students3.FIO);
            students2.grupa = 195;
            students2.god = 2000;
            string GetStudN = "2003.196.DKS";
            bool TestBool;
            //Act
            string a = GetStudNumber(2004, 195, students1.FIO);
            if (GetStudN != a)
            {
                TestBool = false;
            }
            else
            {
                TestBool = true;
            }
            //Assert
            Assert.IsFalse(TestBool);
        }
    }
}
