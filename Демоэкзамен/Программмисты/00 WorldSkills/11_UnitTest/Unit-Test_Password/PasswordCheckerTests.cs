using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPassword.Tests
{
    [TestClass()]
    public class PasswordCheckerTests
    {
        [TestMethod()]
        public void Check_8Symbols_ReturnsTrue()
        {
            string password = "ASDqwe12$$";
            bool expected = true;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_4Symbols_ReturnFalse()
        {
            string password = "Aq1$";
            bool expected = false;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Check_8Symbols_ReturnTrue()
        {
            string password = "ASqw12$$";
            bool expected = true;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_30Symbols_ReturnFalse()
        {
            string password = "ASDqwe123$ASDqwe123$ASDqwe123$";
            bool expected = false;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Check_Numbers_ReturnTrue()
        {
            string password = "ASDqwe123$";
            bool expected = true;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_Numbers_ReturnFalse()
        {
            string password = "ASDqweASD$";
            bool expected = false;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Check_SpecialSymbols_ReturnTrue()
        {
            string password = "Aqwe132$";
            bool expected = true;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_SpecialSymbols_ReturnFalse()
        {
            string password = "ASDqwe123";
            bool expected = false;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Check_UpperSymbols_ReturnTrue()
        {
            string password = "Aqwe123$";
            bool expected = true;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_UpperSymbols_ReturnFalse()
        {
            string password = "asdqwe123$";
            bool expected = false;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Check_LowerSymbols_ReturnTrue()
        {
            string password = "ASDqwe123$";
            bool expected = true;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_LowerSymbols_ReturnFalse()
        {
            string password = "ASDQWE123$";
            bool expected = false;

            bool actual = PasswordChecker.validatePassword(password);

            Assert.IsFalse(actual);
        }


    }

}