open System

let a = Math.PI / 5.0
let b = 6.0 * Math.PI / 5.0
let n = 10
let eps = 0.01

let f x = -log(abs (2.0 * sin (x / 2.0)))


let rec sumUntil next k state acc =
    let value = fst state

    if abs value < eps then
        (acc, k)
    else
        let newState = next k state
        sumUntil next (k + 1) newState (acc + value)

let taylorDumb x =

    let next k _ =
        let k1 = k + 1
        let term = cos (float k1 * x) / float k1
        (term, ())

    let first = cos x / 1.0

    sumUntil next 1 (first, ()) 0.0

let taylorSmart x =

    let cosx = cos x
    let sinx = sin x

    let next k (_, (cos_kx, sin_kx)) =

        let cos_next = cos_kx * cosx - sin_kx * sinx
        let sin_next = sin_kx * cosx + cos_kx * sinx

        let k1 = k + 1
        let term = cos_next / float k1

        (term, (cos_next, sin_next))

    let first = cos x / 1.0

    sumUntil next 1 (first, (cos x, sin x)) 0.0


let print x =
    let builtin = f x
    let smartValue, smartN = taylorSmart x
    let dumbValue, dumbN = taylorDumb x

    printfn "%8.4f | %12.6f | %12.6f | %6d | %12.6f | %6d" x builtin smartValue smartN dumbValue dumbN


let main () =
    printfn "------------------------------------------------------------------------"
    printfn "    x    |    Builtin   | Smart Taylor |    #   |  Dumb Taylor |    #   "
    printfn "------------------------------------------------------------------------"

    for i in 0 .. n - 1 do
        let x = a + float i / float n * (b - a)
        print x


main ()
