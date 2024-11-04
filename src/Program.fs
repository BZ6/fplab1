open System.Diagnostics
open Task3
//open Task28

// Calculate time of solution
let printTimeFunc message f num =
  let stopwatch = Stopwatch.StartNew()
  let result = f num
  stopwatch.Stop()
  printfn "%s %d" message result
  printfn "Time taken: %A ms" stopwatch.ElapsedMilliseconds

[<EntryPoint>]
let main argv = 
  printfn "number: %d" number
  printTimeFunc "The largest prime factor of the number (recursive):      %d" task3Rec number
  printTimeFunc "The largest prime factor of the number (tail recursive): %d" task3TailRec number
  printTimeFunc "The largest prime factor of the number (module):         %d" task3Module number
  printTimeFunc "The largest prime factor of the number (map):            %d" task3Map number
  printTimeFunc "The largest prime factor of the number (cycle):          %d" task3Cycle number
  printTimeFunc "The largest prime factor of the number (lazy):           %d" task3Lazy number

  0
