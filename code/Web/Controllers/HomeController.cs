using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly RequestHelper _requestHelper;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var data = _requestHelper.GetData();
        return View(data);
    }

    public IActionResult RequestData()
    {
        var data = _requestHelper.GetData();
        return PartialView("_RequestData", data);
    }
}
