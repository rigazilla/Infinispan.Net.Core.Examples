# Infinispan.Example.Caching

This is a simple `webapp` project which uses Infinispan as distributed cache. Aim of this example is to show how Infinispan can be easily integrated into an ASP.NET application.

Let's go over the three steps (actually 4) needed to implement our app.

# Step 0

Let set our goal: we want to implement and app that shows on a page some basic info, and we want that info to be cached in the session with an idle expiration time of 10 sec.

# Step 1

First step is to create a project template using the `dotnet cli`.

```sh
dotnet new webapp -lang 'C#' -n Infinispan.Example.Caching
```

A new webapp project is now ready in the `Infinispan.Example.Caching` folder.
The `session-1` tag of this repo contains the code at this stage.

*Note: I've changed the default ports to 5500/5501 due to conflicts on my pc*

# Step 2

In this step we will add Infinispan as distributed caching service provider.

In order to do that, we must add the `Infinispan.HotRod.Caching` package to the project:
```sh
dotnet add package Infinispan.Hotrod.Caching --version 0.0.1-alpha
```
and then write some glue code in `Startup.cs` so the app knows that we want to use Infinispan as cache provider.
```code
```
`session-2` tag contains the code for this step, you can check the changes from step 1 with a diff:
```sh
git diff session-1 session-2
```
Notabily, in the `Startup.cs`, Infinispan is added and configured as distributed cache and sessions are configured to expire after 10 sec of idle time.

# Step 3

Everything is now ready to write the application code: in our simple case we just need to code our model `Pages/Index.cshtml.cs` and view `Pages/Index.cshtml`. You can see the added code running:
```
git diff session-1 session-2
```

# Run the app
The app is ready to run (don't forget that the app is expecting an Infinispan node listening on `127.0.0.1:11222`).
```sh
dotnet run
```

Go in a browser to `http://127.0.0.1:5500` and check how everything work.
