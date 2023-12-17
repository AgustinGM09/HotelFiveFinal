namespace Presentation.Admin
{
    partial class ReporteReservas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReservas = new System.Windows.Forms.Button();
            this.btnTopEmpleados = new System.Windows.Forms.Button();
            this.btnTopHabitacion = new System.Windows.Forms.Button();
            this.btnTopTipoHabitacion = new System.Windows.Forms.Button();
            this.btnTopClientesIngresos = new System.Windows.Forms.Button();
            this.btnTopClientes = new System.Windows.Forms.Button();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clientesIngresosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReservasHechas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridReportes = new System.Windows.Forms.DataGridView();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesIngresosBindingSource)).BeginInit();
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
            this.barraTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(810, 32);
            this.barraTitulo.TabIndex = 42;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::Presentation.Properties.Resources.maximizar;
            this.btnMaximizar.Location = new System.Drawing.Point(734, 2);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(22, 24);
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
            this.btnMinimizar.Location = new System.Drawing.Point(689, 2);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(22, 24);
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
            this.btnCerrar.Location = new System.Drawing.Point(778, 2);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(22, 24);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.btnReservas);
            this.panel1.Controls.Add(this.btnTopEmpleados);
            this.panel1.Controls.Add(this.btnTopHabitacion);
            this.panel1.Controls.Add(this.btnTopTipoHabitacion);
            this.panel1.Controls.Add(this.btnTopClientesIngresos);
            this.panel1.Controls.Add(this.btnTopClientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 618);
            this.panel1.TabIndex = 43;
            // 
            // btnReservas
            // 
            this.btnReservas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnReservas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReservas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReservas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservas.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnReservas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReservas.Location = new System.Drawing.Point(0, 466);
            this.btnReservas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Size = new System.Drawing.Size(170, 89);
            this.btnReservas.TabIndex = 7;
            this.btnReservas.Text = "TOP RESERVAS";
            this.btnReservas.UseVisualStyleBackColor = false;
            // 
            // btnTopEmpleados
            // 
            this.btnTopEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopEmpleados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopEmpleados.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopEmpleados.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnTopEmpleados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopEmpleados.Location = new System.Drawing.Point(0, 374);
            this.btnTopEmpleados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTopEmpleados.Name = "btnTopEmpleados";
            this.btnTopEmpleados.Size = new System.Drawing.Size(170, 89);
            this.btnTopEmpleados.TabIndex = 6;
            this.btnTopEmpleados.Text = "TOP EMPLEADOS";
            this.btnTopEmpleados.UseVisualStyleBackColor = false;
            // 
            // btnTopHabitacion
            // 
            this.btnTopHabitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopHabitacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopHabitacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopHabitacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopHabitacion.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnTopHabitacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopHabitacion.Location = new System.Drawing.Point(4, 281);
            this.btnTopHabitacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTopHabitacion.Name = "btnTopHabitacion";
            this.btnTopHabitacion.Size = new System.Drawing.Size(170, 89);
            this.btnTopHabitacion.TabIndex = 5;
            this.btnTopHabitacion.Text = "TOP HABITACION MAS PEDIDA";
            this.btnTopHabitacion.UseVisualStyleBackColor = false;
            // 
            // btnTopTipoHabitacion
            // 
            this.btnTopTipoHabitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopTipoHabitacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopTipoHabitacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopTipoHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopTipoHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopTipoHabitacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopTipoHabitacion.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnTopTipoHabitacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopTipoHabitacion.Location = new System.Drawing.Point(0, 188);
            this.btnTopTipoHabitacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTopTipoHabitacion.Name = "btnTopTipoHabitacion";
            this.btnTopTipoHabitacion.Size = new System.Drawing.Size(170, 89);
            this.btnTopTipoHabitacion.TabIndex = 4;
            this.btnTopTipoHabitacion.Text = "TOP TIPO DE HABITACION MAS PEDIDA";
            this.btnTopTipoHabitacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTopTipoHabitacion.UseVisualStyleBackColor = false;
            // 
            // btnTopClientesIngresos
            // 
            this.btnTopClientesIngresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopClientesIngresos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopClientesIngresos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopClientesIngresos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopClientesIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopClientesIngresos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopClientesIngresos.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnTopClientesIngresos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopClientesIngresos.Location = new System.Drawing.Point(4, 96);
            this.btnTopClientesIngresos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTopClientesIngresos.Name = "btnTopClientesIngresos";
            this.btnTopClientesIngresos.Size = new System.Drawing.Size(170, 89);
            this.btnTopClientesIngresos.TabIndex = 3;
            this.btnTopClientesIngresos.Text = "TOP CLIENTES MAYORES INGRESOS";
            this.btnTopClientesIngresos.UseVisualStyleBackColor = false;
            // 
            // btnTopClientes
            // 
            this.btnTopClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTopClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.btnTopClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopClientes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopClientes.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnTopClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTopClientes.Location = new System.Drawing.Point(2, 3);
            this.btnTopClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTopClientes.Name = "btnTopClientes";
            this.btnTopClientes.Size = new System.Drawing.Size(170, 89);
            this.btnTopClientes.TabIndex = 2;
            this.btnTopClientes.Text = "TOP CLIENTES MAS FRECUENTES";
            this.btnTopClientes.UseVisualStyleBackColor = false;
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart2.Legends.Add(legend5);
            this.chart2.Location = new System.Drawing.Point(500, 48);
            this.chart2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart2.Name = "chart2";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart2.Series.Add(series5);
            this.chart2.Size = new System.Drawing.Size(300, 320);
            this.chart2.TabIndex = 45;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(179, 48);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series6.Legend = "Legend1";
            series6.MarkerSize = 12;
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(303, 320);
            this.chart1.TabIndex = 40;
            this.chart1.Text = "chart1";
            // 
            // ReservasHechas
            // 
            this.ReservasHechas.HeaderText = "Reservas Hechas";
            this.ReservasHechas.MinimumWidth = 6;
            this.ReservasHechas.Name = "ReservasHechas";
            this.ReservasHechas.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // dataGridReportes
            // 
            this.dataGridReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReportes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.ReservasHechas});
            this.dataGridReportes.Location = new System.Drawing.Point(179, 384);
            this.dataGridReportes.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridReportes.Name = "dataGridReportes";
            this.dataGridReportes.RowHeadersWidth = 51;
            this.dataGridReportes.RowTemplate.Height = 24;
            this.dataGridReportes.Size = new System.Drawing.Size(622, 256);
            this.dataGridReportes.TabIndex = 46;
            // 
            // ReporteReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(810, 650);
            this.Controls.Add(this.dataGridReportes);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barraTitulo);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReporteReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Reservas";
            this.Load += new System.EventHandler(this.ReporteReservas_Load_1);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReporteReservas_MouseDown);
            this.barraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesIngresosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button btnTopHabitacion;
        private System.Windows.Forms.Button btnTopTipoHabitacion;
        private System.Windows.Forms.Button btnTopClientesIngresos;
        private System.Windows.Forms.Button btnTopClientes;
        private System.Windows.Forms.Button btnTopEmpleados;
        private System.Windows.Forms.Button btnReservas;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.BindingSource clientesIngresosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservasHechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridView dataGridReportes;
    }
}