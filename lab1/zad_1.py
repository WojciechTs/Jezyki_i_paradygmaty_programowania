def podzial_paczek(paczki, max):
    kursy = []
    paczki_sorted = sorted(paczki, reverse= True)
    for i in paczki:
        if i > max:
            raise ValueError(f"Paczka o wadze {i} przekracza max dozwolną wagę {max}")
    for waga in paczki_sorted:
        dodano = False
        for kurs in kursy:
            if sum(kurs) + waga <= max:
                kurs.append(waga)
                dodano = True
                break
        if not dodano:
            kursy.append([waga])

    return len(kursy), kursy


wagi = [10,15,7,20,5,8,10,1,1,1,1,2,1,1,6,1,1,1,12]
max_wag = 25

print(podzial_paczek(wagi,max_wag))

licza_kursow, kursy = podzial_paczek(wagi,max_wag)

for i, kurs in enumerate(kursy,1):
    print(f"Kurs {i}: {kurs} - suma wag: {sum(kurs)} kg.")