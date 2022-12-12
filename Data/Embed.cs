using System.ComponentModel.DataAnnotations;

namespace noisyadmin.Data;
public class Embed{

    public string? id{get; set;}
    public string? Subject {get; set;}
    public string? LinkUrl {get; set;}

    public string? EmbeddedLink {get; set;}

    public string? Content {get; set;}

    public DateTime? CreatedDate {get; set;}

    public DateTime? LastScraped   { get; set;}
}