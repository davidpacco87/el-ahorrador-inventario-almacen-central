using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Dominio;
using Microsoft.Data.SqlClient;

namespace ElAhorrador.Datos
{
    public class RepositorioCatalogosSql : IRepositorioCatalogos
    {
        private readonly ConexionSql _conexionSql;

        public RepositorioCatalogosSql(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }

        public List<Producto> ListarProductos(string filtro = "")
        {
            var lista = new List<Producto>();

            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, p.PresentacionFisica,
                       p.IdCategoria, c.Nombre AS NombreCategoria, p.Clasificacion,
                       p.ConservacionRequerida, p.ControlLote, p.ControlVencimiento, p.Estado
                FROM dbo.Producto p
                INNER JOIN dbo.Categoria c ON c.IdCategoria = p.IdCategoria
                WHERE (@Filtro = N'' OR p.Codigo LIKE N'%' + @Filtro + N'%' OR p.Nombre LIKE N'%' + @Filtro + N'%')
                ORDER BY p.Codigo;";

            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Filtro", filtro);

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Producto
                {
                    IdProducto = lector.GetInt32(0),
                    Codigo = lector.GetString(1),
                    Nombre = lector.GetString(2),
                    Descripcion = lector.GetString(3),
                    PresentacionFisica = lector.GetString(4),
                    IdCategoria = lector.GetInt32(5),
                    NombreCategoria = lector.GetString(6),
                    Clasificacion = lector.GetString(7),
                    ConservacionRequerida = lector.GetString(8),
                    ControlLote = lector.GetBoolean(9),
                    ControlVencimiento = lector.GetBoolean(10),
                    Estado = lector.GetBoolean(11)
                });
            }

            return lista;
        }
    }
}
