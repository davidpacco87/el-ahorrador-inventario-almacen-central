namespace ElAhorrador.Presentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            lblLogo = new Label();
            btnInicio = new Button();
            btnCatalogos = new Button();
            lblUsuario = new Label();
            btnCerrarSesion = new Button();
            panelSuperior = new Panel();
            lblEncabezado = new Label();
            panelContenido = new Panel();
            panelVistaProductos = new Panel();
            lblProdTitulo = new Label();
            lblBuscar = new Label();
            txtBuscarProducto = new TextBox();
            dgvProductos = new DataGridView();
            panelVistaInicio = new Panel();
            lblInicioTitulo = new Label();
            lblInicioSub = new Label();
            btnIrProductos = new Button();
            panelMenu.SuspendLayout();
            panelSuperior.SuspendLayout();
            panelContenido.SuspendLayout();
            panelVistaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelVistaInicio.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(24, 77, 59);
            panelMenu.Controls.Add(lblLogo);
            panelMenu.Controls.Add(btnInicio);
            panelMenu.Controls.Add(btnCatalogos);
            panelMenu.Controls.Add(lblUsuario);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(230, 681);
            panelMenu.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 22);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(156, 40);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "EL AHORRADOR\r\nALMACÉN CENTRAL";
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(35, 107, 78);
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(15, 95);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(200, 40);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "  Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnCatalogos
            // 
            btnCatalogos.BackColor = Color.FromArgb(35, 107, 78);
            btnCatalogos.Cursor = Cursors.Hand;
            btnCatalogos.FlatAppearance.BorderSize = 0;
            btnCatalogos.FlatStyle = FlatStyle.Flat;
            btnCatalogos.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCatalogos.ForeColor = Color.White;
            btnCatalogos.Location = new Point(15, 145);
            btnCatalogos.Name = "btnCatalogos";
            btnCatalogos.Size = new Size(200, 40);
            btnCatalogos.TabIndex = 2;
            btnCatalogos.Text = "  Catálogos (Productos)";
            btnCatalogos.TextAlign = ContentAlignment.MiddleLeft;
            btnCatalogos.UseVisualStyleBackColor = false;
            btnCatalogos.Click += btnCatalogos_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblUsuario.ForeColor = Color.FromArgb(215, 230, 222);
            lblUsuario.Location = new Point(20, 565);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(102, 34);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "David Pacco\r\nJefe de Almacén";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(35, 107, 78);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(20, 620);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(190, 36);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(lblEncabezado);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(230, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(934, 52);
            panelSuperior.TabIndex = 1;
            // 
            // lblEncabezado
            // 
            lblEncabezado.AutoSize = true;
            lblEncabezado.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblEncabezado.ForeColor = Color.FromArgb(50, 65, 58);
            lblEncabezado.Location = new Point(25, 15);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(392, 19);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.Text = "Almacén Central  |  Sesión activa: d.pacco (Jefe de Almacén)";
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(panelVistaProductos);
            panelContenido.Controls.Add(panelVistaInicio);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(230, 52);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(25);
            panelContenido.Size = new Size(934, 629);
            panelContenido.TabIndex = 2;
            // 
            // panelVistaProductos
            // 
            panelVistaProductos.Controls.Add(lblProdTitulo);
            panelVistaProductos.Controls.Add(lblBuscar);
            panelVistaProductos.Controls.Add(txtBuscarProducto);
            panelVistaProductos.Controls.Add(dgvProductos);
            panelVistaProductos.Dock = DockStyle.Fill;
            panelVistaProductos.Location = new Point(25, 25);
            panelVistaProductos.Name = "panelVistaProductos";
            panelVistaProductos.Size = new Size(884, 579);
            panelVistaProductos.TabIndex = 0;
            // 
            // lblProdTitulo
            // 
            lblProdTitulo.AutoSize = true;
            lblProdTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblProdTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblProdTitulo.Location = new Point(10, 10);
            lblProdTitulo.Name = "lblProdTitulo";
            lblProdTitulo.Size = new Size(277, 37);
            lblProdTitulo.TabIndex = 0;
            lblProdTitulo.Text = "Gestionar productos";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F);
            lblBuscar.ForeColor = Color.FromArgb(80, 95, 85);
            lblBuscar.Location = new Point(10, 62);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(166, 17);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar por código o nombre:";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Font = new Font("Segoe UI", 10.5F);
            txtBuscarProducto.Location = new Point(10, 85);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(340, 26);
            txtBuscarProducto.TabIndex = 2;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.Font = new Font("Segoe UI", 10F);
            dgvProductos.Location = new Point(10, 130);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(860, 420);
            dgvProductos.TabIndex = 3;
            // 
            // panelVistaInicio
            // 
            panelVistaInicio.Controls.Add(lblInicioTitulo);
            panelVistaInicio.Controls.Add(lblInicioSub);
            panelVistaInicio.Controls.Add(btnIrProductos);
            panelVistaInicio.Dock = DockStyle.Fill;
            panelVistaInicio.Location = new Point(25, 25);
            panelVistaInicio.Name = "panelVistaInicio";
            panelVistaInicio.Size = new Size(884, 579);
            panelVistaInicio.TabIndex = 1;
            // 
            // lblInicioTitulo
            // 
            lblInicioTitulo.AutoSize = true;
            lblInicioTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblInicioTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblInicioTitulo.Location = new Point(10, 15);
            lblInicioTitulo.Name = "lblInicioTitulo";
            lblInicioTitulo.Size = new Size(86, 37);
            lblInicioTitulo.TabIndex = 0;
            lblInicioTitulo.Text = "Inicio";
            // 
            // lblInicioSub
            // 
            lblInicioSub.AutoSize = true;
            lblInicioSub.Font = new Font("Segoe UI", 11F);
            lblInicioSub.ForeColor = Color.FromArgb(90, 105, 95);
            lblInicioSub.Location = new Point(10, 58);
            lblInicioSub.Name = "lblInicioSub";
            lblInicioSub.Size = new Size(447, 20);
            lblInicioSub.TabIndex = 1;
            lblInicioSub.Text = "Selecciona una operación disponible en la línea base de construcción:";
            // 
            // btnIrProductos
            // 
            btnIrProductos.BackColor = Color.FromArgb(35, 107, 78);
            btnIrProductos.Cursor = Cursors.Hand;
            btnIrProductos.FlatAppearance.BorderSize = 0;
            btnIrProductos.FlatStyle = FlatStyle.Flat;
            btnIrProductos.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIrProductos.ForeColor = Color.White;
            btnIrProductos.Location = new Point(10, 105);
            btnIrProductos.Name = "btnIrProductos";
            btnIrProductos.Size = new Size(280, 48);
            btnIrProductos.TabIndex = 2;
            btnIrProductos.Text = "Gestionar productos (Catálogo base)";
            btnIrProductos.UseVisualStyleBackColor = false;
            btnIrProductos.Click += btnCatalogos_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 243, 238);
            ClientSize = new Size(1164, 681);
            Controls.Add(panelContenido);
            Controls.Add(panelSuperior);
            Controls.Add(panelMenu);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "El Ahorrador - Gestión de inventarios y control de almacén";
            Load += FrmPrincipal_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelVistaProductos.ResumeLayout(false);
            panelVistaProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelVistaInicio.ResumeLayout(false);
            panelVistaInicio.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Label lblLogo;
        private Button btnInicio;
        private Button btnCatalogos;
        private Label lblUsuario;
        private Button btnCerrarSesion;
        private Panel panelSuperior;
        private Label lblEncabezado;
        private Panel panelContenido;
        private Panel panelVistaInicio;
        private Label lblInicioTitulo;
        private Label lblInicioSub;
        private Button btnIrProductos;
        private Panel panelVistaProductos;
        private Label lblProdTitulo;
        private Label lblBuscar;
        private TextBox txtBuscarProducto;
        private DataGridView dgvProductos;
    }
}
