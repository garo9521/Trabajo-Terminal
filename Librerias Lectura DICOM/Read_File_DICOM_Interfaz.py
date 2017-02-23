import dicom
import pylab
from matplotlib.backend_bases import NavigationToolbar2
import os, sys

home = NavigationToolbar2.home
back = NavigationToolbar2.back
forward = NavigationToolbar2.forward

position = 0
A = []
path = "/home/alexis/Escritorio/imgDicom"

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

for i in range (10):
	pylab.imshow(A[0].pixel_array, cmap=pylab.cm.bone)
pylab.show()

