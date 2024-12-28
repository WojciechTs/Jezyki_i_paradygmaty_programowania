let USDToPLN money = money * 4.05
let GBPToPLN money = money * 5.12
let CHFToPLN money = money * 4.50
let EURToPLN money = money * 4.24

let PLNToUSD money = money / 4.05
let PLNToGBP money = money / 5.12
let PLNToCHF money = money / 4.50
let PLNToEUR money = money / 4.24

let konwerter kwota start endd =
    match start with
    | "USD" -> match endd with 
               | "PLN" -> USDToPLN kwota
               | "GBP" -> USDToPLN kwota |> PLNToGBP 
               | "CHF" -> USDToPLN kwota |> PLNToCHF
               | "EUR" -> USDToPLN kwota |> PLNToEUR
               | _ -> -1.0
    | "GBP" -> match endd with 
               | "PLN" -> GBPToPLN kwota
               | "USD" -> GBPToPLN kwota |> PLNToUSD 
               | "CHF" -> GBPToPLN kwota |> PLNToCHF
               | "EUR" -> GBPToPLN kwota |> PLNToEUR
               | _ -> -1.0
    | "CHF" -> match endd with 
               | "PLN" -> CHFToPLN kwota
               | "USD" -> CHFToPLN kwota |> PLNToUSD 
               | "GBP" -> CHFToPLN kwota |> PLNToGBP
               | "EUR" -> CHFToPLN kwota |> PLNToEUR
               | _ -> -1.0
    | "EUR" -> match endd with 
               | "PLN" -> EURToPLN kwota
               | "USD" -> EURToPLN kwota |> PLNToUSD 
               | "GBP" -> EURToPLN kwota |> PLNToGBP
               | "CHF" -> EURToPLN kwota |> PLNToCHF
               | _ -> -1.0
    | "PLN" -> match endd with 
               | "EUR" -> PLNToEUR kwota
               | "USD" -> PLNToUSD kwota
               | "GBP" -> PLNToGBP kwota
               | "CHF" -> PLNToCHF kwota
               | _ -> -1.0
    | _ -> -1.0

[<EntryPoint>]
let main argv =
    printfn "Konwersja walut"
    printfn "Dostępne waluty:"
    printfn "USD, GBP, CHF, EUR, PLN"
    printfn "Podaj kwotę"
    let kwota = System.Console.ReadLine()
    let kwota_f = float kwota
    printfn "Wybierz walutę źródłową"
    let start = System.Console.ReadLine()
    printfn "Wybierz walutę docelową"
    let endd = System.Console.ReadLine()
    let wynik = konwerter kwota_f start endd
    if wynik = -1.0 then printfn "Niepraidłowa nazwa waluty"
    else printfn "%s %s to %f %s" kwota start wynik endd
    0
