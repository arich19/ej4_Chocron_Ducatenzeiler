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
        string motivoRechazo = "Motivos del rechazo: ";
        bool puede = true;
        terminosYCondiciones = true;
        if (edad < 18)
        {
            puede = false;
            motivoRechazo += "El solicitante es menor de edad. ";
        }
        if (situacionLaboral == "desempleado")
        {
            puede = false;
            motivoRechazo += "El solicitante está desempleado. ";
        }
        if (ingreso < 250000)
        {
            puede = false;
            motivoRechazo += "El ingreso mensual es insuficiente. ";
        }
        if (montoSolicitado > ingreso * 5)
        {
            puede = false;
            motivoRechazo += "El monto solicitado es demasiado alto en relación al ingreso. ";
        }
        if (deudas.Count >= 1)
        {
            puede = false;
            motivoRechazo += "El solicitante tiene deudas pendientes. ";
        }
        if (!terminosYCondiciones)
        {
            puede = false;
            motivoRechazo += "No se han aceptado los términos y condiciones. ";
        }
        ViewBag.Puede = puede;
        ViewBag.MotivoRechazo = motivoRechazo;

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
