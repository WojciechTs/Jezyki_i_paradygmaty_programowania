let mutable kontaBankowe = Map.empty.Add(1233,12313.50)

let komunikat () = 
    printfn "System bankowy"
    printfn "Dostepne operacje:"
    printfn "1 - Stwórz nowe konto"
    printfn "2 - Zdepozynuj środki na konto"
    printfn "3 - Wypłać środki z konta"
    printfn "4 - Wyświetl saldo konta"
    printfn "0 - Zakończ działanie programu"
    

let znajdzKonto konto =
    let znalezionekonto = kontaBankowe.TryFind konto
    match znalezionekonto with
    | Some x -> znalezionekonto
    | _ -> None

let stworzKonto ():string = 
    printfn "Podaj numer konta:"
    let konto1 = System.Console.ReadLine()
    let konto = int konto1
    let znalezionekonto = znajdzKonto konto
    if znalezionekonto = None then
        kontaBankowe <- Map.add konto 0.0 kontaBankowe
        let string1 = "Stworzono konto: " + string konto + " Saldo: 0.0"
        string1
    else
        "Takie konto już istanieje"

let dodajSrodki ():string =
    printfn "Podaj numer konta:"
    let konto1 = System.Console.ReadLine()
    let konto = int konto1
    let znalezionekonto = znajdzKonto konto
    if znalezionekonto <> None then
        printfn "Wielkość sumy depozytu:"
        let depo1 = System.Console.ReadLine()
        let depo = float depo1
        kontaBankowe <- Map.add konto (znalezionekonto.Value+depo) kontaBankowe
        "Operacja sie udała"
    else
        "Operacja się nie udała, takie konto nie istanieje"

let wyplacSrodki ():string = 
    printfn "Podaj numer konta:"
    let konto1 = System.Console.ReadLine()
    let konto = int konto1
    let znalezionekonto = znajdzKonto konto
    if znalezionekonto <> None then
        printfn "Wielkość wypłaconej sumy: "
        let depo1 = System.Console.ReadLine()
        let depo = float depo1
        if depo > znalezionekonto.Value then
            "Nie ma tylu srodów na koncie"
        else
            kontaBankowe <- Map.add konto (znalezionekonto.Value-depo) kontaBankowe
            "Operacja sie udała"
    else
        "Operacja się nie udała, takie konto nie istanieje"

let wyswietlKonto (): string =
    printfn "Podaj numer konta:"
    let konto1 = System.Console.ReadLine()
    let konto = int konto1
    let znalezionekonto = znajdzKonto konto
    if znalezionekonto <> None then
        let string1 = "Konto: " + string konto + " Saldo: " + string znalezionekonto.Value
        string1
    else
        "Nie ma takiego konta"

let blad (): string = "Nie znana operacja"


[<EntryPoint>]
let main argv =
    let mutable inputValue = -1
    while inputValue <> 0 do    
        komunikat ()
        let input = System.Console.ReadLine()
        inputValue <- int input
        let wynik =
            match int input with
            | 1 -> stworzKonto ()
            | 2 -> dodajSrodki ()
            | 3 -> wyplacSrodki ()
            | 4 -> wyswietlKonto ()
            | _ -> blad ()
        printfn "%s" wynik
        printfn ""
    printfn "Zakończo działanie"
    0
