import dicom, pylab, os, sys
import matplotlib.pyplot as plt
import numpy as np
from matplotlib.backend_bases import NavigationToolbar2
from Tkinter import *
from tkFileDialog import *
from matplotlib.widgets import Button
from PIL import Image

from Umbralizacion import Umbral
from RegionCreciente import *

home = NavigationToolbar2.home
back = NavigationToolbar2.back
forward = NavigationToolbar2.forward
position = 0



def LeerArchivosDICOM():
	root = Tk()
	root.withdraw()

	filez = askdirectory(parent = root, title = 'Escoge carpeta que contenga los archivos DICOM')
	#filez = "C:\\Users\\lenovo\\Documents\\GitHub\\Trabajo-Terminal\\Ejemplos Archivos DICOM\\32370000"
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
	del auxArray
	return img

class Acciones:
    def histograma(self, event):
        print ("funciona boton histograma")
        pylab.show()

def new_home(self, *args, **kwargs):
	position = 0
	home(self, *args, **kwargs)

def new_back(self, *args, **kwargs):	
	global position	
	position -= 1
	# binarizacion = Umbral(A[position].pixel_array)
	# img = CrearImagenRGB(binarizacion)
	# pylab.imshow(img)
	# pylab.show()
	pylab.imshow(A[0].pixel_array, cmap = pylab.cm.bone)
	pylab.show()
	back(self, *args, **kwargs)

def new_forward(self, *args, **kwargs):	
	global position	
	position += 1
	# binarizacion = Umbral(A[position].pixel_array)
	
	# img = CrearImagenRGB(binarizacion)
	
	# pylab.imshow(img)
	# pylab.show()
	pylab.imshow(A[position].pixel_array, cmap = pylab.cm.bone)
	pylab.show()
	forward(self, *args, **kwargs)

NavigationToolbar2.home = new_home
NavigationToolbar2.back = new_back
NavigationToolbar2.forward = new_forward

A = LeerArchivosDICOM()

print A[0]
#binarizacion = Umbral(A[0].pixel_array)
# N = len(binarizacion)
# M = len(binarizacion[0])
# img = Image.new('RGB', (N, M))
# auxArray = []
# for i in binarizacion:
# 	for j in i:
# 		auxArray.append(j)
# img.putdata(auxArray)

#pylab.show()
#im = pylab.imshow(binarizacion, interpolation='none', aspect='auto')
#pylab.colorbar(im, orientation='horizontal')
# pylab.show()
#pylab.imshow(img)

pylab.imshow(A[0].pixel_array, cmap = pylab.cm.bone)
pylab.show()

