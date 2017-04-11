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

Rango = { (-1000, -899) : 'gris',  		# aire
		  (-900, -500)  : 'rosa',   	# pulmones
		  (-5, 5) 		: 'azul',       # agua
          (-100, -80) 	: 'amarillo',  	# grasa
          (250, 2000) 	: 'crema',   	# hueso compacto
          (100, 230)   	: 'naranja',	# hueso esponjoso
		  (10, 90)		: 'rojo'		# organos
}

def Umbralizacion(rango, originalPix):
	nuevaPix = []

	for i in originalPix:
		auxV = []
		for j in i:
			j -= 1000
			a = EscalaGrises(j + 10000)
			color = (a, a, a)
			for k in rango:
				if k[0] <= j and k[1] >= j:
					color = Colores[rango[k]]
					break
			auxV.append(color)
		nuevaPix.append(auxV)

	return nuevaPixeles
