# Infinispan on OCP
This is an example application that works with an Infinispan cluster deployed on Openshift and exposed via Route.

You need an Openshift project with a running Infinispan Operator.

Execution steps:
- deploy infinispan.yaml
- get user, password and the route host and update the `Program.cs` file accordingly
- `dotnet run` the application
