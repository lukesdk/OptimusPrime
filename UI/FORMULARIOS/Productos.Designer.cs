﻿// <auto-generated/>
namespace UI
{
    partial class Productos
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNroProd = new System.Windows.Forms.Label();
            this.lblPecioVenta = new System.Windows.Forms.Label();
            this.btnSelVta = new System.Windows.Forms.Button();
            this.lblPreUnitario = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtPcosto = new System.Windows.Forms.TextBox();
            this.txtPunitario = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblCant = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.txtMinStock = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgProd = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInactivos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnVolver.Location = new System.Drawing.Point(11, 7);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(96, 46);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNroProd
            // 
            this.lblNroProd.AutoSize = true;
            this.lblNroProd.Location = new System.Drawing.Point(243, 9);
            this.lblNroProd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNroProd.Name = "lblNroProd";
            this.lblNroProd.Size = new System.Drawing.Size(68, 13);
            this.lblNroProd.TabIndex = 25;
            this.lblNroProd.Text = "PRODUCTO";
            // 
            // lblPecioVenta
            // 
            this.lblPecioVenta.AutoSize = true;
            this.lblPecioVenta.Location = new System.Drawing.Point(139, 110);
            this.lblPecioVenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPecioVenta.Name = "lblPecioVenta";
            this.lblPecioVenta.Size = new System.Drawing.Size(107, 13);
            this.lblPecioVenta.TabIndex = 24;
            this.lblPecioVenta.Text = "PRECIO DE VENTA:";
            // 
            // btnSelVta
            // 
            this.btnSelVta.BackColor = System.Drawing.Color.Yellow;
            this.btnSelVta.Location = new System.Drawing.Point(7, 436);
            this.btnSelVta.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelVta.Name = "btnSelVta";
            this.btnSelVta.Size = new System.Drawing.Size(126, 49);
            this.btnSelVta.TabIndex = 5;
            this.btnSelVta.Text = "SELECCIONAR PRODUCTO";
            this.btnSelVta.UseVisualStyleBackColor = false;
            this.btnSelVta.Click += new System.EventHandler(this.btnSelVta_Click);
            // 
            // lblPreUnitario
            // 
            this.lblPreUnitario.AutoSize = true;
            this.lblPreUnitario.Location = new System.Drawing.Point(139, 80);
            this.lblPreUnitario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPreUnitario.Name = "lblPreUnitario";
            this.lblPreUnitario.Size = new System.Drawing.Size(105, 13);
            this.lblPreUnitario.TabIndex = 22;
            this.lblPreUnitario.Text = "PRECIO UNITARIO:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(138, 49);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(83, 13);
            this.lblDesc.TabIndex = 21;
            this.lblDesc.Text = "DESCRIPCION:";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Red;
            this.btnBorrar.Location = new System.Drawing.Point(696, 181);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(126, 44);
            this.btnBorrar.TabIndex = 3;
            this.btnBorrar.Text = "BORRAR PRODUCTO";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnModificar.Location = new System.Drawing.Point(313, 181);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(126, 45);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "MODIFICAR PRODUCTO";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtPcosto
            // 
            this.txtPcosto.Location = new System.Drawing.Point(246, 107);
            this.txtPcosto.Margin = new System.Windows.Forms.Padding(2);
            this.txtPcosto.Name = "txtPcosto";
            this.txtPcosto.Size = new System.Drawing.Size(292, 20);
            this.txtPcosto.TabIndex = 18;
            // 
            // txtPunitario
            // 
            this.txtPunitario.Location = new System.Drawing.Point(246, 77);
            this.txtPunitario.Margin = new System.Windows.Forms.Padding(2);
            this.txtPunitario.Name = "txtPunitario";
            this.txtPunitario.Size = new System.Drawing.Size(292, 20);
            this.txtPunitario.TabIndex = 17;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(246, 46);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(292, 20);
            this.txtDescripcion.TabIndex = 16;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Lime;
            this.btnNuevo.Location = new System.Drawing.Point(7, 181);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(126, 45);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "NUEVO PRODUCTO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(15, 43);
            this.lblCant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(65, 13);
            this.lblCant.TabIndex = 30;
            this.lblCant.Text = "CANTIDAD:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(116, 40);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(125, 20);
            this.txtCantidad.TabIndex = 19;
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Location = new System.Drawing.Point(6, 102);
            this.lblMinStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(89, 13);
            this.lblMinStock.TabIndex = 32;
            this.lblMinStock.Text = "STOCK MINIMO:";
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(116, 95);
            this.txtMinStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(125, 20);
            this.txtMinStock.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCant);
            this.groupBox1.Controls.Add(this.txtMinStock);
            this.groupBox1.Controls.Add(this.lblMinStock);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Location = new System.Drawing.Point(558, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(258, 133);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INVENTARIO";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgProd
            // 
            this.dgProd.AllowUserToAddRows = false;
            this.dgProd.AllowUserToDeleteRows = false;
            this.dgProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.PUnitario,
            this.PVenta,
            this.Stock,
            this.MinStock});
            this.dgProd.Location = new System.Drawing.Point(7, 231);
            this.dgProd.Name = "dgProd";
            this.dgProd.ReadOnly = true;
            this.dgProd.Size = new System.Drawing.Size(815, 200);
            this.dgProd.TabIndex = 34;
            this.dgProd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProd_CellClick);
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 88;
            // 
            // PUnitario
            // 
            this.PUnitario.DataPropertyName = "PUnitario";
            this.PUnitario.HeaderText = "Precio Unitario";
            this.PUnitario.Name = "PUnitario";
            this.PUnitario.ReadOnly = true;
            this.PUnitario.Width = 101;
            // 
            // PVenta
            // 
            this.PVenta.DataPropertyName = "PVenta";
            this.PVenta.HeaderText = "Precio Venta";
            this.PVenta.Name = "PVenta";
            this.PVenta.ReadOnly = true;
            this.PVenta.Width = 93;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Cantidad";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 74;
            // 
            // MinStock
            // 
            this.MinStock.DataPropertyName = "MinStock";
            this.MinStock.HeaderText = "Stock Minimo";
            this.MinStock.Name = "MinStock";
            this.MinStock.ReadOnly = true;
            this.MinStock.Width = 96;
            // 
            // btnInactivos
            // 
            this.btnInactivos.BackColor = System.Drawing.Color.Gray;
            this.btnInactivos.Location = new System.Drawing.Point(696, 437);
            this.btnInactivos.Name = "btnInactivos";
            this.btnInactivos.Size = new System.Drawing.Size(126, 48);
            this.btnInactivos.TabIndex = 4;
            this.btnInactivos.Text = "PRODUCTOS INACTIVOS";
            this.btnInactivos.UseVisualStyleBackColor = false;
            this.btnInactivos.Click += new System.EventHandler(this.btnInactivos_Click);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 496);
            this.Controls.Add(this.btnInactivos);
            this.Controls.Add(this.dgProd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblNroProd);
            this.Controls.Add(this.lblPecioVenta);
            this.Controls.Add(this.btnSelVta);
            this.Controls.Add(this.lblPreUnitario);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtPcosto);
            this.Controls.Add(this.txtPunitario);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Productos_FormClosing);
            this.Load += new System.EventHandler(this.Productos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblNroProd;
        private System.Windows.Forms.Label lblPecioVenta;
        private System.Windows.Forms.Button btnSelVta;
        private System.Windows.Forms.Label lblPreUnitario;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtPcosto;
        private System.Windows.Forms.TextBox txtPunitario;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.TextBox txtMinStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgProd;
        private System.Windows.Forms.Button btnInactivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn PVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinStock;
    }
}