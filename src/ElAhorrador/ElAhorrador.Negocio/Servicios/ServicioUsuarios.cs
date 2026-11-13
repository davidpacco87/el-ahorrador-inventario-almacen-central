using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Intercambio;
using ElAhorrador.Negocio.Seguridad;

namespace ElAhorrador.Negocio.Servicios
{
    public class ServicioUsuarios
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;

        public ServicioUsuarios(IRepositorioUsuarios repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public ResultadoSesion IniciarSesion(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                return new ResultadoSesion
                {
                    Exito = false,
                    Mensaje = "Complete el nombre de usuario y la contraseña."
                };
            }

            var usuario = _repositorioUsuarios.ObtenerPorNombre(nombreUsuario.Trim());
            if (usuario == null || usuario.Contrasena != contrasena)
            {
                return new ResultadoSesion
                {
                    Exito = false,
                    Mensaje = "El usuario o la contraseña no son válidos."
                };
            }

            if (!usuario.ValidarEstado())
            {
                return new ResultadoSesion
                {
                    Exito = false,
                    Mensaje = "La cuenta de usuario se encuentra inactiva."
                };
            }

            SesionActual.Iniciar(usuario);
            return new ResultadoSesion
            {
                Exito = true,
                Mensaje = "Sesión iniciada correctamente.",
                Usuario = usuario
            };
        }

        public void CerrarSesion()
        {
            SesionActual.Cerrar();
        }
    }
}
