namespace DAL.Dao
{
    using System.Collections.Generic;
    using BE.Entidades;


    //Declarar los metodos de la interfaz

    public interface IIdiomaDAL
    {
        List<Idioma> ObtenerTodosLosIdiomas();

        List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm);
    }
}