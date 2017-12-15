# Dillinger

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

Dillinger is a cloud-enabled, mobile-ready, offline-storage, AngularJS powered HTML5 Markdown editor.

  - Type some Markdown on the left
  - See HTML in the right
  - Magic

# New Features!

  - Import a HTML file and watch it magically convert to Markdown
  - Drag and drop images (requires your Dropbox account be linked)


You can also:
  - Import and save files from GitHub, Dropbox, Google Drive and One Drive
  - Drag and drop markdown and HTML files into Dillinger
  - Export documents as Markdown, HTML and PDF

Markdown is a lightweight markup language based on the formatting conventions that people naturally use in email.  As [John Gruber] writes on the [Markdown site][df1]

> The overriding design goal for Markdown's
> formatting syntax is to make it as readable
> as possible. The idea is that a
> Markdown-formatted document should be
> publishable as-is, as plain text, without
> looking like it's been marked up with tags
> or formatting instructions.

This text you see here is *actually* written in Markdown! To get a feel for Markdown's syntax, type some text into the left window and watch the results in the right.

### Tech

Dillinger uses a number of open source projects to work properly:

* [AngularJS] - HTML enhanced for web apps!
* [Ace Editor] - awesome web-based text editor
* [markdown-it] - Markdown parser done right. Fast and easy to extend.
* [Twitter Bootstrap] - great UI boilerplate for modern web apps
* [node.js] - evented I/O for the backend
* [Express] - fast node.js network app framework [@tjholowaychuk]
* [Gulp] - the streaming build system
* [Breakdance](http://breakdance.io) - HTML to Markdown converter
* [jQuery] - duh

And of course Dillinger itself is open source with a [public repository][dill]
 on GitHub.

### Installation

Dillinger requires [Node.js](https://nodejs.org/) v4+ to run.

Install the dependencies and devDependencies and start the server.

```sh
$ cd dillinger
$ npm install -d
$ node app
```

For production environments...

```sh
$ npm install --production
$ NODE_ENV=production node app
```

### Plugins

Dillinger is currently extended with the following plugins. Instructions on how to use them in your own application are linked below.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md] [PlDb] |
| Github | [plugins/github/README.md] [PlGh] |
| Google Drive | [plugins/googledrive/README.md] [PlGd] |
| OneDrive | [plugins/onedrive/README.md] [PlOd] |
| Medium | [plugins/medium/README.md] [PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md] [PlGa] |


### Development

Want to contribute? Great!

Dillinger uses Gulp + Webpack for fast developing.
Make a change in your file and instantanously see your updates!

Open your favorite Terminal and run these commands.

First Tab:
```sh
$ node app
```

Second Tab:
```sh
$ gulp watch
```

(optional) Third:
```sh
$ karma test
```
#### Building for source
For production release:
```sh
$ gulp build --prod
```
Generating pre-built zip archives for distribution:
```sh
$ gulp build dist --prod
```
### Docker
Dillinger is very easy to install and deploy in a Docker container.

By default, the Docker will expose port 8080, so change this within the Dockerfile if necessary. When ready, simply use the Dockerfile to build the image.

```sh
cd dillinger
docker build -t joemccann/dillinger:${package.json.version}
```
This will create the dillinger image and pull in the necessary dependencies. Be sure to swap out `${package.json.version}` with the actual version of Dillinger.

Once done, run the Docker image and map the port to whatever you wish on your host. In this example, we simply map port 8000 of the host to port 8080 of the Docker (or whatever port was exposed in the Dockerfile):

```sh
docker run -d -p 8000:8080 --restart="always" <youruser>/dillinger:${package.json.version}
```

Verify the deployment by navigating to your server address in your preferred browser.

```sh
127.0.0.1:8000
```

#### Kubernetes + Google Cloud

See [KUBERNETES.md](https://github.com/joemccann/dillinger/blob/master/KUBERNETES.md)


### Todos

 - Write MORE Tests
 - Add Night Mode

License
----

MIT


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
#### LINQ
#### WPF - Concept, XAML, Code Behind, Routed Evens
#### MVVM
#### Async - Concept, await, async
#### WCF - Concept, ABC of Endpoints, Service/implementation, hosting, channels

**Free Software, Hell Yeah!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)


   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
