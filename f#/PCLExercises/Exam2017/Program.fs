open System.Text.RegularExpressions
open System.Security.Cryptography.X509Certificates

//1a
//Dynamic typing - used in languages like JavaScript, it checks the type of the object during the program execution time. All types start as a var. It is less safe, since it doesn't know what to expect in the beginning and it makes it harder to debug. The only advantage is that it makes it more flexible. 
//Static typing - used in languages like Java, all variables should have a type (int, String, etc.) so the compiler knows the types before execution. It is safer than dynamic typing which makes it less error prone and easier to debug, but at the same time it takes from flexibility and you may feel restricted at some point. Also, in the beginning when you don't know what data type to use, it makes it difficult since you have to think in advance.

//1b
//Some of the benefits of functional programming over imperative languages can be: immutability of data (you enforce your variables as immutable, meaning you can change them). Functional programming means you have different small functions to take care of different issues, meaning your syntax will be small, clean and organized and methods will just do ONE logical thing, not more. Also, in functional programming languages functions are treated as any other data values, meaning you can send them as parameters to another functions and make your life easier when coding.

//1c
//A scala trait is like an interface in Java, but the advantage of a trait compared to an interface is that it allows default implementations. They can't be instantiated and can't have a constructor. If you want to define an abstract method in a trait, those will need to be implemented in A class. Traits are very useful when doing inheritance or composition and you have shared functionality between your objects since you can add it in the trait itself.

//1d
//No you wouldn't need to rewrite or adapt your program because Erlang can use multiple CPUs on multiprocessor machines with ease. Processes may use the same program code at the same time, each has its own program counter, stack, and variables and the programmer does not need to think about the processes updating the variables.

//1e
//The Erlang process is a method 'serve' that takes in 0 parameters. It is waiting for 'TiZo' which seems to be the hour from user input. It then calls the 'time()' function to get a tuple of the current Hour, Minute, Second. Then, it goes in the if-statement where it checks if the current hour plus the input hour (TiZo) is greater than 23. If it is, it means it's a new day, so it's sending back the 'current hour + input hour - 24' - meaning a new day, same Minutes same Seconds as it got from the function time(). If the sum of current hour plus input hour (TiZo) is less than 0, it sends back the sum of these plus 24, same minutes and seconds. Otherwise it will send back the current hour + input hour, same minutes and seconds. The fuction serves send back a tuple containing Hour, Minutes, Seconds based on the calculations and possibilites handled in the if-statement.

//2a
let rec sumAbsDr (lst : list<int>) = 
    match lst with
        | [] -> 0
        | hd::tl -> abs hd + sumAbsDr(tl);;

//2b
let sumAbsHof (lst : list<int>) = List.sum(lst |> List.map(fun x -> abs x));;

//2c
let lastElement list = 
    let rec lastElementTail lst acc =    
       match lst with
       | [] -> failwith "Empty list"
       | hd::tl -> lastElementTail tl hd
    lastElementTail list ""

//3a
let withSnd (x,y) z = (x,y+z);;

//3b
let recur n x = [for a in 1..n do yield x];;

//3c
let displayListRec list =
    let rec displayListRecTail lst acc =
        match lst with
        | [] -> ""
        | hd::tl -> printfn "%i: %i" (acc) (hd)
                    displayListRecTail tl (acc+1)
    displayListRecTail list 1;;

//4a
type BinaryTree = | Node of (int * BinaryTree * BinaryTree)
                  | Empty

let rtNodeValue (x:BinaryTree) =
    match x with
    |Empty -> failwith "Empty tree"
    |Node(x1,x2,x3) -> x1;;

let emptyNode = Empty;;
let oneNode = Node(1, Empty, Empty);;
let secondNode = Node(1, Node(2, Empty, Empty), Node(3, Empty, Empty));;
rtNodeValue emptyNode;;
rtNodeValue oneNode;;

//4b
let leftSubTree (x:BinaryTree) =
    match x with
    |Node(x1,x2,x3) -> if (x2 <> Empty) then x2 else failwith "Cannot return anything";;

//4c
let appears (x:BinaryTree) = 
    match x with
    | Empty -> false
    | Node(x1, x2, x3) -> true

//5
type Route = int
type Make = string
type Model = string
type Registration = string
type TransportMeans = 
    | Car of Make * Model * Registration
    | Bicycle
    | Bus of Route * Registration

//5a
let car = Car("Porsche", "Panamera", "1X2Y3Z");;
let bus = Bus(1, "B113");;
let bike = Bicycle;;
let transportMeansList = [car;bus;bike;Bus(2,"B332");Car("Ferrari", "LaFerrari","3344XX");Bicycle];;

//5b
let cityAverageSpeed (x:TransportMeans) = 
    match x with
    | Car(_,_,_) -> 40
    | Bicycle -> 18
    | Bus(_,_) -> 30;;

//6
type Dept = string;;
type Scores = Scores of int;;
type Points = Points of int;;
type Fixture = Dept * Dept;;
type Result = (Dept * Scores) * (Dept * Scores);;
type Table = Map<Dept, Points>;;

let competition : string list = ["ATCM"; "ISM"; "VCM"; "CEG"; "GBE"; "ICT"]

let res = ("ICT", Scores 5), ("GBE", Scores 3);;

//6a
let deptPoints (x:Scores) (y:Scores) =
    if
        (x > y) then (Points 2, Points 0) else if
        (x < y) then (Points 0, Points 2) else
        Points 1, Points 1;;

//6b
let initializeCompetition (name:Dept) = (name, Points 0)

let initializeTable ls = Map.ofList (List.map initializeCompetition ls)

let updateTable (x:Table) y =
    match y with
    | Fixture ( (Dept(x1), Scores(x2)), (Dept(x3), Scores(x4)))   -> failwith "";;

//6c

//7
type DrinkQty = 
        | Water of int
        | Cola of int
        | Coffee of int
        | Tea of int
    with
        override qty.ToString() =
            match qty with
                | Water qty -> Printf.sprintf "%i cup(s)/glass(es) of Water" qty
                | Cola qty -> Printf.sprintf "%i cup(s)/bottles(es) of Cola" qty
                | Coffee qty -> Printf.sprintf "%i cup(s) of Coffee" qty
                | Tea qty -> Printf.sprintf "%i cup(s) of Tea" qty


let drinkingFunc x y =
    match x with
                | "Water" -> if y < 3 then printfn "%i cups of water is too less!" y else printfn "%i cups of water should be fine" y
                | "Cola" -> if y > 6 then printfn "%i cups of Cola is too much!" y else printfn "%i cups of cola should be fine" y
                | "Coffee" -> if y < 3 then printfn "%i cups of coffee is fine!" y else printfn "%i cups of coffee is too much" y
                | "Tea" -> if y < 5 then printfn "%i cups of coffee is fine!" y else printfn "%i cups of coffee is too much" y;;
//7a
let drinkAgent = MailboxProcessor.Start(fun drink->

    let rec drinkLoop() = async{

        let! word = drink.Receive()
        let sep = new Regex("\s")
        let arr = sep.Split(word)
        let drink = arr.[0]
        let qty = int32(arr.[1])
        drinkingFunc drink qty

        return! drinkLoop()
        }

    drinkLoop()
    );;

//7b
drinkAgent.Post "Coffee 10" //10 cups of coffee is too much
drinkAgent.Post "Water 1" //1 cups of water is too less!
drinkAgent.Post "Tea 3" //3 cups of coffee is fine!