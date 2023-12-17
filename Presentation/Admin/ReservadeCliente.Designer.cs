namespace Presentation.Admin
{
    partial class ReservadeCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservadeCliente));
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.dataGridListadoDeReservasClientes = new System.Windows.Forms.DataGridView();
            this.btnMoficiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Logo = new System.Windows.Forms.ToolStripMenuItem();
            this.Dashboar = new System.Windows.Forms.ToolStripMenuItem();
            this.Gestion = new System.Windows.Forms.ToolStripMenuItem();
            this.recepciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pisosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDePagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoDeReservasClientes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(17)))), ((int)(((byte)(29)))));
            this.barraTitulo.Controls.Add(this.btnMaximizar);
            this.barraTitulo.Controls.Add(this.btnMinimizar);
            this.barraTitulo.Controls.Add(this.btnCerrar);
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(1730, 39);
            this.barraTitulo.TabIndex = 18;
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::Presentation.Properties.Resources.maximizar;
            this.btnMaximizar.Location = new System.Drawing.Point(1630, 2);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(29, 30);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 20;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = global::Presentation.Properties.Resources.minimizar_signo;
            this.btnMinimizar.Location = new System.Drawing.Point(1570, 2);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(29, 30);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 19;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::Presentation.Properties.Resources.cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(1687, 2);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 30);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dataGridListadoDeReservasClientes
            // 
            this.dataGridListadoDeReservasClientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridListadoDeReservasClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridListadoDeReservasClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListadoDeReservasClientes.Location = new System.Drawing.Point(551, 352);
            this.dataGridListadoDeReservasClientes.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridListadoDeReservasClientes.MultiSelect = false;
            this.dataGridListadoDeReservasClientes.Name = "dataGridListadoDeReservasClientes";
            this.dataGridListadoDeReservasClientes.ReadOnly = true;
            this.dataGridListadoDeReservasClientes.RowHeadersWidth = 51;
            this.dataGridListadoDeReservasClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridListadoDeReservasClientes.Size = new System.Drawing.Size(1051, 358);
            this.dataGridListadoDeReservasClientes.TabIndex = 19;
            this.dataGridListadoDeReservasClientes.SelectionChanged += new System.EventHandler(this.dataGridUsuarios_SelectionChanged);
            // 
            // btnMoficiar
            // 
            this.btnMoficiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMoficiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMoficiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoficiar.FlatAppearance.BorderSize = 0;
            this.btnMoficiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnMoficiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMoficiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoficiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoficiar.ForeColor = System.Drawing.Color.LightGray;
            this.btnMoficiar.Location = new System.Drawing.Point(1111, 294);
            this.btnMoficiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoficiar.Name = "btnMoficiar";
            this.btnMoficiar.Size = new System.Drawing.Size(300, 39);
            this.btnMoficiar.TabIndex = 40;
            this.btnMoficiar.Text = "MODIFICAR";
            this.btnMoficiar.UseVisualStyleBackColor = false;
            this.btnMoficiar.Click += new System.EventHandler(this.btnMoficiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Location = new System.Drawing.Point(695, 294);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(300, 39);
            this.btnAgregar.TabIndex = 39;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.LightGray;
            this.btnBuscar.Location = new System.Drawing.Point(945, 204);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(368, 39);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblDni
            // 
            this.lblDni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblDni.Location = new System.Drawing.Point(689, 212);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(40, 23);
            this.lblDni.TabIndex = 42;
            this.lblDni.Text = "Dni";
            // 
            // txtDni
            // 
            this.txtDni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(757, 209);
            this.txtDni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(159, 30);
            this.txtDni.TabIndex = 41;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Logo,
            this.Dashboar,
            this.Gestion,
            this.Mantenimiento,
            this.toolStripMenuReportes,
            this.Usuarios,
            this.Clientes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 39);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(234, 749);
            this.menuStrip1.TabIndex = 56;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Logo
            // 
            this.Logo.AutoSize = false;
            this.Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo.BackgroundImage")));
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.Name = "Logo";
            this.Logo.Padding = new System.Windows.Forms.Padding(0);
            this.Logo.Size = new System.Drawing.Size(222, 130);
            // 
            // Dashboar
            // 
            this.Dashboar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Dashboar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboar.ForeColor = System.Drawing.Color.Cornsilk;
            this.Dashboar.Image = ((System.Drawing.Image)(resources.GetObject("Dashboar.Image")));
            this.Dashboar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Dashboar.Name = "Dashboar";
            this.Dashboar.Size = new System.Drawing.Size(223, 64);
            this.Dashboar.Text = "Dashboard";
            this.Dashboar.Click += new System.EventHandler(this.Dashboar_Click);
            // 
            // Gestion
            // 
            this.Gestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recepciónToolStripMenuItem,
            this.habitacionesToolStripMenuItem,
            this.pisosToolStripMenuItem1,
            this.reservasToolStripMenuItem});
            this.Gestion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gestion.ForeColor = System.Drawing.Color.Cornsilk;
            this.Gestion.Image = ((System.Drawing.Image)(resources.GetObject("Gestion.Image")));
            this.Gestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gestion.Name = "Gestion";
            this.Gestion.Size = new System.Drawing.Size(223, 64);
            this.Gestion.Text = "Gestión";
            // 
            // recepciónToolStripMenuItem
            // 
            this.recepciónToolStripMenuItem.Name = "recepciónToolStripMenuItem";
            this.recepciónToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.recepciónToolStripMenuItem.Text = "Recepción";
            this.recepciónToolStripMenuItem.Click += new System.EventHandler(this.recepciónToolStripMenuItem_Click);
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones";
            this.habitacionesToolStripMenuItem.Click += new System.EventHandler(this.habitacionesToolStripMenuItem_Click);
            // 
            // pisosToolStripMenuItem1
            // 
            this.pisosToolStripMenuItem1.Name = "pisosToolStripMenuItem1";
            this.pisosToolStripMenuItem1.Size = new System.Drawing.Size(222, 28);
            this.pisosToolStripMenuItem1.Text = "Pisos";
            this.pisosToolStripMenuItem1.Click += new System.EventHandler(this.pisosToolStripMenuItem1_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.reservasToolStripMenuItem.Text = "Reservas";
            this.reservasToolStripMenuItem.Click += new System.EventHandler(this.reservasToolStripMenuItem_Click);
            // 
            // Mantenimiento
            // 
            this.Mantenimiento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mantenimiento.ForeColor = System.Drawing.Color.Cornsilk;
            this.Mantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("Mantenimiento.Image")));
            this.Mantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Mantenimiento.Name = "Mantenimiento";
            this.Mantenimiento.Size = new System.Drawing.Size(223, 64);
            this.Mantenimiento.Text = "Mantenimiento";
            this.Mantenimiento.Click += new System.EventHandler(this.Mantenimiento_Click);
            // 
            // toolStripMenuReportes
            // 
            this.toolStripMenuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesToolStripMenuItem,
            this.listadoDePagosToolStripMenuItem});
            this.toolStripMenuReportes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuReportes.ForeColor = System.Drawing.Color.Cornsilk;
            this.toolStripMenuReportes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuReportes.Image")));
            this.toolStripMenuReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuReportes.Name = "toolStripMenuReportes";
            this.toolStripMenuReportes.Size = new System.Drawing.Size(223, 64);
            this.toolStripMenuReportes.Text = "Reportes";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // listadoDePagosToolStripMenuItem
            // 
            this.listadoDePagosToolStripMenuItem.Name = "listadoDePagosToolStripMenuItem";
            this.listadoDePagosToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.listadoDePagosToolStripMenuItem.Text = "Listado de Pagos";
            this.listadoDePagosToolStripMenuItem.Click += new System.EventHandler(this.listadoDePagosToolStripMenuItem_Click);
            // 
            // Usuarios
            // 
            this.Usuarios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuarios.ForeColor = System.Drawing.Color.Cornsilk;
            this.Usuarios.Image = ((System.Drawing.Image)(resources.GetObject("Usuarios.Image")));
            this.Usuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(223, 64);
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // Clientes
            // 
            this.Clientes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clientes.ForeColor = System.Drawing.Color.Cornsilk;
            this.Clientes.Image = ((System.Drawing.Image)(resources.GetObject("Clientes.Image")));
            this.Clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(223, 64);
            this.Clientes.Text = "Clientes";
            this.Clientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.pnlSuperior.Controls.Add(this.lblUsuario);
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Location = new System.Drawing.Point(301, 38);
            this.pnlSuperior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1547, 66);
            this.pnlSuperior.TabIndex = 55;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblUsuario.Location = new System.Drawing.Point(1135, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(79, 23);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(478, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "RESERVAS DE CLIENTES";
            // 
            // ReservadeCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(90)))), ((int)(((byte)(99)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1730, 788);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnMoficiar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataGridListadoDeReservasClientes);
            this.Controls.Add(this.barraTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReservadeCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReservadeCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.barraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListadoDeReservasClientes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.DataGridView dataGridListadoDeReservasClientes;
        private System.Windows.Forms.Button btnMoficiar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Logo;
        private System.Windows.Forms.ToolStripMenuItem Dashboar;
        private System.Windows.Forms.ToolStripMenuItem Gestion;
        private System.Windows.Forms.ToolStripMenuItem recepciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pisosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Mantenimiento;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuReportes;
        private System.Windows.Forms.ToolStripMenuItem Usuarios;
        private System.Windows.Forms.ToolStripMenuItem Clientes;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDePagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
    }
}