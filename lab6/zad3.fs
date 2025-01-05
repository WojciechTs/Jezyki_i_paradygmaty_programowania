let rec isSame list x =
  match list with
  | [] -> false
  | head :: tail ->
    if x = head then true else isSame tail x

let removeDuplicates list1 =
  let rec remove list1 list2 =
    match list1 with
    | [] -> list2
    | head :: tail when isSame list2 head =
        false -> remove tail (head::list2)
    | h::t -> remove t list2
  remove list1 []

let wynik = removeDuplicates ["one";"One";"one";"ala"]
printfn "%A" wynik
