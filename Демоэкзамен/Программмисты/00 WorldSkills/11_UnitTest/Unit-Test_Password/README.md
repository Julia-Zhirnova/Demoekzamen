## Unit-Test

**Тестовые данные:**
| Требование | Пароль | Результат |
|------------|--------|-----------|
| 1. Корректный пароль | ASDqwe123$ | True |
| 2. Кол-во символов (от 8 до 20) | Aq1$<br>ASqw12$$<br>ASDqwe123$ASDqwe123$ASDqwe123$ | False<br>True<br>False<br> |
| 3. Наличие цифр | ASDqwe123$<br>ASDqweASD$ | True<br>False |
| 4. Наличие спецсимволов (#$%^&\_)| Aqwe132$<br>ASDqwe123 | True<br>False |
| 5. Наличие прописных букв | Aqwe123$<br>asdqwe123$ | True<br>False |
| 6. Наличие строчных букв | ASDqwe123$<br>ASDQWE123$ | True<br>False |

<br />

**Процесс выполнения:**
1. Создать проект > `Библиотека классов (.NET Framework)`

2. В файле `Class1.cs` написан код.

3. Нажать ПКМ влюбой части кода и выбрать `Создание модульных тестов` > нажать Ок

5. В открывшемся файле `PasswordCheckerTests.cs` написать проверку для всех пунктов таблицы `Тестовые данные`:
    ```c#
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
    ```

6. Запустить тесты (Верхнее меню > Тест > Запуск всех тестов)

<br />

**Результат:**
![img](https://github.com/MeoW-2020-2/Unit-Test/blob/main/Result.png "Результать выполненных тестов")
