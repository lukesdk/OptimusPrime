namespace BLL
{
    using BE;
    using BE.Entidades;
    //interfaz permite injeccion de dependencias.

    public interface IClienteBLL : ICRUD<Cliente>
    {
        string ObtenerClienteConId(int? clienteId);
    }
}
