using System.Diagnostics;
using LeaveMgmt.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeaveMgmt.Web.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
