using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
namespace TP7_PreguntadORT_Sasson_Izraelewicz;

public class Pregunta
{
    public int IdPregunta {get; set;}
    public int IdCategoria {get; set;}
    public int IdDificultad {get; set;}
    public string Enunciado {get; set;}
    public string Foto {get; set;}

    public Pregunta(){}

    public Pregunta(int idpregunta, int idcategoria, int iddificultad, string enunciado, string foto){
        IdPregunta = idpregunta;
        IdCategoria = idcategoria;
        IdDificultad = iddificultad;
        Enunciado = enunciado;
        Foto = foto;
    }

}