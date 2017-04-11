Colores = {'azul' : (0, 0, 255),
		   'rojo' : (239, 9, 9),
		   'amarillo' : (239, 235, 9),
		   'naranja' : (239, 174, 9),
		   'morado' : (185, 9, 239),
		   'verde' : (44, 239, 9),
		   'crema' : (255, 255, 191),
		   'gris' : (171, 171, 171),
		   'rosa' : (247, 191, 190),
		   'negro' : (0, 0, 0) }

				   #Escala de Hounsfield
RangoHouns = { (-1000, -899) : 'gris',  		# aire
		  (-900, -500)  : 'rosa',   	# pulmones
		  (-5, 5) 		: 'azul',       # agua
          (-100, -80) 	: 'amarillo',  	# grasa
          (250, 2000) 	: 'crema',   	# hueso compacto
          (100, 230)   	: 'naranja',	# hueso esponjoso
		  (10, 90)		: 'rojo'		# organos
}


def EscalaGrises(x):    # Es una escala sencilla
	value = int((2.0 ** 8 / 2000.0) * x)
	value = min(255, value)
	value = max(0, value) 
	return value

def Umbral(originalPix):
	nuevoPix = []
	global RangoHouns
	for i in originalPix:
		auxV = []
		for j in i:
			j -= 1000
			a = EscalaGrises(j + 10000)
			color = (a, a, a)
			for k in RangoHouns:
				if k[0] <= j and k[1] >= j:
					color = Colores[RangoHouns[k]]
					break
			auxV.append(color)
		nuevoPix.append(auxV)

	return nuevoPix
