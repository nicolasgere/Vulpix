Vulpix
--------------

Fast, unopinionated, minimalist web framework for [.NET core](https://www.microsoft.com/net/core#windows).



```c#
  public class Startup : Vulpix
   {
        public Startup(){
           var foo = new MyController();
           base.AddRoute("GET","/", foo.Index);
        }
    }
   public class MyController
    {
        public async void Index(Req req, Res res)
        {          
            await res.Response.WriteAsync("Hello world");
        }
     }

```

## Installation
Currently close this repository, and use the exemple helloworld project.
In future a Nugget Package will be create

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

 Clone the repo

```bash
$ git clone https://github.com/nicolasgere/Vulpix
```

  Install dependencies

```bash
$ cd Vulpix
$ dotnet restore
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
