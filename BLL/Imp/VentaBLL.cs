namespace BLL
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class VentaBLL : ICRUD<Venta>, IVentaBLL
    {
        private readonly IVentaDAL ventaDAL;
        private readonly IDigitoVerificador digitoVerificador;

        public VentaBLL(IVentaDAL ventaDAL, IDigitoVerificador digitoVerificador)
        {
            this.ventaDAL = ventaDAL;
            this.digitoVerificador = digitoVerificador;
        }

        public bool Actualizar(Venta objUpd)
        {
            return ventaDAL.Actualizar(objUpd);
        }

        public bool Borrar(Venta objDel)
        {
            return ventaDAL.Borrar(objDel);
        }

        public List<Venta> Cargar()
        {
            return ventaDAL.Cargar();
        }

        public void CargarDVHVenta()
        {
            ventaDAL.CargarDVHVenta();
        }

        public bool Crear(Venta objAlta)
        {
            var result =  ventaDAL.Crear(objAlta);
            digitoVerificador.ActualizarDVVertical("Venta");
            return result;
        }

        public string ObtenerEstadoVenta(int estadoId)
        {
            return ventaDAL.ObtenerEstadoVentaConId(estadoId);
        }

        public int ObtenerEstadoVentaConString(string estado)
        {
            return ventaDAL.ObtenerEstadoVentaConString(estado);
        }

        public string ObtenerTipoVenta(int tipoVtaId)
        {
            return ventaDAL.ObtenerTipoVentaConId(tipoVtaId);
        }

        public int ObtenerTipoVentaConString(string tipoVta)
        {
            return ventaDAL.ObtenerTipoVentaConString(tipoVta);
        }

        public int ObtenerUltimoIdVenta()
        {
            return ventaDAL.ObtenerUltimoIdVenta();
        }
    }
}
