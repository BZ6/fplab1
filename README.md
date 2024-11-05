# Лабораторная работа №1

`Захаркин Богдан 367224. Вариант 3,28`
`367224`

## Задача 3. Largest Prime Factor

The prime factors of **13195** are **5**, **7**, **13** and **29**.
What is the largest prime factor of the number **600851475143**?

### Решение задачи 3

#### 1. Решение через рекурсию

```f#
let task3Rec num =
    let mutable factor = 2L

    let rec findFactor n =
        if n <= 1L then
            factor
        elif (n % factor) = 0L then
            findFactor (n / factor)
        else
            factor <- factor + 1L
            findFactor n

    findFactor num
```

#### 2. Решение через хвостовую рекурсию

```f#
let task3TailRec num =
    let rec findFactor factor n =
        if n <= 1L then
            factor
        elif (n % factor) = 0L then
            findFactor factor (n / factor)
        else
            findFactor (factor + 1L) n

    findFactor 2L num
```

#### 3. Решение используя filter и fold/reduce

```f#
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
```

#### 4. Решение используя map

```f#
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
```

#### 5. Решение используя циклы

```f#
let task3Cycle num =
    let mutable n = num
    let mutable factor = 2L

    while n > 1L do
        if n % factor = 0L then
            n <- n / factor
        else
            factor <- factor + 1L

    factor
```

#### 6. Решение используя ленивую коллекцию

```f#
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
    |> Seq.filter isFactor
    |> Seq.takeWhile (fun x -> x <= int64 (sqrt (float num)))
    |> Seq.max
```

Seq является ленивой коллекцией последовательности, но выиграша по времени не дала ощутимого.

#### 7. Решение на Python

```python
number = 600851475143

n = number
factor = 2
while n > 1:
    if n % factor == 0:
        n /= factor
    else:
        factor += 1
result = factor

print(result)
```


## Задача 28. Number Spiral Diagonals

Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

|        |        |        |        |        |
| ------ | ------ | ------ | ------ | ------ |
| **21** | 22     | 23     | 24     | **25** |
| 20     |  **7** |  8     |  **9** | 10     |
| 19     |  6     |  **1** |  2     | 11     |
| 18     |  **5** |  4     |  **3** | 12     |
| **17** | 16     | 15     | 14     | **13** |

It can be verified that the sum of the numbers on the diagonals is 101.
What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

### Решение задачи 28

#### 1. Решение через рекурсию

```f#
let task28Rec num =
    let rec findSumDig n =
        if n = 1 then
            1
        else
            4 * n * n - 6 * (n - 1) + findSumDig (n - 2)

    findSumDig num
```

#### 2. Решение через хвостовую рекурсию

```f#

let task28TailRec num =
    let rec findSumDig acc n =
        if n = 1 then
            acc
        else
            findSumDig (acc + 4 * n * n - 6 * (n - 1)) (n - 2)

    findSumDig 1 num
```

#### 3. Решение используя filter и fold/reduce

```f#
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
```

#### 4. Решение используя map

```f#
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
```

#### 5. Решение используя циклы

```f#
let task28Cycle num =
    let mutable sum = 1
    let mutable cur = 1

    for i in 2..2 .. (num - 1) do
        for _ in 0..3 do
            cur <- cur + i
            sum <- sum + cur

    sum
```

#### 7. Решение на C++

```cpp
#include<iostream>

using namespace std;

const int number = 1001;

int main()
{
    int result, cur = 1, sum = 1;
    
    for (int i = 2; i < number; i += 2)
        for (int j = 0; j < 4; j++) {
            cur += i;
            sum += cur;
        }
    result = sum;
    
    cout << result << endl;
    
    return 0;
}
```

### Вывод

Эта лабораторная работа позволила мне познакомиться с базовыми концепциями и инструментами языка F#, теперь, я надеюсь, готов к решению более сложных и комплексных задач.

Приятной особенностью языка оказалась автоматическое приведение типов, так как для языка со статической типизацией, хотелось бы знать об ошибке во время компиляции, а то и раньше.

Код на питоне и C++ выглядят приятнее и компактнее, возможно от того, что я там использовал циклы.

Возможно некоторые решения вышли громоздкими и не оптимальными, но мне нужно было их попробовать, для практики в некоторых особеностях языка f#.
