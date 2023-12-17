
namespace Presentation.Admin
{
    partial class Reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportes));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
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
            this.lisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnlDetalleHabitacion = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridReportes = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReservasPorMes = new System.Windows.Forms.Button();
            this.btnTopClientes = new System.Windows.Forms.Button();
            this.btnTopTipoHabitacionesMasReservadas = new System.Windows.Forms.Button();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlDetalleHabitacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).BeginInit();
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
            this.barraTitulo.TabIndex = 16;
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
            this.menuStrip1.Size = new System.Drawing.Size(234, 931);
            this.menuStrip1.TabIndex = 17;
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
            this.lisToolStripMenuItem});
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
            // lisToolStripMenuItem
            // 
            this.lisToolStripMenuItem.Name = "lisToolStripMenuItem";
            this.lisToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.lisToolStripMenuItem.Text = "Listado de Pagos";
            this.lisToolStripMenuItem.Click += new System.EventHandler(this.lisToolStripMenuItem_Click);
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
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Controls.Add(this.lblUsuario);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(234, 39);
            this.pnlSuperior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1496, 66);
            this.pnlSuperior.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(242, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 32);
            this.label1.TabIndex = 26;
            this.label1.Text = "REPORTES";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblUsuario.Location = new System.Drawing.Point(1244, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(79, 23);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // pnlDetalleHabitacion
            // 
            this.pnlDetalleHabitacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlDetalleHabitacion.AutoSize = true;
            this.pnlDetalleHabitacion.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetalleHabitacion.Controls.Add(this.lblTitulo);
            this.pnlDetalleHabitacion.Controls.Add(this.lblFechaFin);
            this.pnlDetalleHabitacion.Controls.Add(this.lblFechaInicio);
            this.pnlDetalleHabitacion.Controls.Add(this.chart1);
            this.pnlDetalleHabitacion.Controls.Add(this.dateTimePicker2);
            this.pnlDetalleHabitacion.Controls.Add(this.dataGridReportes);
            this.pnlDetalleHabitacion.Controls.Add(this.btnBuscar);
            this.pnlDetalleHabitacion.Controls.Add(this.dateTimePicker1);
            this.pnlDetalleHabitacion.Location = new System.Drawing.Point(321, 330);
            this.pnlDetalleHabitacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDetalleHabitacion.Name = "pnlDetalleHabitacion";
            this.pnlDetalleHabitacion.Size = new System.Drawing.Size(1453, 576);
            this.pnlDetalleHabitacion.TabIndex = 56;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblTitulo.Location = new System.Drawing.Point(17, 67);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(59, 23);
            this.lblTitulo.TabIndex = 64;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.Visible = false;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblFechaFin.Location = new System.Drawing.Point(497, 44);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(104, 23);
            this.lblFechaFin.TabIndex = 58;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblFechaInicio.Location = new System.Drawing.Point(496, 4);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(131, 23);
            this.lblFechaInicio.TabIndex = 57;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(733, 98);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(695, 447);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(667, 50);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 22);
            this.dateTimePicker2.TabIndex = 63;
            // 
            // dataGridReportes
            // 
            this.dataGridReportes.AllowUserToAddRows = false;
            this.dataGridReportes.AllowUserToDeleteRows = false;
            this.dataGridReportes.AllowUserToResizeColumns = false;
            this.dataGridReportes.AllowUserToResizeRows = false;
            this.dataGridReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridReportes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridReportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReportes.Location = new System.Drawing.Point(21, 98);
            this.dataGridReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridReportes.MultiSelect = false;
            this.dataGridReportes.Name = "dataGridReportes";
            this.dataGridReportes.RowHeadersVisible = false;
            this.dataGridReportes.RowHeadersWidth = 51;
            this.dataGridReportes.RowTemplate.Height = 24;
            this.dataGridReportes.Size = new System.Drawing.Size(707, 449);
            this.dataGridReportes.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(824, 44);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(153, 28);
            this.btnBuscar.TabIndex = 62;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(667, 4);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 22);
            this.dateTimePicker1.TabIndex = 61;
            // 
            // btnReservasPorMes
            // 
            this.btnReservasPorMes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReservasPorMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(129)))), ((int)(((byte)(59)))));
            this.btnReservasPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservasPorMes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservasPorMes.Image = ((System.Drawing.Image)(resources.GetObject("btnReservasPorMes.Image")));
            this.btnReservasPorMes.Location = new System.Drawing.Point(1237, 129);
            this.btnReservasPorMes.Margin = new System.Windows.Forms.Padding(4);
            this.btnReservasPorMes.Name = "btnReservasPorMes";
            this.btnReservasPorMes.Size = new System.Drawing.Size(367, 154);
            this.btnReservasPorMes.TabIndex = 54;
            this.btnReservasPorMes.Text = "Reservas por Periodo";
            this.btnReservasPorMes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReservasPorMes.UseVisualStyleBackColor = false;
            this.btnReservasPorMes.Click += new System.EventHandler(this.btnReservasPorMes_Click);
            // 
            // btnTopClientes
            // 
            this.btnTopClientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTopClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(109)))), ((int)(((byte)(183)))));
            this.btnTopClientes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopClientes.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnTopClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnTopClientes.Image")));
            this.btnTopClientes.Location = new System.Drawing.Point(821, 129);
            this.btnTopClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnTopClientes.Name = "btnTopClientes";
            this.btnTopClientes.Size = new System.Drawing.Size(367, 154);
            this.btnTopClientes.TabIndex = 53;
            this.btnTopClientes.Text = "Top Clientes";
            this.btnTopClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopClientes.UseVisualStyleBackColor = false;
            this.btnTopClientes.Click += new System.EventHandler(this.btnTopClientes_Click);
            // 
            // btnTopTipoHabitacionesMasReservadas
            // 
            this.btnTopTipoHabitacionesMasReservadas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTopTipoHabitacionesMasReservadas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopTipoHabitacionesMasReservadas.Image = ((System.Drawing.Image)(resources.GetObject("btnTopTipoHabitacionesMasReservadas.Image")));
            this.btnTopTipoHabitacionesMasReservadas.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTopTipoHabitacionesMasReservadas.Location = new System.Drawing.Point(400, 129);
            this.btnTopTipoHabitacionesMasReservadas.Margin = new System.Windows.Forms.Padding(4);
            this.btnTopTipoHabitacionesMasReservadas.Name = "btnTopTipoHabitacionesMasReservadas";
            this.btnTopTipoHabitacionesMasReservadas.Size = new System.Drawing.Size(367, 154);
            this.btnTopTipoHabitacionesMasReservadas.TabIndex = 52;
            this.btnTopTipoHabitacionesMasReservadas.Text = "Top Tipo Habitaciones Más reservadas";
            this.btnTopTipoHabitacionesMasReservadas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopTipoHabitacionesMasReservadas.UseVisualStyleBackColor = true;
            this.btnTopTipoHabitacionesMasReservadas.Click += new System.EventHandler(this.btnTopTipoHabitacionesMasReservadas_Click);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(90)))), ((int)(((byte)(99)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1730, 970);
            this.Controls.Add(this.pnlDetalleHabitacion);
            this.Controls.Add(this.btnReservasPorMes);
            this.Controls.Add(this.btnTopClientes);
            this.Controls.Add(this.btnTopTipoHabitacionesMasReservadas);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.barraTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.barraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlDetalleHabitacion.ResumeLayout(false);
            this.pnlDetalleHabitacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
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
        private System.Windows.Forms.Panel pnlDetalleHabitacion;
        private System.Windows.Forms.DataGridView dataGridReportes;
        private System.Windows.Forms.Button btnReservasPorMes;
        private System.Windows.Forms.Button btnTopClientes;
        private System.Windows.Forms.Button btnTopTipoHabitacionesMasReservadas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lisToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblTitulo;
    }
}