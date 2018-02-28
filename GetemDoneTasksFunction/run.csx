using System.Net;
using System.Security.Claims; 

public static HttpResponseMessage Run(HttpRequestMessage req, IQueryable<Task> tasks, TraceWriter log)
{
    var userId = ClaimsPrincipal.Current.Claims
                    .First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
    var userTasks = tasks.All(t => t.UserId == userId);
    var response = req.CreateResponse(HttpStatusCode.OK, userTasks);
    return response;
}

public class Task 
{
    public string UserId { get; set; }
    public string Description { get; set; }
}

public class UserClaim{
    public string Type { get; set; }
    public string Value { get; set; }
    public string Issuer { get; set; }
    public string ValueType { get; set; }
}
