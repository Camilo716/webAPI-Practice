using System.Text.Json.Serialization;

namespace webAPI.Models;

public class OpenTaskModel
{
    public Guid TaskID {get;set;}
    public Guid CategoryID {get;set;}

    public string tittle {get;set;}
    public string description {get;set;}
    public priority Priority {get;set;}
    public DateTime creationDate {get;set;}
    public DateTime Deadline {get;set;}

    public virtual CategoryModel categoryOfTask{get;set;}

    [JsonIgnore]
    public string summary {get;set;}
}

public enum priority
{
    Low,
    medium,
    high,  
}
