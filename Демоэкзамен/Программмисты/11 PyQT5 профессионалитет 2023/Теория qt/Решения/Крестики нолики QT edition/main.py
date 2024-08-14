from PyQt5.QtWidgets import QApplication, QWidget, QPushButton, QLineEdit, QLabel, QRadioButton
from PyQt5.QtGui import QPixmap
import sys


class XOIterator:
    ## Итератор, генерирующий крестик или нолик. По очереди
    def __init__(self, init='X'):
        if init == "X":
            self.status = True
        else:
            self.status = False

    def __next__(self):
        self.status = not self.status
        if self.status:
            return "O"
        else:
            return "X"


class TicTacToe(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()
        self.grid = []
        self.xo = XOIterator()

    def initUI(self):
        self.setGeometry(400, 400, 350, 400)
        self.setWindowTitle('Крестики-нолики')

        ## Создание матрицы кнопок, поля.
        self.button_grid = [[QPushButton(self) for i in range(3)] for i in range(3)]

        ## Поле для вывода результата
        self.result = QLabel(self)
        self.result.move(100, 300)
        self.result.setFixedWidth(200)

        ## RadioButton, для выбора первого хода
        self.x = QRadioButton(self)
        self.x.setText("X")
        self.x.move(120, 20)
        self.x.setChecked(True)
        self.x.clicked.connect(self.run2)

        self.y = QRadioButton(self)
        self.y.setText("O")
        self.y.move(160, 20)
        self.y.clicked.connect(self.run2)

        ## Кнопка, очищающая поле
        self.clear = QPushButton(self)
        self.clear.setText("Новая игра")
        self.clear.move(100, 350)
        self.clear.clicked.connect(self.run2)

        ## Размещение поля на экране
        for i in range(len(self.button_grid)):
            for j in range(len(self.button_grid[i])):
                self.button_grid[i][j].move(65 * (i + 1), 65 * (j + 1))
                self.button_grid[i][j].resize(60, 60)
                self.button_grid[i][j].clicked.connect(self.run)

    ## Возвращает все возможные наборы (вертикали, горизонтали и диагонали)
    def all_path(self):
        res = [[i[0] for i in self.grid]]
        res += [[i[1] for i in self.grid]]
        res += [[i[2] for i in self.grid]]
        res += [i for i in self.grid]
        res += [[self.grid[k][k] for k in range(3)]]
        res += [[self.grid[k][2 - k] for k in range(3)]]
        return res


    ## Проверяет, выиграл ли кто-то или произошла ли ничья
    def check_stat(self):
        for i in self.all_path():
            if (set(i) == set('X')) or (set(i) == set('O')):
                self.result.setText("Выиграл {}!".format(i[0]))
                for line in self.button_grid:
                    for btn in line:
                        btn:QPushButton = btn
                        btn.setDisabled(True)
        if self.check_all():
            self.result.setText("Ничья!".format(i[0]))

    ## Выбор первого игрока и очистка поля.
    def run2(self):
        self.xo = XOIterator('X' if self.x.isChecked() else 'Y')
        for line in self.button_grid:
            for btn in line:
                btn.setText("")
                btn.setDisabled(False)
        self.result.setText("")

    ## Ход. Нажатие на кнопку.
    def run(self):
        if (self.sender().text() == ''):
            self.sender().setText(next(self.xo))
            self.grid = [[s.text() for s in i] for i in self.button_grid]
            self.check_stat()

    ## Проверяет, есть ли пустые поля
    def check_all(self):
        for i in self.grid:
            if '' in i:
                return False
        return True


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ttt = TicTacToe()
    ttt.show()
    sys.exit(app.exec())
