from collections import deque
#Movimiento de 4
movs4 = [(0, 1),
        (0, -1),
        (1, 0),
        (-1, 0)]

def RegionCrecienteOrigen(Pixeles, y, x):
    Epsilon = int(input("Error de transicion: "))
    N = len(Pixeles)
    M = len(Pixeles[0])
    cola = deque([(y, x)])
    
    RegionNueva = [[0 for i in range(M)] for j in range(N)]
    valor = int(Pixeles[y][x])
    while cola:
        y, x = cola.popleft()
        for addY, addX in movs4:
            yy = y + addY
            xx = x + addX
            if yy < 0 or xx < 0 or yy == N or xx == M:
                continue
            if RegionNueva[yy][xx] == 1:
                continue
            diff = valor - int(Pixeles[yy][xx])
            if diff < 0:
                diff *= -1
            if diff > Epsilon:
                continue

            RegionNueva[yy][xx] = 1
            cola.append((yy, xx))

    return RegionNueva    



def RegionCrecienteVecinos(Pixeles, PuntosIniciales):
    Epsilon = int(raw_input("Error de transicion: "))
    N = len(Pixeles)
    M = len(Pixeles[0])
    cola = deque([])
    for i in PuntosIniciales:
        cola.append(i)
    RegionNueva = [[0 for i in range(M)] for j in range(N)]

    while cola:
        y, x = cola.popleft()
        valor = int(Pixeles[y][x])
        for addY, addX in movs4:
            yy = y + addY
            xx = x + addX
            if yy < 0 or xx < 0 or yy == N or xx == M:
                continue
            if RegionNueva[yy][xx] == 1:
                continue
            diff = valor - int(Pixeles[yy][xx])
        
            if diff < 0:
                diff *= -1
            if diff > Epsilon:
                continue

            RegionNueva[yy][xx] = 1
            cola.append((yy, xx))

    return RegionNueva    

