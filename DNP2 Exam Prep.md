# Plan for DNP Exam

- Put all assigments into one project
- Clean assignments
- Add useful comments
- Write execises for each topic with comments for exam

## Explanations, examples and code for

#### Delegates

- A delegate variable can have the value null (no method assigned);
- If null, delegate variable must not be call -> NullReferenceException;
- Delegate variable stores method and its receiver, **no parameters**;

```
public delegate void Notifier(string sender);

 private void SayGoodBye(string sender) {
    Console.WriteLine("GoodBye from {0}", sender);
}

Notifier greetings = SayGoodBye;
greetings("John") // GoodBye from John
```

- Delegate variables are first class objects -> can be stored in a data structure, passed as parameters etc.;
- Can use *this* and be omitted, can be *static*, **NOT abstract**, can be *virtual, override, new*;

```
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

#### Interfaces - Idisposable interface
#### Inheritance
#### Generics
#### Anonymous Types and Methods

Anonymous methods are inline un-named methods.
- can be defined using the delegate keyword;
- must be assigned to a delegate;

```
Array.FindAll(integers, delegate(int value) { 
    return value % 2 == 0; 
});
```

- can access outer variables and functions;
- can be passed as a parameter;
- can be used as event handlers;
```
saveButton.Click += delegate(Object o, EventArgs e) { 
    System.Windows.Forms.MessageBox.Show("Save Successfully!"); 
};
```

Anonymous Types. The compiler will generate a `__Anonymous1` class with the specified fields and p will have that type.
```
var p new {Name = "John", Age = 25 };
```

- Anonymous type can be defined using the `new` keyword and object initializer syntax;
- var (implicitly typed variable) is used to hold an anonymous type;
- Anonymous type is a reference type;
- All properties are **read only**;
- Scope is local to the method where it is defined
- Can be send as a parameter only if the method accepts a **dynamic type**;

[Source of a lot of information](http://www.tutorialsteacher.com/csharp/csharp-anonymous-type)

#### Lambda expressions
#### Extension methods

Extension methods provide syntactical sugar by allowing partial and shared implementation outside of a class, but enable the appearance a method belongs to a class. Extension methods are compiler tricks, allowing existing classes to be extended without relying on inheritance or having to change the source code, such as: **int, list** classes or even **sealed classes, like string**.

- Can't be used to override existent methods;
- Extension method with same name and signature will not be called over instance method;
- Concept of extension methods **CAN'T** be applied to fields, properties or events;

```
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

#### LINQ
#### WPF - Concept, XAML, Code Behind, Routed Evens
#### MVVM
#### Async - Concept, await, async
#### WCF - Concept, ABC of Endpoints, Service/implementation, hosting, channels
