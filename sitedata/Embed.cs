namespace noisyadmin.sitedata;
public class Embed{

    public string Id{get; set;}
    public string? Subject {get; set;}
    public string? LinkUrl {get; set;}

    public string EmbeddedLink {get; set;}

    public string Content {get; set;}

    public DateTime CreatedDate {get; set;}

    public DateTime? LastScraped   { get; set;}
}