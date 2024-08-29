using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
namespace TP7_PreguntadORT_Sasson_Izraelewicz;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=PreguntadORT; Trusted_Connection=True";

    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> listaCategorias = new List<Categoria>();
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Nombre FROM Categorias";
            listaCategorias = db.Query<Categoria>(sql).ToList();
        }

        return listaCategorias;
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        List<Dificultad> listaDificultades = new List<Dificultad>();
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT Nombre FROM Dificultades";
            listaDificultades = db.Query<Dificultad>(sql).ToList();
        }

        return listaDificultades;
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        List<Pregunta> listaPreguntas = new List<Pregunta>();
        
        if(dificultad != -1 && categoria != -1){
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Preguntas WHERE (IdDificultad = @pdificultad) AND (IdCategoria = pcategoria)";
                listaPreguntas = db.Query<Pregunta>(sql, new {pdificultad = dificultad, pcategoria = categoria}).ToList();
            }
    
        }
        else if(dificultad == -1 && categoria != -1)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Preguntas WHERE IdCategoria = pcategoria";
                listaPreguntas = db.Query<Pregunta>(sql, new {pcategoria = categoria}).ToList();
            }
          
        }
        else if(dificultad != -1 && categoria == -1)
        {
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pdificultad";
                listaPreguntas = db.Query<Pregunta>(sql, new {pdificultad = dificultad}).ToList();
            }
         
        }
        else if(dificultad == -1 && categoria == -1){
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Preguntas";
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            
        }

        return listaPreguntas;
        
    }

    public static List<Respuesta> ObtenerRespuestas(int idPregunta)
    {
        List<Respuesta> listaRespuestas = new List<Respuesta>();
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
            listaRespuestas = db.Query<Respuesta>(sql, new {pIdPregunta = idPregunta}).ToList();
        }
        return listaRespuestas;

    }

}