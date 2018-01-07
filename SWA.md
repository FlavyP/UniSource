# Exam Topics

- [x] Functional programming in JavaScript
  - Summarise functional programming in JavaScript.
  - Explain Higher-order functions and demonstrate their use in JavaScript programming.
  - Use the relevant Array and Function methods as part of your demonstration.
- [ ] The JavaScript object model
  - Summarise the JavaScript object model and contrast it to object models from other languages like Java or C#
  - Explain how ‘this’ works in JavaScript, and how to control it using bind
  - Demonstrate the use of prototypes and constructors in creating and using JavaScript objects
- [ ] Asynchronous programming
  - Single-threaded
  - Multi-threaded
  - Shared memory
  - Promises
  - Callbacks
  - Web Workers
- [ ] Client/Server programming
  - Demonstrate client/server programming in Single-page web application
  - Asynchronous server calls and callbacks
  - Promises
  - JSON
  - Web services
- [ ] Patterns of DOM programming
  - Classic Model-View-Controller
  - 1-way data flow
  - 2-way data binding
- [ ] Object construction
  - Demonstrate the different ways of creating objects in JavaScript and contrast them.
  - Compare object construction in JavaScript to other languages.
- [ ] Object composition and inheritance
  - Demonstrate the different ways of object composition and inheritance in JavaScript and contrast them.
  - Compare to other languages
- [ ] JavaScript run-time model
  - Demonstrate how the JavaScript run-time model is used in an application
  - Demonstrate how the following elements interact
    - Event queue
    - Call stack
    - Web Workers
    
## Functional programming in JavaScript

JavaScript is a multi-paradigm language, meaning that it supports programming in many different styles. Other styles supported by JavaScript include procedural (imperative) programming (like C), where functions represent a subroutine of instructions that can be called repeatedly for reuse and organization, object-oriented programming, where objects — not functions — are the primary building blocks, and of course, functional programming. JavaScript has the most important features needed for functional programming.

- **First class functions** - ability to use *functions as data values* such as passing functions as arguments, return functions, assign functions to variables and object properties. This allows for **higher order functions** which enable currying, composition.
- **Anonymous functions and concise lamdba syntax** - such as *x => x*2*

In imperative programming, most data structures are mutable to enable efficient in-place manipulation of objects and arrays. Some features that functional languages have and JavaScript doesn't:

- **Purity** - expressions with side-effects are not allowed;
- **Immutability** - expressions evaluate to new data structures. This may sound inefficient, but most functional languages use trie data structures under the hood, which feature structural sharing: meaning that the old object and new object share references to the data that is the same.

**const** - keyword in ES6, can't be reassigned to refer to a different value. Does **NOT** represent an immutable value. A const object can't be reassigned to refer to a completely different object, but the object it refers to can have its properties mutated.

JavaScript technically supports recursion, but most functional languages have a feature called tail call optimization. Tail call optimization is a feature which allows recursive functions to reuse stack frames for recursive calls. Without tail call optimization, a call stack can grow without bounds and cause a stack overflow.

**Composition** - take one function and put it into another function; 
Filter, map, reduce - high order functions;

A **callback** is a function that gets executed at the end of an operation, once all of the other operations of been completed. Usually this callback function is passed in as the last argument in the function. Frequently, it’s defined inline as an anonymous function. This is very useful in a web programming environment, where a script may send an Ajax request off to a server, and then need to handle the response whenever it arrives, with no knowledge in advance of network latency or processing time on the server. Node.js frequently uses callbacks to make the most efficient use of server resources. This approach is also useful in the case of an app that waits for user input before performing a function.

**Currying** - you can pass all of the arguments a function is expecting and get the result, or pass a subset of those arguments and get a function back that’s waiting for the rest of the arguments.

## The JavaScript object model

JavaScript is an object-based language based on prototypes, rather than being class-based (like Java is). 

**Class-based languages:**
- Class defines all of the properties (methods and fields);
- An instance is the instantiation of a class and has exactly the same properties of its parent class;
- Define a class in a separate class definition. In there you define special methods, constructors etc;
- Create a hierarchy of classes through the class definitions, specifying the new class is a subclass of an existing class;

**Prototype-based languages:**
- Simply has objects;
- Notion of *prototypical object* - object used as a template from which to get the initial properties for a new object;
- Any object can specify its own properties, either when you create it or at run time;
- Any object can be associated as the *prototype* for another;
- JS does not have a class definition separate from the constructor; You define a constructor function to create objects with a particular initial set of properties and values;
- Any JS function can be used as a constructor;
- You use the **new** operator with a constructor function to create a new object;
- JS implements inheritance by allowing you to associate a *prototypical* object with any constructor function;
- You need to call the *super classes* constructor, add new properties and assign a new object derived from *SuperClass.prototype* as the prototype for the sub class;
- At run time you can add or remove properties of any object;
- If you add a property to an object that is used as the prototype for a set of objects, the objects for which it is the prototype also get the new property;

The **bind()** method creates a new function that, when called, has its this keyword set to the provided value, with a given sequence of arguments preceding any provided when the new function is called.

