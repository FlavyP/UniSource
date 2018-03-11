open System;    

//Exercise 02.03
let addNum1(x : int) = printfn "addNum1 result = %i" (x+1);;
let addNum10(x : int) : int = x+10;;
let addNum20(x : int) : int = addNum10(addNum10(x));;

//Exercise 02.04
let max2(x:int,y:int) : int = if(x>y) then x else y;;
let evenOrOdd(x: int) = 
    if(x % 2 = 0) then printfn "%i is even" (x) else printfn "%i is odd" (x);;
let addXY(x: int, y:int) = printfn "adding %i and %i " x y
                           printfn "result = %i" (x+y);;

addNum1(1);;
printfn "addNum10 result = %i" (addNum10(5));;
printfn "addNum20 result = %i" (addNum20(10));;
printfn "max between 2 and 5 = %i" (max2(2,5));;
evenOrOdd(35);;
evenOrOdd(44);;
addXY(5,7);;