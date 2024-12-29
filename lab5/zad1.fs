let rec fibonaci n =
    if n<=0 then 0
    elif n = 1 then 1
    else fibonaci (n-1) + fibonaci (n-2)


let wynik = fibonaci 10
printfn "Wynik %d" wynik

let fib n = 
    let rec aux n a b =
        if n<=0 then a
        elif n = 1 then b
        else aux (n-1) b (a + b)
    aux n 0 1

let wynik1 = fib 10
printfn "Wynik %d" wynik1
