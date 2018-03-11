open System.Security.Cryptography.X509Certificates

//Ex1. isLeapYear
let isLeapYear(x: int) : bool = 
    if(x % 400 = 0) then 
        true
    elif (x % 4 = 0 && x % 100 <> 0) then 
        true
    else
        false;;

printfn "Is 1990 leap year? %b" (isLeapYear(1990));;
printfn "Is 1991 leap year? %b" (isLeapYear(1991));;
printfn "Is 1992 leap year? %b" (isLeapYear(1992));;
printfn "Is 2000 leap year? %b" (isLeapYear(2000));;
printfn "";;

//Ex2. getMaximum
let rec getMaximum ls =
    match ls with
    | [] -> 0
    | [x] -> x
    | head :: tail -> if (head > getMaximum tail) then head
                                else getMaximum tail;;

printfn "Max of [9;2;5;23;11;17;6] is %i" (getMaximum([9;2;5;23;11;17;6]));;
printfn "";;

//Ex3. pclAppend
let rec appednding ls1 ls2 =
    match ls1 with
    | [] -> []
    | [x] -> x :: ls2
    | head :: tail -> head :: (appednding tail ls2);;

printfn "Test appending [1;3;5] with [7] = %A" (appednding [1;3;5] [7] );;
printfn "";;

//Ex4. pclRev a)
let rec pclReverseList ls = 
    match ls with
    | [] -> []
    | [y] -> [y]
    | head :: tail -> pclReverseList tail @ [head];;

printfn "[2; 4; 6; 8; 10] in reverse is -> %A" (pclReverseList([2; 4; 6; 8; 10]));;
printfn "";;

//Ex4. isPalindrome b)
let isPalindome ls =
   if ls = pclReverseList ls then true else false
   
printfn "[2; 4; 6; 8; 10] in palindrome is %b" (isPalindome([2; 4; 6; 8; 10]));;
printfn "[2; 4; 6; 4; 2] in palindrome is %b" (isPalindome([2; 4; 6; 4; 2]));;
printfn "";;

//Ex5. pclZipper
let rec pclZipper a b =
    match a, b with
        | [], [] -> []
        | x, y when x.Length <> y.Length -> failwith "Lists are not of the same size"
        | x :: xs, y :: ys -> (x, y) :: pclZipper xs ys;;

printfn "Zipping [1;2] and ['word'; 'test'] -> %A" (pclZipper [1;2] ["word"; "test"])