namespace SharpTodo.Models

module Commands =
    [<CLIMutable>]
    type AddTask =
        { Name : string }

module Task =
    [<CLIMutable>]
    type Task =
        { Id: int
          Name: string }

    let create name (tasks: list<Task>) =
        let id = tasks.Length + 1
        let task = { Id = id; Name = name }
        tasks @ [task]