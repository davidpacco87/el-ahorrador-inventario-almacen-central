using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Dominio;
using Microsoft.Data.SqlClient;

namespace ElAhorrador.Datos
{
    public class RepositorioUsuariosSql : IRepositorioUsuarios
    {
        private readonly ConexionSql _conexionSql;

        public RepositorioUsuariosSql(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }

        public Usuario? ObtenerPorNombre(string nombreUsuario)
        {
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT IdUsuario, NombreUsuario, NombreCompleto, Contrasena, Rol, Estado
                FROM dbo.Usuario
                WHERE NombreUsuario = @NombreUsuario;";

            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

            using var lector = comando.ExecuteReader();
            if (lector.Read())
            {
                return new Usuario
                {
                    IdUsuario = lector.GetInt32(0),
                    NombreUsuario = lector.GetString(1),
                    NombreCompleto = lector.GetString(2),
                    Contrasena = lector.GetString(3),
                    Rol = lector.GetString(4),
                    Estado = lector.GetBoolean(5)
                };
            }

            return null;
        }
    }
}
