open Task3
//open Task28

[<EntryPoint>]
let main argv = 
  printfn "number: %d" numberForTest
  printfn "The largest prime factor of the number: %d" (task3Rec numberForTest)

  0
