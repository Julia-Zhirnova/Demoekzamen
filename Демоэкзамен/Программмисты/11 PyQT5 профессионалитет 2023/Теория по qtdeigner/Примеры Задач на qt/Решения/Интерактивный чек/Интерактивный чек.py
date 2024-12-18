import sys
from PyQt5.QtWidgets import QApplication, QMainWindow, QTableWidgetItem, QHeaderView
from ui_1 import Ui_Form
import csv


class MyWidget(QMainWindow, Ui_Form):
    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.loadTable('data.csv')
        self.tableWidget.itemChanged.connect(self.update_check)

    def loadTable(self, table_name):
        with open(table_name, encoding="utf8") as csvfile:
            reader = csv.reader(csvfile, delimiter=';', quotechar='"')
            title = next(reader)
            self.tableWidget.setColumnCount(len(title) + 1)
            # self.tableWidget.insertColumn(1)
            self.tableWidget.setHorizontalHeaderLabels(title + ["Количество"])
            header = self.tableWidget.horizontalHeader()
            header.setSectionResizeMode(0, QHeaderView.Stretch)
            self.tableWidget.setRowCount(0)
            for i, row in enumerate(reader):
                self.tableWidget.setRowCount(self.tableWidget.rowCount() + 1)
                for j, elem in enumerate(row):
                    self.tableWidget.setItem(i, j, QTableWidgetItem(elem))

    def update_check(self):
        row_count = self.tableWidget.rowCount()
        price = [int(self.tableWidget.item(i, 1).text()) if self.tableWidget.item(i, 1) is not None else 0 for i in
                 range(row_count)]
        count = [int(self.tableWidget.item(i, 2).text()) if self.tableWidget.item(i, 2) is not None else 0 for i in
                 range(row_count)]
        sum_of = 0
        for i in range(len(price)):
            sum_of += price[i] * count[i]
        self.textEdit.setText(str(sum_of))


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyWidget()
    ex.show()
    sys.exit(app.exec_())
