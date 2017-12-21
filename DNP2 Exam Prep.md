# Plan for DNP Exam

- Put all assigments into one project
- Clean assignments
- Add useful comments
- Write execises for each topic with comments for exam

## Explanations, examples and code for

### Delegates

- A delegate variable can have the value null (no method assigned);
- If null, delegate variable must not be call -> NullReferenceException;
- Delegate variable stores method and its receiver, **no parameters**;

```sh
public delegate void Notifier(string sender);

 private void SayGoodBye(string sender) {
    Console.WriteLine("GoodBye from {0}", sender);
}

Notifier greetings = SayGoodBye;
greetings("John") // GoodBye from John
```

- Delegate variables are first class objects -> can be stored in a data structure, passed as parameters etc.;
- Can use *this* and be omitted, can be *static*, **NOT abstract**, can be *virtual, override, new*;

```sh
var delList = new List<Notifier> { SayGoodBye, SayHello };
    foreach(var del in delList) {
        del("John");
    }
```
- **MUST match** signature of Delegate type: number of params, param type, return type;
- Delegate can hold multiple methods at the same time;
- Can also have predicate delegates (allows a predicate function to be defined and passed as a parameter to another function) - Takes single parameter and returns a bool;

```sh
private static bool isEven(int val) {
        return val % 2 == 0;
}

int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int[] evenIntegers = Array.FindAll(integers, isEven);

evenIntegers.ToList().ForEach(Console.WriteLine);
```

### [NEEDS WORK]() Interfaces - Idisposable interface

Interface in C# contains the declaration of the methods, properties and events.
### [NEEDS WORK]() Inheritance
### Generics

Introduced in C# 2.0, they allow us to define a class with placeholders for the type of its fields, methods, parameters, etc. Generics replace these placeholders with some specific type at compile time.

Generic class can be defined using **angle brackets <>**:

```sh
class MyGenericClass<T>
{
    private T genericMemberVariable;

    public MyGenericClass(T value)
    {
        genericMemberVariable = value;
    }

    public T genericMethod(T genericParameter)
    {
        Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(),genericParameter);
        Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);
            
        return genericMemberVariable;
    }

    public T genericProperty { get; set; }
}
```

Class is defined with **<T>**. **<>** indicates that class is generic and underlying type would be defined later, for now consider it as *T*. The compiler assigns the type based on the type passed by the caller when instantiating a class. Example:
 
 ```sh
 MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);

int val = intGenericClass.genericMethod(200);

//Parameter type: int, value: 200 
//Return type: int, value: 10

**WITH STRING:**

MyGenericClass<string> strGenericClass = new MyGenericClass<string>("Hello Generic World");

strGenericClass.genericProperty = "This is a generic property example.";
string result = strGenericClass.genericMethod("Generic Parameter");

//Parameter type: string, value: Generic Parameter 
//Return type: string, value: Hello Generic World
 ```
 **Generic base class:**
 
 When deriving from a generic base class, you must provide a type argument instead of the base-class's generic type parameter:
 
 ```sh
 class MyDerivedClass : MyGenericClass<string>
 ```
 
 If you want to the derived class to be generic then no need to specify type for the generic base class:
 
 ```sh
 class MyDerivedClass<U> : MyGenericClass<U>
 ```
 
 If the generic base class has contraints, derived class must use the same constraints:
 
 ```sh
 class MyGeneric Class<T> where T: class
 
 ...
 
 class MyDerivedClass<U> : MyGenericClass<U> where U:class
 ```
 
 **Generic Delegates:**
 
 A generic delegate can be defined the same way as delegate but with genric type.
 
 ```sh
 class Program {
  public delegate T add<T>(T param1, T param2);
  
  static void Main(string[] args) {
      add<int> sum = AddNumber;
      
      Console.WriteLine(sum(10,20)); //30
      
      add<string> conct = Concate;
      
      Console.WriteLine(conct("Hello", "World!!")); // Hello World!!
      
      public static int AddNumber(int val1, int val2) {
        return val1 + val2;
    }

    public static string Concate(string str1, string str2) {
        return str1 + str2;
    }
}
```

Add delegate is generic. In Main, it has defined add delegate of int type variable sum. It points to AddNumber() which has int types parameters. Another variable of add delegate uses string type, so it can point to Concate method. You can use generic delegates for diferent methods of different types of parameters.

Generics can be applied to the following:

- Interface;
- Abstract class;
- Class;
- Method;
- Static method;
- Property;
- Event;
- Delegates;
- Operator;

**Advantages of Generics:**

- Increases the reusability of code;
- Type safety. You get compile errors if you try to use a different type of data than the one specified in the definition;
- Performance advantage because it removes the possibilities of boxing and unboxing;
- Compiler applys specified type for generics at compile time;

**Constraints in Generics:**
 
 C# includes Contraints to specify which type of placeholder type with the generic class is allowed. It will give a compile time error if you try to instantiate a generic class suing a placeholder type that is now allowed by a constraint. If the generic constraints specifies that only reference type can be used with the generic class, then you cannot use value type to create an object of generic type.
 
 Constraints can be applied using the **where** keyword. In the following example, MyGenericClass specifies constraints that only a reference type can be used with MyGenericClass. This means that only a class can be a placeholder type, not the primitive types, struct, etc.
 
```sh
class MyGenericClass<T> where T: class
```

Now, we cannot use int as a placeholder type, since it will give a compile time error. String ro any class type is valid because it is a reference type.

```sh
MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10); //ERROR
MyGenericClass<string> strGenericClass = new MyGenericClass<string>("Hello World");
MyGenericClass<Student> stdGenericClass = new MyGenericClass<Student>(new Student());
```

| Constraint  |Description|
|---|---|
|where T : class|Type must be reference type|
|where T : struct|Type must be value type|
|where T : new()|Type must have public parameterless constructor|
|where T : base class name|Type must be or derive from the specified base class|
|where T : interface name|Type must be or implement the specified interface|
|where T : U|Type supplied for T must be or derive from the argument supplied for U|

**Multiple constraints** - generic class can have multiple constraints:

```sh
class MyGenericClass<T, U> where T: class where U:struct
```

**Constraint on generic methods:**
- Constraints specifies the kind of types allowed with the generics;
- Constraints can be applied using the **where** keyword;
- Six types of constraints: class, struct, new(), base class name, interface and derived type;
- Multiple constraints also can be applied;
```sh
class MyGenericClass<T> where T: class {
    public T genericMethod<U>(T genericParameter, U anotherGenericType) where U: struct {
        Console.WriteLine("Generic Parameter of type {0}, value {1}", typeof(T).ToString(),genericParameter);
        Console.WriteLine("Return value of type {0}, value {1}", typeof(T).ToString(), genericMemberVariable);
            
        return genericMemberVariable;
    }        
}
```
 
### Anonymous Types and Methods

Anonymous methods are inline un-named methods.
- can be defined using the delegate keyword;
- must be assigned to a delegate;

```sh
Array.FindAll(integers, delegate(int value) { 
    return value % 2 == 0; 
});
```

- can access outer variables and functions;
- can be passed as a parameter;
- can be used as event handlers;
```sh
saveButton.Click += delegate(Object o, EventArgs e) { 
    System.Windows.Forms.MessageBox.Show("Save Successfully!"); 
};
```

Anonymous Types. The compiler will generate a `__Anonymous1` class with the specified fields and p will have that type.
```sh
var p new {Name = "John", Age = 25 };
```

- Anonymous type can be defined using the `new` keyword and object initializer syntax;
- var (implicitly typed variable) is used to hold an anonymous type;
- Anonymous type is a reference type;
- All properties are **read only**;
- Scope is local to the method where it is defined
- Can be send as a parameter only if the method accepts a **dynamic type**;

[Source of a lot of information](http://www.tutorialsteacher.com/csharp/csharp-anonymous-type)

### Lambda expressions

Introduced in C# 3.0 along with LINQ, being a shorter way to represent an anonymous method, using some special syntax.

```sh
s => s.Age > 12 && s.Age <20
```

- Lamdba expression can have multiple parameters

```sh
(s, youngAge) => s.Age >= youngAge;
```

- Can also give type to each parameters, if confusing:
 
```sh
(Student s, int youngAge) => s.Age >= youngAge;
```

- There are lamdba expression with no parameters

```sh
() => Console.WriteLine("Lamdba 0-param expression")
```

- Can have multiple statements in body expression of lambda:

```sh
(s, youngAge) => {
    Console.WriteLine("Student {0}", s);
    
    Return s.Age >= youngAge;
```

- Can have a local variable in Lambda Expression:

```sh
s => {
    int youngAge = 18;
    return s.Age >= youngAge;
}
```

- Can have lamdba as a Func Delegate. First params are input, last param is always the return type:

```sh
Func<Student, bool> isStudentTeenager = s => s.age > 12 && s.age < 20;

Student std = new Student() { age = 21 };

bool isTeen = isStudentTeenAger(std);
```

- Can have lambda as Action Delegate, which has no return type, can only have input parameters:

```sh
Action<Student> PrintStudentDetail = s => Console.WriteLine("Name: {0}, Age: {1} ", s.StudentName, s.Age);

Student std = new Student(){ StudentName = "Bill", Age=21};

PrintStudentDetail(std);
```

- Can also have lambda expression in LINQ query:

```sh
IList<Student> studentList = new List<Student>(){...};

Func<Student, bool> isStudentTeenAger = s => s.age > 12 && s.age < 20;

var teenStudents = studentList.Where(isStudentTeenAger).ToList<Student>();
```

**OR**

```sh
IList<Student> studentList = new List<Student>(){...};

Func<Student, bool> isStudentTeenAger = s => s.age > 12 && s.age < 20;

var teenStudents = from s in studentList
                   where isStudentTeenAger(s)
                   select s;
```
### Extension methods

Extension methods provide syntactical sugar by allowing partial and shared implementation outside of a class, but enable the appearance a method belongs to a class. Extension methods are compiler tricks, allowing existing classes to be extended without relying on inheritance or having to change the source code, such as: **int, list** classes or even **sealed classes, like string**.

- Can't be used to override existent methods;
- Extension method with same name and signature will not be called over instance method;
- Concept of extension methods **CAN'T** be applied to fields, properties or events;

```sh
public static class StringExtension {
        public static int WordCount(this String str) {
            return str.Split(new char[] { ' ', '.', '?', ','}, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
```

Resolution of an extension method is based on scope:
- A *Sort()* method that extends `IEnumerable<T>` is visible on an array;
- When using `List<T>`, since it has it's own *Sort()*, it's using the class implementation and **NOT** the extension method.

Extension method considerations and practices:
- Methods are not polymorphic, they are statically bound at compile time;
- Extend as small a part of the class hierarchy as possible;
- Use polymorphic/virtual base-class methods whenever possible;
- Good canditates: operations over collections, utility functions and types to which we don't have code;
- The first parameter of an extension method must be of the type for which the method is appliable, preceded by the **this** keyword;
- Extension methods can be used anywhere in the application by including the namespace of the extension method;

### LINQ

Language-Integrated Query (LINQ) - powerful query language introduced with .NET 3.5, used to retrieve data from different sources. It eliminates the mismatch between programming languages and databases, providing a single querying interface for different types of data sources.

SQL - used to CRUD data from a database;
LINQ - used to CRUD data from different types of data sources like Object Collection, SQL server database, XML, web services;

Example - C# 2.0 had to loop a collection to get certain objects. Now we can "select where";

**Advantages of LINQ:**

- Familiar Language: don't have to learn a new query language for each type of data;
- Less coding: reduces the amount of code written compared to traditional approaches;
- Readable code: LINQ makes code readable for other developers, easy to understand and maintain;
- Compile time safety - provides type checking of objects at compile time;
- Shaping data - can retireve data in different shapes (can select only 2 properties of an object with more);
- Can be used with query expressions and lamdba/extension methods;


```sh
var CommonWords = 
    from w in wordOccurances
    where w.Count > 2
    select new {w.Word, w.Count};
```

**OR**

```sh
var CommonWords = 
    wordOccurances.
    Where(w => w.Count > 2).
    Select(w => new {w.Word, w.Count});
```

**LINQ different cool methods to use:**

- Aggregate;
- Average;
- Cast;
- Contains;
- Count;
- Distinct;
- Except;
- First;
- GroupB;
- Join;
- Last;
- Min / Max;
- OfType;
- OrderBy / OrderByDescending;
- Range;
- Reserve;
- SelectMany;
- Sum;
- ToDictionary / ToList / Union; 

**Walkthrough:**

```sh
IEnumerable<int> passingScores = from score in scores
where score >= 60
select score;
```

**is transformed by the compiler into:**

```sh
IEnumerable<int> passingScores = scores.Where((int score) >= 60);
```

**Then to delegate and method:**

```sh
Func<int, bool> test = delegate(int score) { return score >= 60; };
IEnumerable<int> passingScores = scores.Where(test);
```


### [NEEDS WORK]() WPF - Concept, XAML, Code Behind, Routed Evens
### [NEEDS WORK]() MVVM
### Async - Concept, await, async

**Why Async?**
- Responsiveness in applications;
- Avoid blocking threads;
- Paralellism;

**Async in C# 4.0:**

Callback based programming - method for kicking off work I/O or CPU bound work on a background thread. Events or delegates used to handle completion and progress;

```sh
static void TraditionalAPM() {
 HttpWebRequest request = WebRequest.Create (url) as HttpWebRequest;
 request.BeginGetResponse( Callback, request);
}

static void Callback( IAsyncResult iar ) {
 HttpWebRequest request = iar.AsyncState as HttpWebRequest;
 HttpWebResponse response = request.EndGetResponse(iar) as HttpWebRequest;
}
```

*Problems:*
- Async programming is much harder than synchronous programming;
- Programming concepts not usable, such as try-catch, for loop etc;
- Uncertainty of location, which thread at what time - UI thread, Background thread?;

**Async in C# 5.0:**

*Goals:*
- No more callbacks;
- Compiler handles the hard work using new keywords provided in C# 5.0;
- No more worrying about threading;
- Can always return to the same thread you left off on;

**TaskParallel Library (TPL) introduced in .NET 4.0, enhanced in .NET 4.5 with special keywords included in C3 5.0**

**Task class:**
- Captures a unit of computation;
- Task<T> captures a unit of computation that returns T;
- Running tasks can be requested cancelled;
 - Signal token created by CancellationTokenSource class;
 - Other code signal token supplied to task;
- Task method checks if cancellation is requested. Throws OperationCanceledException to accept cancellation;
- Can check status via Task.Status;
```sh
 task = Task.Run( () => {
  if( token.IsCancellationRequested) {
   throw new OperationCanceledException( token );
  }
 }
```
**C# 5.0 await operator**
 
 - **await** keyword for methods returning **Task** or **Task<T>**
 - Yields control to calling thread until awaited task completes;
 - Results gets returned;
 - Allows you to program just like synchronous programming;
 - When Task is awaited, the thread will **NOT** be blocked;
 - Result of a Task<T> is the generic argument and is returned when awaiting;
 - Complex control flow under the hood made stunningly simple by compiler;

**Compiler interpretation** - Whenever a Task is awaited, the awaiting thread will return from the method, so it can do other things, and come back to the method when the Task is completed!

```sh
WebClient client = new WebClient();
String result = await client.DownloadStringTaskAsync(...);
```

**C# 5.0 async Modifier**

- Marks method or lamdba asyncrhonous;
- Methods making use of **await** must be marked **async**;
- Can easily define own async methods;
- Async methods can return **void, Task or Task<T>**;
 
**Compiler interpretation** - An async method will be split up by the compiler whenever the await keyword is used, so the calling thread will actually return from the method before it reaches the end.

```sh
async static void DoStuff() {
 string result = await client.DownloadStringTaskAsync(...);
}
```

**Static Task Utilit Methods:**

- **Task.Run()** - creates a task from a delegate that runs on the ThreadPool;
- **Task.Delay()** - creates a task that completes after a timespan;
- **Task.WhenAll()** - creates a task that completes when all supplied tasks are completed;
- **Task.WhenAny()** - creates a task that completes when any of the supplied tasks completes;
- **Task.WaitAll()** - blocks the current thread until all of the supplied tasks are completed;
- **Task.WaitAny()** - blocks the current thread until any of the supplied tasks are completed;
 
**Async Improves Responsiveness:**

**Web Access** - HttpClient, SyndicationClient;
**Working with files** - StorageFile, StreamWriter, StreamReader, XmlReader;
**Working with images** - MediaCapture, BitmapEncoder, BitmapDecoder;
**WCF programming** - Synchronous and Asynchronous Operations;
 
### [NEEDS WORK]() WCF - Concept, ABC of Endpoints, Service/implementation, hosting, channels
