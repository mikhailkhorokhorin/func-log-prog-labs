open System

let eps = 0.00001


let rec dichotomy f a b =
    let mid = (a + b) / 2.0

    if abs (f mid) < eps || (b - a) < eps then mid
    else if f a * f mid < 0.0 then dichotomy f a mid
    else dichotomy f mid b

let rec newton f df x iter =
    let nextX = x - f x / df x

    if abs (nextX - x) < eps || iter > 100 then
        nextX
    else
        newton f df nextX (iter + 1)

let rec iterations g x iter =
    let nextX = g x

    if abs (nextX - x) < eps || iter > 100 then
        nextX
    else
        iterations g nextX (iter + 1)


let f28 x = x - 2.0 + sin (1.0 / x)
let df28 x = 1.0 - cos (1.0 / x) / (x * x)
let g28 x = 2.0 - sin (1.0 / x)


let f1 x = exp x + log x - 10.0 * x
let df1 x = exp x + 1.0 / x - 10.0
let g1 x = log (10.0 * x - log x)


let f2 x = cos x - exp (-x * x / 2.0) + x - 1.0
let df2 x = -sin x + x * exp (-x * x / 2.0) + 1.0
let g2 x = 1.0 - cos x + exp (-x * x / 2.0)


let main () =
    printfn "%-10s | %-12s | %-12s | %-12s" "Equation" "Dichotomy" "Newton" "Iterations"
    printfn "------------------------------------------------------------"

    printfn
        "%-10s | %-12.5f | %-12.5f | %-12.5f"
        "№28"
        (dichotomy f28 1.2 2.0)
        (newton f28 df28 1.5 0)
        (iterations g28 1.5 0)

    printfn
        "%-10s | %-12.5f | %-12.5f | %-12.5f"
        "№1"
        (dichotomy f1 3.0 4.0)
        (newton f1 df1 3.5 0)
        (iterations g1 3.5 0)

    printfn
        "%-10s | %-12.5f | %-12.5f | %-12.5f"
        "№2"
        (dichotomy f2 0.5 2.0)
        (newton f2 df2 1.0 0)
        (iterations g2 1.0 0)

main ()
