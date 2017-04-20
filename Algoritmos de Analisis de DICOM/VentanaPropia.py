# Aplicacion QT

import time # pruebas de tiempo

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

def CambiarDensidadGris(Pixeles):
	
	maxValor = -100000
	minValor = 100000
	for i in Pixeles:
		for j in i:
			maxValor = max(maxValor, int(j))
			minValor = min(minValor, int(j))
	nuevoMat = []
	size = maxValor - minValor
	for i in Pixeles:
		nuevoArr = []
		for j in i:
			x = int((255.0 / size) * j)
			nuevoArr.append(x)
		nuevoMat.append(nuevoArr)
	return nuevoMat

def CrearImagenRGBQT(Pixeles):
	N = len(Pixeles)
	M = len(Pixeles[0])
	img = QtGui.QImage(N, M, QtGui.QImage.Format_RGB888)
	for i in range(N):
		for j in range(M):
			a, b, c = Pixeles[i][j]
			img.setPixel(j, i, QtGui.qRgb(a, b, c))
	return img

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
		data = A[0]
		img = CrearImagenGrisQT(CambiarDensidadGris(data))
		self.DesplegarImagen(img)

	def DesplegarImagen(self, img):
		pic = QtGui.QLabel(self.ui.Canvas)
		qp = QtGui.QPixmap() 
		pic.setPixmap(QtGui.QPixmap(img))
		pic.show()

	def Siguiente(self):
		print("entro siguiente")
		global A, position
		# position += 1
		# img = CrearImagenGrisQT(CambiarDensidadGris(A[position]))
		img = CrearImagenRGBQT(Umbral(A[0]))
		self.DesplegarImagen(img)


	def Anterior(self):
		print("entro en anterior")
		global A, position
		pos = input("Punto de origen: ").split()
		MA = RegionCrecienteOrigen(A[0], int(pos[0]), int(pos[1]))
		#print (MA)
		#print (MA[int(pos[0])][int(pos[1])])
		MAD = CambiarDensidadGris(MA)
		#print (MAD)
		img = CrearImagenGrisQT(MAD)
		# position -= 1
		# img = CrearImagenGrisQT(CambiarDensidadGris(A[position]))
		self.DesplegarImagen(img)
	


def LeerArchivosDICOM():
	# root = Tk()
	# root.withdraw()
	#filez = askopenfilename()(parent = root, title = 'Escoge carpeta que contenga los archivos DICOM')
	filez = "C:\\Users\\lenovo\\Documents\\GitHub\\Trabajo-Terminal\\Ejemplos Archivos DICOM\\32370000"
	paths = [filez]
	A = []
	print ("La ruta de las imagenes cargadas:", filez)
	for path in paths:
		dirs = os.listdir(path)
		print (len(dirs))
		for fil in dirs:		    
			aux = path + "/" + fil 
			auxDICOM = dicom.read_file(aux)
			M = []
			for i in auxDICOM.pixel_array:
				V = []
				for j in i:
					V.append(int(j))
				M.append(V)
			A.append(M)
	return A

def MostrarHistograma(Pixeles):
	lum_img = np.array(Pixeles)
	plt.hist(lum_img.ravel(), bins = 400, range = (800, 1200), fc='k', ec='k')
	plt.show(block = False)

import subprocess


A = LeerArchivosDICOM()

# proc = subprocess.Popen("a.exe",
# stdin=subprocess.PIPE,
# stdout=subprocess.PIPE)

# state = "run"
# N = 0 #int(len(A[0]))
# M = 0 #int(len(A[0][0]))

# input = str(N) + " " + str(M)
# proc.stdin.write(input.encode('utf-8'))
# proc.stdin.flush()
# #print (input)
# for i in range(N):
# 	for j in range(M):
# 		input = str(j) + "\n"
# 		proc.stdin.write(input.encode('utf-8'))
# 		proc.stdin.flush()
# 		#print (input)
# #cppMessage = proc.stdout.readline()
# print ("acabo")
# #print ("cppreturn message ->" + cppMessage + " written by python \n")

app = QtGui.QApplication(sys.argv)
myapp = MyForm()
myapp.show()
sys.exit(app.exec())

# begin = time.time()

# end = time.time()
# print ("Total:", end - begin)
## Medir tiempos