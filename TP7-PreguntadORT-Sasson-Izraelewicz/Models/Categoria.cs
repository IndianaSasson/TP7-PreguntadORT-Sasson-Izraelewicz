using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
namespace TP7_PreguntadORT_Sasson_Izraelewicz;
public class Categoria
{
    public int IdCategoria {get; set;}
    public string Nombre {get; set;}
    public string Foto {get; set;}

    public Categoria(){}

    public Categoria(int id, string nombre, string foto){
        IdCategoria = id;
        Nombre = nombre;
        Foto = foto;
    }

}

