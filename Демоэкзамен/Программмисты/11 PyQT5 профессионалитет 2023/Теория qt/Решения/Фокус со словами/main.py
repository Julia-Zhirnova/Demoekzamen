import sys

from PyQt5.QtWidgets import QWidget, QLineEdit, QPushButton, QApplication


class WordTrick(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Фокус со словами")
        self.setGeometry(300, 300, 370, 50)

        self.first_value = QLineEdit(self)
        self.first_value.move(10, 10)
        self.first_value.resize(150, 30)

        self.trick_button = QPushButton('->', self)
        self.trick_button.move(165, 10)
        self.trick_button.resize(30, 30)
        self.trick_button.clicked.connect(self.make_trick)

        self.left_to_right = True

        self.second_value = QLineEdit(self)
        self.second_value.move(200, 10)
        self.second_value.resize(150, 30)

    def make_trick(self):
        if self.left_to_right:
            self.second_value.setText(self.first_value.text())
            self.left_to_right = False
            self.first_value.setText('')
            self.trick_button.setText('<-')
        else:
            self.first_value.setText(self.second_value.text())
            self.left_to_right = True
            self.second_value.setText('')
            self.trick_button.setText('->')


if __name__ == '__main__':
    app = QApplication(sys.argv)
    wt = WordTrick()
    wt.show()
    sys.exit(app.exec())
