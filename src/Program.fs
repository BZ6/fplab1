open System.Diagnostics
open Task3
open Task28

// Calculate time of solution
let printTimeFunc message f num =
    let stopwatch = Stopwatch.StartNew()
    let result = f num
    stopwatch.Stop()
    printfn "%s %A" message result
    printfn "Time taken: %A ms" stopwatch.ElapsedMilliseconds

[<EntryPoint>]
let main argv =
    // printfn "number: %d" number
    // printTimeFunc "The largest prime factor of the number (recursive):      " task3Rec number
    // printTimeFunc "The largest prime factor of the number (tail recursive): " task3TailRec number
    // printTimeFunc "The largest prime factor of the number (module):         " task3Module number
    // printTimeFunc "The largest prime factor of the number (map):            " task3Map number
    // printTimeFunc "The largest prime factor of the number (cycle):          " task3Cycle number
    printTimeFunc "The largest prime factor of the number (lazy):           " task3Lazy number

    // printfn "rang: %d" rang
    // printTimeFunc "The summary of spiral diagonals (recursive):      " task28Rec rang
    // printTimeFunc "The summary of spiral diagonals (tail recursive): " task28TailRec rang
    // printTimeFunc "The summary of spiral diagonals (module):         " task28Module rang
    // printTimeFunc "The summary of spiral diagonals (map):            " task28Map rang
    // printTimeFunc "The summary of spiral diagonals (cycle):          " task28Cycle rang

    0
