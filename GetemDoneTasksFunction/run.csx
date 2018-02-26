#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static HttpResponseMessage Run(HttpRequestMessage req, IQueryable<Person> inTable, TraceWriter log)
{
    // var query = from person in inTable select person;
    // foreach (Person person in query)
    // {
    //     log.Info($"Name:{person.Name}");
    // }
    Task[] tasks = new Task[]{
        new Task(){
            Description = "First task"
        },
        new Task(){
            Description = "Second task"
        }
    };

    return req.CreateResponse(HttpStatusCode.OK, tasks);
}

public class Task 
{
    public string Description { get; set; }
}

public class Person : TableEntity
{
    public string Name { get; set; }
}
