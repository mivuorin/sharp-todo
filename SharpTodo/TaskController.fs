namespace SharpTodo.Controllers

open System.Net
open System.Net.Http
open System.Web.Http

open SharpTodo.Models.Task
open SharpTodo.Models.Commands

[<RoutePrefix("api")>]
type TaskController() =
    inherit ApiController()

    static let mutable tasks =
        [] |> create "Load tasks"
           |> create "Add task"
           |> create "Persist tasks"

    [<Route("tasks")>]
    [<HttpGet>]
    member x.Get() = tasks

    [<Route("tasks")>]
    [<HttpPost>]
    member x.Post(command: AddTask) =
        do tasks <- create command.Name tasks
        tasks |> List.rev |> List.head 