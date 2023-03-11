namespace RedditOrganizeSaved.Models;

public class Post
{
    public int Id { get; set; }
    public String? Fullname { get; set; }
    public String? Title { get; set; }
    public String? Permalink { get; set; }
    
    public Category? Category { get; set; }
}