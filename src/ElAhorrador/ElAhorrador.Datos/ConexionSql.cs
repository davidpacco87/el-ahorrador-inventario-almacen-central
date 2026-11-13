using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace ElAhorrador.Datos
{
    public class ConexionSql
    {
        private readonly string _cadenaMaster = @"Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;TrustServerCertificate=True;";
        private readonly string _cadenaConexion;

        public ConexionSql(string cadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Database=ElAhorrador;Integrated Security=True;TrustServerCertificate=True;")
        {
            _cadenaConexion = cadenaConexion;
        }

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }

        public void AsegurarBaseDatosLocal()
        {
            using var conexionMaster = new SqlConnection(_cadenaMaster);
            conexionMaster.Open();

            const string sqlVerificar = @"
                SELECT CASE 
                    WHEN DB_ID(N'ElAhorrador') IS NOT NULL 
                     AND OBJECT_ID(N'ElAhorrador.dbo.Usuario', N'U') IS NOT NULL 
                    THEN 1 ELSE 0 
                END;";

            using var cmdVerificar = new SqlCommand(sqlVerificar, conexionMaster);
            int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());
            if (existe == 1)
            {
                return;
            }

            string? rutaScript = BuscarScriptInicial();
            if (rutaScript == null)
            {
                return;
            }

            string contenidoSql = File.ReadAllText(rutaScript);
            string[] bloques = Regex.Split(contenidoSql, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            foreach (string bloque in bloques)
            {
                if (string.IsNullOrWhiteSpace(bloque))
                {
                    continue;
                }

                using var cmdBloque = new SqlCommand(bloque, conexionMaster);
                cmdBloque.ExecuteNonQuery();
            }
        }

        private static string? BuscarScriptInicial()
        {
            var directorio = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (directorio != null)
            {
                string candidato = Path.Combine(directorio.FullName, "db", "01_BaseDatos_Inicial.sql");
                if (File.Exists(candidato))
                {
                    return candidato;
                }
                directorio = directorio.Parent;
            }
            return null;
        }

        public (bool Exito, string Mensaje) ProbarConexion()
        {
            try
            {
                AsegurarBaseDatosLocal();

                using var conexion = CrearConexion();
                conexion.Open();

                const string sql = @"
                    SELECT 
                        (SELECT COUNT(*) FROM dbo.Usuario WHERE Estado = 1),
                        (SELECT COUNT(*) FROM dbo.Producto WHERE Estado = 1),
                        (SELECT COUNT(*) FROM dbo.GrupoExistencia);";

                using var cmd = new SqlCommand(sql, conexion);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return (true, $"Conectado a (localdb)\\MSSQLLocalDB [BD: {conexion.Database}] | Usuarios activos: {reader.GetInt32(0)} | Productos: {reader.GetInt32(1)} | Grupos en stock: {reader.GetInt32(2)}");
                }

                return (true, "Conexión abierta correctamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error de conexión a la base de datos: {ex.Message}");
            }
        }
    }
}
