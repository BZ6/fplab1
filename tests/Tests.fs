module Tests

open Xunit
open Task3
open Task28

[<Fact>]
let ``task3Rec should find the largest prime factor is 6857L!`` () =
    let result = task3Rec number
    Assert.Equal(6857L, result)

[<Fact>]
let ``task3TailRec should find the largest prime factor is 6857L!`` () =
    let result = task3TailRec number
    Assert.Equal(6857L, result)

[<Fact>]
let ``task3Module should find the largest prime factor is 6857L!`` () =
    let result = task3Module number
    Assert.Equal(6857L, result)

[<Fact>]
let ``task3Map should find the largest prime factor is 6857L!`` () =
    let result = task3Map number
    Assert.Equal(6857L, result)

[<Fact>]
let ``task3Cycle should find the largest prime factor is 6857L!`` () =
    let result = task3Cycle number
    Assert.Equal(6857L, result)

[<Fact>]
let ``task3Lazy should find the largest prime factor is 6857L!`` () =
    let result = task3Lazy number
    Assert.Equal(6857L, result)

[<Fact>]
let ``task28Rec should find summary of spiral diagonals is 669171001!`` () =
    let result = task28Rec rang
    Assert.Equal(669171001, result)

[<Fact>]
let ``task28TailRec should find summary of spiral diagonals is 669171001!`` () =
    let result = task28TailRec rang
    Assert.Equal(669171001, result)

[<Fact>]
let ``task28Module should find summary of spiral diagonals is 669171001!`` () =
    let result = task28Module rang
    Assert.Equal(669171001, result)

[<Fact>]
let ``task28Map should find summary of spiral diagonals is 669171001!`` () =
    let result = task28Map rang
    Assert.Equal(669171001, result)

[<Fact>]
let ``task28Cycle should find summary of spiral diagonals is 669171001!`` () =
    let result = task28Cycle rang
    Assert.Equal(669171001, result)
