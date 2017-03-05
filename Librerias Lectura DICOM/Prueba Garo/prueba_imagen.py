from PIL import Image

img = Image.open("images.jpg")
a = list(img.getdata())
print a
img.show()
img.save('image.png')