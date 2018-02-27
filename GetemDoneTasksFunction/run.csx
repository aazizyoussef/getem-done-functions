#r "Microsoft.WindowsAzure.Storage"

using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static HttpResponseMessage Run(HttpRequestMessage req, IQueryable<Person> inTable, TraceWriter log)
{
    Task[] tasks = new Task[]{
        new Task(){
            Description = "First task"
        },
        new Task(){
            Description = "Second task"
        }
    };
    var response = req.CreateResponse(HttpStatusCode.OK, tasks);
    return response;
}

public class Task 
{
    public string Description { get; set; }
}
