using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AntonioCampusanoCoderApi.Repositories;
using AntonioCampusanoCoderApi.Models;
using System.Data.SqlClient;
using System.Data;

namespace AntonioCampusanoCoderApi.Repositories
{
    public class LoginRepositorio
    {
        private SqlConnection? conexion;
        private readonly string cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
                                        "Database= AntonioCampusano-F0S9PI4;" +
                                        "User Id= Antonio Campusano-F0S9P14;" +
                                        "Password  AC-F0S9P14;";                                    
        public LoginRepositorio()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {

            }
        }

        public bool verificarUsuario(Usuario usuario)
        {
            if (conexion == null)
            {
                throw new Exception("Conexión no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contrasenia", conexion))
                {
                    conexion.Open();
                    cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.nombreUsuario });
                    cmd.Parameters.Add(new SqlParameter("Contrasenia", SqlDbType.VarChar) { Value = usuario.contrasenia });
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
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
        }
    }
}