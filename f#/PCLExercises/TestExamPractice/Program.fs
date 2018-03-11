let x = "asdasdasdasd"

let rec stringToList (s:string) = 
        match s with
        | "" -> []
        | _ -> (s.[0]) :: (stringToList (s.Substring(1)));;


//Q3
type Vector =
    | V2 of float * float
    | V3 of float * float * float
    | V4 of float * float * float * float
    | V5 of float * float * float * float * float
    
let vecLen (v:Vector) =
    match v with
    | V2(_,_) -> 2
    | V3(_,_,_) -> 3
    | V4(_,_,_,_) -> 4
    | V5(_,_,_,_,_) -> 5
    
let vecAdd (v1:Vector,v2:Vector) =
    if vecLen v1 = vecLen v2 
    then match v1,v2 with
            | V2(x11,x12),V2(x21,x22) -> V2(x11+x21,x12+x22)
            | V3(x11,x12,x13),V3(x21,x22,x23) -> V3(x11+x21,x12+x22,x13+x23)
            | V4(x11,x12,x13,x14),V4(x21,x22,x23,x24) -> V4(x11+x21,x12+x22,x13+x23,x14+x24)
            | V5(x11,x12,x13,x14,x15),V5(x21,x22,x23,x24,x25) -> V5(x11+x21,x12+x22,x13+x23,x14+x24,x15+x25)
    else failwith "vectors are not the same length"
    

let v2 = V3 (10.0,10.0, 10.0);;
let v3 = V3 (15.0,16.0, 25.0);;

//Q4
let rec rerun (s:string) (n:int) =
    match s,n with
    | _,0 -> ""
    | "",_ -> ""
    | _,_ -> s + rerun s (n-1)

let rerun2 (s:string) (n:int) =
    let rec rerunTail (st:string) (nt:int) (acc:string) =    
       match st,nt with
       | _,0 -> acc
       | "",_ -> acc
       | _,_ -> rerunTail st (nt-1) (acc+st)
    rerunTail s n ""

let f2 f p sq = 
    seq {
        for x in sq do
            if p x then yield f x
    }

let f2X f p sq = List.map f sq;;

type expr = | Const of int
            | BinOpr of expr * string * expr

let val1 = BinOpr(Const(1),"+",BinOpr(Const(2),"*",Const(3)));
let val2 = BinOpr(Const(5),"-",Const(2));
let val3 = BinOpr(Const(5),"*",Const(2));

let rec toString (e:expr) =
    match e with
    | Const(a) -> a.ToString()
    | BinOpr(a,b,c) -> "(" + toString a + b + toString c + ")";;

let rec extOperators (e:expr) =
    match e with
    | Const(_) -> ""
    | BinOpr(a,b,c) -> extOperators a + b + extOperators c ;;
