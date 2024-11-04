open Task3
//open Task28

[<EntryPoint>]
let main argv = 
  printfn "number: %d" number
  printfn "The largest prime factor of the number (recursive):      %d" (task3Rec number)
  printfn "The largest prime factor of the number (tail recursive): %d" (task3TailRec number)
  printfn "The largest prime factor of the number (module):         %d" (task3Module number)
  printfn "The largest prime factor of the number (map):            %d" (task3Map number)
  printfn "The largest prime factor of the number (cycle):          %d" (task3Cycle number)

  0
