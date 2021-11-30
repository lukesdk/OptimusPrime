namespace BLL
{
    using BE.Entidades;
    using System;
    using System.Collections.Generic;
    //interfaz permite injeccion de dependencias.
    //La inyección de dependencias consiste de manera resumida en evitar el acoplamiento entre clases
    //utilizando interfaces. conseguimos que cada clase tenga una función única,
    //facilitando así el mantenimiento y el soporte de nuestro código.
    public interface IBitacoraBLL
    {
        void RegistrarEnBitacora(Usuario usu);

        Bitacora FiltrarBitacora(DateTime from, DateTime to);

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, string desde, string hasta);

        List<string> CargarUsuarios();

        void CargarDVHBitacora();
    }
}