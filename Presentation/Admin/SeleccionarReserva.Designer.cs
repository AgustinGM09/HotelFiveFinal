namespace Presentation.Admin
{
    partial class SeleccionarReserva
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
            this.dataGridClienteReserva = new System.Windows.Forms.DataGridView();
            this.lblAgregar = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAeptar = new System.Windows.Forms.Button();
            this.btnBuscarDNI = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClienteReserva)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridClienteReserva
            // 
            this.dataGridClienteReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClienteReserva.Location = new System.Drawing.Point(12, 113);
            this.dataGridClienteReserva.MultiSelect = false;
            this.dataGridClienteReserva.Name = "dataGridClienteReserva";
            this.dataGridClienteReserva.ReadOnly = true;
            this.dataGridClienteReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridClienteReserva.Size = new System.Drawing.Size(576, 252);
            this.dataGridClienteReserva.TabIndex = 0;
            // 
            // lblAgregar
            // 
            this.lblAgregar.AutoSize = true;
            this.lblAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgregar.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblAgregar.Location = new System.Drawing.Point(174, 28);
            this.lblAgregar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAgregar.Name = "lblAgregar";
            this.lblAgregar.Size = new System.Drawing.Size(207, 21);
            this.lblAgregar.TabIndex = 56;
            this.lblAgregar.Text = "SELECCIONE LA RESERVA";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Location = new System.Drawing.Point(347, 394);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(225, 32);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAeptar
            // 
            this.btnAeptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAeptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAeptar.FlatAppearance.BorderSize = 0;
            this.btnAeptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnAeptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAeptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAeptar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAeptar.ForeColor = System.Drawing.Color.LightGray;
            this.btnAeptar.Location = new System.Drawing.Point(26, 394);
            this.btnAeptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAeptar.Name = "btnAeptar";
            this.btnAeptar.Size = new System.Drawing.Size(225, 32);
            this.btnAeptar.TabIndex = 57;
            this.btnAeptar.Text = "ACEPTAR";
            this.btnAeptar.UseVisualStyleBackColor = false;
            this.btnAeptar.Click += new System.EventHandler(this.btnAeptar_Click);
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.Location = new System.Drawing.Point(209, 66);
            this.btnBuscarDNI.Name = "btnBuscarDNI";
            this.btnBuscarDNI.Size = new System.Drawing.Size(115, 23);
            this.btnBuscarDNI.TabIndex = 66;
            this.btnBuscarDNI.Text = "Buscar DNI";
            this.btnBuscarDNI.UseVisualStyleBackColor = true;
            this.btnBuscarDNI.Click += new System.EventHandler(this.btnBuscarDNI_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 65;
            this.label3.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(69, 68);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 64;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // SeleccionarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(600, 447);
            this.Controls.Add(this.btnBuscarDNI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAeptar);
            this.Controls.Add(this.lblAgregar);
            this.Controls.Add(this.dataGridClienteReserva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionarReserva";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClienteReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridClienteReserva;
        private System.Windows.Forms.Label lblAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAeptar;
        private System.Windows.Forms.Button btnBuscarDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDNI;
    }
}