import re
stop_words= ["i","o","a","z","w","u"]
def analiza_tekstu(tekst):
    slowa = tekst.strip().split(" ")
    numSl = len(slowa)
    #zdania = tekst.strip().split(".")
    zdanie = re.split(r'[.!?]',tekst)
    numZd = len([s for s in zdanie if s.strip()])
    paragraf = tekst.strip().split("\n")
    numPa = len(paragraf)

    filter_slowa = list(filter(lambda slowo: slowo not in stop_words,slowa))
    numfilter_slowa = len(filter_slowa)
    print("Liczba pargrafów:", numPa)
    print("Liczba zdań:", numZd)
    print("Liczba słów:", numfilter_slowa)


tekst = """Pancerniki typu Kaiser Friedrich III – niemieckie pancerniki z przełomu XIX i XX wieku. Okręty miały wyporność 11 097 ton i osiągały prędkość ponad 17 węzłów, ich główne uzbrojenie stanowiły cztery działa kalibru 24 cm umieszczone w dwóch wieżach. W latach 1896–1902 w stoczniach Kaiserliche Werft, Germaniawerft, Schichau oraz Blohm & Voss zbudowano pięć okrętów tego typu, które otrzymały nazwy upamiętniające niemieckich władców. Załoga pojedynczej jednostki składała się z 39 oficerów oraz 612 podoficerów i marynarzy. W przypadku pełnienia funkcji okrętu flagowego liczebność załogi zwiększała się o 63–75 osób, z czego 12 stanowili oficerowie. Pancerniki zostały wcielone do służby w Kaiserliche Marine w latach 1898–1902. 
Służyły w Heimatflotte oraz w Hochseeflotte, biorąc ograniczony udział w I wojnie światowej. 
"""

analiza_tekstu(tekst)

