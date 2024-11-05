// Euler Problem 28
module Task28

let rang = 1001
let rangForTest = 5

// Monolithic solutions: Recursive
let task28Rec num =
    let rec findSumDig n =
        if n = 1 then
            1
        else
            4 * n * n - 6 * (n - 1) + findSumDig (n - 2)

    findSumDig num

// Monolithic solutions: Tail recursive
let task28TailRec num =
    let rec findSumDig acc n =
        if n = 1 then
            acc
        else
            findSumDig (acc + 4 * n * n - 6 * (n - 1)) (n - 2)

    findSumDig 1 num

// Module solution
let task28Module num =
    let generateSpiral n =
        [ for i in 3..2..n -> [ ((i - 2) * (i - 2) + 1) .. (i * i) ] ]

    let filterDiagonals lists =
        let isDiagonal n i =
            i = n * n
            || i = n * n - (n - 1)
            || i = n * n - 2 * (n - 1)
            || i = n * n - 3 * (n - 1)

        let rec filterDiagonalsRec current result lists n =
            if List.isEmpty lists then
                ((List.filter (isDiagonal n) current) @ result)
            else
                filterDiagonalsRec
                    (List.head lists)
                    ((List.filter (isDiagonal n) current) @ result)
                    (List.tail lists)
                    (n + 2)

        filterDiagonalsRec (List.head lists) [] (List.tail lists) 3

    num
    |> generateSpiral
    |> filterDiagonals
    |> List.fold (+) 1


// Map solution
let task28Map num =
    let generateSpiral n =
        [ for i in 3..2..n -> [ ((i - 2) * (i - 2) + 1) .. (i * i) ] ]

    let i = ref 1

    let mapThroughOption list =
        let isDiagonal n i =
            i = n * n
            || i = n * n - (n - 1)
            || i = n * n - 2 * (n - 1)
            || i = n * n - 3 * (n - 1)

        i.Value <- i.Value + 2

        list
        |> List.map (fun x ->
            if (isDiagonal i.Value x) then
                Some x
            else
                None)

    num
    |> generateSpiral
    |> List.map mapThroughOption
    |> List.reduce (@)
    |> List.choose id
    |> List.sum
    |> (+) 1


// Cycle solution
let task28Cycle num =
    let mutable sum = 1
    let mutable cur = 1

    for i in 2..2 .. (num - 1) do
        for _ in 0..3 do
            cur <- cur + i
            sum <- sum + cur

    sum
