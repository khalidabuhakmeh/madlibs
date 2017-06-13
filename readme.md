# Madlibs C# 

This .NET Core console application allows a developer to create a `format` and a set of `options` that can fit into `placeholders`. The `Madlib` class that can help generate and *regenerate* fun strings randomly.

```csharp
var madlib = new Madlib(
    "my name is {name}. I like to {task}. My favorite food is {food}.",
    new
    {
        name = new[] { "Khalid", "Nicole" },
        task = new[] { "code", "dance", "watch television", "sing" },
        food = new[] { "pizza", "tacos", "steak", "ice cream" }
    }
);

var result = madlib.Execute();
Console.WriteLine(result.ToString());
```

Which results in the following:

```console
Seed : 022
Text : my name is Khalid. I like to watch television. My favorite food is steak.
```

You can also *regenerate* the same output by using the seed provided.

```csharp
var regenerated = madlib.Execute("123");
Console.WriteLine(regenerated.ToString());
```

which results in the following:

```console
Seed : 123
Text : my name is Nicole. I like to watch television. My favorite food is ice cream.
```

## Getting Started

You will need the [.NET Core 1.1](https://www.microsoft.com/net/download/core) SDK for any operating system installed.

```
dotnet restore
dotnet run
```

## Contributing

Feel free to fork or submit pull requests to this project if you feel it can be improved.

## MIT License

Copyright (c) 2017 Khalid Abuhakmeh

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
