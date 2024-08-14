import sys

from PyQt5.QtWidgets import QApplication, QMainWindow

from design import Ui_Form


class MyNotes(QMainWindow, Ui_Form):
    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.pushButton.clicked.connect(self.addContact)

    def addContact(self):
        self.Phones.addItem("{} {}".format(self.Name.text(), self.Contact.text()))


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyNotes()
    ex.show()
    sys.exit(app.exec_())
