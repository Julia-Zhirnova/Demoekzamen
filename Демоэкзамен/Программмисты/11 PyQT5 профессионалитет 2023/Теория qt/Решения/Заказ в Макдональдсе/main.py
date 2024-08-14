import sys

from PyQt5.QtWidgets import QApplication, QWidget, QPushButton, QCheckBox, QPlainTextEdit


class MacOrder(QWidget):
    def __init__(self):
        super().__init__()
        ##Список блюд, доступных в меню
        self.menu = ["Чизбургер", "Гамбургер", "Кока-кола", "Нагетсы"]
        self.initUI()

    def initUI(self):
        self.setGeometry(400, 300, 370, 400)
        self.setWindowTitle('Заказ в Макдональдсе')

        ## Создание массива чекбоксов, отвечающих за каждый из блюд меню
        self.check_b = [QCheckBox(self) for i in self.menu]

        ## Кнопка "Заказать"
        self.btn = QPushButton('Заказать', self)
        self.btn.clicked.connect(self.run)
        ## Расположение кнопки зависит от количества блюд в меню
        self.btn.move(10, 20 * (len(self.check_b) + 1))

        ## Размещение чекбоксов на экране
        for i in range(len(self.check_b)):
            self.check_b[i].setText(self.menu[i])
            self.check_b[i].move(10, 20 * i)

        ## Размещение поля для вывода заказа на экране
        self.result = QPlainTextEdit(self)
        self.result.setEnabled(False)
        self.result.move(10, 20 * (len(self.check_b) + 3))

    def run(self):
        self.result.clear()
        ## Проверяем, какие из блюд выбраны
        result = [i.text() for i in self.check_b if i.isChecked()]
        result.insert(0, "Ваш заказ:\n")

        ## Отображаем заказ на экране
        self.result.appendPlainText("\n".join(result))


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MacOrder()
    ex.show()
    sys.exit(app.exec())
