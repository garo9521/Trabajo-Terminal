import dicom
import pylab
from matplotlib.backend_bases import NavigationToolbar2
import os, sys
from PIL import Image
import numpy as np

def HexToDec(x):
	return int(x, 16)

Colores = {'azul' : (HexToDec('00'), HexToDec('00'), HexToDec('ff')),
		   'rojo' : (239, 9, 9),
		   'amarillo' : (239, 235, 9),
		   'naranja' : (239, 174, 9),
		   'morado' : (185, 9, 239),
		   'verde' : (44, 239, 9),
		   'negro' : (0, 0, 0)
		  }


def EscalaGrises(x):
	value = int((2.0 ** 8 / 2000.0) * x)
	value = min(255, value)
	value = max(0, value) 
	return value

def Umbralizacion(x, y, pixeles):
	nuevaPixeles = []

	for i in pixeles:
		vectorAux = []
		for j in i:
			if j >= x + 1000 and j <= y + 1000:
				
				vectorAux.append(Colores['azul'])
			elif j >= 0 and j <= 900:
				vectorAux.append(Colores['morado'])
			else:
				a = EscalaGrises(j)
				vectorAux.append((a, a, a))
		nuevaPixeles.append(vectorAux)

	return nuevaPixeles

home = NavigationToolbar2.home
back = NavigationToolbar2.back
forward = NavigationToolbar2.forward

position = 0
A = []
path = "C:\\Users\\lenovo\\Documents\\GitHub\\Trabajo-Terminal\\Ejemplos Archivos DICOM\\Ejemplo CD DICOM"   # Ruta Windows
#path = "/home/garo/Documents/Trabajo-Terminal/Ejemplos Archivos DICOM/Ejemplo CD DICOM"  # Ruta Ubuntu
print path

def new_home(self, *args, **kwargs):
	print 'chosto'
	home(self, *args, **kwargs)

def new_back(self, *args, **kwargs):	
	global position	
	position -= 1
	pylab.imshow(A[position].pixel_array, cmap=pylab.cm.bone)
	pylab.show()
	back(self, *args, **kwargs)

def new_forward(self, *args, **kwargs):	
	global position	
	position += 1
	pylab.imshow(A[position].pixel_array, cmap=pylab.cm.bone)
	pylab.show()
	forward(self, *args, **kwargs)

NavigationToolbar2.home = new_home
NavigationToolbar2.back = new_back
NavigationToolbar2.forward = new_forward

dirs = os.listdir(path)

for fil in dirs:		    
	aux = path + "/" + fil 
	A.append(dicom.read_file(aux))	

binarizacion = Umbralizacion(0, 900, A[0].pixel_array)
N = len(binarizacion)
M = len(binarizacion[0])
img = Image.new('RGB', (N, M))
auxArray = []
for i in binarizacion:
	for j in i:
		auxArray.append(j)
img.putdata(auxArray)
img.save('myimg.png')

# pylab.imshow(binarizacion, cmap = pylab.cm.bone)
#pylab.show()
#im = pylab.imshow(binarizacion, interpolation='none', aspect='auto')
#pylab.colorbar(im, orientation='horizontal')
# pylab.show()
pylab.imshow(img)
#pylab.imshow(A[0].pixel_array, cmap = pylab.cm.bone)
pylab.show()

