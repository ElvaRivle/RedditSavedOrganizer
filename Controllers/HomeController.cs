using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedditOrganizeSaved.Models;
using Reddit;

namespace RedditOrganizeSaved.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        string appId = _configuration.GetValue<string>("Reddit:appId");
        string appSecret = _configuration.GetValue<string>("Reddit:appSecret");
        string accessToken = _configuration.GetValue<string>("Reddit:accessToken");
        
        RedditClient reddit = new RedditClient(appId, null, appSecret,
            accessToken, "RedditOrganizer/0.1 by __rusmir__");

        var spaseni = reddit.Account.Me.GetPostHistory("saved");
        ViewBag.username = reddit.Account.Me.Name;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}