from collections import deque


def bfs_s(graf, start, stop ):
    kolejka = deque([[start]])
    odwiedzone = set()

    while kolejka:
        sciezka = kolejka.popleft()
        wierzcholek = sciezka[-1]

        if wierzcholek == stop:
            return sciezka

        if wierzcholek not in odwiedzone:
            for sasiad in graf.get(wierzcholek,[]):
                nowa_sciezka = list(sciezka)
                nowa_sciezka.append(sasiad)
                kolejka.append(nowa_sciezka)
            odwiedzone.add(wierzcholek)
    return None



graf = {"A": ["B","C"],
        "B":["A","D","E"],
        "C":["A","F"],
        "D":["B"],
        "E":["B","F"],
        "F":["C","E"]}


print(bfs_s(graf,"A","F"))
print(bfs_s(graf,"E","C"))