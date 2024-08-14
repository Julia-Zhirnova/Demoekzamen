import sys

from PyQt5.QtWidgets import QApplication, QWidget, QLineEdit, QPushButton, \
    QLCDNumber, QLabel


class MiniCalcularor(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        self.setGeometry(300, 300, 420, 140)
        self.setWindowTitle('Миникалькулятор')

        self.button = QPushButton('->', self)
        self.button.move(130, 40)
        self.button.clicked.connect(self.calculating)

        self.number_1 = QLabel('Первое чило(целое): ', self)
        self.number_1.move(10, 10)

        self.number_2 = QLabel('Второе чило(целое): ', self)
        self.number_2.move(10, 70)

        self.line = QLineEdit(self)
        self.line.move(10, 30)
        self.line.resize(100, 20)

        self.line_2 = QLineEdit(self)
        self.line_2.move(10, 85)
        self.line_2.resize(100, 20)

        self.label = QLCDNumber(self)
        self.label.move(300, 10)
        self.label.resize(100, 30)

        self.label_2 = QLCDNumber(self)
        self.label_2.move(300, 40)
        self.label_2.resize(100, 30)

        self.label_3 = QLCDNumber(self)
        self.label_3.move(300, 70)
        self.label_3.resize(100, 30)

        self.label_4 = QLCDNumber(self)
        self.label_4.move(300, 100)
        self.label_4.resize(100, 30)

        self.func = QLabel('Сумма: ', self)
        self.func.move(260, 20)

        self.func_2 = QLabel('Разность: ', self)
        self.func_2.move(245, 50)

        self.func_3 = QLabel('Произведение: ', self)
        self.func_3.move(220, 80)

        self.func_4 = QLabel('Частное: ', self)
        self.func_4.move(250, 110)

    def calculating(self):
        self.label.display(
            str(int(self.line.text()) + int(self.line_2.text())))
        self.label_2.display(
            str(int(self.line.text()) - int(self.line_2.text())))
        self.label_3.display(
            str(int(self.line.text()) * int(self.line_2.text())))
        self.label_4.display(
            f'{(int(self.line.text()) / int(self.line_2.text())):.3}' if self.line_2.text() != '0' else 'Error')


if __name__ == '__main__':
    app = QApplication(sys.argv)
    calc = MiniCalcularor()
    calc.show()
    sys.exit(app.exec())
