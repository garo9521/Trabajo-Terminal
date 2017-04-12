# Aplicacion QT

import dicom, os, sys
import numpy as np
from tkinter.filedialog import *
from PIL import Image
import matplotlib.pyplot as plt
from matplotlib.backends.backend_qt4agg import FigureCanvasQTAgg as FigureCanvas

from Ventana import *
from Umbralizacion import Umbral
from RegionCreciente import *

position = 0

def EscalaGrises(x, i, j):    # Es una escala sencilla
	size = j - i + 1
	value = int((2.0 ** 8 / size) * (x - i))
	return value

def CambiarDensidadGris(Pixeles):
	maxValor = -100000
	minValor = 100000
	for i in Pixeles:
		for j in i:
			maxValor = max(maxValor, int(j))
			minValor = min(minValor, int(j))
	nuevoMat = []
	for i in Pixeles:
		nuevoArr = []
		for j in i:
			nuevoArr.append(EscalaGrises(j, minValor, maxValor))
		nuevoMat.append(nuevoArr)
	return nuevoMat

def CrearImagenRGB(Pixeles):
	global Image
	N = len(Pixeles)
	M = len(Pixeles[0])
	img = Image.new('RGB', (N, M))
	auxArray = []
	for i in Pixeles:
		for j in i:
			auxArray.append(j)
	img.putdata(auxArray)
	return img

def CrearImagenGrey(Pixeles):
	global Image
	N = len(Pixeles)
	M = len(Pixeles[0])
	img = Image.new('L', (N, M))
	auxArray = []
	for i in Pixeles:
		for j in i:
			auxArray.append(j)
	img.putdata(auxArray)
	
	return img

def CrearImagenGrisQT(Pixeles):
	N = len(Pixeles)
	M = len(Pixeles[0])
	img = QtGui.QImage(N, M, QtGui.QImage.Format_RGB888)
	for i in range(N):
		for j in range(M):
			a, b, c = Pixeles[i][j], Pixeles[i][j], Pixeles[i][j]
			img.setPixel(j, i, QtGui.qRgb(a, b, c))
	return img

class MyForm(QtGui.QMainWindow):
	def __init__(self, parent = None):
		QtGui.QWidget.__init__(self, parent)
		self.ui = Ui_MainWindow()
		self.ui.setupUi(self)
		self.ui.BotonSiguient.clicked.connect(self.Siguiente)
		self.ui.BotonAnterior.clicked.connect(self.Anterior)
		A = LeerArchivosDICOM()
		data = A[0].pixel_array
        # create an axis
		ax = self.ui.figure.add_subplot(111)

        # plot data
		ax.imshow(data, cmap = plt.cm.bone)

        # refresh canvas
		self.ui.Canvas.draw()

	def DesplegarImagen(self, img):
		pic = QtGui.QLabel(self.ui.Canvas)
		qp = QtGui.QPixmap() 
		pic.setPixmap(QtGui.QPixmap(img))
		pic.show()

	def Siguiente(self):
		print("entro siguiente")
		global A, position
		position += 1
		img = CrearImagenGrisQT(CambiarDensidadGris(A[position].pixel_array))
		self.DesplegarImagen(img)


	def Anterior(self):
		print("entro en anterior")
		global A, position
		position -= 1
		img = CrearImagenGrisQT(CambiarDensidadGris(A[position].pixel_array))
		self.DesplegarImagen(img)
	


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

def MostrarHistograma(Pixeles):
	lum_img = np.array(Pixeles)
	plt.hist(lum_img.ravel(), bins = 400, range = (800, 1200), fc='k', ec='k')
	plt.show(block = False)
	print (lum_img)


A = LeerArchivosDICOM()

app = QtGui.QApplication(sys.argv)
myapp = MyForm()
myapp.show()
sys.exit(app.exec())