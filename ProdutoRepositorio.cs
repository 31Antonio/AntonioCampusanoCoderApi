﻿using System.Data.SqlClient;
using AntonioCampusanoCoderApi.Models;
using System.Data;

namespace AntonioCampusanoCoderApi.Repositories
{
    public class ProductoRepositorio
    {
        private SqlConnection? conexion;
        private String CadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
            "Database=adrians_E001;" +
            "User Id=adrians_E001;" +
            "Password=AsdaF1159*;";
        public ProductoRepositorio()
        {
            try
            {
                conexion = new SqlConnection(CadenaConexion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Producto> GetProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    Console.WriteLine("Estableciendo Conexion");
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(reader["Id"].ToString());
                                producto.Descripciones = reader["Descripciones"].ToString();
                                producto.Costo = Convert.ToDecimal(reader["Costo"].ToString());
                                producto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"].ToString());
                                producto.Stock = Convert.ToInt32(reader["Stock"].ToString());
                                listaProductos.Add(producto);
                            }
                        }
                    }
                }
                Console.WriteLine("Cerrando Conexion");
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return listaProductos;
        }
    }


}