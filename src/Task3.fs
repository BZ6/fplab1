// Euler Problem 3
module Task3

let number = 600851475143L
let numberForTest = 13195L

// Monolithic solutions: Recursive
let task3Rec num =
    let rec findFactor factor n =
        if n <= 1L then
            factor
        elif (n % factor) = 0L then
            let n = n / factor
            findFactor factor n
        else
            let factor = factor + 1L
            findFactor factor n

    findFactor 2L num

// Monolithic solutions: Tail recursive with pattern matching
let task3TailRec num =
    let rec findFactor factor n =
        match n with
        | _ when n <= 1L -> factor
        | _ when (n % factor) = 0L -> findFactor factor (n / factor)
        | _ -> findFactor (factor + 1L) n

    findFactor 2L num

// Module solution
let task3Module num =
    let generateFactors n = [ 2L .. int64 (sqrt (float n)) ]

    let filterSimple factors =
        let rec filterSimpleRec current simple factors =
            if List.isEmpty factors then
                simple
            else
                filterSimpleRec
                    (List.head factors)
                    (current :: simple)
                    (List.filter (fun a -> a % current <> 0L) (List.tail factors))

        filterSimpleRec (List.head factors) [] factors

    let isFactor factor = (num % factor = 0L)

    let maxFactor acc i = if acc < i then i else acc

    num
    |> generateFactors
    |> filterSimple
    |> List.filter isFactor
    |> List.reduce maxFactor

// Map solution
let task3Map num =
    let generateFactors n = [ 2L .. int64 (sqrt (float n)) ]

    let isPrime n =
        let rec check i =
            i > n / 2L || (n % i <> 0L && check (i + 1L))

        check 2

    let isFactor factor = (num % factor = 0L)

    let mapThroughOption f =
        List.map (fun x -> if (f x) then Some x else None)
        >> List.choose id

    num
    |> generateFactors
    |> mapThroughOption isPrime
    |> mapThroughOption isFactor
    |> List.max

// Cycle solution
let task3Cycle num =
    let mutable n = num
    let mutable factor = 2L

    while n > 1L do
        if n % factor = 0L then
            n <- n / factor
        else
            factor <- factor + 1L

    factor

// Lazy solution
let task3Lazy num =
    let generateFactors n =
        Seq.initInfinite (fun i -> int64 i + 2L)

    let isPrime n =
        let rec check i =
            i > n / 2L || (n % i <> 0L && check (i + 1L))

        check 2L

    let isFactor factor = (num % factor = 0L)

    num
    |> generateFactors
    |> Seq.filter isPrime
    |> Seq.takeWhile (fun x -> x <= int64 (sqrt (float num)))
    |> Seq.filter isFactor
    |> Seq.max
