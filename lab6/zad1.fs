open System


let letterCount(text: string) =
    text |> Seq.filter(fun c -> not (Char.IsWhiteSpace(c))) |> Seq.length
let wordCount (text: string) =
    text.Split([|' '; '.'; ','; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

[<EntryPoint>]
let main argv =
    printfn "Podaj tekst:"
    let input = Console.ReadLine()

    let cWord = wordCount input
    printfn "Liczba slów %i" cWord
    let cLetters = letterCount input
    printfn "Liczba znaków %i" cLetters
    
    0
