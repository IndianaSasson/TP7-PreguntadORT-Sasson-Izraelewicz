using System;
using System.Collections.Generic;
namespace TP7_PreguntadORT_Sasson_Izraelewicz;

public static class Juego{
    public static string Username {get; set;}
    public static int PuntajeActual {get; private set;}
    private static int ContadorPreguntaActual {get; set;}
    private static int CantidadPreguntasCorrectas {get; set;}
    private static List<Pregunta> ListaPreguntas {get; set;}
    private static List<Respuesta> ListaRespuestas {get; set;}
    private static Pregunta PreguntaActual {get; set;}

    private static void InicializarJuego()
    {
        Username = "";
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorPreguntaActual = 0;
    }

    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> listaCategorias = new List<Categoria>();
        listaCategorias = BD.ObtenerCategorias();
        return listaCategorias;
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        List<Dificultad> listaDificultades = new List<Dificultad>();
        listaDificultades = BD.ObtenerDificultades();
        return listaDificultades;
    }

    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        InicializarJuego();
        Username = username;
        ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
    }

    public static Pregunta ObtenerProximaPregunta()
    {
        return ListaPreguntas[ContadorPreguntaActual];
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
    {
        return ListaRespuestas = BD.ObtenerRespuestas(idPregunta);
    }

    public static bool VerificarRespuesta(int idRespuesta)
    {
        bool Correcta=false;
        foreach(Respuesta item in ListaRespuestas)
        {
            if(item.IdRespuesta == idRespuesta)
            {
                Correcta = item.Correcta;
            }
        }

        if(Correcta)
        {
            PuntajeActual+= 10;
            CantidadPreguntasCorrectas ++;
        }
        PreguntaActual = ObtenerProximaPregunta();
        ContadorPreguntaActual ++;

        return Correcta;
    }
}