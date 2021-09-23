namespace DAL.Dao
{
    using System.Collections.Generic;
    using BE.Entidades;


    //Declarar los metodos de la interfaz

    public interface IFormControlDAL
    {
        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(int formId);
    }
}