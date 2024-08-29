using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
namespace TP7_PreguntadORT_Sasson_Izraelewicz;

public class Dificultad
{
    public int IdDificultad {get; set;}
    public string Nombre {get; set;}

    public Dificultad(){}

    public Dificultad(int id, string nombre){
        IdDificultad = id;
        Nombre = nombre;
    }

}