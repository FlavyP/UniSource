open System;    

let addNum1(x : int) = 
        printfn "addNum1 result = %i" (x+1);;

addNum1(1);;
System.Console.ReadKey() |> ignore