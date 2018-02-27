using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
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
