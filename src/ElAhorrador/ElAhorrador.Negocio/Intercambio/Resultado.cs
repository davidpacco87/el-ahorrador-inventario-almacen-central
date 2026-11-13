using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Dominio;

namespace ElAhorrador.Negocio.Intercambio
{
    public class ResultadoSesion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }
    }

    public class ResultadoRegistro
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public int IdGenerado { get; set; }
    }
}
