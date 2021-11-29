namespace BE.Entidades
{
    using System.Collections.Generic;
    //Declaramos los atributos de la Clase DETALLEVENTA
    public class DetalleVenta
    {
        public int DetalleId { get; set; }

        public int VentaId { get; set; }

        public List<LineaDetalle> LineasDetalle { get; set; } = new List<LineaDetalle>();
    }
}
