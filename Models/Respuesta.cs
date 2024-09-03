using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
namespace TP7_PreguntadORT_Sasson_Izraelewicz;

public class Respuesta
{
    public int IdRespuesta {get; set;}
    public int IdPregunta {get; set;}
    public int Opcion {get; set;}
    public string Contenido {get; set;}
    public bool Correcta {get; set;}
    public string Foto {get; set;}
    public Respuesta(){}

    public Respuesta(int idrespuesta, int idpregunta, int opcion, string contenido, bool correcta, string foto){
        IdRespuesta = idrespuesta;
        IdPregunta = idpregunta;
        Opcion = opcion;
        Contenido = contenido;
        Correcta = correcta;
        Foto = foto;
    }

}