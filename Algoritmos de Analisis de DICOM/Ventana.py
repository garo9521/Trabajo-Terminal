# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'Ventana.ui'
#
# Created by: PyQt4 UI code generator 4.11.4
#
# WARNING! All changes made in this file will be lost!

from matplotlib.backends.backend_qt4agg import FigureCanvasQTAgg as FigureCanvas
import matplotlib.pyplot as plt
from PyQt4 import QtCore, QtGui

try:
    _fromUtf8 = QtCore.QString.fromUtf8
except AttributeError:
    def _fromUtf8(s):
        return s

try:
    _encoding = QtGui.QApplication.UnicodeUTF8
    def _translate(context, text, disambig):
        return QtGui.QApplication.translate(context, text, disambig, _encoding)
except AttributeError:
    def _translate(context, text, disambig):
        return QtGui.QApplication.translate(context, text, disambig)

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName(_fromUtf8("MainWindow"))
        MainWindow.resize(900, 650)
        self.centralwidget = QtGui.QWidget(MainWindow)
        self.centralwidget.setObjectName(_fromUtf8("centralwidget"))
        self.figure = plt.figure()
        self.Canvas = FigureCanvas(self.figure)
        self.Canvas.setGeometry(QtCore.QRect(10, 10, 700, 550))
        self.Canvas.setObjectName(_fromUtf8("Canvas"))
        self.BotonAnterior = QtGui.QPushButton(self.centralwidget)
        self.BotonAnterior.setGeometry(QtCore.QRect(30, 580, 80, 40))
        self.BotonAnterior.setObjectName(_fromUtf8("BotonAnterior"))
        self.BotonSiguient = QtGui.QPushButton(self.centralwidget)
        self.BotonSiguient.setGeometry(QtCore.QRect(130, 580, 80, 40))
        self.BotonSiguient.setObjectName(_fromUtf8("BotonSiguient"))
        self.CerrarTodo = QtGui.QPushButton(self.centralwidget)
        self.CerrarTodo.setGeometry(QtCore.QRect(240, 580, 80, 40))
        self.CerrarTodo.setObjectName(_fromUtf8("CerrarTodo"))
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtGui.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 804, 21))
        self.menubar.setObjectName(_fromUtf8("menubar"))
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtGui.QStatusBar(MainWindow)
        self.statusbar.setObjectName(_fromUtf8("statusbar"))
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow", None))
        self.BotonAnterior.setText(_translate("MainWindow", "Anterior", None))
        self.BotonSiguient.setText(_translate("MainWindow", "Siguiente", None))
        self.CerrarTodo.setText(_translate("MainWindow", "Cerrar todo", None))

