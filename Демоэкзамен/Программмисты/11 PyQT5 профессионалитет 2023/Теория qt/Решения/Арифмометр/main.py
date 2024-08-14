import sys

from PyQt5.QtWidgets import QWidget, QLineEdit, QPushButton, QLabel, QApplication


class Arifmometr(QWidget):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

        self.setWindowTitle("Арифмометр")
        self.setGeometry(300, 300, 330, 100)

        self.first_value = QLineEdit(self)
        self.first_value.setText("0")
        self.first_value.move(10, 10)
        self.first_value.resize(50, 30)

        self.second_value = QLineEdit(self)
        self.second_value.setText("0")
        self.second_value.move(150, 10)
        self.second_value.resize(50, 30)

        self.add_button = QPushButton('+', self)
        self.add_button.move(60, 10)
        self.add_button.resize(30, 30)
        self.add_button.clicked.connect(self.make_evaluations)

        self.substract_button = QPushButton('-', self)
        self.substract_button.move(90, 10)
        self.substract_button.resize(30, 30)
        self.substract_button.clicked.connect(self.make_evaluations)

        self.multiply_button = QPushButton('*', self)
        self.multiply_button.move(120, 10)
        self.multiply_button.resize(30, 30)
        self.multiply_button.clicked.connect(self.make_evaluations)

        self.label1 = QLabel('=', self)
        self.label1.move(200, 15)

        self.result = QLineEdit(self)
        self.result.move(210, 10)
        self.result.resize(50, 30)
        self.result.setDisabled(True)

    def make_evaluations(self):
        self.result.setText(str(eval(f"{self.first_value.text()}{self.sender().text()}{self.second_value.text()}")))


if __name__ == '__main__':
    app = QApplication(sys.argv)
    form = Arifmometr()
    form.show()
    sys.exit(app.exec())
