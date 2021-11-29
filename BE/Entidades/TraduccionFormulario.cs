namespace BE.Entidades
{
    //Detalle de atributos de la Clase:TrudccionFormulario
    public class TraduccionFormulario
    {
        public int IdTraduccion { get; set; }

        public int IdIdioma { get; set; }

        public int IdFormulario { get; set; }

        public string ControlName { get; set; }

        public string MensajeCodigo { get; set; }

        public string Traduccion { get; set; }
    }
}
