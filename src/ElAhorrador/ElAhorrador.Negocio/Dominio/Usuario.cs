using System;
using System.Collections.Generic;
using System.Text;

namespace ElAhorrador.Negocio.Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public bool ValidarEstado()
        {
            return Estado;
        }

        public bool EsJefe
        {
            get { return Rol == "JEFE_ALMACEN"; }
        }

        public string RolDescripcion
        {
            get { return EsJefe ? "Jefe de Almacén" : "Auxiliar de Almacén"; }
        }
    }
}
