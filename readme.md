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

## Getting Started

You will need the [.NET Core 1.1](https://www.microsoft.com/net/download/core) SDK for any operating system installed.

```
dotnet restore
dotnet run
```
