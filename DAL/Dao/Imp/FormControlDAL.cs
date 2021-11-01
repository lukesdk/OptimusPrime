namespace DAL.Dao.Imp
{
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class FormControlDAL : BaseDao, IFormControlDAL
    {
        public List<Patente> ObtenerPermisosFormulario(int formId)
        {
            var query = "SELECT IdPatente FROM FormularioPatente WHERE IdFormulario = @formId";

            return CatchException(() =>
            {
                return Exec<Patente>(query, new { @formId = formId });
            });
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            var query = "SELECT fp.IdPatente,p.descripcion FROM FormularioPatente fp INNER JOIN Patente p ON p.IdPatente=fp.IdPatente";

            return CatchException(() =>
            {
                return Exec<Patente>(query);
            });
        }
    }
}
