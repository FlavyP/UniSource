open System;


type LanguageEnums = Lithuanian=0 | Romanian=1 | English=2;;

type Fruit = {Name: string; Language: LanguageEnums; Translation: string};;
type Greeting = {Name: string; Language: LanguageEnums; Translation: string};;
type Animal = {Name: string; Language: LanguageEnums; Translation: string};;

let apl:Fruit = {Name="Obuolys"; Language=LanguageEnums.Lithuanian; Translation="Apple"};;
let apr:Fruit = {Name="Abrikosas"; Language=LanguageEnums.Lithuanian; Translation="Appricot"};;
let apls:Fruit = {Name="Apelsinas"; Language=LanguageEnums.Lithuanian; Translation="Orange"};;
let krs:Fruit = {Name="Kriause"; Language=LanguageEnums.Lithuanian; Translation="Pear"};;
let prs:Fruit = {Name="Persikas"; Language=LanguageEnums.Lithuanian; Translation="Peach"};;

let hey:Greeting = {Name="Sveikas"; Language=LanguageEnums.Lithuanian; Translation="Hey"};;
let eve:Greeting = {Name="Labas Vakaras"; Language=LanguageEnums.Lithuanian; Translation="Good evening"};;
let hel:Greeting = {Name="Labas"; Language=LanguageEnums.Lithuanian; Translation="Hello"};;
let day:Greeting = {Name="Laba diena"; Language=LanguageEnums.Lithuanian; Translation="Good afternoon"};;
let bye:Greeting = {Name="Viso gero"; Language=LanguageEnums.Lithuanian; Translation="Bye Bye"};;

let cat:Animal = {Name="Kate"; Language=LanguageEnums.Lithuanian; Translation="Cat"};;
let dog:Animal = {Name="Suo"; Language=LanguageEnums.Lithuanian; Translation="Dog"};;
let lio:Animal = {Name="Liutas"; Language=LanguageEnums.Lithuanian; Translation="Lion"};;
let tig:Animal = {Name="Tigras"; Language=LanguageEnums.Lithuanian; Translation="Tiger"};;
let hor:Animal = {Name="Arklys"; Language=LanguageEnums.Lithuanian; Translation="Horse"};;

let fruits = [apl; apr;apls;krs;prs];;
let greetings = [hey; eve; hel; day; bye];;
let animals = [cat; dog; lio; tig; hor];;

let isExistInFruits value = fruits |> List.exists(fun x -> x.Name.ToLower() = value)
let isExistInGreetings value = greetings |> List.exists(fun x -> x.Name.ToLower() = value)
let isExistInAnimals value = animals |> List.exists(fun x -> x.Name.ToLower() = value)


let findByValueInFruits value = fruits |> List.find(fun y -> y.Name.ToLower() = value)
let findByValueInGreetings value = greetings |> List.find(fun y -> y.Name.ToLower() = value)
let findByValueInAnimals value = animals |> List.find(fun y -> y.Name.ToLower() = value)


let translate word = match word with
                    | "" -> failwith "Cannot be empty"
                    | _ -> 
                           if (isExistInFruits(word))
                           then printfn "Word in english (FRUIT) : %s" (findByValueInFruits(word).Translation)
                           else if (isExistInGreetings(word))
                           then printfn "Word in english (GREETING) : %s" (findByValueInGreetings(word).Translation)
                           else if (isExistInAnimals(word))
                           then printfn "Word in english (ANIMAL) : %s" (findByValueInAnimals(word).Translation)
                           else printfn "Word cannot be translated";;

Console.WriteLine("Please input a word \n");
let input = Console.ReadLine();
translate input;;

Console.ReadLine();;   
