namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;
    //interfaz permite injeccion de dependencias.

    public interface IFormControlBLL
    {
        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(int formId);
    }
}