let checkForValue (str : string) commandList =
    let commands = Set.ofList commandList
    str.Split(' ') |> Seq.exists (fun x -> Set.contains x commands)

[<EntryPoint>]
let main argv =

    printfn "Podaj tekst"
    let input = System.Console.ReadLine()
    printfn "Podaj szukane słowo"
    let input1 = System.Console.ReadLine()
    let word = input1.Split(" ") |> Seq.toList
    let wynik = checkForValue input word
    if wynik = true then
        printfn "Słowo %s istnieje w tekscie" input1
        printfn "Podaj nowe słowo"
        let input2 = System.Console.ReadLine()
        let wynik1 = input.Replace (input1, input2)
        printfn "Zmodyfikownay tekst"
        printfn "%s" wynik1
    else
        printfn "Słowo %s nie istnieje w tekscie" input1
    0

