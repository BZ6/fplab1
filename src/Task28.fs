// Euler Problem 28
module Task28

let rang = 1001
let rangForTest = 5

// Monolithic solutions: Recursive
let task28Rec num =
  let rec findSumDig n = 
    if n = 1 then 1
    else 4 * n * n - 6 * (n - 1) + findSumDig (n - 2)
  
  findSumDig num

// Monolithic solutions: Tail recursive
// let task28TailRec num =


// Module solution
// let task28Module num =


// Map solution
// let task28Map num =


// Cycle solution
// let task28Cycle num =


// Lazy solution
// let task28Lazy num =

