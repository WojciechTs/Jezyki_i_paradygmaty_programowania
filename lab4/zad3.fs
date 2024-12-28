let strings = "one, two, one, three, four, one, two, four, one   five"
let wordsCounting (strings: string) = 
    let newstring = strings.Replace(",","")
    newstring.Split([|' '|])
    |> Seq.length

let letterCounting (strings: string)=
    let newstring = strings.Replace(" ","")
    newstring |> Seq.length
  
let popularWord (strings: string) = 
    let newstring = strings.Replace(",","")
    newstring.Split([|' '|])
    |> Seq.countBy id 
    |> Seq.toList
    |> Seq.sortBy (fun (_,x)-> -x)
    |> Seq.head
    |> fst
    

let w = wordsCounting(strings)
printfn "Liczba słów: %i" w
let s = letterCounting(strings)
printfn "Liczba znaków bez spacji: %i" w
let z = popularWord strings
printfn "Najczęściej występujące słowo: %A" z
