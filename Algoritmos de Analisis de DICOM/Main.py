import dicom, pylab, os, sys
from matplotlib.backend_bases import NavigationToolbar2
from PIL import Image

from Umbralizacion import Umbral
from RegionCreciente import *

from Tkinter import *
from tkFileDialog import *

home = NavigationToolbar2.home
back = NavigationToolbar2.back
forward = NavigationToolbar2.forward
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


def new_home(self, *args, **kwargs):
	position = 0
	home(self, *args, **kwargs)

def new_back(self, *args, **kwargs):	
	global position	
	position -= 1
	binarizacion = Umbral(A[position].pixel_array)
	img = CrearImagenRGB(binarizacion)
	pylab.imshow()
	pylab.show()
	back(self, *args, **kwargs)

def new_forward(self, *args, **kwargs):	
	global position	
	position += 1
	binarizacion = Umbral(A[position].pixel_array)
	
	img = CrearImagenRGB(binarizacion)
	
	pylab.imshow(img)
	pylab.show()
	forward(self, *args, **kwargs)

NavigationToolbar2.home = new_home
NavigationToolbar2.back = new_back
NavigationToolbar2.forward = new_forward

# # Ruta Windows
# path = "C:\\Users\\lenovo\\Documents\\GitHub\\Trabajo-Terminal\\Ejemplos Archivos DICOM\\Ejemplo CD DICOM"   

# # Ruta Ubuntu
# #path = "/home/garo/Documents/Trabajo-Terminal/Ejemplos Archivos DICOM/Ejemplo CD DICOM"  

# path = "C:\Users\lenovo\Documents\GitHub\Trabajo-Terminal\Ejemplos Archivos DICOM\\32370000"

A = LeerArchivosDICOM()

print A[0].pixel_array
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

pylab.imshow(binarizacion, cmap = pylab.cm.bone)
#pylab.show()
#im = pylab.imshow(binarizacion, interpolation='none', aspect='auto')
#pylab.colorbar(im, orientation='horizontal')
# pylab.show()
#pylab.imshow(img)
#pylab.imshow(A[0].pixel_array, cmap = pylab.cm.bone)
pylab.show()

