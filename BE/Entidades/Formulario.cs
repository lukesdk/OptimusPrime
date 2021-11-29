namespace BE.Entidades
{
    using System.Collections.Generic;
    //Detalle de atributos de la Clase:Formulario
    public class Formulario
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public List<Patente> IdPatente { get; set; }
    }
}
