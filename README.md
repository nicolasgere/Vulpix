Vulpix
--------------

Fast, unopinionated, minimalist web framework for [.NET core](https://www.microsoft.com/net/core#windows).

```c#

public static void Main(string[] args)
{
    var app = new VulpixServer();
    app.AddRoute("GET","/", async (Req req, Res res)=>{
        await res.Send("Hello World");
    });
    app.Listen(8080);
}

```

## Installation

We are on [NuGet](https://www.nuget.org/packages/VulpixServer/1.0.2).

## Features

  * Middleware based
  * Async everywhere
  * Focus on high performance
  * Robust and simple routing
  * Use your template engine
  * Middleware based
  * Executable for generating applications quickly

## Quick Start

If you don't have [.NET core](https://www.microsoft.com/net/core#windows), please install it before.

 Add `VulpixServer` as dependency

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
    var app = new VulpixServer();
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
