max_waga = 70
przedmioty = [
    {"nazwa":"a","waga":10, "wartosc":60},
    {"nazwa":"b","waga":20, "wartosc":100},
    {"nazwa":"c","waga":30, "wartosc":120},
    {"nazwa":"d","waga":40, "wartosc":125},
    {"nazwa":"e","waga":50, "wartosc":129}
]


def algorytm_plecakowy_funkcyjnie(waga, przedmiotLista):

    # Base Case
    if len(przedmiotLista) == 0 or waga == 0:
        return 0, []

    if (przedmiotLista[-1]["waga"] > waga):
        return algorytm_plecakowy_funkcyjnie(waga, przedmiotLista[:-1])

    max_wartosc_1, lista_przedmiotow_1 = algorytm_plecakowy_funkcyjnie(waga - przedmiotLista[-1]["waga"], przedmiotLista[:-1])
    max_wartosc_1 += przedmiotLista[-1]["wartosc"]
    lista_przedmiotow_1.append(przedmiotLista[-1]["nazwa"])

    max_wartosc_2, lista_przedmiotow_2 = algorytm_plecakowy_funkcyjnie(waga, przedmiotLista[:-1])

    return (max_wartosc_1, lista_przedmiotow_1) if max_wartosc_1 >= max_wartosc_2 else (max_wartosc_2, lista_przedmiotow_2)


def algorytm_plecakowy_procedularnie(waga, przedmiotLista):
    dp = [0 for i in range(waga + 1)]
    lista_przedmiotow = [[] for i in range(waga + 1)]
    for i in range(1, len(przedmiotLista)+ 1):
        for w in range(waga, 0, -1):
            if przedmiotLista[i - 1]["waga"] <= w:
                if dp[w] <= dp[w - przedmiotLista[i - 1]["waga"]] + przedmiotLista[i - 1]["wartosc"]:
                    dp[w] = dp[w - przedmiotLista[i - 1]["waga"]] + przedmiotLista[i - 1]["wartosc"]
                    lista_przedmiotow[w].append(przedmiotLista[i - 1]["nazwa"])
    return dp[waga],lista_przedmiotow[waga]





print(algorytm_plecakowy_funkcyjnie(max_waga, przedmioty))
print(algorytm_plecakowy_procedularnie(max_waga,przedmioty))