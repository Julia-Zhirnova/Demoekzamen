import sys

from PyQt5.QtWidgets import QWidget, QLineEdit, QPushButton, QApplication, QLabel


class Evaluator(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Вычисление выражений")
        self.setGeometry(300, 300, 370, 100)

        self.label1 = QLabel('Выражение:', self)
        self.label1.move(10, 10)
        self.label1.resize(150, 30)

        self.first_value = QLineEdit(self)
        self.first_value.move(10, 40)
        self.first_value.resize(150, 30)

        self.trick_button = QPushButton('->', self)
        self.trick_button.move(165, 40)
        self.trick_button.resize(30, 30)
        self.trick_button.clicked.connect(self.make_evaluations)

        self.label2 = QLabel('Результат:', self)
        self.label2.move(200, 10)
        self.label2.resize(150, 30)


        self.second_value = QLineEdit(self)
        self.second_value.move(200, 40)
        self.second_value.resize(150, 30)

    def make_evaluations(self):
        self.second_value.setText(str(eval(self.first_value.text())))


if __name__ == '__main__':
    app = QApplication(sys.argv)
    form = Evaluator()
    form.show()
    sys.exit(app.exec())
