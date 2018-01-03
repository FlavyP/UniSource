# Plan for DNP Exam

- Put all assigments into one project
- Clean assignments
- Add useful comments
- Write execises for each topic with comments for exam

# Checklist

- [x] Delegates
- [x] Interfaces, Idisposable interface
- [x] Inheritance
- [x] Generics
- [x] Anonymous Types and Methods
- [x] Lambda expressions
- [x] Extension Methods
- [x] LINQ
- [x] WPF - Concept, XAML, Code Behind, Routed Events
- [ ] WCF - Concept, ABC of endpoints, Service/implementation, hosting, channels
- [x] MVVM
- [x] Async - Concept, await, async

## Delegates

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

## Interfaces - Idisposable interface

Interface in C# contains the declaration of the methods, properties and events. Like abstract classes, they share the fact that no instances of them can be created. Also, no bodies are allowed as well. Consider an interface like a contract - class that implements it is required to implement all of the methods and properties. All members of an interface are public.

C# does **NOT** allow multiple inheritance, it **DOES** allow for multiple interfaces implementations. Has to use the keyword **interface** and it's a coding standard to use *I* in front of the name: **IAnimal**. Makes it easier for programmers to see that it's an interface without looking at the class definition.

```sh
 interface IAnimal
    {
        string Describe();

        string Name
        {
            get;
            set;
        }
    }
```

**IDisposable** - primary use of this interface is to clean up unmanaged resources, such as database connections.

**Explicit interfaces** - used when a class implements multiple interfaces or if the interfaces share the same method. 

```sh
class ConsoleLog: ILog
{
    public void ILog.Log(string msgToPrint) // explicit implementation
    {
        Console.WriteLine(msgToPrint);
    }
}
```

## Inheritance

Inheritance allows us to define a class in terms of another class, which makes it easier to create and maintain an application. This also provides an opportunity to reuse the code functionality and speeds up implementation time.

When creating a class, instead of writing completely new data members and member functions, the programmer can designate that the new class should inherit the members of an existing class. This existing class is called the base class, and the new class is referred to as the derived class.

The idea of inheritance implements the **IS-A relationship**. For example, mammal IS A animal, dog IS-A mammal hence dog IS-A animal as well, and so on.

```sh
 class Shape {
      public void setWidth(int w) {
         width = w;
      }
      public void setHeight(int h) {
         height = h;
      }
      protected int width;
      protected int height;
   }

   // Derived class
   class Rectangle: Shape {
      public int getArea() { 
         return (width * height); 
      }
   }
```

**Initializing Base Class** - The derived class inherits the base class member variables and member methods. Therefore the super class object should be created before the subclass is created. You can give instructions for superclass initialization in the member initialization list.

## Generics

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
 
## Anonymous Types and Methods

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

## Lambda expressions

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
## Extension methods

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

## LINQ

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


## WPF - Concept, XAML, Code Behind, Routed Events

**XAML** (eXtensible Application Markup Language)

- XML-based language used for declaring object graphs;
- Most concise way to represent GUI;
- Separates front-end and back-end;
- Language that almost all WPF-related tools emit;
- A declarative Language with Flow Contorl Support;
- Objects instantiated at runtime;
- Declares a layout of User Interface;
- Everything declared in XAML can be defined in code;
- XAML complies to BAML (binary application markup language) for performance;
- XAML is case sensitive;

**Uses for XML elements in XAML:**

- Elements representing objects;
- Elements representing properties of objects;

```sh
<Button Content="Click Me" Click="OnButtonClick">
 <Button.Background>
  <LinearGradientBrush>
   <GradientStop Color="Yellow" Offset="0" />
   <GradientStop Color="Green" Offset="1" />
  </LinearGradientBrush>
 </Button.Background>
</Button>
```

**VS**

```sh
Button b = new Button();
b.Content = "Click Me";
b.Click += this.OnButtonClick;
LinearGradientBrush lgb = new LinearGradientBrush();
lgb.GradientStops.Add( new GradientStop( Colors.Yellow, 0 ) );
lgb.GradientStops.Add( new GradientStop( Colors.Green, 1 ) );
b.Background = lgb;
```

**Markup extensions**:

- *{}* used for markup extension;
- *x:Key* sets a unique key for each resource in a resource dictionary;

```sh
<Grid>
 <Grid.Resources>
  <LinearGradientBrush x:Key="FunkyBrush">
   <GradientStop Color="Yellow" Offset="0" />
   <GradientStop Color="Green" Offset="1" />
  </LinearGradientBrush>
 </Grid.Resources>
 <Button Background="{StaticResource FunkyBrush}">Click Me</Button>
</Grid>
```

**Define and Reference a Resource**:

- Define using *Page.Resource* with *x:Key="PageBackground"*;
- Reference StaticResource using *="{StaticResource PageBackground}"*;
- Reference DynamicResource using *="{DynamicResource PageBackground}"*;
- Can define resources at various levels: **aplication scope**, **Windows or Page scope**, and **Element-level scope**;
- C# code for *findResource*, *setResourceReference* and *Resources property*;

```sh
<Page.Resources>
 <SolidColorBrush x:Key="MyBrush" Color="Gold"/> 
</Page.Resources>

<Style TargetType="TextBlock" x:Key="Label"> 
 <Setter Property="Foreground" Value="{StaticResource MyBrush}"/>
</Style> 
```

**The X: prefix:**
```sh
<Page xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
x:Class="MyNamespace.MyPageCode">
 <Button Click="ClickHandler" >Click Me!</Button>
</Page>
```

- **x:key** sets a unique key for each resource in a ResourceDictionary;
- **x:Class** specifies the CLR namespace and class name for the class that provides code-behind for a XAML page;
- **x:Name** specifies a run-time object name for the instance that exists in run-time code after an object element is processed;
- **x:Static** enables a value reference that gets a static value that is not otherwise a XAML-compatible property;
- **x:Type** constructs a Type reference based on a type name;

**The layout system:**

*Layout* describes the process of measuring and arranging the members of a Panel element's Children collection then drawing them onscreen. Each time a child UIElement changes its position it has the potential to trigger a new pass by the layout system. As such, it's important to understand the events that can invoke the layout system, as unnecessary invocation can lead to poor application performance.

- A child UIElement begins layout process by first having its core properties measured;
- Sizing properties defined on FrameWorkElement are evaluated, such as Width, Height and Margin;
- Panel specific logic is applied, such as Dock direction or stacking Orientation;
- Content is arranged after all children have been measured;
- Children collection is drawn to screen;
- The process is invoked again if additional Children are added to teh collection, a Layout Transform is applied, or the Update Layout method is called;

**Panel elements and Custom Layout Behaviours**

- **Canvas** defines an area within which you can explicitly position child elements by coordinates relative to the Canvas area;
- **DockPanel** defines an area within which you can arrange child elements either horizontally or vertically, relative to each other;
- **Grid** defines a flexible grid area consisting of columns and rows;
- **StackPanel** arranges child elements into a single line that can be oriented horizontally or vertically;
- **VirtualizingPanel** - provides a framework for Panel elements that *virtualize* the child data collection. This is an abstract class;
- **WrapPanel** - positions child elements in sequential position from left to right, breaking content to the next line at the edge of the containing box. Subsequent ordering happens sequentially from top to bottom or right to left, depending on the value of the Orientation property;

**Events and XAML Code-Behind**

- Clicking buttons;
- Entering text;
- Selecting lists;
- Gaining focus;
```sh
<Button Click="ClickHandler" >Click Me!</Button> 
```
```sh
void ClickHandler(object sender, RoutedEventArgs e)
 {
  Button b = e.Source as Button;
  b.Background = Brushes.Red;
 } 
```

**Routed Events** 

- Type of event that can invoke handlers on multiple listeners in an element tree, rather than just on the object that raised the event; 
- Routed event is a CLR event that is backed by an instance of the RoutedEvent class and is processed by the WPF event system;

- Define leaf elements inside a container element (CommonClickHandler);
- Handle leaf events at the container level;

```sh
<Border Height="50" Width="300" BorderBrush="Gray" BorderThickness="1">
 <StackPanel Background="LightGray" Orientation="Horizontal"
Button.Click="CommonClickHandler">
  <Button Name="YesButton" Width="Auto" >Yes</Button>
  <Button Name="NoButton" Width="Auto" >No</Button>
  <Button Name="CancelButton" Width="Auto" >Cancel</Button>
 </StackPanel>
</Border> 
```

```sh
private void CommonClickHandler(object sender, RoutedEventArgs e) {
 FrameworkElement feSource = e.Source as FrameworkElement;
 switch ( feSource.Name ) {
  case "YesButton":
  // do something here ...
  break;
  case "NoButton":
  // do something ...
  break;
  case "CancelButton":
  // do something ...
  break; }
 e.Handled=true;
} 
```

**Button -> StackPanel -> Border**

**WPF** is a new foundation for building Windows-based applications by using Media, Documents and Application UI. Features and capabilities: 

- Page layout management;
- Data Binding;
- 2D and 3D graphics, Multimedia, Animations;
- Documents and printing;
- Security, Accessibility, Localization and Interoperability with WinForms controls;

**The code-behind file contains event-handler code**

**Control Templates** - built-in appearance and behavior. Behavior is defined by a predefined control class. Appearance is defined by a default ControlTemplate.

- Define a <Style> for a type of control;
 - Set the Template proeprty to a ControlTemplate;
 - Define a ContentPresenter for the control content;
 
**Triggers** define a list of setters that are executed if the specified condition is fulfilled. WPF knows three different types of triggers.

- **Property Triggers** get active when a property gets a specified value;
- **Event Triggers** get active when a specified event is fired;
- **Data Triggers** get active when a binding expression reaches a specified value;

**Data Binding**

- Binding target object;
- Binding target dependency property;
- Binding source;
- Path to the binding source property;
- Binding to: Class Property, Multiple Controls to a Class, Full Object, XML Data, Another UI Element;

**Data Binding Modes:**
- OneWay;
- TwoWay;
- OneWayToSource;
- OneTime;


## MVVM (Model-View-ViewModel)

Design pattern used to delimitate application layers and structure your code to write maintainable, testable and extensible applications.
The key benefit is allowing true separation between the View and Model beyond achieving separation and the efficiency that you gain from having that. What that means in real terms is that when your model needs to change, it can be changed easily without the view needing to and vice-versa.

**Model Responsabilities** 

It is the client side data model that supports the views in the application.

− It simply holds the data and has nothing to do with any of the business logic, composed with properties and variables;
- Some of those properties may reference other model objects and create the object graph which as a whole is the model objects;
- Model objects should raise property change notifications which in WPF means data binding;
- The last responsibility is validation which is optional, but you can embed the validation information on the model objects by using the WPF data binding validation features via interfaces like INotifyDataErrorInfo/IDataErrorInfo;
- Represents the underlying data structures used in the applcation. Can represent a connection to an external source;

**ViewModel Responsabilities** 

The main purpose and responsibilities of views is to define the structure of what the user sees on the screen. The structure can contain static and dynamic parts. The primary responsibility of the ViewModel is to provide data to the view, so that view can put that data on the screen.

− It acts as the link/connection between the Model and View and makes stuff look pretty. Used to prepare the data for the views. Aggregation of different classes (other ViewModels) a view can bind to.
- Allows the user to interact with data and change the data;
- ViewModel should also manage any navigation logic like deciding when it is time to navigate to a different view;
- Should be able to handle the appropriate sequencing of calls to make the right thing happen based on user or any changes on the view;

**View Responsabilities** 

− It simply holds the formatted data and essentially delegates everything to the Model. Mostly XAML code that defines how the view looks and how the user interacts with it. View elements bind to Properties in the ViewModel.
- Static parts are the XAML hierarchy that defines the controls and layout of controls that a view is composed of;
- Dynamic part is like animations or state changes that are defined as part of the View;
- The primary goal of MVVM is that there should be no code behind in the view;
- It's impossible that there is no code behind in the view. In view you at least need the constructor and a call to inialize the component;
- The idea is that the event handling, action and data manipulation logic code shouldn't be in the code behind in the View;
- There are also other kinds of code that have to go in the code behind, any code that's required to have a reference to UI element is inherently view code;

**Maintainability**

- A clean separation of different kinds of code should make it easier to go into one or several of those more granular and focused parts and make changes without worrying;
- Means you can remain agile and keep moving out to new releases quickly;

**Testability**

- With MVVM, each piece of code is more granular and if it is implemented right your external and internal depedencies are in separate pieces of code from the parts with the core logic that you would like to test;
- Makes it a lot easier to write unit tests against a core logic;
- Make sure it works right when written and keeps working even when things change in maintenance;

**Extensibility**

- It sometimes overlaps with maintainability, because of the clean separation boundaries and more granular pieces of code;
- You have a better chance of making any of those parts more reusable;
- It has also the ability to replace or add new pieces of code that do similar things into the right places in the architecture;

The obvious purpose of MVVM pattern is abstraction of the View which reduces the amount of business logic in code-behind. However, following are some other solid advantages:

- ViewModel is easier to unit test than code-behind or event-driven code;
- You can test it without awkward UI automation and interaction;
- The presentation layer and the logic is loosely coupled;
- The View can be switched - therefore the naming conventions in the ViewModel are important;
- The model can be switched (could interface with different service technologies such as WCF, SOAP or databases)
- Clear delimitation of the application layers;
- Reusability;
- Components can be developed independently (by different vendors);
- Isolated unit testing;

**Disadvantages**

- For simple UIs, MVVM might be overkill;
- Similar in bigger cases, can be hard to design the ViewModel;
- Debugging would be bit difficult when we have complex data bindings;

## Async - Concept, await, async

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
 
## [NEEDS WORK]() WCF (Windows Communication Foundation) - Concept, ABC of Endpoints, Service/implementation, hosting, channels

**WCF supports SOA (Service Oriented Architecture):** 
- Developers do not have to learn WSDL;
- Functionality is handled by the runtime;
- Tools to enable easy creation and consumption of service;
- Just because you have exposed an interface over a Web Service protocol stack does not mean that you have created part of a SOA;
- SOA helps you design services and WCF enables you to implement these services;

- Give a principal namespace for WCF;
- Attributes control exposure of types and methods;

```sh
[ServiceContract(Namespace="http://")]
public interface IBank {
 [OperationContract]
 decimal GetBalance(string account);
}
```

**ServiceContract:**
- Can be used on interfaces or classes;
- Is identified by tools and environments designed for WCF;
- Supports services;
- Are analogous to interfaces on a polymorphic object - caller may not care about other contracts;
- Are only visible to clients if exported on an endpoint;
- Contains one or more operations;

**Namespace serves to disambiguate types and operations in service metadata. Not to be confused with language-level namespace**
**Methods are only visible in service contract if marked with OperationContract**

- Parameters and return values must be marshaled between client and server;
- CLR types are mapped to XML Infoset by serialization;
- WCF enables you to define custom serialization;
- Serialized data is packed into the message;
- Contents and structure of message must be understood by client or service at the other end;
- Data and message contracts provide control over these areas;

**Life Cycle of a Self-Hosted WCF Service**
- Create a ServiceHost object;
- Open the ServiceHost to start listening;
- Stop the ServiceHost from closing;
- Close and dispose of the ServiceHost object;

**To call a WCF service, the client requires the following:**
- A channel over which to pass messages (transport channel at the bottom && the makeup of the channel derives from the binding);
- A client-side representation of the contract;
- A way of creating WCF messages to pass across the channel and a way to of retrieving message contents;
- An address for the WCF service;

**Can use ChannelFactory class to create a proxy or instantiate proxy class generated by a tool**

**Creating a Service Instance Per-Call**
- New instance created for every call and disposed of afterwards;
- As many instances as concurrent calls to the service;
- Only ever one client call in the instance;
- No state held in instance between calls;

**Creating a Single Service Instance**
- Service instance created when service starts;
- Only one single instance of the service exists;
- This handles all calls from all clients so concurrency is implicit;
- In-memory state held between calls;

```sh
[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
```
