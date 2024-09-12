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
        ViewBag.Usuario = Juego.Username;
        return RedirectToAction("Jugar");
    }

    public IActionResult Jugar()
    {
        ViewBag.UserName = Juego.Username;
        ViewBag.Puntaje = Juego.PuntajeActual;
        ViewBag.PreguntaActual = Juego.ObtenerProximaPregunta();

        if(ViewBag.PreguntaActual == null)
        {
            return View ("Fin");
        }
        else{
            ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.IdPregunta);
            ViewBag.Respuesta = Juego.ObtenerProximasRespuestas(ViewBag.PreguntaActual.IdPregunta);
            return View ("Jugar");
        }
        
    }

    public IActionResult VerificarRespuesta(int idRespuesta)
    {
        ViewBag.Correcta = Juego.VerificarRespuesta(idRespuesta);
        ViewBag.UserName = Juego.Username;
        ViewBag.Puntaje = Juego.PuntajeActual;
        return View("Respuesta");
    }

}
