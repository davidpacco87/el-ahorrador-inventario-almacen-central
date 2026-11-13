using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Dominio;

namespace ElAhorrador.Negocio.Contratos
{
    public interface IRepositorioUsuarios
    {
        Usuario? ObtenerPorNombre(string nombreUsuario);
    }

    public interface IRepositorioCatalogos
    {
        List<Producto> ListarProductos(string filtro = "");
    }
}
