
lista = [
    [1,10,10],[2,5,10],[3,10,5],[4,7,8],[5,3,4],[6,3,7],[7,3,5],[8,5,5] # [numer zadania, czas, nagroda]
]

def sort_zadania_funkcyjne(lista_zadan):
    return sorted(lista_zadan,key = lambda x: (x[1],-x[2]))

def sort_zadania_proceduralnie(lista_zadan):
    for x in range(0, len(lista_zadan)):
        for y in range(x + 1, len(lista_zadan)):
            if lista_zadan[x][1] >= lista_zadan[y][1]:
                lista_zadan[x], lista_zadan[y] = lista_zadan[y], lista_zadan[x]
    for x in range(0, len(lista_zadan)):
        for y in range(x + 1, len(lista_zadan)):
            if lista_zadan[x][1] == lista_zadan[y][1] and lista_zadan[x][2] <= lista_zadan[y][2]:
                lista_zadan[x], lista_zadan[y] = lista_zadan[y], lista_zadan[x]
    return lista_zadan



print("Funkcyjnie")
for i in sort_zadania_funkcyjne(lista):
    print(f"Zadanie {i[0]}, czas: {i[1]}, nagroda: {i[2]}")
print("")
print("Procedularnie")
for i in sort_zadania_proceduralnie(lista):
    print(f"Zadanie {i[0]}, czas: {i[1]}, nagroda: {i[2]}")