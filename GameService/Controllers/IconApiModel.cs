namespace GameService.Controllers;

public class IconApiModel(string path, string body)
{
    public string Path { get; set; } = path;
    public string Body { get; set; } = body;
}