namespace BE
{
    using System;
    using System.Collections.Generic;

    //Detalle de atributos de la Clase:FiltrosBitacora
    public class FiltrosBitacora
    {
        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public List<string> IdsUsuarios { get; set; }

        public List<string> Criticidades { get; set; }
    }
}
