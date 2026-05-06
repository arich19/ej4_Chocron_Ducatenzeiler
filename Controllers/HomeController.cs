using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ej4_Chocron_Ducatenzeiler_Schatzyki.Models;

namespace ej4_Chocron_Ducatenzeiler_Schatzyki.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult respuesta(string nombre, int edad, string situacionLaboral, int ingreso, List<string> deudas, int montoSolicitado, string plazoDevolucion, bool terminosYCondiciones)
    {
        bool puede;
        if (edad < 18)
        {
            puede = false;
        }
        if (situacionLaboral == "desempleado")
        {
            puede = false;
        }
        if (ingreso < 250000)
        {
            puede = false;
        }
        if (montoSolicitado > ingreso * 5)
        {
            puede = false;
        }
        if (deudas.Count > 0)
        {
            puede = false;
        }
        if (!terminosYCondiciones)
        {
            puede = false;
        }


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
