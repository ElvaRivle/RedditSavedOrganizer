namespace RedditOrganizeSaved.Models;

public class Category
{
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public List<Post>? Posts { get; set; }
}