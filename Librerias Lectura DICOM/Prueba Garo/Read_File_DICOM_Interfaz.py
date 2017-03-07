import dicom
import pylab
from matplotlib.backend_bases import NavigationToolbar2
import os, sys

def Umbralizacion(x, y, pixeles):
	nuevaPixeles = []

	for i in pixeles:
		vectorAux = []
		for j in i:
			vectorAux.append(j - 1000)
			# if j >= x + 1000 and j <= y + 1000:
			# 	vectorAux.append(1)
			# else:
			# 	vectorAux.append(0)
		nuevaPixeles.append(vectorAux)

	return nuevaPixeles

home = NavigationToolbar2.home
back = NavigationToolbar2.back
forward = NavigationToolbar2.forward

position = 0
A = []
path = "/home/alexis/Escritorio/imgDicom"
path = "/home/garo/Documents/Trabajo-Terminal/Ejemplos Archivos DICOM/Ejemplo CD DICOM"
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

binarizacion = Umbralizacion(0, 100, A[0].pixel_array)
print binarizacion
pylab.imshow(binarizacion, cmap = pylab.cm.bone)
pylab.show()
pylab.imshow(binarizacion,  cmap='RGB',  interpolation='nearest')
pylab.show()
pylab.imshow(A[0].pixel_array, cmap = pylab.cm.bone)
pylab.show()

