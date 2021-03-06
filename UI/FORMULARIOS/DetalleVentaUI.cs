// <auto-generated/>

namespace UI
{
    using BE.Entidades;
    using BLL;
    using DAL.Dao.Imp;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class DetalleVentaUI : Form, IDetalleVenta
    {
        private const string nombreForm = "Venta";
        private const string nomEntidad = "DetalleVenta";
        private const string campoId = "DetalleId";

        private readonly IVentaBLL ventaBLL;
        private readonly IDetalleVentaBLL detalleVentaBLL;
        private readonly IProductoBLL productoBLL;
        private readonly IProductos productos;
        private readonly IClienteBLL clienteBLL;
        private readonly IClientes cliente;
        private readonly IFormControl formControl;
        private readonly ITraductor traductor;
        private readonly SqlUtils sqlUtils = new SqlUtils();

        public Cliente ClienteSeleccionado { get; set; } = new Cliente();
        public Producto ProductoSeleccionado { get; set; } = new Producto();
        public Usuario UsuarioActivo { get; set; } = new Usuario();
        public LineaDetalle LineaDetalleSeleccionada { get; set; } = new LineaDetalle();
        private List<LineaDetalle> ListGrid { get; set; } = new List<LineaDetalle>();
        private DetalleVenta DetalleEnGrid { get; set; }

        public DetalleVentaUI(
            IVentaBLL ventaBLL,
            IDetalleVentaBLL detalleVentaBLL,
            IProductoBLL productoBLL,
            IProductos productos,
            IClienteBLL clienteBLL,
            IClientes cliente,
            IFormControl formControl,
            ITraductor traductor)
        {
            this.ventaBLL = ventaBLL;
            this.detalleVentaBLL = detalleVentaBLL;
            this.productoBLL = productoBLL;
            this.productos = productos;
            this.cliente = cliente;
            this.clienteBLL = clienteBLL;
            this.formControl = formControl;
            this.traductor = traductor;
            InitializeComponent();
            dgDetalleVta.AutoGenerateColumns = false;
        }

        private void VtaProd_Load(object sender, EventArgs e)
        {
            UsuarioActivo = formControl.ObtenerInfoUsuario();

            traductor.Traduccir(this, nomEntidad);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (ProductoSeleccionado.ProductoId != 0 && !string.IsNullOrEmpty(txtCant.Text))
            {
                ListGrid.Add(CrearNuevaLinea());

                RecargarDatagrid();

                LimpiarControles();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCodProd.Text) && !string.IsNullOrEmpty(txtCant.Text))
                {
                    ProductoSeleccionado = productoBLL.ObtenerProductoPorCodigo(txtCodProd.Text);

                    if (ProductoSeleccionado != null)
                    {
                        ListGrid.Add(CrearNuevaLinea());

                        RecargarDatagrid();

                        LimpiarControles();
                    }
                    else
                    {
                        Alert.ShowSimpleAlert("El codigo de producto no existe", "MSJ080");
                    }
                }
                else
                {
                    Alert.ShowSimpleAlert("Debe Seleccionar al menos un producto y la cantidad", "MSJ082");
                }
            }
        }

        private LineaDetalle CrearNuevaLinea()
        {
            return new LineaDetalle()
            {
                Producto = ProductoSeleccionado,
                DescProducto = ProductoSeleccionado.Descripcion,
                Cantidad = int.Parse(txtCant.Text),
                Importe = ProductoSeleccionado.PVenta * int.Parse(txtCant.Text)
            };
        }

        private void LimpiarControles()
        {
            txtCant.Text = string.Empty;
            txtCodProd.Text = string.Empty;
           
        }

        private Venta CrearNuevaVenta(int estadoId, DateTime fecha, float monto, int tipoVta, int usuarioId, int clienteId)
        {
            return new Venta()
            {
                ClienteId = clienteId,
                EstadoId = estadoId,
                Fecha = fecha,
                Monto = monto,
                TipoVentaId = tipoVta,
                UsuarioId = usuarioId,
            };
        }

        private void RecargarDatagrid()
        {
            dgDetalleVta.DataSource = null;
            dgDetalleVta.DataSource = ListGrid;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSelCliente_Click(object sender, EventArgs e)
        {
            var resultado = cliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ClienteSeleccionado = cliente.ObtenerClienteSeleccionado();
                lblCliente.Text = $"CLIENTE: {ClienteSeleccionado.NombreCompleto}";
                radioVtaCC.Enabled = true;
                radioVtaCC.Checked = true;
            }
            else
            {
                radioVtaCC.Enabled = false;
            }
        }

        private void btnListaProd_Click(object sender, EventArgs e)
        {
            var resultado = productos.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                ProductoSeleccionado = productos.ObtenerProductoSeleccionado();
            }

            txtCodProd.Text = ProductoSeleccionado.ProductoId.ToString();
        }

        private void VtaProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnCancelarVta_Click(object sender, EventArgs e)
        {
            VaciaListGrid();

            RecargarDatagrid();

            ClienteSeleccionado = null;
            ProductoSeleccionado = null;
            txtCant.Text = "";
            txtCodProd.Text = "";
            radioVtaCC.Enabled = true;
            radioVtaSimple.Enabled = true;
            rbSe.Enabled = true;

            if (MessageBox.Show("       ¿Desea Cancelar la venta?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            //Alert.ShowSimpleAlert("Venta cancelada", "MSJ038");
            
            
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (radioVtaSimple.Checked)
            {
                ventaBLL.Crear(CrearNuevaVenta(VentaDAL.EstadoVenta.Aprobada.GetHashCode(), DateTime.UtcNow, CalcularMontoTotal(), VentaDAL.TipoVenta.VentaSimple.GetHashCode() , UsuarioActivo.UsuarioId, ClienteSeleccionado.ClienteId));
            }

            if (radioVtaCC.Checked)
            {
                ventaBLL.Crear(CrearNuevaVenta(VentaDAL.EstadoVenta.Pendiente.GetHashCode(), DateTime.UtcNow, CalcularMontoTotal(), VentaDAL.TipoVenta.Cliente.GetHashCode(), UsuarioActivo.UsuarioId, ClienteSeleccionado.ClienteId));
            }

            if (rbSe.Checked)
            {
                ventaBLL.Crear(CrearNuevaVenta(VentaDAL.EstadoVenta.Pendiente.GetHashCode(), DateTime.UtcNow, CalcularMontoTotal(), VentaDAL.TipoVenta.Seña.GetHashCode(), UsuarioActivo.UsuarioId, ClienteSeleccionado.ClienteId));
            }
            
            foreach (var linea in ListGrid)
            {
                DetalleEnGrid = new DetalleVenta() { DetalleId = sqlUtils.GenerarId(campoId, nomEntidad), VentaId = ventaBLL.ObtenerUltimoIdVenta() };

                DetalleEnGrid.LineasDetalle.Add(linea);

                detalleVentaBLL.Crear(DetalleEnGrid);

                
            }
            //Alert.ShowSimpleAlert( "MSJ086", "Venta realizada con exito");
            
           
            VaciaListGrid();

            RecargarDatagrid();

            ClienteSeleccionado = null;
            ProductoSeleccionado = null;
            txtCant.Text = "";
            txtCodProd.Text = "";
            radioVtaCC.Enabled = true;
            radioVtaSimple.Enabled = true;
            rbSe.Enabled = true;
            lblCliente.Text = "";


            MessageBox.Show("       Venta Realiza con exito");
        }

        private void VaciaListGrid()
        {
            ListGrid = null;
            ListGrid = new List<LineaDetalle>();
        }

        private float CalcularMontoTotal()
        {
            var total = 0.0F;

            foreach (var linea in ListGrid)
            {
                total += linea.Importe;
            }

            return total;
        }

        private void btnQuitarProd_Click(object sender, EventArgs e)
        {
            ListGrid.Remove(LineaDetalleSeleccionada); 
            RecargarDatagrid();
        }

        private void dgDetalleVta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LineaDetalleSeleccionada = (LineaDetalle)dgDetalleVta.CurrentRow.DataBoundItem;
            }
        }

        private void radioVtaCC_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
