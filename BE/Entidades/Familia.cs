namespace BE.Entidades
{
    using System.Collections.Generic;

    //Detalle de atributos de la Clase:Familia
    public class Familia
    {
        public int FamiliaId { get; set; }

        public string Descripcion { get; set; }

        public List<Patente> Patentes { get; set; }
    }
}
