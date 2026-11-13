using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Dominio;

namespace ElAhorrador.Negocio.Seguridad
{
    public static class SesionActual
    {
        public static Usuario? UsuarioActivo { get; private set; }

        public static bool EstaAutenticado
        {
            get { return UsuarioActivo != null && UsuarioActivo.Estado; }
        }

        public static void Iniciar(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        public static void Cerrar()
        {
            UsuarioActivo = null;
        }
    }
}
