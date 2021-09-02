﻿// <auto-generated/>
namespace UI
{
    using BE.Entidades;
    using BLL;
    using EasyEncryption;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class VentaUI : Form, IVentaUI
    {
        private readonly IVentaBLL ventaBLL;
        private readonly ITraductor traductor;
        private readonly IClienteBLL clienteBLL;
        private readonly IUsuarioBLL usuarioBLL;
        private readonly IDetalleRefForm detalleRefForm;

        private const string nombreForm = "Venta";
        public const string key = "bZr2URKx";
        public const string iv = "HNtgQw0w";

        private Regex obtenerInt = new Regex("\\d+");

        public LineaVenta LineaSeleccionada { get; set; } = new LineaVenta();
        public Venta VentaSeleccionada { get; set; } = new Venta();
        public List<Venta> VentasBd { get; set; } = new List<Venta>();
        public List<LineaVenta> ListGrid { get; set; }

        public VentaUI(ITraductor traductor, IVentaBLL ventaBLL, IClienteBLL clienteBLL, IUsuarioBLL usuarioBLL, IDetalleRefForm detalleRefForm)
        {
            this.traductor = traductor;
            this.ventaBLL = ventaBLL;
            this.clienteBLL = clienteBLL;
            this.usuarioBLL = usuarioBLL;
            this.detalleRefForm = detalleRefForm;
            InitializeComponent();
            dgVenta.AutoGenerateColumns = false;
        }

        private void VentaUI_Load(object sender, EventArgs e)
        {
            traductor.Traduccir(this, nombreForm);
            HacerLoad();
        }

        public void HacerLoad()
        {
            CargarVentas();
            CargarGrid();
        }

        private void CargarVentas()
        {
            ListGrid = null;
            ListGrid = new List<LineaVenta>();

            VentasBd = ventaBLL.Cargar();

            foreach (var venta in VentasBd)
            {
                ListGrid.Add(
                    new LineaVenta()
                    {
                        VentaId = venta.VentaId,
                        Fecha = venta.Fecha,
                        Cliente = clienteBLL.ObtenerClienteConId(venta.ClienteId),
                        Estado = ventaBLL.ObtenerEstadoVenta(venta.EstadoId),
                        TipoVenta = ventaBLL.ObtenerTipoVenta(venta.TipoVentaId),
                        Vendedor = usuarioBLL.Cargar().Where(x => x.UsuarioId == venta.UsuarioId).Select(x => DES.Decrypt(x.Email, key, iv)).FirstOrDefault(),
                        Monto = venta.Monto
                    });
            }
        }

        private void CargarGrid()
        {
            dgVenta.DataSource = null;
            dgVenta.DataSource = ListGrid;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void VentaUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void dgVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LineaSeleccionada = (LineaVenta)dgVenta.CurrentRow.DataBoundItem;

                VentaSeleccionada = CrearVenta(LineaSeleccionada.Estado);
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            var venta = CrearVenta("Aprobada");

            ventaBLL.Actualizar(venta);

            CargarVentas();

            CargarGrid();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            var venta = CrearVenta("Rechazada");

            ventaBLL.Actualizar(venta);

            CargarVentas();

            CargarGrid();
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            var venta = CrearVenta("Cancelada");

            ventaBLL.Actualizar(venta);

            CargarVentas();

            CargarGrid();
        }

        private int DeterminarCliente()
        {
            int cliente = 0;

            if (LineaSeleccionada.Cliente != " - ")
            {
                cliente = clienteBLL.Cargar()
                   .Where(x => x.ClienteId == int.Parse(obtenerInt.Match(LineaSeleccionada.Cliente).Value))
                   .Select(x => x.ClienteId).FirstOrDefault();
            }
            else
            {
                cliente = 0;
            }

            return cliente;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            
            


            detalleRefForm.ShowDialog();
           
        }

        private Venta CrearVenta(string estadoVenta)
        {
            int cliente = DeterminarCliente();

            var venta = new Venta()
            {
                VentaId = LineaSeleccionada.VentaId,
                ClienteId = cliente,
                EstadoId = ventaBLL.ObtenerEstadoVentaConString(estadoVenta),
                Fecha = LineaSeleccionada.Fecha,
                Monto = LineaSeleccionada.Monto,
                TipoVentaId = ventaBLL.ObtenerTipoVentaConString(LineaSeleccionada.TipoVenta),
                UsuarioId = usuarioBLL.ObtenerUsuarioConEmail(LineaSeleccionada.Vendedor).UsuarioId
            };
            return venta;
        }

        public Venta ObtenerVentaSeleccionada()
        {
            return VentaSeleccionada;
        }

        private void dgVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
