open System

//Ex.3b.01.a
let charToUpper(x: char) = match x with
                                        | 'a' -> printf "%c" 'A'
                                        | 'b' -> printf "%c" 'B'
                                        | 'c' -> printf "%c" 'C'
                                        | _ -> printf "%c" x;;

//Ex.3b.01.b
let rec stringToUpper n = for char in n do
                                match char with
                                |'a' | 'b' | 'c' -> charToUpper(char)
                                | _ -> printf "%c" char;;

//Ex.3b.02.a
let rec pclLength list =
  match list with
  | [] -> 0
  | _ :: tail -> 1 + pclLength tail;;

//Ex.3b.02.b
let rec pclSum list =
  match list with
  | [] -> 0
  | _ :: tail -> list.Head + pclSum tail;;

//Ex.3b.03
let rec takeSome n ls =
        match ls with
        | [] -> []
        | _ -> ls.Head :: takeSome (n-1) (ls.Tail);;

printf "Char To Upper: "
charToUpper('a');;
printfn "";;

printf "String To Upper: "
stringToUpper("asdXpbCsXlMabcabc");;
printfn "";;

printfn "Length of list: %i" (pclLength [1;2;3;4;5;6]);;
printfn "Sum of list: %i" (pclSum [1;2;3;4;5;6]);;
printfn "testing: %A" (takeSome 2 [1;2;23]);;
Console.ReadKey();