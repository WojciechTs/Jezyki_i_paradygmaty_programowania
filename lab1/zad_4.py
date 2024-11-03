max_waga = 70
przedmioty = [
    {"nazwa":"a","waga":10, "wartosc":60},
    {"nazwa":"b","waga":20, "wartosc":100},
    {"nazwa":"c","waga":30, "wartosc":120},
    {"nazwa":"d","waga":40, "wartosc":125},
    {"nazwa":"e","waga":50, "wartosc":129}
]


def algorytmPlecakowy(waga, przedmiotLista):

    # Base Case
    if len(przedmiotLista) == 0 or waga == 0:
        return 0, []

    if (przedmiotLista[-1]["waga"] > waga):
        return algorytmPlecakowy(waga, przedmiotLista[:-1])

    max_wartosc_1, lista_przedmiotow_1 = algorytmPlecakowy(waga - przedmiotLista[-1]["waga"], przedmiotLista[:-1])
    max_wartosc_1 += przedmiotLista[-1]["wartosc"]
    lista_przedmiotow_1.append(przedmiotLista[-1]["nazwa"])

    max_wartosc_2, lista_przedmiotow_2 = algorytmPlecakowy(waga, przedmiotLista[:-1])

    return (max_wartosc_1, lista_przedmiotow_1) if max_wartosc_1 >= max_wartosc_2 else (max_wartosc_2, lista_przedmiotow_2)

max_wartosc, lista_przedmiotow = algorytmPlecakowy(max_waga, przedmioty)
print(max_wartosc, lista_przedmiotow)