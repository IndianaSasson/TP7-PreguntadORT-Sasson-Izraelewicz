using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_PreguntadORT_Sasson_Izraelewicz.Models;

namespace TP7_PreguntadORT_Sasson_Izraelewicz.Controllers;

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

    public IActionResult ConfigurarJuego()
    {
        ViewBag.listaCategorias = BD.ObtenerCategorias();
        ViewBag.listaDificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        ViewBag.Usuario = username;
        return RedirectToAction("Jugar");
    }

    public IActionResult Jugar()
    {
        ViewBag.PreguntaActual = Juego.ObtenerProximaPregunta();
        ViewBag.Respuesta = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.idPregunta);

        if(ViewBag.PreguntaActual == null)
        {
            return View ("Fin");
        }
        else{
            ViewBag.Respuesta = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.idPregunta);
            return View ("Juego");
        }
        
    }

    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        ViewBag.Correcta = Juego.VerificarRespuesta(idRespuesta);
        return View("Respuesta");
    }

}
