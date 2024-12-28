let bmi_function kg m :float= 
    let mm = m / 100.0
    kg / (mm * mm)

let bmi value =
    if value < 16.0 then printfn "wygłodzenie"
    elif value >= 16.0 && value < 17.0 then printfn "wychudzenie"
    elif value >= 16.0 && value < 17.0 then printfn "niedowaga"
    elif value >= 17.0 && value < 18.6 then printfn "waga prawidłowa"
    elif value >= 18.6 && value < 25.0 then printfn "nadwaga"
    else printfn "otyłość"

[<EntryPoint>]
let main argv =
    printfn "Oblicanie BMI"
    printfn "Podaj wagę w kg"
    let waga = System.Console.ReadLine()
    let waga_float = float waga
    printfn "Podaj wzrost w cm"
    let wzrost = System.Console.ReadLine()
    let wzrost_float = float wzrost
    let wynik = bmi_function waga_float wzrost_float
    printfn "BMI: %f" wynik
    bmi wynik
    0
