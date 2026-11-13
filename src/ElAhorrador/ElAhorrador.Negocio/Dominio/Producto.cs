using System;
using System.Collections.Generic;
using System.Text;

namespace ElAhorrador.Negocio.Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string PresentacionFisica { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public string Clasificacion { get; set; } = string.Empty;
        public string ConservacionRequerida { get; set; } = string.Empty;
        public bool ControlLote { get; set; }
        public bool ControlVencimiento { get; set; }
        public bool Estado { get; set; }

        public string EstadoTexto
        {
            get { return Estado ? "Activo" : "Inactivo"; }
        }
    }
}
