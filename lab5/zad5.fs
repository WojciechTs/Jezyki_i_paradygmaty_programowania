let rec quicksort list =
   match list with
   | [] ->                            
        []                            
   | first::other ->      
        let smal =         
            other
            |> List.filter (fun e -> e < first)
            |> quicksort              
        let large =         
            other
            |> List.filter (fun e -> e >= first)
            |> quicksort              
        List.concat [smal; [first]; large]

printfn "%A" (quicksort [21;3;23;18;9;41;2])
