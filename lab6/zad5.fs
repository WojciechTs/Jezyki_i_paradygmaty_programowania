let loungestWord (strings: string) = 
    let newstring = strings.Replace(",","")
    newstring.Split([|' '|])
    |> Seq.sortBy (fun (x : string) -> -x.Length)
    |> Seq.toList
    |> List.head

let letterCounting (strings: string)=
    let newstring = strings.Replace(" ","")
    newstring |> Seq.length

[<EntryPoint>]
let main argv =

    printfn "Podaj tekst"
    let input = System.Console.ReadLine()
    let slowo = loungestWord input
    let dlugosc = letterCounting slowo
    printfn "Najdłusze słowo to %s, a jego długość to %i" slowo dlugosc
    
    0
