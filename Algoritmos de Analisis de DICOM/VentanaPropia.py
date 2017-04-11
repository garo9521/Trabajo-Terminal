import dicom, os, sys
import matplotlib.pyplot as plt
import numpy as np
from Tkinter import *
from tkFileDialog import *
from matplotlib.widgets import Button
from PIL import Image

from Umbralizacion import Umbral
from RegionCreciente import *

position = 0



def LeerArchivosDICOM():
	root = Tk()
	root.withdraw()
	filez = askdirectory(parent = root, title = 'Escoge carpeta que contenga los archivos DICOM')
	paths = [filez]
	A = []
	print "La ruta de las imagenes cargadas:", filez
	for path in paths:
		dirs = os.listdir(path)
		print len(dirs)
		for fil in dirs:		    
			aux = path + "/" + fil 
			A.append(dicom.read_file(aux))	
	return A

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
        print "funciona boton histograma"
        plt.show()

def new_home(self, *args, **kwargs):
	position = 0
	home(self, *args, **kwargs)

def new_back(self, *args, **kwargs):	
	global position	
	position -= 1
	binarizacion = Umbral(A[position].pixel_array)
	img = CrearImagenRGB(binarizacion)
	plt.imshow(img)
	plt.show()
	back(self, *args, **kwargs)

def new_forward(self, *args, **kwargs):	
	global position	
	position += 1
	binarizacion = Umbral(A[position].pixel_array)
	
	img = CrearImagenRGB(binarizacion)
	
	plt.imshow(img)
	plt.show()
	forward(self, *args, **kwargs)


A = LeerArchivosDICOM()

# lum_img = np.array(A[0].pixel_array)
# plt.hist(lum_img.ravel(), bins = 400, range = (800, 1200), fc='k', ec='k')
# plt.show(block = False)
callback = Acciones()
axprev = plt.axes([1.0, 1.0, 0.1, 0.075])
bprev = Button(axprev, 'Histograma')
bprev.on_clicked(callback.histograma)

#binarizacion = Umbral(A[0].pixel_array)
binarizacion = RegionCrecienteOrigen(A[0].pixel_array, 0, 0)
# N = len(binarizacion)
# M = len(binarizacion[0])
# img = Image.new('RGB', (N, M))
# auxArray = []
# for i in binarizacion:
# 	for j in i:
# 		auxArray.append(j)
# img.putdata(auxArray)

plt.plot(binarizacion, cmap = plt.cm.bone, lw = 2)
#plt.show()
#im = plt.imshow(binarizacion, interpolation='none', aspect='auto')
#plt.colorbar(im, orientation='horizontal')
# plt.show()
#plt.imshow(img)
#plt.imshow(A[0].pixel_array, cmap = plt.cm.bone)
plt.show()

