using System.Net;
using System.Security.Claims; 

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

    var claims = new List<UserClaim>();
    foreach (Claim claim in ClaimsPrincipal.Current.Claims)
    {
        claims.Add(new UserClaim(){
            Type = claim.Type,
            Value = claim.Value,
            Issuer = claim.Issuer,
            ValueType = claim.ValueType
        });
    }
    var response = req.CreateResponse(HttpStatusCode.OK, claims);
    return response;
}

public class Task 
{
    public string Description { get; set; }
}

public class UserClaim{
    public string Type { get; set; }
    public string Value { get; set; }
    public string Issuer { get; set; }
    public string ValueType { get; set; }
}
