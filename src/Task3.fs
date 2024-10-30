// Euler Problem 3
module Task3

let number = 600851475143L
let numberForTest = 13195L

// Monolithic solutions: Recursive
let task3Rec num =
  let mutable factor = 2L
  let rec findFactor n =
    if n <= 1L then factor
    elif (n % (int64 factor)) = 0L then findFactor (n / (int64 factor))
    else 
      factor <- factor + 1L
      findFactor n

  findFactor num

// Monolithic solutions: Tail recursive
let task3TailRec num =
  let rec findFactor factor  n =
    if n <= 1L then factor
    elif (n % factor) = 0L then findFactor factor (n / factor)
    else findFactor (factor + 1L) n

  findFactor 2L num

// Module solution
let task3Module num =
  let generateFactors n = [2L .. int64 (sqrt (float num))]

  let filterSimple factors = 
    let rec filterSimpleRec current simple factors = 
      if List.length factors = 0 then simple
      else filterSimpleRec (List.head factors) (current :: simple) (List.filter (fun a -> a % current <> 0L) (List.tail factors))

    filterSimpleRec (List.head factors) [] factors
    
  let isFactor factor = (num % factor = 0L)

  let maxFactor acc i =
    if acc < i then i
    else acc

  num
  |> generateFactors
  |> filterSimple
  |> List.filter isFactor
  |> List.reduce maxFactor
