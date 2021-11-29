namespace BE.Entidades
{
    //Detalle de atributos de la Clase:LineaDetalle
    public class LineaDetalle

    {
        public Producto Producto { get; set; }

        public string DescProducto { get; set; }

        public int Cantidad { get; set; }

        public float Importe { get; set; }
    }
}