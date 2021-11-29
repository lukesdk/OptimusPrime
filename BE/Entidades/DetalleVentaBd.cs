namespace BE.Entidades
{
    //Detalle de los atributos de la clase DetalleVentaBD
    public class DetalleVentaBd
    {
        public int DetalleId { get; set; }

        public int VentaId { get; set; }

        public int ProductoId { get; set; }

        public float  Importe { get; set; }

        public int Cantidad { get; set; }
    }
}
