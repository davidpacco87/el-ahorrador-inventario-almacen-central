using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Dominio;

namespace ElAhorrador.Negocio.Servicios
{
    public class ServicioCatalogos
    {
        private readonly IRepositorioCatalogos _repositorioCatalogos;

        public ServicioCatalogos(IRepositorioCatalogos repositorioCatalogos)
        {
            _repositorioCatalogos = repositorioCatalogos;
        }

        public List<Producto> ConsultarProductos(string filtro = "")
        {
            return _repositorioCatalogos.ListarProductos(filtro.Trim());
        }
    }
}
