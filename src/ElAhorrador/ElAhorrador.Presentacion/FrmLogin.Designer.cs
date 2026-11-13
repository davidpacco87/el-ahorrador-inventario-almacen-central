namespace ElAhorrador.Presentacion
{
    partial class FrmLogin
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
            panelIzquierdo = new Panel();
            lblMarca = new Label();
            lblSubtitulo = new Label();
            lblSede = new Label();
            panelTarjeta = new Panel();
            lblIniciar = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            lblEstadoBd = new Label();
            panelIzquierdo.SuspendLayout();
            panelTarjeta.SuspendLayout();
            SuspendLayout();
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.BackColor = Color.FromArgb(24, 77, 59);
            panelIzquierdo.Controls.Add(lblMarca);
            panelIzquierdo.Controls.Add(lblSubtitulo);
            panelIzquierdo.Controls.Add(lblSede);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Size = new Size(380, 601);
            panelIzquierdo.TabIndex = 0;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(45, 180);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(256, 41);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "EL AHORRADOR";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.FromArgb(215, 230, 222);
            lblSubtitulo.Location = new Point(45, 230);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(200, 50);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestión de inventarios\r\ny control de almacén";
            // 
            // lblSede
            // 
            lblSede.AutoSize = true;
            lblSede.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSede.ForeColor = Color.FromArgb(190, 215, 200);
            lblSede.Location = new Point(45, 530);
            lblSede.Name = "lblSede";
            lblSede.Size = new Size(185, 19);
            lblSede.TabIndex = 2;
            lblSede.Text = "Almacén Central - Arequipa";
            // 
            // panelTarjeta
            // 
            panelTarjeta.BackColor = Color.White;
            panelTarjeta.Controls.Add(lblIniciar);
            panelTarjeta.Controls.Add(lblUsuario);
            panelTarjeta.Controls.Add(txtUsuario);
            panelTarjeta.Controls.Add(lblContrasena);
            panelTarjeta.Controls.Add(txtContrasena);
            panelTarjeta.Controls.Add(btnIngresar);
            panelTarjeta.Location = new Point(475, 95);
            panelTarjeta.Name = "panelTarjeta";
            panelTarjeta.Size = new Size(440, 380);
            panelTarjeta.TabIndex = 1;
            // 
            // lblIniciar
            // 
            lblIniciar.AutoSize = true;
            lblIniciar.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblIniciar.ForeColor = Color.FromArgb(30, 45, 38);
            lblIniciar.Location = new Point(40, 35);
            lblIniciar.Name = "lblIniciar";
            lblIniciar.Size = new Size(162, 32);
            lblIniciar.TabIndex = 0;
            lblIniciar.Text = "Iniciar sesión";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblUsuario.ForeColor = Color.FromArgb(90, 105, 95);
            lblUsuario.Location = new Point(40, 95);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(52, 17);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(40, 120);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(360, 27);
            txtUsuario.TabIndex = 2;
            txtUsuario.Text = "d.pacco";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblContrasena.ForeColor = Color.FromArgb(90, 105, 95);
            lblContrasena.Location = new Point(40, 170);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(73, 17);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 11F);
            txtContrasena.Location = new Point(40, 195);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(360, 27);
            txtContrasena.TabIndex = 4;
            txtContrasena.Text = "Admin123*";
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(35, 107, 78);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(40, 255);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(360, 42);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblEstadoBd
            // 
            lblEstadoBd.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblEstadoBd.ForeColor = Color.FromArgb(35, 107, 78);
            lblEstadoBd.Location = new Point(475, 495);
            lblEstadoBd.Name = "lblEstadoBd";
            lblEstadoBd.Size = new Size(490, 50);
            lblEstadoBd.TabIndex = 2;
            lblEstadoBd.Text = "Estado de conexión a Base de Datos";
            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 243, 238);
            ClientSize = new Size(1008, 601);
            Controls.Add(panelTarjeta);
            Controls.Add(lblEstadoBd);
            Controls.Add(panelIzquierdo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "El Ahorrador - Gestión de inventarios y control de almacén";
            Load += FrmLogin_Load;
            panelIzquierdo.ResumeLayout(false);
            panelIzquierdo.PerformLayout();
            panelTarjeta.ResumeLayout(false);
            panelTarjeta.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIzquierdo;
        private Label lblMarca;
        private Label lblSubtitulo;
        private Label lblSede;
        private Panel panelTarjeta;
        private Label lblIniciar;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Label lblEstadoBd;
    }
}
