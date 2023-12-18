namespace Presentation.Admin
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnTotalHabitaciones = new System.Windows.Forms.Button();
            this.btnHabitacionesDisponibles = new System.Windows.Forms.Button();
            this.btnHabitacionesOcupadas = new System.Windows.Forms.Button();
            this.btnHabitacionesEnLimpieza = new System.Windows.Forms.Button();
            this.pnlDetalleHabitacion = new System.Windows.Forms.Panel();
            this.dataGridHabitaciones = new System.Windows.Forms.DataGridView();
            this.lblListaHabitacion = new System.Windows.Forms.Label();
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
            this.pnlDetalleHabitacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabitaciones)).BeginInit();
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
            this.barraTitulo.TabIndex = 15;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
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
            // btnTotalHabitaciones
            // 
            this.btnTotalHabitaciones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTotalHabitaciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalHabitaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnTotalHabitaciones.Image")));
            this.btnTotalHabitaciones.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTotalHabitaciones.Location = new System.Drawing.Point(311, 148);
            this.btnTotalHabitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.btnTotalHabitaciones.Name = "btnTotalHabitaciones";
            this.btnTotalHabitaciones.Size = new System.Drawing.Size(297, 154);
            this.btnTotalHabitaciones.TabIndex = 16;
            this.btnTotalHabitaciones.Text = "Total Habitaciones";
            this.btnTotalHabitaciones.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTotalHabitaciones.UseVisualStyleBackColor = true;
            this.btnTotalHabitaciones.Click += new System.EventHandler(this.btnTotalHabitaciones_Click);
            // 
            // btnHabitacionesDisponibles
            // 
            this.btnHabitacionesDisponibles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHabitacionesDisponibles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(183)))));
            this.btnHabitacionesDisponibles.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabitacionesDisponibles.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnHabitacionesDisponibles.Image = ((System.Drawing.Image)(resources.GetObject("btnHabitacionesDisponibles.Image")));
            this.btnHabitacionesDisponibles.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabitacionesDisponibles.Location = new System.Drawing.Point(689, 148);
            this.btnHabitacionesDisponibles.Margin = new System.Windows.Forms.Padding(4);
            this.btnHabitacionesDisponibles.Name = "btnHabitacionesDisponibles";
            this.btnHabitacionesDisponibles.Size = new System.Drawing.Size(297, 154);
            this.btnHabitacionesDisponibles.TabIndex = 17;
            this.btnHabitacionesDisponibles.Text = "Habitaciones Disponibles:";
            this.btnHabitacionesDisponibles.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHabitacionesDisponibles.UseVisualStyleBackColor = false;
            this.btnHabitacionesDisponibles.Click += new System.EventHandler(this.btnHabitacionesDisponibles_Click);
            // 
            // btnHabitacionesOcupadas
            // 
            this.btnHabitacionesOcupadas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHabitacionesOcupadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(129)))), ((int)(((byte)(59)))));
            this.btnHabitacionesOcupadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabitacionesOcupadas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabitacionesOcupadas.Image = ((System.Drawing.Image)(resources.GetObject("btnHabitacionesOcupadas.Image")));
            this.btnHabitacionesOcupadas.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabitacionesOcupadas.Location = new System.Drawing.Point(1073, 148);
            this.btnHabitacionesOcupadas.Margin = new System.Windows.Forms.Padding(4);
            this.btnHabitacionesOcupadas.Name = "btnHabitacionesOcupadas";
            this.btnHabitacionesOcupadas.Size = new System.Drawing.Size(297, 154);
            this.btnHabitacionesOcupadas.TabIndex = 18;
            this.btnHabitacionesOcupadas.Text = "Habitaciones Ocupadas:";
            this.btnHabitacionesOcupadas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHabitacionesOcupadas.UseVisualStyleBackColor = false;
            this.btnHabitacionesOcupadas.Click += new System.EventHandler(this.btnHabitacionesOcupadas_Click);
            // 
            // btnHabitacionesEnLimpieza
            // 
            this.btnHabitacionesEnLimpieza.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHabitacionesEnLimpieza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(148)))), ((int)(((byte)(77)))));
            this.btnHabitacionesEnLimpieza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabitacionesEnLimpieza.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabitacionesEnLimpieza.Image = ((System.Drawing.Image)(resources.GetObject("btnHabitacionesEnLimpieza.Image")));
            this.btnHabitacionesEnLimpieza.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabitacionesEnLimpieza.Location = new System.Drawing.Point(1456, 148);
            this.btnHabitacionesEnLimpieza.Margin = new System.Windows.Forms.Padding(4);
            this.btnHabitacionesEnLimpieza.Name = "btnHabitacionesEnLimpieza";
            this.btnHabitacionesEnLimpieza.Size = new System.Drawing.Size(297, 154);
            this.btnHabitacionesEnLimpieza.TabIndex = 19;
            this.btnHabitacionesEnLimpieza.Text = "Habitaciones en Limpieza";
            this.btnHabitacionesEnLimpieza.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHabitacionesEnLimpieza.UseVisualStyleBackColor = false;
            this.btnHabitacionesEnLimpieza.Click += new System.EventHandler(this.btnHabitacionesEnLimpieza_Click);
            // 
            // pnlDetalleHabitacion
            // 
            this.pnlDetalleHabitacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlDetalleHabitacion.AutoSize = true;
            this.pnlDetalleHabitacion.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetalleHabitacion.Controls.Add(this.dataGridHabitaciones);
            this.pnlDetalleHabitacion.Controls.Add(this.lblListaHabitacion);
            this.pnlDetalleHabitacion.Location = new System.Drawing.Point(311, 308);
            this.pnlDetalleHabitacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDetalleHabitacion.Name = "pnlDetalleHabitacion";
            this.pnlDetalleHabitacion.Size = new System.Drawing.Size(1453, 532);
            this.pnlDetalleHabitacion.TabIndex = 51;
            // 
            // dataGridHabitaciones
            // 
            this.dataGridHabitaciones.AllowUserToAddRows = false;
            this.dataGridHabitaciones.AllowUserToDeleteRows = false;
            this.dataGridHabitaciones.AllowUserToResizeColumns = false;
            this.dataGridHabitaciones.AllowUserToResizeRows = false;
            this.dataGridHabitaciones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHabitaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHabitaciones.Location = new System.Drawing.Point(37, 35);
            this.dataGridHabitaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridHabitaciones.MultiSelect = false;
            this.dataGridHabitaciones.Name = "dataGridHabitaciones";
            this.dataGridHabitaciones.RowHeadersVisible = false;
            this.dataGridHabitaciones.RowHeadersWidth = 51;
            this.dataGridHabitaciones.RowTemplate.Height = 24;
            this.dataGridHabitaciones.Size = new System.Drawing.Size(1413, 407);
            this.dataGridHabitaciones.TabIndex = 1;
            // 
            // lblListaHabitacion
            // 
            this.lblListaHabitacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblListaHabitacion.AutoSize = true;
            this.lblListaHabitacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaHabitacion.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblListaHabitacion.Location = new System.Drawing.Point(55, 10);
            this.lblListaHabitacion.Name = "lblListaHabitacion";
            this.lblListaHabitacion.Size = new System.Drawing.Size(292, 23);
            this.lblListaHabitacion.TabIndex = 0;
            this.lblListaHabitacion.Text = "Lista de Habitaciones Totales";
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
            this.menuStrip1.TabIndex = 53;
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
            this.recepciónToolStripMenuItem.Click += new System.EventHandler(this.recepciónToolStripMenuItem_Click_1);
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(222, 28);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones";
            this.habitacionesToolStripMenuItem.Click += new System.EventHandler(this.habitacionesToolStripMenuItem_Click_1);
            // 
            // pisosToolStripMenuItem1
            // 
            this.pisosToolStripMenuItem1.Name = "pisosToolStripMenuItem1";
            this.pisosToolStripMenuItem1.Size = new System.Drawing.Size(222, 28);
            this.pisosToolStripMenuItem1.Text = "Pisos";
            this.pisosToolStripMenuItem1.Click += new System.EventHandler(this.pisosToolStripMenuItem1_Click_1);
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
            this.toolStripMenuReportes.Click += new System.EventHandler(this.toolStripMenuReportes_Click_1);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuReportes_Click);
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
            this.pnlSuperior.Location = new System.Drawing.Point(230, 39);
            this.pnlSuperior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1618, 66);
            this.pnlSuperior.TabIndex = 52;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblUsuario.Location = new System.Drawing.Point(1254, 16);
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
            this.label1.Location = new System.Drawing.Point(662, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "DASHBOARD";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(90)))), ((int)(((byte)(99)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1730, 788);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlDetalleHabitacion);
            this.Controls.Add(this.btnHabitacionesEnLimpieza);
            this.Controls.Add(this.btnHabitacionesOcupadas);
            this.Controls.Add(this.btnHabitacionesDisponibles);
            this.Controls.Add(this.btnTotalHabitaciones);
            this.Controls.Add(this.barraTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            this.barraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.pnlDetalleHabitacion.ResumeLayout(false);
            this.pnlDetalleHabitacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabitaciones)).EndInit();
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
        private System.Windows.Forms.Button btnTotalHabitaciones;
        private System.Windows.Forms.Button btnHabitacionesDisponibles;
        private System.Windows.Forms.Button btnHabitacionesOcupadas;
        private System.Windows.Forms.Button btnHabitacionesEnLimpieza;
        private System.Windows.Forms.Panel pnlDetalleHabitacion;
        private System.Windows.Forms.DataGridView dataGridHabitaciones;
        private System.Windows.Forms.Label lblListaHabitacion;
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