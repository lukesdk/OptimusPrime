namespace DAL.Dao
{
    using BE;
    using BE.Entidades;


    //Declarar los metodos de la interfaz

    public interface IClienteDAL : ICRUD<Cliente>
    {
        string ObtenerClienteConId(int? clienteId);
    }
}