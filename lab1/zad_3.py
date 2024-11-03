
lista = [
    [1,10,10],[2,5,10],[3,10,5] # [numer zadania, czas, nagroda]
]

def sort_zadania(lista_zadan):
    return sorted(lista_zadan,key = lambda x: (x[1],x[2]))

posortowana_lista = sort_zadania(lista)
for i in posortowana_lista:
    print(f"Zadanie {i[0]}, czas: {i[1]}, nagroda: {i[2]}")