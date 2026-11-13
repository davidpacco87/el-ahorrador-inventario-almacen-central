using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ElAhorrador.Negocio.Seguridad;
using ElAhorrador.Negocio.Servicios;

namespace ElAhorrador.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private readonly ServicioUsuarios _servicioUsuarios;
        private readonly ServicioCatalogos _servicioCatalogos;

        public FrmPrincipal(ServicioUsuarios servicioUsuarios, ServicioCatalogos servicioCatalogos)
        {
            InitializeComponent();
            _servicioUsuarios = servicioUsuarios;
            _servicioCatalogos = servicioCatalogos;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var usuario = SesionActual.UsuarioActivo;
            if (usuario != null)
            {
                lblUsuario.Text = $"{usuario.NombreCompleto}\r\n{usuario.RolDescripcion}";
                lblEncabezado.Text = $"Almacén Central  |  Sesión activa: {usuario.NombreUsuario} ({usuario.RolDescripcion})";
            }

            MostrarVistaInicio();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarVistaInicio();
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            MostrarVistaProductos();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _servicioUsuarios.CerrarSesion();
            Close();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            CargarProductosEnTabla();
        }

        private void MostrarVistaInicio()
        {
            panelVistaInicio.Visible = true;
            panelVistaProductos.Visible = false;
            panelVistaInicio.BringToFront();
        }

        private void MostrarVistaProductos()
        {
            panelVistaProductos.Visible = true;
            panelVistaInicio.Visible = false;
            panelVistaProductos.BringToFront();
            CargarProductosEnTabla();
        }

        private void CargarProductosEnTabla()
        {
            var productos = _servicioCatalogos.ConsultarProductos(txtBuscarProducto.Text);

            dgvProductos.DataSource = productos.Select(p => new
            {
                Código = p.Codigo,
                Producto = p.Nombre,
                Categoría = p.NombreCategoria,
                Presentación = p.PresentacionFisica,
                Conservación = p.ConservacionRequerida,
                Estado = p.EstadoTexto
            }).ToList();
        }
    }
}
