using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ElAhorrador.Datos;
using ElAhorrador.Negocio.Servicios;

namespace ElAhorrador.Presentacion
{
    public partial class FrmLogin : Form
    {
        private readonly ServicioUsuarios _servicioUsuarios;
        private readonly ServicioCatalogos _servicioCatalogos;
        private readonly ConexionSql _conexionSql;

        public FrmLogin(ServicioUsuarios servicioUsuarios, ServicioCatalogos servicioCatalogos, ConexionSql conexionSql)
        {
            InitializeComponent();
            _servicioUsuarios = servicioUsuarios;
            _servicioCatalogos = servicioCatalogos;
            _conexionSql = conexionSql;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var resultado = _conexionSql.ProbarConexion();
            lblEstadoBd.Text = resultado.Mensaje;
            lblEstadoBd.ForeColor = resultado.Exito
                ? Color.FromArgb(35, 107, 78)
                : Color.Firebrick;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var resultado = _servicioUsuarios.IniciarSesion(txtUsuario.Text, txtContrasena.Text);
            if (!resultado.Exito)
            {
                MessageBox.Show(
                    resultado.Mensaje,
                    "No se pudo iniciar sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Hide();
            using var frmPrincipal = new FrmPrincipal(_servicioUsuarios, _servicioCatalogos);
            frmPrincipal.ShowDialog(this);

            txtContrasena.Clear();
            Show();
            txtUsuario.Focus();
        }
    }
}
