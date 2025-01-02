let  symbolGracza = "X"
let  symbolKomputera = "O"
let kondycjeWygranej = [[for i in 0..2->i*3];[for i in 0..2->1+i*3];[for i in 0..2->2+i*3];[0;4;8];[2;4;6]]


let miejsca = [|for i in 1 .. 9 -> " "|]

let rysowaniePlanszy () =
    printfn  " %s | %s | %s    1 | 2 | 3" miejsca.[0] miejsca.[1] miejsca.[2]
    printfn  "---+---+---  ---+---+---"
    printfn  " %s | %s | %s    4 | 5 | 6" miejsca.[3] miejsca.[4] miejsca.[5]
    printfn  "---+---+---  ---+---+---"
    printfn  " %s | %s | %s    7 | 8 | 9" miejsca.[6] miejsca.[7] miejsca.[8]

let ruchGracza () = 
    printfn "Twój ruch"
    printfn "Podaj pozyję od 1 do 9, która nie jest zajęta"
    let input = System.Console.ReadLine()
    let intinput = int input
    if intinput >= 1 && intinput <= 9 then
        if miejsca.[intinput-1] = " " then
            miejsca.[intinput-1] <- symbolGracza
            true
        else 
            false
    else
        false

let ruchKomputera() =
    let a = (new System.Random()).Next(1, 9)
    if miejsca.[a-1] = " " then
        miejsca.[a-1] <- symbolKomputera
        true
    else 
        false

let rec iterList items item = 
  match items with
  | [] -> 0
  | head::tail when head = item -> 1 + iterList tail item
  | _::tail -> iterList tail item

let wygranaGry gracz =
    let mutable  wyniczek = false
    for i in kondycjeWygranej do
        let w = [for j in i -> miejsca.[j]]
        let wynik = iterList w gracz
        if wynik = 3 then
            wyniczek <- true
    wyniczek
       

[<EntryPoint>]
let main argv =
    let mutable wygranaGracza = false
    let mutable wygranaKomputera = false
    let mutable rundy = 0
    printfn "Witaj w grze kółko krzyżyk"
    while wygranaGracza = false && wygranaKomputera = false && rundy < 9 do
        if rundy < 9 then
            let mutable rGracza = false
            while rGracza = false do
                rysowaniePlanszy()
                rGracza <- ruchGracza()
                if rGracza = false then
                    printfn "Nie prawidłowa akcja, spróbuj ponownie"
            wygranaGracza <- wygranaGry symbolGracza
            rundy <- rundy + 1
        if rundy < 9 then
            let mutable rKomp = false
            while rKomp = false do
                rKomp <- ruchKomputera()
            wygranaKomputera <- wygranaGry symbolKomputera
            rundy <- rundy + 1
    if wygranaGracza = true then
        printfn "Brawo! Wygrałeś!"
    elif wygranaKomputera = true then 
        rysowaniePlanszy()
        printfn "Tym razem wygrał komputer! :("
    else 
        rysowaniePlanszy()
        printfn "Remis!"
        
    0
