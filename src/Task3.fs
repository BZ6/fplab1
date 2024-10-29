module Task3

let number = 600851475143L
let numberForTest = 13195L

// Recursive
let task3Rec num: int64 =
  let factor = ref 2
  let rec findFactor n =
    if n <= 1L then !factor
    else if (n % (int64 !factor)) = 0L then findFactor (n / (int64 !factor))
    else 
      incr factor
      findFactor n

  findFactor num

// Tail recursive
let task3TailRec num =
  let rec findFactor factor  n =
    if n <= 1L then factor
    else if (n % factor) = 0L then findFactor factor (n / factor)
    else findFactor (factor + 1L) n

  findFactor 2L num

