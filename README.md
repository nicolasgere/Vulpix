Vulpix
--------------

Fast, unopinionated, minimalist web framework for [.NET core](https://www.microsoft.com/net/core#windows).



```c#

public static void Main(string[] args)
{
    var app = new Vulpix();
    var foo = new MyController();
    app.AddRoute("GET","/", foo.Index);
    app.Use(new BodyParser().Exec);
    app.Listen(5000);
}
public class MyController
{
    public async void Index(Req req, Res res)
    {
        await res.Response.WriteAsync("Hello World!");
    }
}
public class BodyParser
{
    public async void Exec(Req req, Res res, Middleware middle){
        middle.Next(req,res);
    }
}

```

## Installation
A nugget package exist, https://www.nuget.org/packages/VulpixServer/1.0.1

## Features

  * Middleware based
  * Async everywhere
  * Focus on high performance
  * Robust and simple routing
  * Use your template engine
  * Middleware based
  * Executable for generating applications quickly

## Quick Start
If you dont have [.NET core](https://www.microsoft.com/net/core#windows), please install it before.

 Add VulpixServer as dependency

```bash
$ Install-Package VulpixServer
```

  Restore dependencies

```bash
$ cd Vulpix
$ dotnet restore
```
  Add simple hello world as bellow:

```c#

public static void Main(string[] args)
{
    var app = new Vulpix();
    var foo = new MyController();
    app.AddRoute("GET","/", (Req req, Res res)=>{
      await res.Response.WriteAsync("Hello World!");
    });
    app.Listen();
}
```
  Start the server:

```bash
$ dotnet run
```

And you have a Hello World webserver listen port 5000

## Philosophy

  The Vulpix philosophy is to provide small, robust tooling for HTTP servers, making
  it a great solution for single page applications, web sites, hybrids, or public
  HTTP APIs.
