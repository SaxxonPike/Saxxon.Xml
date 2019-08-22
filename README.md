# Saxxon.Xml

A fluent XML interface for both `System.Xml` and `System.Xml.Linq`. This
library provides a number of extension methods that unifies both popular
built-in XML namespaces under a single API.

### Getting Started

With either `System.Xml.XmlDocument` or `System.Xml.Linq.XDocument`, invoke
the `Fluent` extension method.

```c#
// at the top:
using Saxxon.Xml;

// in your code:
document.Fluent()
```

From there, a fluent interface is exposed.

### Navigation

Get a document's root node.

```c#
document
    .Fluent()
    .Root
```

Get the child node of the root at index 2 (zero-based.)

```c#
document
    .Fluent()
    .Root
    .Children[2]
```

### Manipulation

Append text and comments to an existing node.

```c#
// this produces, inside the first child node:
// some example test<!--this is my comment-->some more text

document
    .Fluent()
    .Root
    .Children
    .First()    // LINQ
    .AppendText("some example test")
    .AppendComment("this is my comment")
    .AppendText("some more text")
```

### Scoping

Whenever new nodes are created, such as with `AppendText` or `AppendComment`, a scope can be provided
that will allow further customization of the newly created node.

```c#
// this produces, inside the root:
// <MyElement>this text lives inside<!--this comment lives inside too--></MyElement>

document
    .Fluent()
    .Root
    .AppendElement("MyElement", element =>
    {
        element
            .AppendText("this text lives inside")
            .AppendComment("this comment lives inside too");
    });
```

Scopes can be used on any of the fluent XML interfaces, and can be chained
using the `Use` method.

```c#
document
    .Fluent()
    .Root
    .Use(root =>
    {
        root
            .AppendComment("this comment lives in the root node")
            .AppendComment("this one does also");
    })
    .AppendElement("MyNode", node =>
    {
        node.AppendText("this text lives in the newly created node");
    });
```