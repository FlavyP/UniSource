open System.Security.Principal
open System

let pclFormattedDateDifferent (a, b, c) = "Your date when formatted Differently? is: " + string b + " " + string a + " " + string c;;

let pclFormattedDate (a,b,c) = printfn "Your date when formatted is: %s %i %i" b a c;;

let pclFormattedDatePlus (a, b, c) = match (a % 10) with
                                    | 1 -> printfn "Your date when formatted is: %s %ist %i" b a c
                                    | 2 -> printfn "Your date when formatted is: %s %ind %i" b a c
                                    | 3 -> printfn "Your date when formatted is: %s %ird %i" b a c
                                    | _ -> printfn "Your date when formatted is: %s %ith %i" b a c;;

let pclConvertStringToWords (a: string) = printfn "%A" (Seq.toList (a.Split ' '));;


let rec sumList lst = 
    match lst with
        | [] -> 0
        | hd::tl -> hd + sumList(tl);;

//Tail Recursive version of sumList
let sumListTR ls =
    let rec tailRecursiveSumList ls total = 
        match ls with
            | [] -> total
            | hd::tl -> let tmpTotal = hd + total
                        tailRecursiveSumList tl tmpTotal
    tailRecursiveSumList ls 0;;

let factorial x =
    //Keep track of both x and an accumulator value (acc)
    let rec tailRecursiveFactorial x acc = 
        if x <= 1 then
            acc
        else
            tailRecursiveFactorial (x-1) (acc*x)
    tailRecursiveFactorial x 1;;

printfn "%s" (pclFormattedDateDifferent(29, "September", 2017));;

pclFormattedDate(29, "September", 2017);;

pclFormattedDatePlus(21, "September", 2017);;
pclFormattedDatePlus(2, "October", 2017);;
pclFormattedDatePlus(23, "October", 2017);;
pclFormattedDatePlus(24, "December", 2017);;

pclConvertStringToWords "The brown fox jumped over the lazy dog";;

type LanguageEnums = Lithuanian=0 | Romanian=1 | English=2;;

type Fruit = {Name: string; Language: LanguageEnums; Translation: string};;
type Greeting = {Name: string; Language: LanguageEnums; Translation: string};;
type Animal = {Name: string; Language: LanguageEnums; Translation: string};;

type Smth = string * LanguageEnums * string;;

let apl:Fruit = {Name="Obuolys"; Language=LanguageEnums.Lithuanian; Translation="Apple"};;
let apr:Fruit = {Name="Abrikosas"; Language=LanguageEnums.Lithuanian; Translation="Appricot"};;

let short:Greeting = {Name="Sveikas"; Language=LanguageEnums.Lithuanian; Translation="Hey"};;
let long:Greeting = {Name="Labas Vakaras"; Language=LanguageEnums.Lithuanian; Translation="Good evening"};;

let cat:Animal = {Name="Kate"; Language=LanguageEnums.Lithuanian; Translation="Cat"};;
let dog:Animal = {Name="Suo"; Language=LanguageEnums.Lithuanian; Translation="Dog"};;

let fruits = [apl; apr];;
let greetings = [short; long];;
let animals = [cat; dog];;

printfn "daaaaaaaaaaaaaa%s" <| (apl.GetType().ToString());;
printfn "ddddddd%s" <| (cat.GetType().ToString());;
printfn "sssssssssssss%s" <| (short.GetType().ToString());;

type E<'a> = Fruit of string * LanguageEnums * string | Greeting of string * LanguageEnums * string | Animal of string * LanguageEnums * string;;

let bnn = Fruit ("Banana", LanguageEnums.Lithuanian, "Banana");;
printfn "22222222%s" <| (bnn.GetType().ToString());;
match bnn with
    | Fruit (f1,f2,f3) -> printfn "hello FRUIT %s" f3
    | Greeting (f1,f2,f3) -> printfn "hello Greeting %s" f3
    | Animal (f1,f2,f3) -> printfn "hello Animal %s" f3;;

let isExistInFruits value = fruits |> List.exists(fun x -> x.Name = value)
let isExistInGreetings value = greetings |> List.exists(fun x -> x.Name = value)
let isExistInAnimals value = animals |> List.exists(fun x -> x.Name = value)


let findByValueInFruits value = fruits |> List.find(fun y -> y.Name = value)
let findByValueInGreetings value = greetings |> List.find(fun y -> y.Name = value)
let findByValueInAnimals value = animals |> List.find(fun y -> y.Name = value)

let translate word = match word with
                    | "" -> failwith "Cannot be empty"
                    | _ -> 
                           if (isExistInFruits(word))
                           then printfn "Word in english (FRUIT) : %s" (findByValueInFruits(word).Translation)
                           else if (isExistInGreetings(word))
                           then printfn "Word in english (GREETING) : %s" (findByValueInGreetings(word).Translation)
                           else if (isExistInAnimals(word))
                           then printfn "Word in english (ANIMAL) : %s" (findByValueInAnimals(word).Translation)
                           else printfn "Word cannot be translated"


translate "Obuolys";;
translate "Sveikas";;
translate "Kate";; 
translate "Zodis";; 

Console.ReadLine();;

type ProjectTypes = Animal of string | Fruit of string | Greeting of string;;
