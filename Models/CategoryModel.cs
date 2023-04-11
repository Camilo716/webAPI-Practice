using System.Text.Json.Serialization;

namespace webAPI.Models;

public class CategoryModel
{
    // [Key]
    public Guid CategoryID {get;set;}

    //[Required]
    //[MaxLength(150)]
    public string name {get;set;}
    public string description {get;set;}
    public int peso {get;set;}

    [JsonIgnore]
    public virtual ICollection<OpenTaskModel> tasksInCategory{get;set;}
}