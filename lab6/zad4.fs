[<EntryPoint>]
let main argv =
    while 1=1 do
        printfn "Podaj tekst w formacie: imię; nazwisko; wiek"
        let input = System.Console.ReadLine()
        let list = input.Split("; ") |> Seq.toList
        printfn "%s, %s %s lat" list.Tail.Head list.Head list.Tail.Tail.Head
    0
