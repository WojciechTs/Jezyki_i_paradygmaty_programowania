let permute list =
  let rec inserts e = function
    | [] -> [[e]]
    | x::xs as list -> (e::list)::(inserts e xs |> List.map (fun xs' -> x::xs'))

  List.fold (fun accum x -> List.collect (inserts x) accum) [[]] list

let wynik = permute [12;34;132]
printfn "%A" wynik
