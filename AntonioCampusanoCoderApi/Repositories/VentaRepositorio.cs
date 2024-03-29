﻿using System.Data.SqlClient;
using AntonioCampusanoCoderApi.Models;
using System.Data;



namespace AntonioCampusanoCoderApi.Repositories
{
    public class VentaRepositorio
    {
        private SqlConnection conexion;
        private String cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
                                        "Database= AntonioCampusano-F0S9PI4;" +
                                        "User Id= Antonio Campusano-F0S9P14;" +
                                        "Password  AC-F0S9P14;";
        public VentaRepositorio()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {
            }
        }
        public Venta obtenerVentaDesdeReader(SqlDataReader reader)
        {
            Venta vta = new Venta();
            vta.id = long.Parse(reader["Id"].ToString());
            vta.comentarios = reader["Comentarios"].ToString();
            vta.idUsuario = long.Parse(reader["IdUsuario"].ToString());
            return vta;
        }
        public List<Venta> listaVentaDesdeIdUser(int idUser)
        {
            List<Venta> ventaU = new List<Venta>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROm Venta WHERE idUsuario = @idUsuario", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Venta venta = obtenerVentaDesdeReader(reader);
                            ventaU.Add(venta);

                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return ventaU;
        }

        // Cargar una venta en la tabla venta, cargar la venta el ProductoVendido y descontar stock en tabla Producto
        public Venta cargarVenta(Venta venta)
        {
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Venta (Id, Comentarios, IdUsuario) VALUES (@id, @comentarios, @idUsuario); SELECT @@Identity", conexion))
                {
                    conexion.Open();
                    cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.comentarios });
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = venta.idUsuario });
                    venta.id = long.Parse(cmd.ExecuteScalar().ToString());
                    return venta;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        //Eliminar venta desde Id, eliminar los ítem de ProductoVendido con esa venta, sumar stock a los Productos
        public bool eliminarVenta(long id)
        {
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");

            }
            try
            {
                int filasAfectadas = 0;
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Venta WHERE id=@id", conexion))
                {
                    conexion.Open();
                    cmd.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = id });
                    filasAfectadas = cmd.ExecuteNonQuery();
                }

                return filasAfectadas > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        // Traer todas las ventas hechas con las descripciones de los respectivos productos
        public List<Venta> listarVentas()
        {
            List<Venta> lista = new List<Venta>();
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Venta", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Venta venta = obtenerVentaDesdeReader(reader);
                            lista.Add(venta);

                        }
                    }
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}