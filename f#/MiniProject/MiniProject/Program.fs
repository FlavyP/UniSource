open System

type LanguageEnums = Lithuanian=0 | Romanian=1 | English=2;;

type E<'a> = Fruit of Name : string * Language : LanguageEnums * Translation : string | Greeting of Name : string * Language : LanguageEnums * Translation : string | Animal of Name : string * Language : LanguageEnums * Translation : string;;

let apl = Fruit (Name = "Obuolys", Language = LanguageEnums.Lithuanian, Translation = "Apple");;
let apr = Fruit (Name = "Abrikosas", Language = LanguageEnums.Lithuanian, Translation = "Appricot");;
let apls = Fruit (Name="Apelsinas", Language=LanguageEnums.Lithuanian, Translation="Orange");;
let krs = Fruit (Name="Kriause", Language=LanguageEnums.Lithuanian, Translation="Pear");;
let prs = Fruit (Name="Persikas",Language=LanguageEnums.Lithuanian, Translation="Peach");;

let cat = Animal (Name="Kate", Language=LanguageEnums.Lithuanian, Translation="Cat");;
let dog = Animal (Name="Suo", Language=LanguageEnums.Lithuanian, Translation="Dog");;
let lio = Animal (Name="Liutas", Language=LanguageEnums.Lithuanian, Translation="Lion");;
let tig = Animal (Name="Tigras", Language=LanguageEnums.Lithuanian, Translation="Tiger");;
let hor = Animal (Name="Arklys", Language=LanguageEnums.Lithuanian, Translation="Horse");;

let hey =  Greeting (Name="Sveikas", Language=LanguageEnums.Lithuanian, Translation="Hey");;
let eve =  Greeting (Name="Labas Vakaras", Language=LanguageEnums.Lithuanian, Translation="Good evening");;
let hel =  Greeting (Name="Labas", Language=LanguageEnums.Lithuanian, Translation="Hello");;
let day =  Greeting (Name="Laba diena", Language=LanguageEnums.Lithuanian, Translation="Good afternoon");;
let bye =  Greeting (Name="Viso gero", Language=LanguageEnums.Lithuanian, Translation="Bye Bye");;

let thinghies = [apl;apr;apls;krs;prs;cat;dog;lio;tig;hor;hey;eve;hel;day;bye];;

let translate (word:string) = 
        let mutable isTranslated = false;
        for i in thinghies do
            match i with
                | Fruit (f1,f2,f3) -> if f1.ToLower() = word.ToLower() then 
                                                    printfn "'%s' is a Fruit in %A that means '%s' in English \n" word f2 f3
                                                    isTranslated <- true
                | Greeting (f1,f2,f3) -> if f1.ToLower() = word.ToLower() then 
                                                    printfn "'%s' is a Greeting in %A that means '%s' in English \n" word f2 f3
                                                    isTranslated <- true
                | Animal (f1,f2,f3) -> if f1.ToLower() = word.ToLower() then 
                                                    printfn "'%s' is an Animal in %A that means '%s' in English \n" word f2 f3
                                                    isTranslated <- true
        if (not isTranslated) then printfn "Sorry, we don't have any translation for '%s' \n" word;;

let translatorAgent = MailboxProcessor.Start(fun translation->

    let rec translateLoop() = async{

        let! word = translation.Receive()
        printfn "Looking for a translation for: %s" word
        translate word

        return! translateLoop()
        }

    translateLoop()
    );;

translatorAgent.Post "Tigras" 
translatorAgent.Post "Viso gero" 
translatorAgent.Post "Persikas"
translatorAgent.Post "Melionas"
Console.ReadKey();; 
