# Exam Topics

- [x] Functional programming in JavaScript
  - Summarise functional programming in JavaScript.
  - Explain Higher-order functions and demonstrate their use in JavaScript programming.
  - Use the relevant Array and Function methods as part of your demonstration.
- [x] The JavaScript object model
  - Summarise the JavaScript object model and contrast it to object models from other languages like Java or C#
  - Explain how ‘this’ works in JavaScript, and how to control it using bind
  - Demonstrate the use of prototypes and constructors in creating and using JavaScript objects
- [x] Asynchronous programming
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

## Asynchronous programming

JavaScript is single-threaded! One single thread handles the event loop

The problem with the event loop is that if we keep pushing multiple messages to the queue and the call stack takes too long to finish running we will end up delaying processing all these messages and making our code run slowly. If we’re on browsers we can end up delaying renders and making the whole page seem slow.

This also means that any processing intensive tasks will end up blocking your whole code execution because (until a while ago) we had no way of running them in a separate thread.

**Web Workers** 

- Scripts executed from an HTML page that runs on a background thread away from the main execution thread;
- Data is sent between the main thread and workers through messages;
- Utilize web workers to run process intensive tasks without creating blocking instances;
- Need 2 separate files (main, worker) since worker needs to be run in an isolated thread;
- Data sent between main thread and workers are **copied rather than shared** (think about memory allocation and speed of data transfer);
- Event listener in worker.js to look out for messages from main;
- Once the worker hears from main, it starts running the code within the function block;
- We also need a listener in main to hear back from worker;
- Make sure to close the worker thread at the end of event listener in worker;
- Does not support cloning functions, DOM nodes and Error objects and it also won’t walk through the prototype chain and duplicate it too;

**Service Worker:**
- Background service that handles network requests. Ideal for dealing with offline situations and background syncs or push notifications. Cannot directly interact with the DOM. Communication must go through the Service Worker’s postMessage method.

**Web Worker:**

- Mimics multithreading, allowing intensive scripts to be run in the background so they do not block other scripts from running. Ideal for keeping your UI responsive while also performing processor-intensive functions. Cannot directly interact with the DOM. Communication must go through the Web Worker’s postMessage method.
**WebSocket:**

- Creates an open connection between a client and a server, allowing persistent two-way communication over a single connection. Ideal for any situation where you currently use long-polling such as chat apps, online games, or sports tickers. Can directly interact with the DOM. Communication is handled through the WebSocket’s send method.


**SharedMemory**

- Not many browsers support this;
- Sharding memory between two threads: need to use a new data structure available globally which is called SharedArrayBuffer;
- This shared buffer is the memory itself and a typed array on top of that memory area works like a view;

As the comments in the code above show, we:

1. Create a Worker
2. Create a shared memory area by using SharedArrayBuffer
3. Create a view (TypedArray) on top of that shared memory
4. Add 10 even numbers to our shared array
5. Send the shared memory (not the Shared Array) to our worker
6. Schedule a write in the 0 position of our shared memory area (represented through a TypedArray) after 5 seconds

When our worker receives that shared memory we:

1. When the worker receives that memory it creates a view (TypedArray) on top of that
2. Now our worker has access to that shared memory through the TypedArray we created so we schedule it to read the first position of that TypedArray after 10 seconds (because by that time our main thread will already have changed what’s in that index)

**Promises:**

A promise is an object which can be returned synchronously from an asynchronous function that may produce a value some time in the future: a resolved value or a reason that it's not resolved (error). A promise has 3 states: **pending, fulfilled, rejected**. Can attach callbacks to handle the fulfilled value or the reason for rejection. Promises are eager, meaning that a promise will start doing whatever task you give it as soon as the promise constructor is invoked.

Once settled, a promise can not be resettled. Calling resolve() or reject() again will have no effect. The immutability of a settled promise is an important feature.

Because .then() always returns a new promise, it’s possible to chain promises with precise control over how and where errors are handled. Promises allow you to mimic normal synchronous code’s try/catch behavior.

Like synchronous code, chaining will result in a sequence that runs in serial. In other words, you can do:
```sh
fetch(url)
  .then(process)
  .then(save)
  .catch(handleErrors)
;
```
Assuming each of the functions, fetch(), process(), and save() return promises, process() will wait for fetch() to complete before starting, and save() will wait for process() to complete before starting. handleErrors() will only run if any of the previous promises reject.

**Promise.all** - promise for the combined result of multiple parallel-waiting promises;

**Callback function** - function passed into another function as an argument, which is then invoked inside the outer function to complete some kind of routine or action. Often used to continue code execution after an asynchronous operation has completed.

**Async/await**:

In an async function, calls return a Promise (if set so), unless marked with **await**. If marked with await, it will returned the actual result from the function since it will wait for that. When you do, the execution of the **async** function is paused until the promise is resolved.

Because **Object.assign()** copies the properties (including functions) from one object to another, you are increasing the memory burden. When you use prototype delegation and the this keyword you don’t duplicate the functions and properties, you delegate instead. That’s the value of prototypal inheritance, but it doesn’t mean you have to emulate classes. I’ll be exploring this in a future article.

In classical inheritance, we tend to think of our objects in terms of what they are, but when using object composition we think about what they can do.
Classical inheritance is difficult to do correctly, and difficult to change later.
Javascript provides simple tools for object composition that avoid the pitfalls of classical inheritance

The **Object.create()** method creates a new object with the specified prototype object and properties.

