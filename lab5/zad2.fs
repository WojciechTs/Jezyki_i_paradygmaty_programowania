type BinaryTree<'T> = 
    | Empty
    | Node of 'T * BinaryTree<'T> * BinaryTree<'T>

let myTree = 
    Node(10,
        Node(5,Node(2,Empty,Empty), Node(7,Empty,Empty)),
        Node(15, Node(12,Empty,Empty),Node(20,Empty,Empty)))

let rec searchTreeValue tree value =
    match tree with
    | Empty -> false
    | Node(v,left,right) ->
        if v = value then true
        elif searchTreeValue left value then true
        else searchTreeValue right value 

let found = searchTreeValue myTree 20
printfn "Wynik %b" found


let rec searchTreeValueIter tree value =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: rest -> loop rest
        | Node(v,left,right) :: rest ->
            if v = value then true
            else loop (left :: right :: rest)
