open System
let isPalindome (word: string) =
    let word1 = word.ToLower()
    Seq.forall (fun i -> word1.[i] = word1.[word1.Length-i-1]) {0..word1.Length-1}

[<EntryPoint>]
let main argv =
    printfn "Podaj słowo"
    let input = Console.ReadLine()
    let wynik = isPalindome input
    printfn "%b" wynik
    0
