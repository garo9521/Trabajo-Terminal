import dicom, pylab, os, sys
from PyQt4 import QtGui, QtCore

from matplotlib.backends.backend_qt4agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.backends.backend_qt4agg import NavigationToolbar2QT as NavigationToolbar
import matplotlib.pyplot as plt

import random


def LeerArchivosDICOM():
	# root = Tk()
	# root.withdraw()
	# filez = askdirectory(parent = root, title = 'Escoge carpeta que contenga los archivos DICOM')
	filez = "C:\\Users\\lenovo\\Documents\\GitHub\\Trabajo-Terminal\\Ejemplos Archivos DICOM\\32370000"
	paths = [filez]
	A = []
	print ("La ruta de las imagenes cargadas:", filez)
	for path in paths:
		dirs = os.listdir(path)
		print (len(dirs))
		for fil in dirs:		    
			aux = path + "/" + fil 
			A.append(dicom.read_file(aux))	
	return A


class Window(QtGui.QDialog):
    def __init__(self, parent=None):
        super(Window, self).__init__(parent)

        # a figure instance to plot on
        self.figure = plt.figure()

        # this is the Canvas Widget that displays the `figure`
        # it takes the `figure` instance as a parameter to __init__
        self.canvas = FigureCanvas(self.figure)

        # this is the Navigation widget
        # it takes the Canvas widget and a parent
        #self.toolbar = NavigationToolbar(self.canvas, self)
        
        # Just some button connected to `plot` method
        # self.BotonAnterior = QtGui.QPushButton('Hola que hace')
        # self.BotonAnterior.resize(10, 10)
        # self.BotonAnterior.clicked.connect(self.plot)

        # set the layout
        layout = QtGui.QVBoxLayout()
        #layout.addWidget(self.toolbar)
        layout.addWidget(self.canvas)
        # layout.addWidget(self.BotonAnterior)
        self.setLayout(layout)

    def plot(self):
        ''' plot some random stuff '''
        # random data
        A = LeerArchivosDICOM()
        data = A[0].pixel_array

        # create an axis
        ax = self.figure.add_subplot(111)

        # plot data
        ax.imshow(data, cmap = plt.cm.bone)

        # refresh canvas
        self.canvas.draw()

if __name__ == '__main__':
    position = 0
    app = QtGui.QApplication(sys.argv)

    main = Window()
    main.show()

    sys.exit(app.exec_())