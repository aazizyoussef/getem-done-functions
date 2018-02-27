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
    var response = req.CreateResponse(HttpStatusCode.OK, tasks);
    response.Headers.Add("Access-Control-Allow-Credentials", "true");
   response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000, https://accounts.google.com, https://getem-done-functions.azurewebsites.net");
   response.Headers.Add("Access-Control-Allow-Methods", "GET, OPTIONS");
    return response;
}

public class Task 
{
    public string Description { get; set; }
}

public class Person : TableEntity
{
    public string Name { get; set; }
}
