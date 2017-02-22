import dicom
import pylab

ds=dicom.read_file("/home/alexis/Escritorio/my/ejemplo")
print(ds.pixel_array)
print(ds.pixel_array.shape)
pylab.imshow(ds.pixel_array, cmap=pylab.cm.bone)
pylab.show()
