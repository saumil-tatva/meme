using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HalloDOCMVC.Models;
using Data_Layer.DataModels;
using Business_Layer.Interface;
using Data_Layer.DataContext;
using Business_Layer.Repositories;

namespace HalloDOCMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILogin _login;

    public HomeController(ILogger<HomeController> logger, ILogin login)
    {
        _logger = logger;
        _login = login;
    }

    public IActionResult Patientlogin() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Patientlogin(Aspnetuser obj)
    {
        var data = _login.LoginAuthentication(obj);
        if (data != null)
        {
            return Content("hello");
        }
        else
        {
            ViewBag.LoginMessage = "Can't Login";
        }
        return View();
    }

    public IActionResult Patient_site()
    {
        return View();
    }

    public IActionResult Patientforgotpass()
    {
        return View();
    }


    public IActionResult Submit_request()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
